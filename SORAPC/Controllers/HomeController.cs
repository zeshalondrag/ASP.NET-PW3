using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SORAPC.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SORAPC.Controllers
{
    public class HomeController : Controller
    {

        public PcstoreContext db;

        public HomeController(PcstoreContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> gamingpc()
        {
        
            return View(await db.Catalogsses.ToListAsync());
        }

        public async Task<IActionResult> workstation()
        {
            return View(await db.Catalogsses.ToListAsync());
        }

        public async Task<IActionResult> server()
        {
            return View(await db.Catalogsses.ToListAsync());
        }

        public IActionResult assistance()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(Catalogss catalogss)
        {
            ViewBag.CategoryId = catalogss.CategoryId;
            db.Catalogsses.Add(catalogss);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> details(int? id)
        {
            if (id != null)
            {
                Catalogss catalogss = await db.Catalogsses.FirstOrDefaultAsync(p => p.IdCatalogs == id);
                if (catalogss != null)
                {
                    ViewBag.CategoryId = catalogss.CategoryId;
                    return View(catalogss);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> edit(int? id)
        {
            if (id != null)
            {
                Catalogss catalogss = await db.Catalogsses.FirstOrDefaultAsync(p => p.IdCatalogs == id);
                if (catalogss != null)
                {
                    ViewBag.CategoryId = catalogss.CategoryId;
                    return View(catalogss);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> edit(Catalogss catalogss)
        {
            db.Catalogsses.Update(catalogss);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> confirmdelete(int? id)
        {
            if (id != null)
            {
                Catalogss catalogss = await db.Catalogsses.FirstOrDefaultAsync(p => p.IdCatalogs == id);
                if (catalogss != null)
                {
                    ViewBag.CategoryId = catalogss.CategoryId;
                    return View(catalogss);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> delete(int? id)
        {
            if (id != null)
            {
                Catalogss catalogss = await db.Catalogsses.FirstOrDefaultAsync(p => p.IdCatalogs == id);
                if (catalogss != null)
                {
                    db.Catalogsses.Remove(catalogss);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}