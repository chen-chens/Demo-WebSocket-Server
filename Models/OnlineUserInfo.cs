using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class OnlineUserInfo {
    [JsonPropertyName ("id")]
    [Required]
    public string Id {get; set;}
    [JsonPropertyName ("name")]
    [Required]
    public string Name {get; set;}
    [JsonPropertyName ("avator")]
    public string Avator {get; set;}
    [JsonPropertyName ("groups")]
    [Required]
    public string[] Groups {get; set;}
}