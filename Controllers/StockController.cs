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
            Console.WriteLine(ModelState.IsValid);

            stock.show();
            if (ModelState.IsValid)
            {
                Console.WriteLine("valid");
                TempData["success"] = "Đặt lệnh thành công";
                /*stock = new Stock();
                return RedirectToAction("Index", stock);*/
                return View("~/Views/Stock/index.cshtml", stock);
                
            }

            /* if (stock.mack=="")
             {
                 ModelState.AddModelError("mack", "Mã cổ phiếu không được rỗng");
             }*/
            TempData["error"] = "Đặt lệnh thất bại";
            return View("~/Views/Stock/index.cshtml",stock);

            //String mack,int sl,int gia,String loai

            /*Console.WriteLine("------------");
            Console.WriteLine(mack,sl,gia);
            Console.WriteLine(sl);
            Console.WriteLine( gia);
            Console.WriteLine(loai);
            Console.WriteLine("------------");

            String sql = String.Format("ThemLenhDat '{0}','{1}',{2},{3}", mack, loai, sl, gia);
            Console.WriteLine(sql);
            Console.WriteLine("------------");
            int x =_db.Database.ExecuteSqlRaw(sql);
            Console.WriteLine(x);
            Console.WriteLine("--------------------------------");
            String date = DateTime.Now.ToString("MM/dd/yyyy");
            sql = String.Format("SP_KHOPLENH_LO '{0}','{1}',{2},{3},{4}", mack, date, loai, sl, gia);
            Console.WriteLine(sql);
            /*int y = _db.Database.ExecuteSqlRaw(sql);
            Console.WriteLine(y);
            Console.WriteLine("------------");*/


            return RedirectToAction("Index");

        }
    }
}
