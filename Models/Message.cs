public class Message 
{
    public string User {get; set;}
    public string TraceId {get; set;}
    public string Content {get; set;}
    public string CreatedTime {get; set;}

    public Message(string user, string traceId, string content, string createdTime)
    {
        User = user;
        TraceId = traceId;
        Content = content;
        CreatedTime = createdTime;
    }
}