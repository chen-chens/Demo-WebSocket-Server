using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class PrivateMessage : Message 
{
    [JsonPropertyName("toUserId")]
    [Required]
    public string ToUserId {get; set;}

    [JsonPropertyName("toUserName")]
    public string ToUserName {get; set;}

    public PrivateMessage (
        string toUserId, 
        string toUserName, 
        string fromUserId, 
        string fromUserName, 
        string traceId, 
        string content, 
        string createdTime
    ) : base(
        fromUserId, 
        fromUserName, 
        traceId, 
        content, 
        createdTime
    )
    {
        ToUserId = toUserId;
        ToUserName = toUserName;
    }
}