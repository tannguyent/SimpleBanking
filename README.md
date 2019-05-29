# SimpleBanking
this is simple Banking project was make base on micro service infrastructure 

# overview
because it is building base on microservice so it will have a lot of system as below 
1. Identity Server (IdentityServer4): for store and authentication user
2. Banking API (netcore 2.2): provide some api for some application can connect to create account and make some transaction
3. Console App (netcore 2.2): provide application for user can make some actions in this, the application will connect to authentication sever and banking api 
4. WebApp (SPA-VueJS): the web page to user can see some transaction history, it will connect to identity server for authentication user as login and logout, and also it connect to Banking API to get some transaction for user

# how to run
please flow some step as below to run application after clone code 
because i dont create solution project so could you please setup seperate project to run in order as below 

1. Identity Server 
- url: http://localhost:5000 
- commands:
- dotnet restore
- dotnet run

2. Banking API
- url: https://localhost:5001 
- commands:
- dotnet restore
- dotnet run

3. Console App 
- commands:
- dotnet restore
- dotnet run

4. WebApp (SPA-VueJS): 
- url: https://localhost:5002 
- commands:
- npm i
- npm run sever

# some update in the furture
- Https:
- gateway API
- service configruration 
- database project: (history version for database)
- deploy docker with kubernetes
- apply service broker
...
