namespace RestaurantAPI.Domain.Models;


public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ItemName { get; set; }
    public decimal Price { get; set; }
}