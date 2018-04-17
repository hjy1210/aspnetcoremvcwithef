# Project AspNetCoreTodo
跟隨[ASP.NET Core Book](https://nbarbettini.gitbooks.io/little-asp-net-core-book/content/) 
練習 Asp.Net Core with MVC

## Create an ASP.NET Core project
為了用 LocalDb 取代 SQLite，將
```
dotnet new mvc --auth Individual -o AspNetCoreTodo
```
改成
```
dotnet new mvc -uld --auth Individual -o AspNetCoreTodo
```
## MVC basics

* Create a controller
* Create Models
* Create a View
* Add a service class
* Use dependency injection
* Finish the controller