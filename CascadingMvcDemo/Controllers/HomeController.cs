using CascadingMvcDemo.Data;
using CascadingMvcDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CascadingMvcDemo.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {

          
            var categories = _context.Categories.ToList();

       

            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
           

            return View();
        }


        public JsonResult GetProductByCategoryId(int categoryId) 
        {
            return Json(_context.Products.Where(u => u.CategoryId == categoryId).ToList());
        }


        public JsonResult GetProductdetailsByProductId(int productId)
        {
            return Json(_context.ProductDetailes.Where(u => u.ProductId == productId).ToList());
        }

        public IActionResult GetProductdetailsView(int productdetailsId)
        {
            List<ProductDetails> productDetailsList = _context.ProductDetailes.Where(u => u.Id == productdetailsId).Include(p => p.Product).ToList();




            //    _context.ProductDetailes.Include(p => p.Product).ToList();
            // return PartialView("_ProductDetailsPartial", productDetailsList);



            return View(productDetailsList);

            //return RedirectToAction("Index", "ProductDetails");
        }





    }






  }
