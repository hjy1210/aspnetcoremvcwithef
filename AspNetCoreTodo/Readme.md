# AspNetCoreTodo

寫要寫可以在不同的作業系統中使用的網頁程式，選擇用 Asp.Net Core MVC 架構來撰寫網頁程式。

為了學習，跟隨 nbarbettini 先生的 [little-asp-net-core-book](https://nbarbettini.gitbooks.io/little-asp-net-core-book/content/)，了解 Asp.Net Core MVC 
的各項功能與運作方式。


這本小書有下列章節:
* Introduction
* Your first application
* MVC basics
* Add External packages
* Use a database
* Add more features
* Security and identity
* Automated testing

它具有下列特色：

* 主要用 .NET CLI Command 來進行演練，適用於在各種作業系統中進行。
* 講解的方式，初學者可以了解，有經驗的人也有相當的收穫。
* 自動測試的章節裡，示範了與 MVC 息息相關的測試：
	* 針對服務的單元測試
    * 針對控制器的整合測試
* 明確告知，要預先植入(Seed)資料，應該在 Program.cs 裡面進行而非 Startup.cs。

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

## Automated testing

學習到：
* 多用 interface，功能透過 interface 告知大眾。如此，實作修改不會對使用者造成干擾，也有利於單元測試。
* 同一方案的專案間，目錄資料夾不能有互相包含的關係。
