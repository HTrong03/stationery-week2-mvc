namespace StationeryWeek2.Mvc.ViewModels;

public class StationeryStatsViewModel
{
    public int TotalItems { get; set; }

    public int TotalQuantity { get; set; }

    public decimal TotalValue { get; set; }

    public int OutOfStock { get; set; }

    public int NeedRestock { get; set; }

    public int InStockCount { get; set; }

   //
    public int LowStockCount { get; set; }

    public decimal HighestInventoryValue { get; set; }

    public decimal AverageInventoryValue { get; set; }

    public double AverageQuantity { get; set; }

    public string HighestInventoryValueText
        => $"{HighestInventoryValue:N0} VND";

    public string AverageInventoryValueText
        => $"{AverageInventoryValue:N0} VND";
    //
    public string TotalValueText => $"{TotalValue:N0} VND";


}