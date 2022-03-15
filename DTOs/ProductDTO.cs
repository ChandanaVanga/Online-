using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Online.Models;

namespace Online.DTOs;

public record ProductsDTO
{
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("discription")]
    public string Discription { get; set; }

    [JsonPropertyName("in_stock")]
    public string InStock { get; set; }

}

public record ProductsCreateDTO
{
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("discription")]
    public string Discription { get; set; }

    [JsonPropertyName("in_stock")]
    public string InStock { get; set; }

}

public record ProductsUpdateDTO
{
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("discription")]
    public string Discription { get; set; }

    [JsonPropertyName("in_stock")]
    public string InStock { get; set; }

}