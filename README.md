<h1 style="display: flex; justify-content: center">Social media website</h1>

### Tech stack
* .NET 8.0.
* Blazor (WebAssembly / Server)
* Entity Framework Core 
* MySQL Server

### Requirements

* .NET & SDK 8.0.+
* Visual Studio or JetBrains Rider newest possible version

### Installation

#### Navigate repository
```csharp
cd ProjectWebApp/ProjectWebApp
```
#### Load database migrations
```csharp
dotnet ef database update
```
#### Run project
```csharp 
dotnet run 
```

<h1 style="display: flex; justify-content: center">Test Cases</h1>

### Create Post
| Test Case Name  | Test Case ID   | Test Step | Description                                | Test Data                                            | Expected Result                                             | Actual Result                | Remarks | 
|-----------------|----------------|-----------|--------------------------------------------|------------------------------------------------------|-------------------------------------------------------------|------------------------------|---------|
| Create post     | Create_Post_01 | 1         | Navigate endpoint /Posts/Create            | Authorized user                                      | Page loaded                                                 | Page loaded                  | PASS    |
| Create post     | Create_Post_02 | 2         | Press button "publish" while inputs empty  | Empty string                                         | Required Field Validation message shoved up                 | Validation message shoved up | PASS    |
| Create post     | Create_Post_03 | 3         | Press button "publish" with data in inputs | Lorem Ipsum 501 chars                                | String Validation message shoved up                         | Validation message shoved up | PASS    |
| Create post     | Create_Post_04 | 4         | Press button "publish" with data in inputs | Lorem Ipsum <br/>title: 100 chars<br/>bio: 500 chars | Post must be created and user redirected to /Posts endpoint | Post Created successfully    | PASS    |

### Navigate endpoints while unauthorized
| Test Case Name            | Test Case ID       | Test Step  | Description                        | Test Data         | Expected Result                               | Actual Result        | Remarks | 
|---------------------------|--------------------|------------|------------------------------------|-------------------|-----------------------------------------------|----------------------|---------|
| Navigate dashboard        | Endpoint_UnAuth_01 | 1          | Navigate endpoint /Admin/Dashboard | Unauthorized user | Page not loaded, but user redirected to login | Redirected to login  | PASS    |
| Navigate any post detail  | Endpoint_UnAuth_02 | 2          | Navigate endpoint /Posts/{id:int}  | Unauthorized user | Page not loaded, but user redirected to login | Redirected to login  | PASS    |
| Navigate Account Settings | Endpoint_UnAuth_03 | 3          | Navigate endpoint /Account/Manage  | Unauthorized user | Page not loaded, but user redirected to login | Redirected to login  | PASS    |
| Navigate Posts            | Endpoint_UnAuth_04 | 4          | Navigate endpoint /Posts           | Unauthorized user | Page loaded and shoved posts list             | List of posts loaded | PASS    |

### Change nickname
| Test Case Name            | Test Case ID | Test Step | Description                       | Test Data             | Expected Result                          | Actual Result                            | Remarks | 
|---------------------------|--------------|-----------|-----------------------------------|-----------------------|------------------------------------------|------------------------------------------|---------|
| Navigate Account Settings | Account_01   | 1         | Navigate endpoint /Account/Manage | Authorized user       | Page loaded                              | Page loaded                              | PASS    |
| Change profile data       | Account_02   | 2         | Change nickname with long string  | Lorem Ipsum 17+ chars | String Validation message shoved up      | Validation message shoved up             | PASS    |
| Change profile data       | Account_03   | 3         | Change nickname with short string | Nickname: lol         | String Validation message shoved up      | Validation message shoved up             | PASS    |
| Change profile data       | Account_04   | 4         | Change to normal nickname         | Nickname: 0zena       | Nickname changed and Success message and | Nickname changed and Success message and | PASS    |
| Login after changes       | Account_05   | 5         | Login after nickname update       | Unauthorized user     | Login successful with new nickname       | Login successful                         | PASS    |

### Set phone number
| Test Case Name            | Test Case ID   | Test Step  | Description                        | Test Data             | Expected Result                                 | Actual Result                 | Remarks | 
|---------------------------|----------------|------------|------------------------------------|-----------------------|-------------------------------------------------|-------------------------------|---------|
| Navigate Account Settings | PhoneNumber_01 | 1          | Navigate endpoint /Account/Manage  | Authorized user       | Page loaded                                     | Page loaded                   | PASS    |
| Set phone number          | PhoneNumber_02 | 2          | Press "Submit" button without data | Empty string          | Wrong phone number validation message shoved up | Validation message shoved up  | PASS    |
| Set phone number          | PhoneNumber_03 | 3          | Enter symbols                      | data: RandomString45* | Wrong phone number validation message shoved up | Validation message shoved up  | PASS    |
| Set phone number          | PhoneNumber_04 | 4          | Enter digits                       | data: +000 29999999   | Phone number set successfully                   | Phone number set successfully | PASS    |

### Delete profile
| Test Case Name            | Test Case ID     | Test Step  | Description                                          | Test Data           | Expected Result                                                   | Actual Result                                                     | Remarks | 
|---------------------------|------------------|------------|------------------------------------------------------|---------------------|-------------------------------------------------------------------|-------------------------------------------------------------------|---------|
| Navigate Account Settings | DeleteProfile_01 | 1          | Navigate endpoint /Account/Manage/DeletePersonalData | User has posts      | Delete profile button disabled while is active delete blog button | Delete profile button disabled while is active delete blog button | PASS    |
| Delete blog               | DeleteProfile_02 | 2          | Press "Delete blog" button to clear data             |                     | Blog deleted, Delete profile enabled while delete blog disabled   | Blog deleted, Delete profile enabled while delete blog disabled   | PASS    |
| Delete profile            | DeleteProfile_03 | 3          | Press "Delete profile" button to clear data          |                     | Profile deleted, redirected to homepage                           | Profile deleted, redirected to homepage                           | PASS    |
