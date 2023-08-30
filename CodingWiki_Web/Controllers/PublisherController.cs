using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext context;

        public PublisherController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Publisher> objList = this.context.Publishers.ToList();
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Publisher obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            obj = await this.context.Publishers.FirstOrDefaultAsync(c => c.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    // create
                    await this.context.Publishers.AddAsync(obj);
                }
                else
                {
                    // update
                    this.context.Publishers.Update(obj);
                }
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Publisher obj = new();
            obj = await this.context.Publishers.FirstOrDefaultAsync(c => c.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            this.context.Publishers.Remove(obj);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
