using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using ECommerce.Web.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Web.ViewModels.Products;
using ECommerce.Services.Data.ProductsServices;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService productService;

        public HomeController(ILogger<HomeController> logger,
            IProductsService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var viewModel = new ProductsViewModel
            {
                Products = this.productService.GetAll<ProductViewModel>(),
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Post(ProductsViewModel model)
        {

            await productService.Create(model.Product.Name, model.Product.Description, model.Product.Value);
            return RedirectToAction(nameof(Index));
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
