using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Klad.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db;
        public HomeController(ProductContext context)
        {
            db = context;
        }


        //   public async Task<IActionResult> Index(int page = 1, string category = null)
        public async Task<IActionResult> Index( string category = null,  int page = 1)
        {
           // var pathBase = HttpContext.Request.PathBase;
            //string table = "";
            //foreach (var header in Request.Headers)
            //{
            //    table += $"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>";
            //}
            //Response.WriteAsync(String.Format("<table>{0}</table>", table));
            //string userAgent = Request.Headers["User-Agent"].ToString();
            //string referer = Request.Headers["Referer"].ToString();

            int pageSize = 2;   // количество элементов на странице
            IQueryable<Product> source;

            if (category == null || category == "all")
                source = db.Products; //.Include(x => x.Company);
            else
            {
                source = db.Products.Where(x => x.Category == category);
            }

            

            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            List<int> pagesList = new PagesLink(pageViewModel)._pages;

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items,
                ListCategory = Category.category,
                CurrentCategory = category,
                Pages = pagesList
            };
            return View(viewModel);
            

        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            
            ViewBag.ProductId = id;
            return View();

        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }

        //public IActionResult Index()
        //{
        //    // return View();
        //    return View(db.Products.ToList());
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
