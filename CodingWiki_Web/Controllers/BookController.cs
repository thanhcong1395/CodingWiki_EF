using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Book> objList = this.context.Books.Include(e => e.Publisher).Include(e => e.BookAuthorMaps).ThenInclude(e => e.Author).ToList();
            
            var temp = objList.Where(e => e.Id == 1).ToList();
            //List<Book> objList = this.context.Books.ToList();
            //foreach (var item in objList)
            //{
            //    this.context.Entry(item).Reference(e => e.Publisher).Load();
            //    this.context.Entry(item).Collection(e => e.BookAuthorMaps).Load();
            //    foreach (var item1 in item.BookAuthorMaps)
            //    {
            //        this.context.Entry(item1).Reference(e => e.Author).Load();
            //    }
            //}

            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            BookVM obj = new();
            obj.PublisherList = this.context.Publishers.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Publisher_Id.ToString(),
            }).ToList();
            if (id == null || id == 0)
            {
                return View(obj);
            }

            obj.Book = await this.context.Books.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                // create
                await this.context.BookDetails.AddAsync(obj.Book.BookDetail);
            }
            else
            {
                // update
                this.context.BookDetails.Update(obj.Book.BookDetail);
            }
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();

            obj = await this.context.BookDetails.Include(e => e.Book).FirstOrDefaultAsync(c => c.Book_Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                // create
                await this.context.BookDetails.AddAsync(obj);
            }
            else
            {
                // update
                this.context.BookDetails.Update(obj);
            }
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();
            obj = await this.context.Books.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            this.context.Books.Remove(obj);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new()
            {
                BookAuthorList = this.context.BookAuthorMaps.Include(e => e.Author).Include(e => e.Book).Where(e => e.Book_Id == id).ToList(),
                BookAuthor = new()
                {
                    Book_Id = id,
                },
                Book = this.context.Books.FirstOrDefault(e => e.Id == id),
            };

            List<int> tempListOfAssignedAuthor = obj.BookAuthorList.Select(e => e.Author_Id).ToList();


            // not in clause
            // get all the authors whos id is not in tempListOfAssignedAuthor
            var tempList = this.context.Authors.Where(e => !tempListOfAssignedAuthor.Contains(e.Author_Id)); 
            obj.AuthorList = tempList.Select(e => new SelectListItem
            {
                Text = e.FullName,
                Value = e.Author_Id.ToString()
            });

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if (bookAuthorVM.BookAuthor.Author_Id != 0 && bookAuthorVM.BookAuthor.Author_Id != 0)
            {
                this.context.Add(bookAuthorVM.BookAuthor);
                this.context.SaveChanges();
            }

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.BookAuthor.Book_Id });
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId ,BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.Id;
            BookAuthorMap bookAuthorMap = this.context.BookAuthorMaps.FirstOrDefault(e => e.Author_Id == authorId && e.Book_Id == bookId);
            this.context.BookAuthorMaps.Remove(bookAuthorMap);
            this.context.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> PlayGround()
        {
            //var bookDetailS1 = this.context.BookDetails.Include(e => e.Book).FirstOrDefault(e => e.BookDetail_Id == 2);
            //bookDetailS1.NumberOfChapters = 33;
            //bookDetailS1.Book.Price = 33;
            //this.context.BookDetails.Update(bookDetailS1);
            //this.context.SaveChanges();

            //var bookDetailS2 = this.context.BookDetails.Include(e => e.Book).FirstOrDefault(e => e.BookDetail_Id == 2);
            //bookDetailS2.NumberOfChapters = 111;
            //bookDetailS2.Book.Price =11.11m;
            //this.context.BookDetails.Attach(bookDetailS1);
            //this.context.SaveChanges();

            //var bookTemp = this.context.Books.FirstOrDefault();

            //var bookCollection = this.context.Books;
            //decimal totalPrice = 0;

            //foreach (var item in bookCollection)
            //{
            //    totalPrice += item.Price;
            //}

            //var bookList = this.context.Books.ToList();
            //foreach (var item in bookList)
            //{
            //    totalPrice += item.Price;
            //}

            //var bookCollection2 = this.context.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = this.context.Books.Count();


            return RedirectToAction(nameof(Index));
        }
    }
}
