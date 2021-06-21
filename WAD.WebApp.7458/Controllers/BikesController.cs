using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WAD.WebApp._7458.DAL;
using WAD.WebApp._7458.DAL.DBO;

namespace WAD.WebApp._7458.Controllers
{
    public class BikesController : Controller
    {
        private readonly BikeDbContext _context;

        public BikesController(BikeDbContext context)
        {
            _context = context;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
            var bikeDbContext = _context.Bike.Include(b => b.Brand).Include(b => b.Category);
            return View(await bikeDbContext.ToListAsync());
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .Include(b => b.Brand)
                .Include(b => b.Category)
                .SingleOrDefaultAsync(m => m.BikeId == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId");
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BikeId,BikeName,CategoryId,BrandId,ModelYear,Price,BinaryPhoto,ArrivedDate,IsReturnable")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                byte[] photoBytes = null;
                if (bike.BikePhoto != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        bike.BikePhoto.CopyTo(memory);
                        photoBytes = memory.ToArray();
                    }
                }
                bike.BinaryPhoto = photoBytes;
                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId", bike.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", bike.CategoryId);
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.SingleOrDefaultAsync(m => m.BikeId == id);
            if (bike == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId", bike.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", bike.CategoryId);
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BikeId,BikeName,CategoryId,BrandId,ModelYear,Price,BinaryPhoto,ArrivedDate,IsReturnable")] Bike bike)
        {
            if (id != bike.BikeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.BikeId))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId", bike.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", bike.CategoryId);
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .Include(b => b.Brand)
                .Include(b => b.Category)
                .SingleOrDefaultAsync(m => m.BikeId == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bike = await _context.Bike.SingleOrDefaultAsync(m => m.BikeId == id);
            _context.Bike.Remove(bike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(int id)
        {
            return _context.Bike.Any(e => e.BikeId == id);
        }
    }
}
