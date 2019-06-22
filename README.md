# NetCoreSample
.Net Core sample project with api gateway and microservice

This project use .NET Core 2.1


Step 1:
Add Crud Microservice Person

To configure database use: Entity Framework Core Migrations
Sample comands in Person project:
> Add-Migration InitialCreate

> update-database

Step 2:
Make a api gateway

Using Ocelot to gateway, version installed is: 13.4.1
> Install-Package Ocelot -Version 13.4.1

Make proxies:
[Get] person/$id
[Post] login

Login implementation on microservice

Applyed JWT to autenticathion.



Future steps: 
1 - Improve token generation mechanism and standardize keys and information.