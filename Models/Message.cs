using System.Text.Json.Serialization;

public class Message 
{
    [JsonPropertyName("fromUserId")]
    public string FromUserId {get; set;}

    [JsonPropertyName("fromUserName")]
    public string FromUserName {get; set;}

    [JsonPropertyName("traceId")]
    public string TraceId {get; set;}

    [JsonPropertyName("content")]
    public string Content {get; set;}

    [JsonPropertyName("createdTime")]
    public string CreatedTime {get; set;}

    public Message(string fromUserId, string fromUserName, string traceId, string content, string createdTime)
    {
        FromUserId = fromUserId;
        FromUserName = fromUserName;
        TraceId = traceId;
        Content = content;
        CreatedTime = createdTime;
    }
}