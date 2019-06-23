# NetCoreSample
.Net Core sample project with api gateway and microservice

This project use .NET Core 2.1


##Step 1:
Add Crud Microservice Person

To configure database use: Entity Framework Core Migrations
Sample comands in Person project:
> Add-Migration InitialCreate

> update-database

##Step 2:
Make a api gateway

Using Ocelot to gateway, version installed is: 13.4.1
> Install-Package Ocelot -Version 13.4.1

Make proxies:
>[Get] person/$id

>[Post] login

Login implementation on microservice

Applyed JWT to autenticathion.


##Step 3:
Make view app, create new react app.
Apply designated layout.

Configure CORS policy.

##Step 4:
Make sample hook 'post-receive' file in './.git/hooks' this repository in './utils/'
Is a simple example of how the project could be configured on the server by monitoring some commit in the master and automatically deploy.

To similar solution in AWS you can see CodeDeploy

##Step 5:
Unit test


#Future steps: 

1 - Improve token generation mechanism and standardize keys and information.

2 - Improve session controller in client app.

3 - Review react techniques (pages components, styles), this is my first project on react.

PS:
utils have live a demo video, and postman sample colection.