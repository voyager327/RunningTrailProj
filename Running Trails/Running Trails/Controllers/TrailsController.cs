using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Running_Trails.Data;
using Running_Trails.Models;

namespace Running_Trails.Controllers
{
    public class TrailsController : Controller
    {
        private readonly Running_TrailsContext _context;

        public TrailsController(Running_TrailsContext context)
        {
            _context = context;
        }

        // GET: Trails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Runner.ToListAsync());
        }

        // GET: Trails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runner
                .FirstOrDefaultAsync(m => m.RunnerId == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // GET: Trails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RunnerId,SearchRunningTrailsByLocation,SearchRunningTrailsByDifficultyLevel,SearchRunningTrailsByTotalDistance,SearchRunningGroupByArea")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(runner);
        }

        // GET: Trails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runner.FindAsync(id);
            if (runner == null)
            {
                return NotFound();
            }
            return View(runner);
        }

        // POST: Trails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RunnerId,SearchRunningTrailsByLocation,SearchRunningTrailsByDifficultyLevel,SearchRunningTrailsByTotalDistance,SearchRunningGroupByArea")] Runner runner)
        {
            if (id != runner.RunnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunnerExists(runner.RunnerId))
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
            return View(runner);
        }

        // GET: Trails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runner
                .FirstOrDefaultAsync(m => m.RunnerId == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // POST: Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var runner = await _context.Runner.FindAsync(id);
            _context.Runner.Remove(runner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunnerExists(int id)
        {
            return _context.Runner.Any(e => e.RunnerId == id);
        }
    }
}
