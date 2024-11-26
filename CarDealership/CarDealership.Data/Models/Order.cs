namespace CarDealership.Data.Models;

public class Order
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }
    
    public decimal PurchasePrice { get; set; }

    public DateTime OrderDate { get; set; }
}