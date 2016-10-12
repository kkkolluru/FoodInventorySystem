using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodInventory.Data.Models.DTOs
{
    public class SalesDTO
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string Name { get; set; }
        public decimal NumberOfUnits { get; set; }
        public decimal Discount { get; set; }
        public string PaymentType { get; set; }

    }
}
