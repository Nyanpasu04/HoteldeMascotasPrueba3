using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoteldeMascotas.Data;
using HoteldeMascotas.Models;

namespace HoteldeMascotas.Controllers
{
    public class DueñosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DueñosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dueños
        public async Task<IActionResult> Index()
        {
            return View(await _context.dueño.ToListAsync());
        }

        // GET: Dueños/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueños = await _context.dueño
                .FirstOrDefaultAsync(m => m.DueñosID == id);
            if (dueños == null)
            {
                return NotFound();
            }

            return View(dueños);
        }

        // GET: Dueños/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dueños/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DueñosID,NombreDueño,Rut,Correo,Direccion,Telefono,ReservaID")] Dueños dueños)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueños);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueños);
        }

        // GET: Dueños/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueños = await _context.dueño.FindAsync(id);
            if (dueños == null)
            {
                return NotFound();
            }
            return View(dueños);
        }

        // POST: Dueños/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DueñosID,NombreDueño,Rut,Correo,Direccion,Telefono,ReservaID")] Dueños dueños)
        {
            if (id != dueños.DueñosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueños);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DueñosExists(dueños.DueñosID))
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
            return View(dueños);
        }

        // GET: Dueños/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueños = await _context.dueño
                .FirstOrDefaultAsync(m => m.DueñosID == id);
            if (dueños == null)
            {
                return NotFound();
            }

            return View(dueños);
        }

        // POST: Dueños/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueños = await _context.dueño.FindAsync(id);
            _context.dueño.Remove(dueños);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DueñosExists(int id)
        {
            return _context.dueño.Any(e => e.DueñosID == id);
        }
    }
}
