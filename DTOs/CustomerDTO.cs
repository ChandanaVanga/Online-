using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Online.Models;

namespace Online.DTOs;

public record CustomerDTO
{
    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }

    [JsonPropertyName("customer_name")]
    public string CustomerName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("mobile_number")]
    public long MobileNumber { get; set; }

   [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("my_orders")]
    public List<OrdersDTO> MyOrders { get; set; }

}

public record CustomerCreateDTO
{
    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }

    [JsonPropertyName("customer_name")]
    public string CustomerName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }


    [JsonPropertyName("mobile_number")]
    public long MobileNumber { get; set; }

}

public record CustomerUpdateDTO
{
    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }

    [JsonPropertyName("customer_name")]
    public string CustomerName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }


    [JsonPropertyName("mobile_number")]
    public long MobileNumber { get; set; }


    [JsonPropertyName("orders")]
    public List<OrdersDTO> Orders { get; set; }

}