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
using WAD.WebApp._7458.DAL.Repository;

namespace WAD.WebApp._7458.Controllers
{
    public class BikesController : Controller
    {
        private readonly BikeDbContext _context;
        private readonly IRepository<Bike> _bikeRepo;
        private readonly IRepository<Brand> _BrandRepo;
        private readonly IRepository<Category> _CategoryRepo;

        public BikesController(BikeDbContext context, IRepository<Bike> bikeRepo, IRepository<Brand> BrandRepo, IRepository<Category> CategoryRepo)
        {
            _context = context;
            _bikeRepo = bikeRepo;
            _BrandRepo = BrandRepo;
            _CategoryRepo = CategoryRepo;
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
        public async Task<IActionResult> Create()
        {
            ViewData["BrandId"] = new SelectList( await _BrandRepo.GetAllAsync(), "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList( await _CategoryRepo.GetAllAsync(), "CategoryId", "CategoryName"); ;
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BikeId,BikeName,CategoryId,BrandId,ModelYear,Price,BikePhoto,ArrivedDate,IsReturnable")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                try
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
                    await _bikeRepo.CreateAsync(bike);
                    return RedirectToAction(nameof(Index));
                } catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    Console.WriteLine(ex);
                }
            }
            ViewData["BrandId"] = new SelectList(await _BrandRepo.GetAllAsync(), "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList(await _CategoryRepo.GetAllAsync(), "CategoryId", "CategoryName");
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", bike.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", bike.CategoryId);
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BikeId,BikeName,CategoryId,BrandId,ModelYear,Price,BinaryPhoto,BikePhoto,ArrivedDate,IsReturnable")] Bike bike)
        {
            if (id != bike.BikeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
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
                    else
                    {
                        photoBytes = bike.BinaryPhoto;
                    }
                    bike.BinaryPhoto = photoBytes;
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", bike.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", bike.CategoryId);
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

        public async Task<IActionResult> ShowImage(int? id)
        {
            if (id.HasValue)
            {
                var bike = await _bikeRepo.GetByIdAsync(id.Value);
                if (bike?.BinaryPhoto != null)
                {
                    return File(
                        bike.BinaryPhoto,
                        "image/jpeg",
                        $"bike_{id}.jpg");
                }
            }

            return NotFound();
        }
    }
}
