using ECommerce.Data;
using ECommerce.Services.Data.ProductsServices;
using ECommerce.Web.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IProductsService productsService;

        public HomeController(ApplicationDbContext _context, 
            IProductsService productsService)
        {
            context = _context;
            this.productsService = productsService;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(id);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductViewModel product)
        {
            var viewModel = await this.productsService.Create(product.Name, product.Description, product.Value);
            return Json(viewModel);
        }
        public ActionResult GetProduct(int? id)
        {
            //var viewModel = new ProductsViewModel
            //{
            //    Products = this.productsService.GetAll<ProductViewModel>(),
            //};
            //return Ok(viewModel);
            var viewModel = this.context.Products.ToList();
            return Ok(viewModel);
        }
        public ActionResult GetAll()
        {
            //var viewModel = new ProductsViewModel
            //{
            //    Products = this.productsService.GetAll<ProductViewModel>(),
            //};
            //return Ok(viewModel);
            var viewModel = this.context.Products.ToList();
            return Ok(viewModel);
        }



        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ProductViewModel product)
        {
            var viewModel = await this.productsService
                .Edit<ProductViewModel>(product.Id, product.Name, product.Description, product.Value);
            return Json(viewModel);
        }

        // GET: HomeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var isItDeleted = await this.productsService.Delete(id);
            return Json(isItDeleted);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
