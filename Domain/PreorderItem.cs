using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Preorder.Domain
{
    public class PreorderItem : BaseEntity
    {
        public int PreorderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
