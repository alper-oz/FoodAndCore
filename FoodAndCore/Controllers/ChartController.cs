using FoodAndCore.Data;
using FoodAndCore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAndCore.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "Laptop",
                stock = 70
            });
            cs.Add(new Class1()
            {
                proname = "Notebook",
                stock = 250
            });
            return cs; 
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c=new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }
        public IActionResult Statistics()
        {
            Context c = new Context();
            var d1 = c.Foods.Count();
            ViewBag.totalfood = d1;

            var d2 = c.Categories.Count();
            ViewBag.totalcategory = d2;

            var d3 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.totalfoodnumber = d3;

            var d4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.totalvegetablenumber = d4;

            var d5 = c.Foods.Sum(x => x.Stock);
            ViewBag.totalfoodstocks = d5;

            var d6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.totallegumes = d6;

            var d7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.totalstockfood = d7;

            var d8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.minstockfood = d8;

            var d9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.foodpriceavg = d9;
            return View();
        }
    }
}
