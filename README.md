# GChatBot

## Description

GChatBot is a simple chatbot application that fetches stock data through a command-based system using the (https://stooq.com/q/l/). It features real-time messaging, secure user authentication, and robust error handling.

## Features

- Authentication: Secured using IdentityServer.
- Real-Time Chatroom: Powered by SignalR, integrated with a React front-end.
- Stock Command: Supports /stock=stock_code to fetch stock data from the  (https://stooq.com/q/l/)
- Message ordered by timestamp on descending order
- Only get lastest 50 messages on the chatroom
- Comprehensive unit tests for reliability.

### Bonus tasks completed

- Secure user authentication using .NET Identity.
- Robust handling of unrecognized messages and exceptions raised within the bot.

## Built with

- .NET 8
- ReactJs
- SignalR
- RabbitMQ
- Sql Server 
- CsvHelper
- IdentityServer

## Prerequisites
- .NET 8 Runtime
- Microsoft SQL Server
- RabbitMQ
- NPM
  
## How to use

1. Set up Services:  
Start RabbitMQ Server and Microsoft SQL Server.

2. Update Configuration:  
Update the connection string in the appsettings.json file across all projects.

3. Initialize the Database:  
Run the SQL script located at SqlScript/script.sql.

4. Start the Application:  
   
  4.1 Navigate to the GChatBot.WebApi project folder and run:
     ```dotnet run```  
  4.2 Navigate to the DavChatBot.Worker project folder and run:
    ```dotnet run```
    
5. Configure the Frontend:  
Update BASE_URL and API_BASE_URL in web-app/utils/constants.ts.

6. Launch the Frontend:  
   Navigate to the web-app project folder and run:
   ```npm run start```

7. Access the Application:  
   Open your browser and visit http://localhost:3000.    
   Create an account, log in, and start using the chatbot.

   
