using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HASRental.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authorization;

namespace HASRental.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly NasContext _context;
        private readonly UserManager<Korisnik> _userManager;
        public RezervacijaController(NasContext context,UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index()
        {
            var nasContext = _context.Rezervacija.Include(r => r.Korisnik).Include(r => r.KrajnjaLokacija).Include(r => r.PocetnaLokacija).Include(r => r.VoziloKategorija);
            ViewBag.Id = _userManager.GetUserId(HttpContext.User);
            return View(await nasContext.ToListAsync());
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.KrajnjaLokacija)
                .Include(r => r.PocetnaLokacija)
                .Include(r => r.VoziloKategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        [Authorize(Roles = "Admin")]
        [Authorize(Roles ="Klijent")]
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad");
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad");
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Ime");
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Create([Bind("Id,PocetnaLokacijaId,KrajnjaLokacijaId,VoziloKategorijaId")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                rezervacija.KorisnikId = int.Parse(_userManager.GetUserId(HttpContext.User));
                var rez = JsonConvert.SerializeObject(rezervacija);
                TempData["Rezervacija"] = rez;
                TempData.Keep("Rezervacija");
               /* _context.Add(rezervacija);
                await _context.SaveChangesAsync();*/

            }
            return RedirectToAction("Create", "Renta");
            /*ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Email", rezervacija.KorisnikId);
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", rezervacija.KrajnjaLokacijaId);
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", rezervacija.PocetnaLokacijaId);
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Ime", rezervacija.VoziloKategorijaId);
            return View(rezervacija);*/
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Email", rezervacija.KorisnikId);
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", rezervacija.KrajnjaLokacijaId);
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", rezervacija.PocetnaLokacijaId);
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Ime", rezervacija.VoziloKategorijaId);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PocetnaLokacijaId,KrajnjaLokacijaId,VoziloKategorijaId")] Rezervacija rezervacija)
        {
            if (id != rezervacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Email", rezervacija.KorisnikId);
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", rezervacija.KrajnjaLokacijaId);
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Grad", rezervacija.PocetnaLokacijaId);
            ViewData["VoziloKategorijaId"] = new SelectList(_context.VoziloKategorija, "Id", "Ime", rezervacija.VoziloKategorijaId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Korisnik)
                .Include(r => r.KrajnjaLokacija)
                .Include(r => r.PocetnaLokacija)
                .Include(r => r.VoziloKategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.Id == id);
        }
    }
}
