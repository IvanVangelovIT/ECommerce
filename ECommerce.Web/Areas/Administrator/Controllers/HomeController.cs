using ECommerce.Data;
using ECommerce.Services.Data.ProductsServices;
using ECommerce.Web.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Areas.Administrator.Controllers
{
    [Area("Admin2")]
    public class HomeController : Controller
    {
        private readonly IProductsService productService;
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext _context)
        {
            this.productService = productService;
            context = _context;
        }
        public IActionResult Index()
        {
            var viewModel = this.context.Products.ToList();

            return View();
        }

        public IActionResult GetAllProducts()
        {
            var viewModel = this.context.Products.ToList();

            return Ok(viewModel);
        }
    }
}
