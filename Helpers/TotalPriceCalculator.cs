using System.Linq;
using agros_repo.Models;

namespace agros_repo.Helpers
{
    public static class TotalPriceCalculator
    {
        public static decimal CalculateTotal(Order order)
        {
            if (order == null || order.Items == null)
                return 0;

            decimal total = order.Items.Sum(item => item.Price);
            return total * 1.10m;
        }
    }
}
