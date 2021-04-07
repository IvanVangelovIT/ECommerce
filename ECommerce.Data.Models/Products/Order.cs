using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Models.Products
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
