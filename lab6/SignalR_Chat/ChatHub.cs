using Microsoft.AspNetCore.SignalR;

namespace RazorPagesApp.Hubs
{
    /// <summary>
    /// Центр управления сообщениями в реальном времени.
    /// Разработал: Даниил Белов
    /// </summary>
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // Рассылка сообщения всем подключенным клиентам
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            // Логика при входе нового пользователя
            await Clients.All.SendAsync("UserConnected", "Системное уведомление: Вход в сеть");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Логика при выходе пользователя
            await Clients.All.SendAsync("UserDisconnected", "Системное уведомление: Выход из сети");
            await base.OnDisconnectedAsync(exception);
        }
    }
}