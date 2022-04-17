using ChuyenDeCongNghePhanMem.Data;
using ChuyenDeCongNghePhanMem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ChuyenDeCongNghePhanMem.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StockController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Test> TestList = _db.Tests.ToList();
            Console.WriteLine(TestList);
            _db.Database.ExecuteSqlRaw("insertTests");
            Stock stock=new Stock();
            return View(stock);
        }
        [HttpPost]
        public IActionResult Create(Stock stock)
        {
            //stock.format();
            Console.WriteLine("-------");
            
            stock.show();
            if (ModelState.IsValid)
            {
                Console.WriteLine("valid");
                TempData["success"] = "Đặt lệnh thành công";

                Console.WriteLine("------------------------------");
                /*String sql = String.Format("ThemLenhDat '{0}','{1}',{2},{3}", stock.mack, stock.loai, stock.sl, stock.gia);
                Console.WriteLine(sql);
                Console.WriteLine(x);
                Console.WriteLine("-------------");*/
                String date = DateTime.Now.ToString("dd/MM/yyyy");
                String sql = String.Format("SP_KHOPLENH_LO '{0}','{1}','{2}',{3},{4}", stock.mack, date, stock.loai, stock.sl, stock.gia);
                Console.WriteLine(sql);
                int x = _db.Database.ExecuteSqlRaw(sql);
                Console.WriteLine(x);
                return RedirectToAction("Index");
                //return View("~/Views/Stock/index.cshtml", stock);
                
            }
            TempData["error"] = "Đặt lệnh thất bại";
            //return RedirectToAction("Index", stock);
            return View("~/Views/Stock/index.cshtml",stock);

            //String mack,int sl,int gia,String loai

        }
    }
}
