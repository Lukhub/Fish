#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fish.Models;
using Microsoft.Extensions.Hosting.Internal;

namespace Fish.Controllers
{
    [Area("Admin")]
    [BasicAuthorize]
    public class AnimalController : Controller
    {
        private readonly FishContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AnimalController(FishContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.Animal.Include(a => a.Genus);
            return View(await fishContext.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Genus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["GenusID"] = new SelectList(_context.Genus, "Id", "Name");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CareLevel,Temparament,MaxSize,GenusID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenusID"] = new SelectList(_context.Genus, "Id", "Name", animal.GenusID);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["GenusID"] = new SelectList(_context.Genus, "Id", "Name", animal.GenusID);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CareLevel,Temparament,MaxSize,Image,GenusID")] Animal animal)
        {
            if (id != animal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Save file to the images folder
                    string fileName = UploadedFile(animal);
                    animal.Photo = fileName;
                   
                    //Update Database
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.ID))
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
            ViewData["GenusID"] = new SelectList(_context.Genus, "Id", "Name", animal.GenusID);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Genus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.FindAsync(id);

            //Delete Photo if exist
            if(animal.Photo != null)
            {
                DeletePhoto(animal);
            }
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.ID == id);
        }


        //Save uploaded image file to the folder
        private string UploadedFile(Animal animal)
        {
            string uniqueFileName = null;

            if (animal.Image != null)
            {
                string uploadsFolder = _webHostEnvironment.WebRootPath + "/images";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + animal.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    animal.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        //Delete Photo in the physical Folder
        private void DeletePhoto(Animal animal)
        {
            string ImagesFolder = _webHostEnvironment.WebRootPath + "/images/";
            string FilePath = ImagesFolder + animal.Photo;
            FileInfo file = new(FilePath);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}

