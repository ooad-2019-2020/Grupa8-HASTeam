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
namespace HASRental.Controllers
{
    public class RentaController : Controller
    {
        private readonly NasContext _context;
        private readonly UserManager<Korisnik> _userManager;
        public RentaController(NasContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Renta
        public async Task<IActionResult> Index()
        {
            String s = _userManager.GetUserId(HttpContext.User);
            Nullable<int> id = null;
            id = int.Parse(s);
            var nasContext = _context.Renta.Include(r => r.Korisnik).Include(r => r.KrajnjaLokacija).Include(r => r.PocetnaLokacija).Include(r => r.TipRezervoara).Include(r => r.Vozilo).Where(k=>k.KorisnikId==id);
            return View(await nasContext.ToListAsync());
        }

        // GET: Renta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Renta
                .Include(r => r.Korisnik)
                .Include(r => r.KrajnjaLokacija)
                .Include(r => r.PocetnaLokacija)
                .Include(r => r.TipRezervoara)
                .Include(r => r.Vozilo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renta == null)
            {
                return NotFound();
            }
            var fakturaRente = await _context.FakturaRente.Where(fr => fr.RentaId == id).FirstOrDefaultAsync();
            int fakturaRenteId = fakturaRente.Id;
            return RedirectToAction("Details","FakturaRente",new{id=id});
        }

        // GET: Renta/Create
        public IActionResult Create()
        {
            string s = TempData.Peek("Rezervacija").ToString();
            Rezervacija rezervacija = JsonConvert.DeserializeObject<Rezervacija>(s);
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija.Where(o=>o.Id==rezervacija.KrajnjaLokacijaId), "Id", "Grad");
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija.Where(o=>o.Id==rezervacija.PocetnaLokacijaId), "Id", "Grad");
            ViewData["TipRezervoaraId"] = new SelectList(_context.TipRezervoara, "Id", "Opis");
            ViewData["VoziloId"] = new SelectList(_context.Vozilo.Where(v=>v.VoziloKategorijaId==rezervacija.VoziloKategorijaId), "Id", "Model");
            return View();
        }

        // POST: Renta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoziloId,PocetnaLokacijaId,KrajnjaLokacijaId,DatumRentanja,DatumVracanja,DodatneNaznake,TipRezervoaraId")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                string s = TempData.Peek("Rezervacija").ToString();
                Rezervacija rezervacija = JsonConvert.DeserializeObject<Rezervacija>(s);
                if (rezervacija == null)
                {
                 
                }
                var voziloKategorija =await _context.VoziloKategorija.Where(r => r.Id == rezervacija.VoziloKategorijaId).FirstOrDefaultAsync();
                double cijenaRente = voziloKategorija.CijenaRente;
                renta.KorisnikId = int.Parse(_userManager.GetUserId(HttpContext.User));
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                _context.Add(renta);
                await _context.SaveChangesAsync();
                int id = renta.Id;
                FakturaRente fakturaRente=new FakturaRente(id,cijenaRente,2,17,0,cijenaRente+(cijenaRente*0.17),cijenaRente,"Kes",1);
                _context.Add(fakturaRente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","FakturaRente",new { id = id });
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", renta.KorisnikId);
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Krajnja Lokacija", renta.KrajnjaLokacijaId);
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Krajnja Lokacija", renta.PocetnaLokacijaId);
            ViewData["TipRezervoaraId"] = new SelectList(_context.TipRezervoara, "Id", "Id", renta.TipRezervoaraId);
            ViewData["VoziloId"] = new SelectList(_context.Vozilo, "Id", "Id", renta.VoziloId);
            return View(renta);
        }

        // GET: Renta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Renta.FindAsync(id);
            if (renta == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", renta.KorisnikId);
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", renta.KrajnjaLokacijaId);
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", renta.PocetnaLokacijaId);
            ViewData["TipRezervoaraId"] = new SelectList(_context.TipRezervoara, "Id", "Id", renta.TipRezervoaraId);
            ViewData["VoziloId"] = new SelectList(_context.Vozilo, "Id", "Id", renta.VoziloId);
            return View(renta);
        }

        // POST: Renta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KorisnikId,VoziloId,PocetnaLokacijaId,KrajnjaLokacijaId,DatumRentanja,DatumVracanja,DodatneNaznake,TipRezervoaraId")] Renta renta)
        {
            if (id != renta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentaExists(renta.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", renta.KorisnikId);
            ViewData["KrajnjaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", renta.KrajnjaLokacijaId);
            ViewData["PocetnaLokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", renta.PocetnaLokacijaId);
            ViewData["TipRezervoaraId"] = new SelectList(_context.TipRezervoara, "Id", "Id", renta.TipRezervoaraId);
            ViewData["VoziloId"] = new SelectList(_context.Vozilo, "Id", "Id", renta.VoziloId);
            return View(renta);
        }

        // GET: Renta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Renta
                .Include(r => r.Korisnik)
                .Include(r => r.KrajnjaLokacija)
                .Include(r => r.PocetnaLokacija)
                .Include(r => r.TipRezervoara)
                .Include(r => r.Vozilo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renta == null)
            {
                return NotFound();
            }

            return View(renta);
        }

        // POST: Renta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renta = await _context.Renta.FindAsync(id);
            _context.Renta.Remove(renta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentaExists(int id)
        {
            return _context.Renta.Any(e => e.Id == id);
        }
    }
}
