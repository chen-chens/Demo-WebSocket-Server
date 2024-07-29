using System.Text.Json.Serialization;

public class GroupMessage : Message 
{
    [JsonPropertyName("groupName")]
    public string GroupName {get; set;}
    
    [JsonPropertyName("groupId")]
    public string GroupId {get; set;}

    public GroupMessage(string user, string traceId, string content, string createdTime, string groupName, string groupId) : base(user, traceId, content, createdTime)
    {
        GroupName = groupName;
        GroupId = groupId;
    }
}