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
    public class TipRezervoaraController : Controller
    {
        private readonly NasContext _context;

        public TipRezervoaraController(NasContext context)
        {
            _context = context;
        }
        [Authorize(Roles="Admin")]
        // GET: TipRezervoara
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipRezervoara.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        // GET: TipRezervoara/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipRezervoara = await _context.TipRezervoara
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipRezervoara == null)
            {
                return NotFound();
            }

            return View(tipRezervoara);
        }
        [Authorize(Roles = "Admin")]
        // GET: TipRezervoara/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: TipRezervoara/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Opis")] TipRezervoara tipRezervoara)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipRezervoara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipRezervoara);
        }

        // GET: TipRezervoara/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipRezervoara = await _context.TipRezervoara.FindAsync(id);
            if (tipRezervoara == null)
            {
                return NotFound();
            }
            return View(tipRezervoara);
        }
        [Authorize(Roles = "Admin")]
        // POST: TipRezervoara/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Opis")] TipRezervoara tipRezervoara)
        {
            if (id != tipRezervoara.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipRezervoara);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipRezervoaraExists(tipRezervoara.Id))
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
            return View(tipRezervoara);
        }

        // GET: TipRezervoara/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipRezervoara = await _context.TipRezervoara
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipRezervoara == null)
            {
                return NotFound();
            }

            return View(tipRezervoara);
        }

        // POST: TipRezervoara/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipRezervoara = await _context.TipRezervoara.FindAsync(id);
            _context.TipRezervoara.Remove(tipRezervoara);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        private bool TipRezervoaraExists(int id)
        {
            return _context.TipRezervoara.Any(e => e.Id == id);
        }
    }
}
