using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Data.ProductsServices
{
    public interface IProductsService
    {
       Task Create(string Name, string Description, decimal Value);
       IEnumerable<T> GetAll<T>(int? count = null);

    }
}
