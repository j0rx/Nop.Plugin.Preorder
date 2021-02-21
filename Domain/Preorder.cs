using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Preorder.Domain
{
    public class Preorder : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Month { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CancelledAt { get; set; }
    }
}
