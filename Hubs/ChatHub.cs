using System.Text.Json;
using Microsoft.AspNetCore.SignalR;

public class ChatHub: Hub 
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger){
        _logger = logger;
    }

    public async Task JoinGroup(string groupId)
    {
        try
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            _logger.LogTrace($"JoinGroup Success: {groupId}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"JoinGroup Error: {ex.Message}");
            _logger.LogError($"JoinGroup Error: {ex.Message}");
        }
    }

    public async Task LeaveGroup(string groupId)
    {
        try
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
            _logger.LogTrace($"LeaveGroup Success: {groupId}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"LeaveGroup Error: {ex.Message}");
            _logger.LogError($"LeaveGroup Error: {ex.Message}");
        }
    }

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

    public async Task SendGroupMessage(string groupId, GroupMessage message)
    {
        // 記錄收到的消息
        _logger.LogInformation($"Received group message: {JsonSerializer.Serialize(message)}");
        try
        {
            string messageJson = JsonSerializer.Serialize(message);
            await Clients.Group(groupId).SendAsync("GroupMessage", messageJson);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"SendGroupMessage Error: {ex.Message}");
            _logger.LogError($"SendGroupMessage Error: {ex.Message}");
        }
    }

}