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

## Add external packages

## Use a database

TodoController dependent on ITodoService(TodoService).
TodoService dependent on ApplicationDbContext.
Both ITodoService(TodoService) and ApplicationDbContext are contigured inConfigureServices method of Startup.

* Connect to a database
* Update the context
* Create a migration
* Create a new service class

## Add more features

* Add new todo items
* Complete items with a checkbox

**function markCompleted(checkbox) in site.js do not handle error correctly.**

## Security and identity

* Add Facebook login (not try yet!)
* Require authentication
* Using identity in the application
* Authorization with roles

Implement testAdmin(admin@todo.local) as a user with Administrator role.

注意：到此為止，若到別的機器執行或是將原來的資料庫移除，重新Update-Database 的時候會失敗。

[How to correctly seed a DbContext using ASP.NET Core 2.0? #2188](https://github.com/aspnet/Home/issues/2188) 提到：Seeding 應該放在 Program.cs 裡面而非 Start.cs。
所以新版的[Authorization with roles](https://github.com/nbarbettini/little-aspnetcore-book/blob/eadacd44856254720e1e817eff3d2d829514e432/chapters/security-and-identity/authorization-with-roles.md)已經改進。

