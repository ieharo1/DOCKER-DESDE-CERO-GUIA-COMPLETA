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

namespace Examen.Views.User
{
    public class userController : Controller
    {
        private readonly examenContext _context;

        public userController(examenContext context)
        {
            _context = context;
        }

        // GET: user
        public async Task<IActionResult> Index(searchstring1 searchstringVM ,string hola)
        {
            var users = _context.user.Select(c => c);
            if (!string.IsNullOrEmpty(searchstringVM.searchstring))
            {
                users = users.Where(c => c.nombre.Contains(searchstringVM.searchstring));
            }
            if (!string.IsNullOrEmpty(searchstringVM.buscarselect))
            {
                var ciudad = _context.ciudad.Where(c => c.nombre_ciudad.Equals(searchstringVM.buscarselect)).FirstOrDefault();
                users = users.Where(c => c.id_ciudad == ciudad.id);
            }

            List<string> ciudades = new List<string>(); 
            foreach (var n in users)
            {
                var aux = _context.ciudad.Where(c => c.id == n.id_ciudad).FirstOrDefault();
                ciudades.Add(aux.nombre_ciudad);
            }
            searchstringVM.Usuarios = await users.ToListAsync();
            searchstringVM.Ciudades = new SelectList(ciudades.Distinct());
            ViewBag.ciudades = ciudades;
            return View(searchstringVM);
        }
        // GET: user/Details/5
        public async Task<IActionResult> Details(int? id, UsuarioCiudad ayu)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var user = await _context.user.FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }
            var aux = _context.ciudad.Where(c => c.id == user.id_ciudad).FirstOrDefault();
            ayu.auxiliar= aux.nombre_ciudad;
            ayu.user = user;
            return View(ayu);
        }

        // GET: user/Create
        public IActionResult Create()
        {
            var aux = _context.ciudad.Select(c => c.nombre_ciudad).Distinct().ToList();
            UsuarioCiudad usuarioCiudad = new UsuarioCiudad();
            usuarioCiudad.MustraCiudadesCreacion = new SelectList(aux);
            return View(usuarioCiudad);
        }

        // POST: user/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,ci_ruc,id_ciudad,arm,uci")] user user, string ciudadnombre)
        {
            var aux = _context.ciudad.Where(c => c.nombre_ciudad == ciudadnombre).FirstOrDefault();
            var aux2 = _context.user.Where(c => c.id_ciudad == aux.id).FirstOrDefault();
            user.id_ciudad = aux2.id_ciudad;
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: user/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var aux = _context.ciudad.Select(c => c.nombre_ciudad).Distinct().ToList();
            UsuarioCiudad usuarioCiudad = new UsuarioCiudad();
            usuarioCiudad.MustraCiudadesCreacion = new SelectList(aux);
            if (id == null)
            {
                return NotFound();
            }

            usuarioCiudad.user = await _context.user.FindAsync(id);
            if (usuarioCiudad.user == null)
            {
                return NotFound();
            }
            
            return View(usuarioCiudad);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,ci_ruc,id_ciudad,arm,uci")] user user, string ciudadnombre)
        {
            var aux = _context.ciudad.Where(c => c.nombre_ciudad == ciudadnombre).FirstOrDefault();
            var aux2 = _context.user.Where(c => c.id_ciudad == aux.id).FirstOrDefault();
            user.id_ciudad = aux2.id_ciudad; 
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(user.id))
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
            return View(user);
        }

        // GET: user/Delete/5
        public async Task<IActionResult> Delete(int? id, UsuarioCiudad ayu)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.user.FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }
            var aux = _context.ciudad.Where(c => c.id == user.id_ciudad).FirstOrDefault();
            ayu.auxiliar = aux.nombre_ciudad;
            ayu.user = user;
            return View(ayu);
           
        }

        // POST: user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.user.FindAsync(id);
            _context.user.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userExists(int id)
        {
            return _context.user.Any(e => e.id == id);
        }
    }
}
