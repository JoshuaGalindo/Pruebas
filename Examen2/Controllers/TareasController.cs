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
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext db;

        public TareasController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<ActionResult> Index(string search)
        {
            if (search == null)
            {
                return View(await db.Tareas.ToListAsync());
            }
            return View(await db.Tareas.
                Where(r => r.TareaName.Contains(search))
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tarea = await db.Tareas.FirstOrDefaultAsync(r => r.TareaId == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);

        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDo tarea)
        {
            if (ModelState.IsValid)
            {
                db.Add(tarea);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);


        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tar = await db.Tareas.FindAsync(id);

            if (tar == null)
            {
                return NotFound();
            }
            return View(tar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDo tarea)
        {
            if (id != tarea.TareaId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tarea);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tar = await db.Tareas
                .FirstOrDefaultAsync(t => t.TareaId == id);
            if (tar == null)
            {
                return NotFound();
            }
            return View(tar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var tar = await db.Tareas.FindAsync(id);
            db.Tareas.Remove(tar);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

