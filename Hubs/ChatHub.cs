using System.Text.Json;
using Microsoft.AspNetCore.SignalR;

public class ChatHub: Hub 
{
    public async Task SendMessage(Message message)
    {
        try
        {
            string messageJson = JsonSerializer.Serialize(message);
            await Clients.All.SendAsync("GlobalMessage", messageJson);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"SendMessage Error: {ex.Message}");
        }
    }
}