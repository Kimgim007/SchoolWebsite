using System;
using System.Collections.Generic;
using System.Text;
using Test3.ObjctDTO;

namespace Test3
{
   
    public class StockDTO: Objct
    {
        public int StoreId { get; set; }
        public virtual StoreDTO Store { get; set; }

        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; } 

        public int Quantity { get; set; }
    }
}
