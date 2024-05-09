namespace ProjectWebApp.Services;

public class AuthMessageSenderOptions
{
    // dotnet user-secrets set "SendGridKey" "key"
    public string? SendGridKey { get; set; }
}