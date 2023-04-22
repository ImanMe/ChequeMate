namespace ChequeMate.API.DTOs;

public class ListItemVm
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}