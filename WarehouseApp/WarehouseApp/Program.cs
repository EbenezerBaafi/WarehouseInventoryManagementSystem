using WarehouseApp;


namespace WarehouseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("______Warehouse Inventory Management System______");
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("*******App Starting*****\n");


            WareHouseManager manager = new WareHouseManager();

            // Initialize the inventory repositories
            manager.SeedData();

            // Print all electronic items
            Console.WriteLine("Electronic Items:");
            manager.PrintAllItems(manager.Electronics);
            Console.WriteLine("_________________________________________________");

            // Print all grocery items
            Console.WriteLine("Grocery Items:");
            manager.PrintAllItems(manager.Groceries);
            Console.WriteLine("_________________________________________________");

            // Testing exception scenarios
            try
            {
                // Attempt to add an item with a that already exists
                var newItem = new ElectronicItem(1, "Headset", 5, "Oraimo", 12);
                manager.Electronics.AddItem(newItem); // This should throw a DuplicateItemException
            }
            catch (CustomExceptions.DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Attempt to remove an item that does not exist
            try
            {
                manager.Electronics.RemoveItem(999); // Assuming 999 does not exist
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Attempt to update quantity with invalid quantity
            try
            {
                manager.IncreasesStocks(manager.Electronics, 1, -5); // Negative quantity
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}