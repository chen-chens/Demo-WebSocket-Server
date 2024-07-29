using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class GroupMessage : Message 
{
    [JsonPropertyName("groupName")]
    public string GroupName {get; set;}

    [JsonPropertyName("groupId")]
    [Required]
    public string GroupId {get; set;}

    public GroupMessage(string fromUserId, string fromUserName, string traceId, string content, string createdTime, string groupName, string groupId) : base(fromUserId, fromUserName, traceId, content, createdTime)
    {
        GroupName = groupName;
        GroupId = groupId;
    }
}