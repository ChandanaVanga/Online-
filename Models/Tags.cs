using Online.DTOs;

namespace Online.Models;



public record Tags
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    /// </summary>
    public long TagId { get; set; }
    public string TagName { get; set; }

    public string Description { get; set; }
    
    public decimal Price { get; set; }

    /// <summary>
    /// Can be NULL
    /// </summary>
    public string Status { get; set; }


    public long OrderId { get; set; }

    public long ProductId { get; set; }
    

    public TagsDTO asDto => new TagsDTO
    {
        TagId = TagId,
        TagName = TagName,
        Description = Description,
        Price = Price,
        // Status = Status,
        // OrderId = OrderId,
        // ProductId = ProductId,
        
        
    };
}