using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreTodo.SqliteUnitTests
{
	public class TodoItemServiceShould
	{
		// [Testing with SQLite](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/sqlite)
		// [Unit testing](https://nbarbettini.gitbooks.io/little-asp-net-core-book/content/chapters/automated-testing/unit-testing.html)
		[Fact]
		public async Task AddNewItem()
		{
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();

			try
			{
				var options = new DbContextOptionsBuilder<ApplicationDbContext>()
					.UseSqlite(connection).Options;

				// Create the schema in the database: This step is necessary
				using (var context = new ApplicationDbContext(options))
				{
					context.Database.EnsureCreated();
				}

				// Set up a context (connection to the DB) for writing
				using (var inMemoryContext = new ApplicationDbContext(options))
				{
					var service = new TodoItemService(inMemoryContext);

					var fakeUser = new ApplicationUser
					{
						Id = "fake-000",
						UserName = "fake@fake"
					};

					await service.AddItemAsync(new NewTodoItem { Title = "Testing?" }, fakeUser);
				}
				// Use a separate context to read the data back from the DB
				using (var inMemoryContext = new ApplicationDbContext(options))
				{
					Assert.Equal(1, await inMemoryContext.Items.CountAsync());

					var item = await inMemoryContext.Items.FirstAsync();
					Assert.Equal("Testing?", item.Title);
					Assert.False(item.IsDone);
					var timespan = DateTimeOffset.Now.AddDays(3) - item.DueAt;
					Assert.True(timespan < TimeSpan.FromSeconds(1) && timespan > -TimeSpan.FromSeconds(1));
				}
			}
			finally
			{
				connection.Close();
			}
		}
	}
}
