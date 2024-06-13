using System.Diagnostics.Metrics;

namespace Products.Metrics;

/// <summary>
/// Represents a class for tracking metrics related to products.
/// </summary>
public class ProductsMetrics
{
    private readonly Counter<int> _serviceCalls;
    private readonly Counter<int> _stockChange;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsMetrics"/> class.
    /// </summary>
    /// <param name="meterFactory">The meter factory used to create metrics.</param>
    public ProductsMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("eShopLite.Products");
        _serviceCalls = meter.CreateCounter<int>(name: "eshoplite.products.service_calls", unit: "{calls}", description: "Number of times the product service is being called to list all products.");
        _stockChange = meter.CreateCounter<int>(name: "eshoplite.products.stock_change", unit: "{stock}", description: "Amount of stock being changed through the product service.");
    }

    /// <summary>
    /// Tracks the number of service calls made to the product service.
    /// </summary>
    /// <param name="quantity">The quantity of service calls to track.</param>
    public void ServiceCalls(int quantity)
    {
        _serviceCalls.Add(quantity);
    }

    /// <summary>
    /// Tracks the amount of stock being changed through the product service.
    /// </summary>
    /// <param name="quantity">The quantity of stock change to track.</param>
    public void StockChange(int quantity)
    {
        _stockChange.Add(quantity);
    }
}