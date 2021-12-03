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
    public class SanPhamsController : Controller
    {
        private readonly QuanLyKhoContext _context;

        public SanPhamsController(QuanLyKhoContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var quanLyKhoContext = _context.SanPham.Include(s => s.IddmNavigation).Include(s => s.IdhxxNavigation).Include(s => s.IdkhoNavigation).Include(s => s.IdnppNavigation);
            return View(await quanLyKhoContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.IddmNavigation)
                .Include(s => s.IdhxxNavigation)
                .Include(s => s.IdkhoNavigation)
                .Include(s => s.IdnppNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["Iddm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm");
            ViewData["Idhxx"] = new SelectList(_context.HangSanXuat, "MaNxx", "MaNxx");
            ViewData["Idkho"] = new SelectList(_context.KhoTonHang, "MaKho", "MaKho");
            ViewData["Idnpp"] = new SelectList(_context.NhaPhanPhoi, "MaNpp", "MaNpp");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenSp,MaSp,Idkho,Slton,NgayNhap,Idnpp,Iddm,Idhxx")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm", sanPham.Iddm);
            ViewData["Idhxx"] = new SelectList(_context.HangSanXuat, "MaNxx", "MaNxx", sanPham.Idhxx);
            ViewData["Idkho"] = new SelectList(_context.KhoTonHang, "MaKho", "MaKho", sanPham.Idkho);
            ViewData["Idnpp"] = new SelectList(_context.NhaPhanPhoi, "MaNpp", "MaNpp", sanPham.Idnpp);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["Iddm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm", sanPham.Iddm);
            ViewData["Idhxx"] = new SelectList(_context.HangSanXuat, "MaNxx", "MaNxx", sanPham.Idhxx);
            ViewData["Idkho"] = new SelectList(_context.KhoTonHang, "MaKho", "MaKho", sanPham.Idkho);
            ViewData["Idnpp"] = new SelectList(_context.NhaPhanPhoi, "MaNpp", "MaNpp", sanPham.Idnpp);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TenSp,MaSp,Idkho,Slton,NgayNhap,Idnpp,Iddm,Idhxx")] SanPham sanPham)
        {
            if (id != sanPham.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSp))
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
            ViewData["Iddm"] = new SelectList(_context.DanhMuc, "MaDm", "MaDm", sanPham.Iddm);
            ViewData["Idhxx"] = new SelectList(_context.HangSanXuat, "MaNxx", "MaNxx", sanPham.Idhxx);
            ViewData["Idkho"] = new SelectList(_context.KhoTonHang, "MaKho", "MaKho", sanPham.Idkho);
            ViewData["Idnpp"] = new SelectList(_context.NhaPhanPhoi, "MaNpp", "MaNpp", sanPham.Idnpp);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.IddmNavigation)
                .Include(s => s.IdhxxNavigation)
                .Include(s => s.IdkhoNavigation)
                .Include(s => s.IdnppNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(string id)
        {
            return _context.SanPham.Any(e => e.MaSp == id);
        }
    }
}
