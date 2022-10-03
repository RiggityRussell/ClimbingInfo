using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimbingInfo.Models;

namespace ClimbingInfo.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ClimbingContext _context;

        public ExperienceController(ClimbingContext context)
        {
            _context = context;
        }

        // GET: Experience
        public async Task<IActionResult> Index()
        {
            var climbingContext = _context.Experience.Include(e => e.Members);
            return View(await climbingContext.ToListAsync());
        }

        // GET: Experience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .Include(e => e.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experience/Create
        public IActionResult Create()
        {
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name");
            return View();
        }

        // POST: Experience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,years,freq,MembersID")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name", experience.MembersID);
            return View(experience);
        }

        // GET: Experience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name", experience.MembersID);
            return View(experience);
        }

        // POST: Experience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,years,freq,MembersID")] Experience experience)
        {
            if (id != experience.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.ID))
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
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "name", experience.MembersID);
            return View(experience);
        }

        // GET: Experience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .Include(e => e.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experience.FindAsync(id);
            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.ID == id);
        }
    }
}
