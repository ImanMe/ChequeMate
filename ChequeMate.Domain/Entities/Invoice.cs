namespace ChequeMate.Domain.Entities;

public class Invoice : BaseEntity
{
    public string CustomerName { get; set; }
    public string DueDate { get; set; }
    public ICollection<ListItem> ListItems { get; set; }
}