using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        Dictionary<int, T> _items = new Dictionary<int, T>();

        // Adds an item to the inventory
        public void AddItem(T item)
        {
            if(_items.ContainsKey(item.Id))
            {
                throw new DuplicateNameException($"Item with ID {item.Id} already exists.");
            }
            _items[item.Id] = item;
        }

        public T GetItemById(int id)
        {
            // Check if the item exists in the dictionary
            if (_items.ContainsKey(id))
            {
                return _items[id];
            }
            throw new ItemNotFoundException($"Item with ID {id} not found.");
        }

        // Removes an item from the inventory
        public void RemoveItem(int id)
        {
            if (_items.ContainsKey(id))
            {
                _items.Remove(id);
            }
            throw new ItemNotFoundException($"Item with ID {id} not found.");
        }

        // Gets all items in the inventory
        public List<T> GetAllItems()
        {
            return _items.Values.ToList();
        }

        // Updates an item in the inventory
        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new InvalidQuantityException("Quantity cannot be negative.");
            }
        }

    }
}

