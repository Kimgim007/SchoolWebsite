using System;
using System.Collections.Generic;
using System.Text;
using Test3.ObjctDTO;

namespace Test3
{
    public class OrderDTO : Objct
    {
        public int CustomerId { get; set; }
        public virtual CustomerDTO Customer { get; set; }

        public string Order_Status { get; set; }

        public DateTime Order_Date { get; set; }
        public DateTime Required_Date { get; set; }
        public DateTime Shipped_Date { get; set; }

        public int StoreId { get; set; }
        public virtual StoreDTO Store { get; set; }

        public int StaffId { get; set; }
        public virtual StaffDTO Staff { get; set; }
    }
}
