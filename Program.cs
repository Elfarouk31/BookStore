using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

using BookStore.Models;
using BookStore.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddSingleton<IBookStoreRepository<AuthorViewModel>, AuthorRepository>();
builder.Services.AddSingleton<IBookStoreRepository<BookViewModel>, BookRepository>();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
	name:"default",
	pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();