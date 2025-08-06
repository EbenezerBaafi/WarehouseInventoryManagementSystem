using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    public class GroceryItem : IInventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }

        public GroceryItem(int id, string name, int quantity, DateTime expirydate)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
            this.ExpiryDate = expirydate;
        }
    }
}
