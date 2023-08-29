// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


//using (ApplicationDbContext context = new ApplicationDbContext())
//{
//context.Database.EnsureCreated();
//if (context.Database.GetPendingMigrations().Count() > 0)
//{
//    context.Database.Migrate();
//}
//}

//AddBook();
GetAllBooks();

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach (var item in books)
    {
        Console.WriteLine(item.Title + " - " + item.ISBN);
    }
}

void AddBook()
{
    using var context = new ApplicationDbContext();
    context.Books.Add(new Book { Title = "Tieng Anh 1", ISBN = "23dfes", Price = 22.99m, Publisher_Id = 1});
    context.SaveChanges();
}