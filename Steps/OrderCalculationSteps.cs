using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using agros_repo.Helpers;
using agros_repo.ApiClient;
using agros_repo.ApiModels;
using agros_repo.Models;
using System.Linq;

[Binding]
public class OrderCalculationSteps
{
    private int _numberOfPeople;
    private int _starters;
    private int _mains;
    private int _drinks;
    private bool _isBefore7pm;
    private decimal _expectedTotal;

    private Order? _order;
    private OrderResponse? _orderResponse;
    private readonly ApiClient _apiClient;

    public OrderCalculationSteps()
    {
        var baseUrl = ConfigReader.GetBaseUrl();
        _apiClient = new ApiClient(baseUrl);
    }

    [Given(@"A group of (.*) people order")]
    public void GivenAGroupOfPeopleOrder(int numberOfPeople, Table table)
    {
        _numberOfPeople = numberOfPeople;

        var row = table.Rows[0];

        _starters = int.TryParse(row["Starters"], out var s) ? s : 0;
        _mains = int.TryParse(row["Mains"], out var m) ? m : 0;
        _drinks = int.TryParse(row["Drinks"], out var d) ? d : 0;
        _isBefore7pm = bool.TryParse(row["IsBefore7pm"], out var b) && b;

        var (starterPrice, mainPrice, drinkPrice) = GetPricesWithDiscount();

        _order = new Order();
        _order.CreateOrder(_starters, _mains, _drinks, starterPrice, mainPrice, drinkPrice);

        _expectedTotal = TotalPriceCalculator.CalculateTotal(_order);
    }

    [When(@"A group of (.*) people is joined and order")]
    public void WhenAGroupOfPeopleIsJoinedAndOrder(int numberOfPeople, Table table)
    {
        if (_order == null)
            throw new InvalidOperationException("Order must be initialized before adding items.");

        var row = table.Rows[0];

        var additionalStarters = int.TryParse(row["Starters"], out var s) ? s : 0;
        var additionalMains = int.TryParse(row["Mains"], out var m) ? m : 0;
        var additionalDrinks = int.TryParse(row["Drinks"], out var d) ? d : 0;
        _isBefore7pm = bool.TryParse(row["IsBefore7pm"], out var b) && b;

        var (starterPrice, mainPrice, drinkPrice) = GetPricesWithDiscount();

        _numberOfPeople += numberOfPeople;

        for (int i = 0; i < additionalStarters; i++)
            _order.Items.Add(new MenuItem("Starter", starterPrice));

        for (int i = 0; i < additionalMains; i++)
            _order.Items.Add(new MenuItem("Main", mainPrice));

        for (int i = 0; i < additionalDrinks; i++)
            _order.Items.Add(new MenuItem("Drink", drinkPrice));

        _expectedTotal = TotalPriceCalculator.CalculateTotal(_order);
    }

    [When(@"Some people from the group cancel order")]
    public void WhenSomePeopleFromTheGroupCancelOrder(Table table)
    {
        if (_order == null)
            throw new InvalidOperationException("Order must be initialized before canceling items.");

        var row = table.Rows[0];

        int cancelStarters = int.TryParse(row["Starters"], out var s) ? s : 0;
        int cancelMains = int.TryParse(row["Mains"], out var m) ? m : 0;
        int cancelDrinks = int.TryParse(row["Drinks"], out var d) ? d : 0;
        _isBefore7pm = bool.TryParse(row["IsBefore7pm"], out var b) && b;

        _order.RemoveItems("Starter", cancelStarters);
        _order.RemoveItems("Main", cancelMains);
        _order.RemoveItems("Drink", cancelDrinks);

        // Recalculate expected total after removing some items from order
        _expectedTotal = TotalPriceCalculator.CalculateTotal(_order);
    }

    //I imagine that OrderRequest parameters for POST endpoint is like JSON {item: price}
    [When(@"The bill is requested via the endpoint")]
    public async Task WhenTheBillIsRequestedViaTheEndpoint()
    {
        var request = _order!.ToOrderRequest();
        _orderResponse = await _apiClient.PostAndDeserializeAsync<OrderRequest, OrderResponse>("/order/calculate", request);
    }

    [Then(@"The calculated sum of bill is correct in the response")]
    public void ThenTheCalculatedSumOfBillIsCorrectInTheResponse()
    {
        Assert.That(_orderResponse, Is.Not.Null, "Bill response was null.");
        Assert.That(_orderResponse!.Total, Is.EqualTo(_expectedTotal), "Total price does not match expected.");
    }

    private (decimal Starter, decimal Main, decimal Drink) GetPricesWithDiscount()
    {
        var prices = ConfigReader.GetMenuPrices();
        var drinkPrice = _isBefore7pm ? prices.Drink * 0.7m : prices.Drink;
        return (prices.Starter, prices.Main, drinkPrice);
    }
}
