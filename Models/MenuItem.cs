namespace agros_repo.Models
{
    public class MenuItem(string name, decimal price)
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
    }
}


