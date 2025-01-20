## **DDFinance Backend**

A backend API built with ASP.NET Core version 8.0 and consuming PostgreSQL as the database.

## **Introduction**

This is the backend API to the DDFinance frontend that allows interaction with the data from the PostgreSQL database

## **Technologies and Tools**

Download ASP.NET Core framework **`https://dotnet.microsoft.com/en-us/apps/aspnet`**
C#
.NET 8.0
ASP .NET Core Web API
Entity Framework Core
PostgreSQL
Automapper
Postman
Swagger UI

## **Installation**

To install Project Title, follow these steps:

1. Clone the repository: **`git clone https://github.com/BuckanianCodes/ddfinance-backend.git`**
2. Navigate to the project directory: **`cd ddfinance-backend`**
3. Install dependencies: **`dotnet restore`**

## **Setup database Optional**
"ConnectionStrings": {
  "ConnectionString": "Server=<server_name>;Database=<NZWalksDb>;Trusted_Connection=True;MultipleActiveResultSets=true",

}


## **Create Migrations**
dotnet ef migration add "Message"

## **Create Database**
dotnet ef database update

## **Run the Project**
dotnet ef database update
![image](https://github.com/user-attachments/assets/b76d9d4b-5256-42c0-b4e9-e4c18a48b528)

## **Test the live URL**
**`https://ddfinance.onrender.com/api/Insurance`**


