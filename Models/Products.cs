using Online.DTOs;

namespace Online.Models;



public record Products
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    /// </summary>
    public long ProductId { get; set; }
    public string ProductName { get; set; }

    public decimal Price { get; set; }
    public string Discription { get; set; }
    public string InStock { get; set; }
    public long CustomerId { get; set; }

    /// <summary>
    /// Can be NULL
    /// </summary>
    public long TagId { get; set; }


    
    

    public ProductsDTO asDto => new ProductsDTO
    {
        ProductId = ProductId,
        ProductName = ProductName,
        Price = Price,
        InStock = InStock,
        Discription = Discription,
        // CustomerId = CustomerId,
        // TagId = TagId,
        
        
    };
}