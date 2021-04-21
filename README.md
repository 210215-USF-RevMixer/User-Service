# User-Service
### Description
Rest API service for adding, updating, and removing users and reports for RevMixer.  

#### API Controllers
<table>
<tr><th><h3>User</h3></th><th><h3>Report</h3></th></tr>
<tr>
<th><h4>Endpoints</h4></th>
</tr>
<tr>
<td>

Get | Post 
----|----
/api/User | /api/User 
/api/User/{Id} | 
/api/User/email/{userEmail} |

</td><td>

Get | Post 
----|----
/api/Report | /api/Report
/api/Report/{Id} | 

</td>
</tr> 
<tr>
<td>

Put | Delete
----|----
/api/User/{Id} | /api/User/{Id}

</td><td>

Put | Delete
----|----
/api/Report/{Id} | /api/Report/{Id}

</td>
</tr> 

<tr>
<th><h4>Model Properties</h4></th>
</tr>

<td>

DataType | Variable
----|----
int|Id
string|userName
string|email
string|role
ICollection \<Report>|Reports

</td>
<td>

DataType | Variable
----|----
int|Id
int|userId
int|targetId
bool|isSample
DateTime|reportDate
string|description
User|User

</td>
</tr>
</table>

### Technologies
* C#
* ASP.NET Core
* Entity Framework Core
* SQL Server
* Moq/Xunit
* Azure Blob Storage

### Setup
* Install [.NET 5.0+](https://dotnet.microsoft.com/download)
* create ~/../User-Service/UserREST/appsettings.json containing:
```
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft": "Warning",
            "Microsoft.Hosting.Lifetime": "Information"
        }
  },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "ProjectDB": "<Insert Valid Connection string to a SQL Database>",
        "BlobStorage": "<Insert Valid Blob Storage Connection String>"
    }
}
```





