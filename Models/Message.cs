using System.Text.Json.Serialization;

public class Message 
{
    [JsonPropertyName("user")]
    public string User {get; set;}
    [JsonPropertyName("traceId")]
    public string TraceId {get; set;}
    [JsonPropertyName("content")]
    public string Content {get; set;}
    [JsonPropertyName("createdTime")]
    public string CreatedTime {get; set;}

    public Message(string user, string traceId, string content, string createdTime)
    {
        User = user;
        TraceId = traceId;
        Content = content;
        CreatedTime = createdTime;
    }
}