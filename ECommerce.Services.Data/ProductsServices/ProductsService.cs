using ECommerce.Data;
using ECommerce.Data.Models.Products;
using ECommerce.Services.Mapping;
using ECommerce.Web.ViewModels.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Data.ProductsServices
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;

        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductViewModel> Create(string Name, string Description, decimal Value)
        {
            var product = new Product()
            {
                Name = Name,
                Description = Description,
                Value = Value,
            };
            
            await this._context.AddAsync(product);
            await this._context.SaveChangesAsync();

            var viewModel = new ProductViewModel
            { 
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };

            return viewModel;
        }

        public async Task<bool> Delete(int? id)
        {
            var product = await this._context.Products.FirstOrDefaultAsync(x=> x.Id == id);

            this._context.Remove(product);

            return true;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Product> query = this._context.Products;

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task<T> GetById<T>(int id)
        {
            //var product = await _context.Products.Where(x => x.Id == id).Select(x => new ProductViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Value = x.Value,

            //}).FirstOrDefaultAsync();

            var product = await this._context
                .Products
                .Where(x => x.Id == id)
                .To<T>()
                .FirstAsync();

            return product;
        }
    }
}
