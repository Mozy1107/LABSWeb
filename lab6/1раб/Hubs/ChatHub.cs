using Microsoft.AspNetCore.SignalR;

namespace Rabota1.Hubs
{
    /// <summary>
    /// Хаб для обеспечения real-time связи в приложении.
    /// Разработчик: Даниил Белов
    /// </summary>
    public class ChatHub : Hub
    {
        // Метод для отправки сообщения всем пользователям
        public async Task SendMessage(string user, string message)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(message)) return;

            await Clients.All.SendAsync("ReceiveMessage", user, message);

            // Простая мини-нейросеть-ответчик (на базе ключевых слов).
            // Не отвечает сама себе и не реагирует на системные сообщения.
            if (!user.Equals("ProCarBot", StringComparison.OrdinalIgnoreCase) &&
                !user.Equals("Система", StringComparison.OrdinalIgnoreCase))
            {
                _ = Task.Run(async () => await AutoRespond(user, message));
            }
        }

        private async Task AutoRespond(string fromUser, string message)
        {
            try
            {
                await Task.Delay(700); // небольшая задержка "думания"
                var txt = (message ?? string.Empty).ToLowerInvariant();
                string reply;

                if (txt.Contains("прив") || txt.Contains("здор") )
                {
                    reply = "Привет! Я ProCarBot — могу помочь по каталогу автомобилей. Спроси марку, модель или цену.";
                }
                else if (txt.Contains("цена") || txt.Contains("сколько") || txt.Contains("руб"))
                {
                    reply = "Уточните модель или диапазон цен — я подберу варианты. Например: 'покажи от 1 500 000 до 3 000 000'.";
                }
                else if (txt.Contains("рекоменд") || txt.Contains("подойдет") || txt.Contains("ищу"))
                {
                    reply = "Могу порекомендовать: Toyota Camry (надежный седан), KIA Seltos (компактный кроссовер), Tesla Model 3 (электро, популярный выбор).";
                }
                else if (txt.Contains("электр") || txt.Contains("tesla") )
                {
                    reply = "В нашем каталоге есть Tesla Model 3 и Model Y — отличные варианты среди электромобилей.";
                }
                else if (txt.Contains("помо") || txt.Contains("как") || txt.Contains("что"))
                {
                    reply = "Спросите, например: 'покажи кроссоверы', 'цены на BMW', 'подбери до 3 млн'.";
                }
                else
                {
                    reply = "Могу помочь с поиском и информацией по автомобилям: марка, модель, год, тип или диапазон цен.";
                }

                await Clients.All.SendAsync("ReceiveMessage", "ProCarBot", reply);
            }
            catch { }
        }

        // Вызывается при подключении нового клиента
        public override async Task OnConnectedAsync()
        {
            // Можно отправить уведомление только вновь подключенному пользователю
            await Clients.Caller.SendAsync("ReceiveMessage", "Система", "Добро пожаловать в корпоративный чат!");
            
            // Уведомляем остальных (опционально)
            await Clients.Others.SendAsync("ReceiveMessage", "Система", "Новый участник вошел в чат");
            
            await base.OnConnectedAsync();
        }

        // Вызывается при отключении клиента
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("ReceiveMessage", "Система", "Один из участников покинул чат");
            await base.OnDisconnectedAsync(exception);
        }
    }
}