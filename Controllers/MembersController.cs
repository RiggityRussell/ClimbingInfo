using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimbingInfo.Models;
using ClimbingInfo.Data;
using Microsoft.AspNetCore.Authorization;

namespace ClimbingInfo.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly ClimbingContext _context;

        public MembersController(ClimbingContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["MemSort"] = String.IsNullOrEmpty(sortOrder) ? "member_desc" : "";

            /*var climbingContext = _context.Membership.Include(m => m.Experience).Include(m => m.Gear);
            return View(await climbingContext.ToListAsync());*/

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var members = from m in _context.Membership.Include(m => m.Experience).Include(m => m.Gear) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m => m.name.Contains(searchString) || m.city.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "member_desc":
                    members = members.OrderByDescending(m => m.name);
                    break;
                default:
                    members = members.OrderBy(m => m.name);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Members>.CreateAsync(members.AsNoTracking(), pageNumber ?? 1, pageSize));
            /*return View(members);*/
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Membership
                .Include(m => m.Experience)
                .Include(m => m.Gear)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceName");
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "SetupName");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,gender,address,city,state,zip,email,cell,ExperienceId,GearId")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", members.ExperienceId);
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "GearId", members.GearId);
            return View(members);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Membership.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceName", members.ExperienceId);
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "SetupName", members.GearId);
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,gender,address,city,state,zip,email,cell,ExperienceId,GearId,ExperienceName,SetupName")] Members members)
        {
            if (id != members.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.ID))
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
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceName", members.ExperienceId);
            ViewData["GearId"] = new SelectList(_context.Gear, "GearId", "SetupName", members.GearId);
            return View(members);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Membership
                .Include(m => m.Experience)
                .Include(m => m.Gear)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Membership.FindAsync(id);
            _context.Membership.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Membership.Any(e => e.ID == id);
        }
    }
}
