using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Author> objList = this.context.Authors.ToList();
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Author obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            obj = await this.context.Authors.FirstOrDefaultAsync(c => c.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    // create
                    await this.context.Authors.AddAsync(obj);
                }
                else
                {
                    // update
                    this.context.Authors.Update(obj);
                }
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Author obj = new();
            obj = await this.context.Authors.FirstOrDefaultAsync(c => c.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            this.context.Authors.Remove(obj);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
