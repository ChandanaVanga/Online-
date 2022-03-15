using Online.DTOs;

namespace Online.Models;


public record Orders
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    /// </summary>
    public long OrderId { get; set; }
    public string Status { get; set; }

    public long CustomerId { get; set; }
    
    

    public OrdersDTO asDto => new OrdersDTO
    {
        OrderId = OrderId,
        Status = Status,
        CustomerId = CustomerId,
    };
}