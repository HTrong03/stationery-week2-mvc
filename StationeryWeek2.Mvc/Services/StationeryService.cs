using StationeryWeek2.Mvc.Models;
using StationeryWeek2.Mvc.ViewModels;

namespace StationeryWeek2.Mvc.Services;

public class StationeryService
{
    private readonly List<Stationery> _items = new()
    {
        new Stationery
        {
            Id = 1,
            Code = "ST001",
            Name = "Bút bi Thiên Long",
            Category = "Bút",
            Brand = "Thiên Long",
            Price = 5000,
            Quantity = 50,
            MinStock = 10,
            LastUpdatedAt = DateTime.Now
        },

        new Stationery
        {
            Id = 2,
            Code = "ST002",
            Name = "Vở 200 trang",
            Category = "Vở",
            Brand = "Hồng Hà",
            Price = 18000,
            Quantity = 8,
            MinStock = 10,
            LastUpdatedAt = DateTime.Now
        },

        new Stationery
        {
            Id = 3,
            Code = "ST003",
            Name = "Bút Highlight",
            Category = "Bút",
            Brand = "Stabilo",
            Price = 25000,
            Quantity = 0,
            MinStock = 5,
            LastUpdatedAt = DateTime.Now
        },

        new Stationery
        {
            Id = 4,
            Code = "ST004",
            Name = "Sổ tay mini",
            Category = "Sổ",
            Brand = "Campus",
            Price = 35000,
            Quantity = 25,
            MinStock = 5,
            LastUpdatedAt = DateTime.Now
        },

        new Stationery
        {
            Id = 5,
            Code = "ST005",
            Name = "Thước kẻ 30cm",
            Category = "Dụng cụ",
            Brand = "FlexOffice",
            Price = 12000,
            Quantity = 40,
            MinStock = 10,
            LastUpdatedAt = DateTime.Now
        }
    };

    public List<Stationery> GetAll()
    {
        return _items;
    }

    public Stationery? GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public StationeryStatsViewModel GetStats()
    {
        var inStockCount = _items.Count(x => x.Quantity > x.MinStock);

        var lowStockCount = _items.Count(x =>
            x.Quantity > 0 && x.Quantity <= x.MinStock);

        var highestInventoryValue = _items
            .Max(x => x.Price * x.Quantity);

        var averageInventoryValue = _items
            .Average(x => x.Price * x.Quantity);

        var averageQuantity = _items
            .Average(x => x.Quantity);
        return new StationeryStatsViewModel
        {
            TotalItems = _items.Count,
            TotalQuantity = _items.Sum(x => x.Quantity),
            TotalValue = _items.Sum(x => x.Price * x.Quantity),
            OutOfStock = _items.Count(x => x.Quantity == 0),
            
            InStockCount = inStockCount,
            LowStockCount = lowStockCount,

            HighestInventoryValue = highestInventoryValue,
            AverageInventoryValue = averageInventoryValue,
            AverageQuantity = averageQuantity,

            NeedRestock = _items.Count(x =>
                x.Quantity > 0 &&
                x.Quantity <= x.MinStock)
        };
    }
}