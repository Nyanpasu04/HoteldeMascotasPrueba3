﻿using System;
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
    public class MascotasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mascota.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Mascota.ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotas = await _context.Mascota
                .FirstOrDefaultAsync(m => m.MascotasId == id);
            if (mascotas == null)
            {
                return NotFound();
            }

            return View(mascotas);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MascotasId,NombreMascota,Raza,Años,Vacunas,DueñosID")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascotas);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotas = await _context.Mascota.FindAsync(id);
            if (mascotas == null)
            {
                return NotFound();
            }
            return View(mascotas);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MascotasId,NombreMascota,Raza,Años,Vacunas,DueñosID")] Mascotas mascotas)
        {
            if (id != mascotas.MascotasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotasExists(mascotas.MascotasId))
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
            return View(mascotas);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotas = await _context.Mascota
                .FirstOrDefaultAsync(m => m.MascotasId == id);
            if (mascotas == null)
            {
                return NotFound();
            }

            return View(mascotas);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotas = await _context.Mascota.FindAsync(id);
            _context.Mascota.Remove(mascotas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotasExists(int id)
        {
            return _context.Mascota.Any(e => e.MascotasId == id);
        }
    }
}
