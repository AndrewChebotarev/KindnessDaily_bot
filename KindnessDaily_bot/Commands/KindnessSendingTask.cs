namespace KindnessDaily_bot.Commands
{
    public static class KindnessSendingTask
    {
        public static async Task StartMessageSendingTask(ITelegramBotClient botClient, CancellationToken cancellationToken, long userId)
        {
            while (true)
            {
                try
                {
                    if (!DataBase.usersIdList.Contains(userId))
                        return;

                    await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.kindnessTask);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при отправке сообщения: {ex.Message}");
                }

                await Task.Delay(2000);
            }
        }
    }
}
