# Project Setup Guide
## How to Set Up the Project
1. Open the terminal use "docker pull mcr.microsoft.com/mssql/server" to pull mssql (If you already have existed DATABASE just log in localhost and use the command on 4.)
2. user "docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=P@ssw0rd" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -e "MSSQL_DATABASE=piDb" -p 1433:1433 -d --name=sql_server mcr.microsoft.com/mssql/server" to run docker
3. Connect to mssql with Server: localhost, User name: sa, Password: P@ssw0rd
4. Run the command below to create the database name "piDb"
   USE master;
   CREATE DATABASE piDb;
5. Open Terminal in the project and use "dotnet ef database update" to update the database (If have error use "dotnet tool install --global dotnet-ef --version 7.*" then update database again)
6. Run project, we can use Swagger UI to test or Run piAssignment.Tests for unit test

## If I had more time what would I do
1. Use Docker to containerize the application and database for easy deployment and testing
   => Right now I'm writing some script in Dockerfile for the project but have not successful in using it
2. Try to use message queue => maybe use Kafka
3. Try to use Authentication because I never use it from scratch so I am not sure what I should do. In this case, I already installed OAuth 2.0(Identity Server 4) but have not successfully used it

## Trade-offs and decisions
1. I use Linq because it is easy just connect the DB and then write logic to do the task
2. It first time that I have written a unit test, so I'm not sure it good enough
