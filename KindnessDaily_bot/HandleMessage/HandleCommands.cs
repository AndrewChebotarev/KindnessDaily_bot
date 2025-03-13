using KindnessDaily_bot.Commands;

namespace KindnessDaily_bot.Новая_папка
{
    public class HandleCommands
    {
        private TelegramBotClient botClient;

        public HandleCommands(TelegramBotClient botClient) 
        {
            this.botClient = botClient;
            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message?.Text == "/start")
                await StartCommand.StartCommandAsync(botClient, update, cancellationToken);
            else if (update.Type == UpdateType.Message && update.Message?.Text == "/stop")
                await StopCommand

            // Сохраняем ID чата при команде /start
            if (update.Type == UpdateType.Message && update.Message?.Text == "/stop")
            {
                if (!DataBase.usersIdList.Contains(update.Message.Chat.Id))
                    return;

                DataBase.usersIdList.Remove(update.Message.Chat.Id);

                await botClient.SendMessage(
                    chatId: update.Message.Chat.Id,
                    text: "Соси!",
                    cancellationToken: cancellationToken);
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Обработка ошибок
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Ошибка API: {apiRequestException.ErrorCode}\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);
            return Task.CompletedTask;
        }
    }
}
