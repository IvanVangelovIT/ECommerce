using ECommerce.Data;
using ECommerce.Data.Models.Products;
using ECommerce.Services.Mapping;
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
        public async Task Create(string Name, string Description, decimal Value)
        {
            var product = new Product()
            {
                Name = Name,
                Description = Description,
                Value = Value,
            };
            
            await this._context.AddAsync(product);
            await this._context.SaveChangesAsync();
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
    }
}
