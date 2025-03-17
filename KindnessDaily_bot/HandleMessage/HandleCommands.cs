namespace KindnessDaily_bot.HandleCommands
{
    public class HandleCommands
    {
        public HandleCommands(TelegramBotClient botClient)
        {
            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == UpdateType.MyChatMember)
                {
                    var chatMember = update.MyChatMember;

                    // Проверяем, что пользователь заблокировал бота
                    if (chatMember.NewChatMember.Status == ChatMemberStatus.Kicked)
                    {
                        long userId = chatMember.Chat.Id;

                        // Удаляем пользователя из базы данных
                        DataBase.RemoveUserId(userId);

                        Console.WriteLine($"Пользователь {userId} заблокировал бота.");

                        return;
                    }
                }
                else
                {
                    string userMessage = HelpFunc.GetMessageUserText(update);
                    HelpFunc.GetInformationUserMessage(update);

                    if (update.Type == UpdateType.Message && userMessage == "/start")
                        await StartCommand.StartCommandAsync(botClient, update, cancellationToken);
                    else if (update.Type == UpdateType.Message && userMessage == "/stop")
                        await StopCommand.StopCommandAsync(botClient, update, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!" + ex);
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
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
