using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HASRental.Models;
using Microsoft.AspNetCore.Authorization;

namespace HASRental.Controllers
{
    public class VoziloKategorijaController : Controller
    {
        private readonly NasContext _context;

        public VoziloKategorijaController(NasContext context)
        {
            _context = context;
        }

        // GET: VoziloKategorija
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.VoziloKategorija.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        // GET: VoziloKategorija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voziloKategorija = await _context.VoziloKategorija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voziloKategorija == null)
            {
                return NotFound();
            }

            return View(voziloKategorija);
        }
        [Authorize(Roles = "Admin")]
        // GET: VoziloKategorija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VoziloKategorija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Ime,CijenaRente")] VoziloKategorija voziloKategorija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voziloKategorija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voziloKategorija);
        }

        // GET: VoziloKategorija/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voziloKategorija = await _context.VoziloKategorija.FindAsync(id);
            if (voziloKategorija == null)
            {
                return NotFound();
            }
            return View(voziloKategorija);
        }

        // POST: VoziloKategorija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,CijenaRente")] VoziloKategorija voziloKategorija)
        {
            if (id != voziloKategorija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voziloKategorija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoziloKategorijaExists(voziloKategorija.Id))
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
            return View(voziloKategorija);
        }

        // GET: VoziloKategorija/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voziloKategorija = await _context.VoziloKategorija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voziloKategorija == null)
            {
                return NotFound();
            }

            return View(voziloKategorija);
        }

        // POST: VoziloKategorija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voziloKategorija = await _context.VoziloKategorija.FindAsync(id);
            _context.VoziloKategorija.Remove(voziloKategorija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        private bool VoziloKategorijaExists(int id)
        {
            return _context.VoziloKategorija.Any(e => e.Id == id);
        }
    }
}
