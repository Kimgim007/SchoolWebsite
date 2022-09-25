using System;
using System.Collections.Generic;
using System.Text;
using Test3.ObjctDTO;

namespace Test3
{
    public class CustomerDTO: Objct
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Phone { get; set; }
        public string Emale { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
    }
}
