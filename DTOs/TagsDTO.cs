using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Online.Models;

namespace Online.DTOs;

public record TagsDTO
{
    [JsonPropertyName("tag_id")]
    public long TagId { get; set; }

    [JsonPropertyName("tag_name")]
    public string TagName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("status")]
    public string status { get; set; }


}

public record TagsCreateDTO
{
     [JsonPropertyName("tag_id")]
    public long TagId { get; set; }

    [JsonPropertyName("tag_name")]
    public string TagName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("status")]
    public string status { get; set; }

}

public record TagsUpdateDTO
{
     [JsonPropertyName("tag_id")]
    public long TagId { get; set; }

    [JsonPropertyName("tag_name")]
    public string TagName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("status")]
    public string status { get; set; }

}