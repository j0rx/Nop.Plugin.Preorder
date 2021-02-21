using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Preorder.Models
{
   public class OrderItemVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
