using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjectWebApp.Data;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProjectWebApp.Services;

public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
{
    private readonly ILogger _logger = logger;

    private AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, 
        string confirmationLink) => SendEmailAsync(email, "Confirm your email", $"Confirm your email by clicking <a href='{confirmationLink}'>here</a>");

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, 
        string resetLink) => SendEmailAsync(email, "Reset your password", 
        $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, 
        string resetCode) => SendEmailAsync(email, "Reset your password", 
        $"Please reset your password using the following code: {resetCode}");

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            throw new Exception("Null EmailAuthKey");
        }

        await Execute(Options.SendGridKey, subject, message, toEmail);
    }

    private async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("z3293422@gmail.com", subject),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail));
        msg.SetClickTracking(false, false);
        
        var response = await client.SendEmailAsync(msg);
        
        _logger.LogInformation(response.IsSuccessStatusCode 
            ? $"Email to {toEmail} queued successfully!"
            : $"Failure Email to {toEmail}");
    }
}