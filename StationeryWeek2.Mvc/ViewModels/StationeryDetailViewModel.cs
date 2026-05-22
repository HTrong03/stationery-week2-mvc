namespace StationeryWeek2.Mvc.ViewModels;

public class StationeryDetailViewModel
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Brand { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int MinStock { get; set; }
    public DateTime LastUpdatedAt { get; set; }

    public string PriceText => $"{Price:N0} VND";
    public string LastUpdatedText => LastUpdatedAt.ToString("dd/MM/yyyy HH:mm");

    public string StockStatus
    {
        get
        {
            if (Quantity >= 30)
                return "Tồn kho cao";

            if (Quantity <= 0)
                return "Hết hàng";

            if (Quantity <= MinStock)
                return "Cần nhập thêm";

            return "Còn hàng";
        }
    }
}