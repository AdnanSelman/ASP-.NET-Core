using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //GET Create action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags special)
        {
            if (ModelState.IsValid)
            {
                _db.Add(special);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(special);
        }

        //GET Edit action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);

            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTags special)
        {
            if (id != special.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(special);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(special);
        }

        //GET Details action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);

            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //GET Delete action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);

            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var special = await _db.SpecialTags.FindAsync(id);
            _db.SpecialTags.Remove(special);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}