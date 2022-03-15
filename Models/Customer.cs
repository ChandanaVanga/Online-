 using Online.DTOs;

namespace Online.Models;

public enum Gender
{
    Female = 1, // "Female" -> "female"
    Male = 2, // "Male" -> "male"
    
}

public record Customer
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    /// </summary>
    public long CustomerId { get; set; }
    public string CustomerName { get; set; }

    public Gender Gender { get; set; }
    public string Address { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public long MobileNumber { get; set; }

    /// <summary>
    /// Can be NULL
    /// </summary>
    public long ProductId { get; set; }


    public long OrderId { get; set; }
    

    public CustomerDTO asDto => new CustomerDTO
    {
        CustomerId = CustomerId,
        CustomerName = CustomerName,
        Gender = Gender.ToString().ToLower(),
        Address = Address,
        MobileNumber = MobileNumber,
        ProductId = ProductId,
        
        
    };
}