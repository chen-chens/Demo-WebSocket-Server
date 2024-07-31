using System.Text.Json;
using Microsoft.AspNetCore.SignalR;

public class ChatHub: Hub 
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger){
        _logger = logger;
    }

    // 加入群組
    public async Task JoinGroup(string[] groupIds)
    {
        try
        {
            foreach(var groupId in groupIds){
                await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
                _logger.LogInformation($"JoinGroup Success: ConnectionId {Context.ConnectionId}/{groupId}");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"JoinGroup Error: {ex.Message}");
            _logger.LogError($"JoinGroup Error: {ex.Message}");
        }
    }

    // 離開群組
    public async Task LeaveGroup(string groupId)
    {
        try
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
            _logger.LogInformation($"LeaveGroup Success: ConnectionId {Context.ConnectionId}/{groupId}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"LeaveGroup Error: {ex.Message}");
            _logger.LogError($"LeaveGroup Error: {ex.Message}");
        }
    }

    // 通知其他人有新加入成員
    public async Task NoticeUserLogIn(OnlineUserInfo userInfo)
    {
        // 記錄收到的消息
        _logger.LogInformation($"UserLogIn: {JsonSerializer.Serialize(userInfo)}");
        try
        {
            string userInfoJson = JsonSerializer.Serialize(userInfo);
            await Clients.All.SendAsync("UserLogIn", userInfoJson);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"NoticeUserLogIn Error: {ex.Message}");
            _logger.LogError($"NoticeUserLogIn Error: {ex.Message}");
        }
    }

    // 發送全域訊息
    public async Task SendGlobalMessage(Message message)
    {
        // 記錄收到的消息
        _logger.LogInformation($"Received message: {JsonSerializer.Serialize(message)}");
        try
        {
            string messageJson = JsonSerializer.Serialize(message);
            await Clients.All.SendAsync("GlobalMessage", messageJson);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"SendMessage Error: {ex.Message}");
            _logger.LogError($"SendMessage Error: {ex.Message}");
        }
    }

    // 發送群組訊息
    public async Task SendGroupMessage(string groupId, GroupMessage message)
    {
        // 記錄收到的消息
        _logger.LogInformation($"Received group message: {JsonSerializer.Serialize(message)}");
        try
        {
            string messageJson = JsonSerializer.Serialize(message);
            await Clients.Group(groupId).SendAsync("GroupMessage", messageJson);
            _logger.LogInformation($"Message sent to group {groupId}: {messageJson}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"SendGroupMessage Error: {ex.Message}");
            _logger.LogError($"SendGroupMessage Error: {ex.Message}");
        }
    }

    // 發送私人訊息
    public async Task SendPrivateMessage(string toUserId, PrivateMessage message)
    {
        // 記錄收到的消息
        _logger.LogInformation($"Received private message: {JsonSerializer.Serialize(message)}");
        try
        {
            string messageJson = JsonSerializer.Serialize(message);
            await Clients.User(toUserId).SendAsync("PrivateMessage", messageJson);
            _logger.LogInformation($"Message sent to {toUserId}: {messageJson}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"SendPrivateMessage Error: {ex.Message}");
            _logger.LogError($"SendPrivateMessage Error: {ex.Message}");
        }
    }
}