using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Controllers
{
    public class ListasController : Controller
    {
        private readonly ApplicationDbContext db;

        public ListasController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<ActionResult> Index(string search)
        {
            if (search == null)
            {
                return View(await db.Listas.ToListAsync());
            }
            return View(await db.Listas.
                Where(r => r.ListName.Contains(search))
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lista = await db.Listas.FirstOrDefaultAsync(r => r.ListId == id);
            if (lista == null)
            {
                return NotFound();
            }
            return View(lista);

        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lists lista)
        {
            if (ModelState.IsValid)
            {
                db.Add(lista);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lista);


        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regis = await db.Listas.FindAsync(id);

            if (regis == null)
            {
                return NotFound();
            }
            return View(regis);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lists lista)
        {
            if (id != lista.ListId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(lista);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lista);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var regis = await db.Listas
                .FirstOrDefaultAsync(r => r.ListId == id);
            if (regis == null)
            {
                return NotFound();
            }
            return View(regis);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var regis = await db.Listas.FindAsync(id);
            db.Listas.Remove(regis);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

