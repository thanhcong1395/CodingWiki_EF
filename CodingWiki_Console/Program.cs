//// See https://aka.ms/new-console-template for more information
//using CodingWiki_DataAccess.Data;
//using CodingWiki_DataAccess.Migrations;
//using CodingWiki_Model.Models;
//using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


////using (ApplicationDbContext context = new ApplicationDbContext())
////{
////context.Database.EnsureCreated();
////if (context.Database.GetPendingMigrations().Count() > 0)
////{
////    context.Database.Migrate();
////}
////}

////AddBook();
////GetAllBooks();
//GetBook();
////UpdateBook();

//void UpdateBook()
//{
//    using var context = new ApplicationDbContext();
//    var book = context.Books.Find(2);
//    var a = book;
//    a.ISBN = "hahaha";
//    context.SaveChanges();
//}

//async void GetBook()
//{
//    using var context = new ApplicationDbContext();
//    var book = await context.Books.SingleAsync();
//    Console.WriteLine(book.Title + " - " + book.ISBN);
//    //var books = context.Books.Skip(2).Take(2);
//    //foreach (var item in books)
//    //{
//    //    Console.WriteLine(item.Title + " - " + item.ISBN);
//    //}
//}

//    void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();
//    foreach (var item in books)
//    {
//        Console.WriteLine(item.Title + " - " + item.ISBN);
//    }
//}

//void AddBook()
//{
//    using var context = new ApplicationDbContext();
//    context.Books.Add(new Book { Title = "Tieng Anh 1", ISBN = "23dfes", Price = 22.99m, Publisher_Id = 1});
//    context.SaveChanges();
//}