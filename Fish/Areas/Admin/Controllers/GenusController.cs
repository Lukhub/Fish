#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fish.Models;

namespace Fish.Controllers
{
    [Area("Admin")]
    [BasicAuthorize]
    public class GenusController : Controller
    {
        private readonly FishContext _context;

        public GenusController(FishContext context)
        {
            _context = context;
        }

        // GET: Genus
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.Genus.Include(g => g.Family);
            return View(await fishContext.ToListAsync());
        }

        // GET: Genus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genus = await _context.Genus
                .Include(g => g.Family)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genus == null)
            {
                return NotFound();
            }

            return View(genus);
        }

        // GET: Genus/Create
        public IActionResult Create()
        {
            ViewData["FamilyId"] = new SelectList(_context.Family, "Id", "Name");
            return View();
        }

        // POST: Genus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FamilyId")] Genus genus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamilyId"] = new SelectList(_context.Family, "Id", "Name", genus.FamilyId);
            return View(genus);
        }

        // GET: Genus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genus = await _context.Genus.FindAsync(id);
            if (genus == null)
            {
                return NotFound();
            }
            ViewData["FamilyId"] = new SelectList(_context.Family, "Id", "Name", genus.FamilyId);
            return View(genus);
        }

        // POST: Genus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FamilyId")] Genus genus)
        {
            if (id != genus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenusExists(genus.Id))
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
            ViewData["FamilyId"] = new SelectList(_context.Family, "Id", "Name", genus.FamilyId);
            return View(genus);
        }

        // GET: Genus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genus = await _context.Genus
                .Include(g => g.Family)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genus == null)
            {
                return NotFound();
            }

            return View(genus);
        }

        // POST: Genus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genus = await _context.Genus.FindAsync(id);
            _context.Genus.Remove(genus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenusExists(int id)
        {
            return _context.Genus.Any(e => e.Id == id);
        }
    }
}
