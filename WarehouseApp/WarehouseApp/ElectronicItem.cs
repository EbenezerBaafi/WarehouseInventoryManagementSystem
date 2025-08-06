using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    public class ElectronicItem
    {
        public int Id;
        public string Name;
        public int Quantity;
        public string Brand;
        public int WarrantyMonths;

        public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
            this.Brand = brand;
            this.WarrantyMonths = warrantyMonths;
        }
    }
}
