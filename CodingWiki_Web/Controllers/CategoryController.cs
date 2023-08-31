using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Category> objList = this.context.Categories.AsNoTracking().ToList();
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            obj = await this.context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.CategoryId == 0)
                {
                    // create
                    await this.context.Categories.AddAsync(obj);
                }
                else
                {
                    // update
                    this.context.Categories.Update(obj);
                }
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category obj = new();
            obj = await this.context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            this.context.Categories.Remove(obj);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 2; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }

            this.context.Categories.AddRange(categories);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }

            this.context.Categories.AddRange(categories);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            List<Category> categories = this.context.Categories.OrderByDescending(e => e.CategoryId).Take(2).ToList();
            this.context.Categories.RemoveRange(categories);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> categories = this.context.Categories.OrderByDescending(e => e.CategoryId).Take(5).ToList();
            this.context.Categories.RemoveRange(categories);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
