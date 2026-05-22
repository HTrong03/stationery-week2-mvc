namespace StationeryWeek2.Mvc.ViewModels;

public class StationeryListItemViewModel
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Brand { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int MinStock { get; set; }

    public string PriceText => $"{Price:N0} VND";

    public decimal InventoryValue => Price * Quantity;

    public string InventoryValueText => $"{InventoryValue:N0} VND";

    public string StockStatus
    {
        get
        {
            if (Quantity >= 30) return "Tồn kho cao";
            if (Quantity <= 0) return "Hết hàng";
            if (Quantity <= MinStock) return "Cần nhập thêm";
            return "Còn hàng";
        }
    }

    public string StockStatusClass
    {
        get
        {
            if (Quantity >= 30)
                return "badge bg-primary-subtle text-primary";

            if (Quantity <= 0)
                return "badge bg-danger-subtle text-danger";

            if (Quantity <= MinStock)
                return "badge bg-warning-subtle text-warning";

            return "badge bg-success-subtle text-success";
        }
    }
}