using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

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
            List<Book> objList = this.context.Books.ToList();
            foreach (var item in objList)
            {
                //item.Publisher = this.context.Publishers.Find(item.Publisher_Id);
                this.context.Entry(item).Reference(e => e.Publisher).Load();
            }
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

            obj.Book = await this.context.Books.FirstOrDefaultAsync(c => c.Id == id);
            obj.Book.BookDetail = await this.context.BookDetails.FirstOrDefaultAsync(c => c.Book_Id == id);

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
    }
}
