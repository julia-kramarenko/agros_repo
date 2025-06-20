
using agros_repo.ApiModels;
using System.Linq;

namespace agros_repo.Models
{
    public class Order
    {
        public List<MenuItem> Items { get; private set; }

        public Order()
        {
            Items = new List<MenuItem>();
        }

        public void CreateOrder(int startersCount, int mainsCount, int drinksCount,
                                decimal starterPrice, decimal mainPrice, decimal drinkPrice)
        {
            Items.Add(new MenuItem("Starter", starterPrice * startersCount));
            Items.Add(new MenuItem("Main", mainPrice * mainsCount));
            Items.Add(new MenuItem("Drink", drinkPrice * drinksCount));
        }

        public void RemoveItems(string itemName, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var itemToRemove = Items.FirstOrDefault(item => item.Name == itemName);
                if (itemToRemove != null)
                    Items.Remove(itemToRemove);
                else break;
            }
        }

        public OrderRequest ToOrderRequest()
        {
            var orderItemsDto = new List<MenuItemDto>();

            foreach (var item in Items)
            {
                orderItemsDto.Add(new MenuItemDto
                {
                    Name = item.Name,
                    Price = item.Price
                });
            }

            return new OrderRequest
            {
                Orders = new List<List<MenuItemDto>> { orderItemsDto }
            };
        }
    }
}

