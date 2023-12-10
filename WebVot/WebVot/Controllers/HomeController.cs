using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebVot.Data;
using WebVot.Models;

namespace WebVot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object _pwHasher;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SanPhams.Include(s => s.MaNccNavigation).Include(s => s.MaNsxNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.MaNccNavigation)
                .Include(s => s.MaNsxNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            ViewData["MaNcc"] = new SelectList(_context.Nccs, "MaNcc", "MaNcc");
            ViewData["MaNsx"] = new SelectList(_context.Nsxes, "MaNsx", "MaNsx");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,Sluong,MaNsx,MaNcc,Hinhanh,GiaBan,GiaGoc")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNcc"] = new SelectList(_context.Nccs, "MaNcc", "MaNcc", sanPham.MaNcc);
            ViewData["MaNsx"] = new SelectList(_context.Nsxes, "MaNsx", "MaNsx", sanPham.MaNsx);
            return View(sanPham);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaNcc"] = new SelectList(_context.Nccs, "MaNcc", "MaNcc", sanPham.MaNcc);
            ViewData["MaNsx"] = new SelectList(_context.Nsxes, "MaNsx", "MaNsx", sanPham.MaNsx);
            return View(sanPham);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSp,TenSp,Sluong,MaNsx,MaNcc,Hinhanh,GiaBan,GiaGoc")] SanPham sanPham)
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
            ViewData["MaNcc"] = new SelectList(_context.Nccs, "MaNcc", "MaNcc", sanPham.MaNcc);
            ViewData["MaNsx"] = new SelectList(_context.Nsxes, "MaNsx", "MaNsx", sanPham.MaNsx);
            return View(sanPham);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.MaNccNavigation)
                .Include(s => s.MaNsxNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SanPhams == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SanPhams'  is null.");
            }
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(string id)
        {
          return (_context.SanPhams?.Any(e => e.MaSp == id)).GetValueOrDefault();
        }
        public IActionResult Login()
        {
          
            return View();

        }

        private void GetInfo()
        {
            throw new NotImplementedException();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(string email, string matkhau)
        //{
        //    var kh = await _context.SanPhams.FirstOrDefaultAsync(m => m.MaNcc == email);
        //   // if (kh != null && _pwHasher.VerifyHashedPassword(kh, kh., matkhau) == PasswordVerificationResult.Success)
        //    {
        //        // dùng biến session để lưu thông tin người vừa đăng nhập
        //       // HttpContext.Session.SetString("HoTenKH", kh.MatKhau);
        //        // chuyển hướng về view
        //        return RedirectToAction(nameof(Customer));
        //    }

        //    return RedirectToAction(nameof(Login));
        //}
        //public IActionResult Customer()
        //{
           
        //    return View();
        //}
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.SetString("khachhang", "");
 
        //    return RedirectToAction(nameof(Index));
        //}

        ////Get 
        //public IActionResult Register()
        //{
        //    GetInfo();
        //    return View();
        //}
        
    
}

}
