using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoHang.Models;

namespace QuanLyKhoHang.Controllers
{
    public class HangSanXuatsController : Controller
    {
        private readonly QuanLyKhoContext _context;

        public HangSanXuatsController(QuanLyKhoContext context)
        {
            _context = context;
        }

        // GET: HangSanXuats
        public async Task<IActionResult> Index()
        {
            return View(await _context.HangSanXuat.ToListAsync());
        }

        // GET: HangSanXuats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuat = await _context.HangSanXuat
                .FirstOrDefaultAsync(m => m.MaNxx == id);
            if (hangSanXuat == null)
            {
                return NotFound();
            }

            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HangSanXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNxx,TenNxx,GhiChu")] HangSanXuat hangSanXuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangSanXuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuat = await _context.HangSanXuat.FindAsync(id);
            if (hangSanXuat == null)
            {
                return NotFound();
            }
            return View(hangSanXuat);
        }

        // POST: HangSanXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNxx,TenNxx,GhiChu")] HangSanXuat hangSanXuat)
        {
            if (id != hangSanXuat.MaNxx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangSanXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangSanXuatExists(hangSanXuat.MaNxx))
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
            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuat = await _context.HangSanXuat
                .FirstOrDefaultAsync(m => m.MaNxx == id);
            if (hangSanXuat == null)
            {
                return NotFound();
            }

            return View(hangSanXuat);
        }

        // POST: HangSanXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hangSanXuat = await _context.HangSanXuat.FindAsync(id);
            _context.HangSanXuat.Remove(hangSanXuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangSanXuatExists(string id)
        {
            return _context.HangSanXuat.Any(e => e.MaNxx == id);
        }
    }
}
