using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    public interface IInventoryItem
    {
         int Id { get; }
         string Name { get; }
         int Quantity { get; set; }
    }
}
