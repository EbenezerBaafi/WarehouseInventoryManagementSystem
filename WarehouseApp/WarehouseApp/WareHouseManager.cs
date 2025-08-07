using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    public class WareHouseManager
    {
        InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
        InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

        public InventoryRepository<ElectronicItem> Electronics
        {
            get { return _electronics; }
        }
        public InventoryRepository<GroceryItem> Groceries
        {
            get { return _groceries; }
        }

        public void GetData()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }
        public void SeedData() 
        {
            //Add electronic objects to the inventory
            _electronics.AddItem(new ElectronicItem(1, "Headset", 5, "Oraimo", 12));
            _electronics.AddItem(new ElectronicItem(2, "Laptop", 3, "Dell", 24));
            _electronics.AddItem(new ElectronicItem(3, "Smartphone", 10, "Samsung", 36));

            //Add grocery objects to the inventory
            _groceries.AddItem(new GroceryItem(1, "Rice", 20, DateTime.Now.AddMonths(6)));
            _groceries.AddItem(new GroceryItem(2, "Beans", 15, DateTime.Now.AddMonths(3)));
            _groceries.AddItem(new GroceryItem(3, "Sugar", 30, DateTime.Now.AddMonths(12)));
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems(); // Gets all items from the repository

            foreach(var item in items)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Quantity: {item.Quantity}");
            }
        }

        // Add items to the stock
        public void IncreasesStocks<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                if (quantity < 0)
                {
                    throw new InvalidQuantityException("Quantity cannot be negative.");

                }
                else
                {
                    repo.UpdateQuantity(id, quantity);
                    Console.WriteLine($"Stock successfully updated for item with ID: {id}");
                }
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine("Error: Item with the specicified ID was not found. ");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occured. {ex.Message}");
            }

        }

        // Removes items from the stocks
        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with id {id} has been successfully removed.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occured while removing the item {ex.Message}");
            }
        }
    }
}
