using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        private int stock;

        [ObservableProperty]
        private decimal price; 

        public DateOnly ShelfLife { get; set; }

        // Constructor zonder THT
        public Product(int id, string name, int stock, decimal price)
            : this(id, name, stock, price, default)
        {
        }

        // Constructor met THT
        public Product(int id, string name, int stock, decimal price, DateOnly shelfLife)
            : base(id, name)
        {
            Stock = stock;
            Price = price;
            ShelfLife = shelfLife;
        }

        public Product(int id, string name, int stock)
            : this(id, name, stock, 0m, default)
        {
        }

        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad - €{Price:F2}";
        }
    }
}
