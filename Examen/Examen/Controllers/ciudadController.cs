using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;
using Examen.ViewModels;

namespace Examen.Views.Ciudad
{
    public class ciudadController : Controller
    {
        private readonly examenContext _context;

        public ciudadController(examenContext context)
        {
            _context = context;
        }

        // GET: ciudad
        public async Task<IActionResult> Index(searchstring1 searchstringVM)
        {
            searchstring1 hola = new searchstring1();
            var ciudades = _context.ciudad.Select(c => c);
            if (!string.IsNullOrEmpty(searchstringVM.searchstring))
            {
                ciudades = ciudades.Where(c => c.nombre_ciudad.Contains(searchstringVM.searchstring));
            }
            hola.CiudadesVM = await ciudades.ToListAsync();
            return View(hola);
        }

        // GET: ciudad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.ciudad.FirstOrDefaultAsync(m => m.id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: ciudad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ciudad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre_ciudad,latitud,longitud")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: ciudad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ciudad = await _context.ciudad.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            return View(ciudad);
        }

        // POST: ciudad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre_ciudad,latitud,longitud")] ciudad ciudad)
        {
            if (id != ciudad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ciudadExists(ciudad.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: ciudad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.ciudad
                .FirstOrDefaultAsync(m => m.id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudad = await _context.ciudad.FindAsync(id);
            _context.ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ciudadExists(int id)
        {
            return _context.ciudad.Any(e => e.id == id);
        }
    }
}
