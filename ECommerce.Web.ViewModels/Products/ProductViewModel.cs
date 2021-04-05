using ECommerce.Data.Models.Products;
using ECommerce.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Web.ViewModels.Products
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
