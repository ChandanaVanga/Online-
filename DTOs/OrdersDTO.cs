using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Online.Models;

namespace Online.DTOs;

public record OrdersDTO
{
    [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }


    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }
}

public record OrdersCreateDTO
{
    [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }


    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }

}

public record OrdersUpdateDTO
{
   [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }


    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }

}