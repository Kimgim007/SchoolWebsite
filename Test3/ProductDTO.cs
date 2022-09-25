using System;
using System.Collections.Generic;
using System.Text;
using Test3.ObjctDTO;

namespace Test3
{
    public class ProductDTO : Objct
    {
        public string ProductName { get; set; }

        public int BrandId { get; set; }
        public virtual BrandsDTO Brand { get; set; }

        public int CategorieId { get; set; }
        public virtual CategoryDTO Categorie { get; set; }

        public int Model_Year { get; set; }

        public int List_Prise { get; set; }

    }
}
