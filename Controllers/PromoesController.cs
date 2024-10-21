using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAbadBurguerPromoCF.Data;
using SAbadBurguerPromoCF.Models;

namespace SAbadBurguerPromoCF.Controllers
{
    public class PromoesController : Controller
    {
        private readonly SAbadBurguerPromoCFContext _context;

        public PromoesController(SAbadBurguerPromoCFContext context)
        {
            _context = context;
        }

        // GET: Promoes
        public async Task<IActionResult> Index()
        {
            var sAbadBurguerPromoCFContext = _context.Promo.Include(p => p.Burguer);
            return View(await sAbadBurguerPromoCFContext.ToListAsync());
        }

        // GET: Promoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burguer)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promoes/Create
        public IActionResult Create()
        {
            ViewData["BurguerID"] = new SelectList(_context.Burguer, "BurguerId", "BurguerId");
            return View();
        }

        // POST: Promoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoID,Descripcion,FechaPromo,BurguerID")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurguerID"] = new SelectList(_context.Burguer, "BurguerId", "BurguerId", promo.BurguerID);
            return View(promo);
        }

        // GET: Promoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["BurguerID"] = new SelectList(_context.Burguer, "BurguerId", "BurguerId", promo.BurguerID);
            return View(promo);
        }

        // POST: Promoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoID,Descripcion,FechaPromo,BurguerID")] Promo promo)
        {
            if (id != promo.PromoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.PromoID))
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
            ViewData["BurguerID"] = new SelectList(_context.Burguer, "BurguerId", "BurguerId", promo.BurguerID);
            return View(promo);
        }

        // GET: Promoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burguer)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
            return _context.Promo.Any(e => e.PromoID == id);
        }
    }
}
