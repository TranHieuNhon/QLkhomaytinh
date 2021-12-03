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
    public class NhaPhanPhoisController : Controller
    {
        private readonly QuanLyKhoContext _context;

        public NhaPhanPhoisController(QuanLyKhoContext context)
        {
            _context = context;
        }

        // GET: NhaPhanPhois
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaPhanPhoi.ToListAsync());
        }

        // GET: NhaPhanPhois/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaPhanPhoi = await _context.NhaPhanPhoi
                .FirstOrDefaultAsync(m => m.MaNpp == id);
            if (nhaPhanPhoi == null)
            {
                return NotFound();
            }

            return View(nhaPhanPhoi);
        }

        // GET: NhaPhanPhois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaPhanPhois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNpp,TenNpp,Qg")] NhaPhanPhoi nhaPhanPhoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaPhanPhoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaPhanPhoi);
        }

        // GET: NhaPhanPhois/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaPhanPhoi = await _context.NhaPhanPhoi.FindAsync(id);
            if (nhaPhanPhoi == null)
            {
                return NotFound();
            }
            return View(nhaPhanPhoi);
        }

        // POST: NhaPhanPhois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNpp,TenNpp,Qg")] NhaPhanPhoi nhaPhanPhoi)
        {
            if (id != nhaPhanPhoi.MaNpp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaPhanPhoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaPhanPhoiExists(nhaPhanPhoi.MaNpp))
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
            return View(nhaPhanPhoi);
        }

        // GET: NhaPhanPhois/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaPhanPhoi = await _context.NhaPhanPhoi
                .FirstOrDefaultAsync(m => m.MaNpp == id);
            if (nhaPhanPhoi == null)
            {
                return NotFound();
            }

            return View(nhaPhanPhoi);
        }

        // POST: NhaPhanPhois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhaPhanPhoi = await _context.NhaPhanPhoi.FindAsync(id);
            _context.NhaPhanPhoi.Remove(nhaPhanPhoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaPhanPhoiExists(string id)
        {
            return _context.NhaPhanPhoi.Any(e => e.MaNpp == id);
        }
    }
}
