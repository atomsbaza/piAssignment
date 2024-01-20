-- How to set-up project --
1. Open terminal use "docker pull mcr.microsoft.com/mssql/server" to pull  mssql
2. user "docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=P@ssw0rd" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -e "MSSQL_DATABASE=piDb" -p 1433:1433 -d --name=sql_server mcr.microsoft.com/mssql/server" to run docker
3. Connect to mssql with Server: localhost, User name: sa, Password: P@ssw0rd
4. Run command below to create database name "piDb"
   USE master;
   CREATE DATABASE piDb;
5. Open Terminal in project and use "dotnet ef database update" to update database
6. Run project, we can use Swagger UI to test or Run piAssignment.Tests for unit test


-- If I have more time what would I do --
1. Use Docker to containerize the application and database for easy deployment and testing
   => right now I'm writh some Dockerfile in project but not successful to use it
2. Try to use message queue => may be use Kafka

