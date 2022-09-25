using System;
using System.Collections.Generic;
using System.Text;
using Test3.ObjctDTO;

namespace Test3
{
    public class Oreder_ItemDTO : Objct
    {
        public int OrderId { get; set; }
        public virtual OrderDTO Order { get; set; }

        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }

        public int Quntity { get; set; }

        public int List_Prise { get; set; }
        public int Discaunt { get; set; }
    }
}
