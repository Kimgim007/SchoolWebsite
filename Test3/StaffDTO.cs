using System;
using System.Collections.Generic;
using System.Text;
using Test3.ObjctDTO;

namespace Test3
{
    public class StaffDTO : Objct
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Phone { get; set; }
        public string Emale { get; set; }
        public bool Active { get; set; }

        public int StoreId { get; set; }
        public StoreDTO Store { get; set; }

        public int ManagerId { get; set; }
        public StaffDTO Manager { get; set; }
    }
}
