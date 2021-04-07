using ECommerce.Web.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Data.ProductsServices
{
    public interface IProductsService
    {
       Task<ProductViewModel> Create(string Name, string Description, decimal Value);
       IEnumerable<T> GetAll<T>(int? count = null);
       Task<bool> Delete(int? id);
       Task<T> GetById<T>(int id);

        Task<ProductViewModel> Edit<T>(int Id, string Name, string Description, decimal Value);
    }
}
