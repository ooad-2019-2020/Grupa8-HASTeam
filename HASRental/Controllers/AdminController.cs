using HASRental.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class AdminController:Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<Korisnik> _userManager;
        private readonly NasContext _context;
        public AdminController(RoleManager<AppRole> roleManager,UserManager<Korisnik> userManager, NasContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult KreirajUlogu()
        {
            return View();

        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var korisnici =await _context.Users.ToListAsync();
            return View(korisnici);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renta = await _context.Renta.Include(r => r.Korisnik).Include(r => r.KrajnjaLokacija).Include(r => r.PocetnaLokacija).Include(r => r.TipRezervoara).Include(r => r.Vozilo).Where(k => k.KorisnikId == id).ToListAsync();
            if (renta == null)
            {
                return NotFound();
            }

            return View(renta);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> KreirajUlogu(KreirajUlogu model)
        {
            if(ModelState.IsValid)
            {
                AppRole Uloga = new AppRole
                {
                    Name = model.NazivUloge
                };
                IdentityResult result = await _roleManager.CreateAsync(Uloga);
                if(result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

            }
            return View(model);
        }
       
    }
}
