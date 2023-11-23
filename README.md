# SQLClient
Allow connecting and interacting with MSSQL databases.

## Usage:

```powershell
> SQlClient.exe --server 127.0.0.1 --database master "select @@version"
> SQlClient.exe --server 127.0.0.1 --database master --username sa --password sa "select @@version"
```

```bash
--server        The IP Address or Hostname
--database      The database name
[--username]    Username used to connect to Microsoft SQL Server (MSSQL)
[--password]    Password used to connect to Microsoft SQL Server (MSSQL)
query positional argument
Query is a positional argument
```

Positional arguments offer various commands, including:

* version: Retrieve the MSSQL Version
* tables: Retrieve the object_id, name,create_date fields of the tables.
* username: Display the current username.
* linkedservers: Retrieve linked servers.
* users: Get all users, excluding system users.
* myrigths: Retrieve all user rights.
* isadmin: Check if the user is and admin or not.
* enablecmd: Enable **xp_cmdshell**
* disablecmd: Disable **xp_cmdshell**

```powershell
> SQlClient.exe --server 127.0.0.1 --database master "users"
> SQlClient.exe --server 127.0.0.1 --database master "enablecmd"
```

> If the **username** and **password** are not set, it connects using Windows Credentials.

