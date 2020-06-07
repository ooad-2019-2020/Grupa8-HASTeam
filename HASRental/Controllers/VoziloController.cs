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
    public class VoziloController : Controller
    {
        private readonly NasContext _context;

        public VoziloController(NasContext context)
        {
            _context = context;
        }

        // GET: Vozilo
        public async Task<IActionResult> Index()
        {
            var nasContext = _context.Vozilo.Include(v => v.Proizvodjac).Include(v => v.TrenutnaLokacija).Include(v => v.VoziloKategorija);
            return View(await nasContext.ToListAsync());
        }

        // GET: Vozilo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilo
                .Include(v => v.Proizvodjac)
                .Include(v => v.TrenutnaLokacija)
                .Include(v => v.VoziloKategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vozilo == null)
            {
                return NotFound();
            }

            return View(vozilo);
        }

        // GET: Vozilo/Create
        public IActionResult Create()
        {
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Naziv");
            ViewData["TrenutnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad");
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Ime");
            return View();
        }

        // POST: Vozilo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Create([Bind("Id,VoziloKategorijaId,ProizvodjacId,TrenutnaLokacijaId,Model,GodinaProizvodnje,Kilometraza,Boja")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vozilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Naziv", vozilo.ProizvodjacId);
            ViewData["TrenutnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", vozilo.TrenutnaLokacijaId);
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Ime", vozilo.VoziloKategorijaId);
            return View(vozilo);
        }

        // GET: Vozilo/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilo.FindAsync(id);
            if (vozilo == null)
            {
                return NotFound();
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Id", vozilo.ProizvodjacId);
            ViewData["TrenutnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", vozilo.TrenutnaLokacijaId);
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Id", vozilo.VoziloKategorijaId);
            return View(vozilo);
        }

        // POST: Vozilo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoziloKategorijaId,ProizvodjacId,TrenutnaLokacijaId,Model,GodinaProizvodnje,Kilometraza,Boja")] Vozilo vozilo)
        {
            if (id != vozilo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vozilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoziloExists(vozilo.Id))
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
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "Id", "Id", vozilo.ProizvodjacId);
            ViewData["TrenutnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", vozilo.TrenutnaLokacijaId);
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Id", vozilo.VoziloKategorijaId);
            return View(vozilo);
        }

        // GET: Vozilo/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilo
                .Include(v => v.Proizvodjac)
                .Include(v => v.TrenutnaLokacija)
                .Include(v => v.VoziloKategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vozilo == null)
            {
                return NotFound();
            }

            return View(vozilo);
        }

        // POST: Vozilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vozilo = await _context.Vozilo.FindAsync(id);
            _context.Vozilo.Remove(vozilo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        private bool VoziloExists(int id)
        {
            return _context.Vozilo.Any(e => e.Id == id);
        }
    }
}
