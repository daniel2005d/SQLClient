# SQLClient
Allow connecting and interacting with MSSQL databases.

## Usage:

> SQlClient.exe --server 127.0.0.1 --database master "select @@version"

> SQlClient.exe --server 127.0.0.1 --database master --username sa --password sa "select @@version"

```bash
--server        The IP Address or Hostname
--database      The database name
[--username]    Username used to connect to Microsoft SQL Server (MSSQL)
[--password]    Password used to connect to Microsoft SQL Server (MSSQL)
query positional argument
Query is a positional argument
```
[ ]If the **username** and **password** are not set, it connects using Windows Credentials.
