using System.Text.Json;
using Microsoft.AspNetCore.SignalR;

public class ChatHub: Hub 
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger){
        _logger = logger;
    }

    public async Task SendMessage(Message message)
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
}