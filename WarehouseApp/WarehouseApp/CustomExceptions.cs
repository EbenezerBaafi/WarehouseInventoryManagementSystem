using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp
{
    // Custom exceptions for the WarehouseApp //

    internal class CustomExceptions
    {
        public class DuplicateItemException : Exception
        {
            public DuplicateItemException() { }
            public DuplicateItemException(string message) : base(message) { }
            public DuplicateItemException(string message, Exception inner) : base(message, inner) { }
        }
    }


    // Invalid quantity custom exception
    internal class InvalidQuantityException : Exception
    {
        public InvalidQuantityException()
        {
        }

        public InvalidQuantityException(string? message) : base(message)
        {
        }

        public InvalidQuantityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    // Item not found  custom exception
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string? message) : base(message)
        {
        }

        public ItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

}
