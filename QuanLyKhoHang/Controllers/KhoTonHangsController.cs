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
    public class KhoTonHangsController : Controller
    {
        private readonly QuanLyKhoContext _context;

        public KhoTonHangsController(QuanLyKhoContext context)
        {
            _context = context;
        }

        // GET: KhoTonHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhoTonHang.ToListAsync());
        }

        // GET: KhoTonHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoTonHang = await _context.KhoTonHang
                .FirstOrDefaultAsync(m => m.MaKho == id);
            if (khoTonHang == null)
            {
                return NotFound();
            }

            return View(khoTonHang);
        }

        // GET: KhoTonHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoTonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKho,TenKho,GhiChup")] KhoTonHang khoTonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoTonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoTonHang);
        }

        // GET: KhoTonHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoTonHang = await _context.KhoTonHang.FindAsync(id);
            if (khoTonHang == null)
            {
                return NotFound();
            }
            return View(khoTonHang);
        }

        // POST: KhoTonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKho,TenKho,GhiChup")] KhoTonHang khoTonHang)
        {
            if (id != khoTonHang.MaKho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoTonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoTonHangExists(khoTonHang.MaKho))
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
            return View(khoTonHang);
        }

        // GET: KhoTonHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoTonHang = await _context.KhoTonHang
                .FirstOrDefaultAsync(m => m.MaKho == id);
            if (khoTonHang == null)
            {
                return NotFound();
            }

            return View(khoTonHang);
        }

        // POST: KhoTonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khoTonHang = await _context.KhoTonHang.FindAsync(id);
            _context.KhoTonHang.Remove(khoTonHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoTonHangExists(string id)
        {
            return _context.KhoTonHang.Any(e => e.MaKho == id);
        }
    }
}
