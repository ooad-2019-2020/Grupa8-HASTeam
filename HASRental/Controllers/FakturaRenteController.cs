using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HASRental.Models;

namespace HASRental.Controllers
{
    public class FakturaRenteController : Controller
    {
        private readonly NasContext _context;

        public FakturaRenteController(NasContext context)
        {
            _context = context;
        }

        // GET: FakturaRente
        // GET: FakturaRente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakturaRente = await _context.FakturaRente
                .Include(f => f.Renta)
                .FirstOrDefaultAsync(m => m.RentaId == id);
            if (fakturaRente == null)
            {
                return NotFound();
            }

            return View(fakturaRente);
        }
    }
}
