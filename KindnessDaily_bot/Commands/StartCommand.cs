namespace KindnessDaily_bot.Commands
{
    public static class StartCommand
    {
        public static async Task StartCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);

            if (!DataBase.CheckContainsUserId(userId))
            {
                DataBase.AddUserId(userId);
                await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.startMessage);

                await Task.Delay(2000);

                KindnessSendingTask.StartMessageSendingTask(botClient, cancellationToken, userId);
            }
            else
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/stop" }, botClient, userId, cancellationToken, DataBase.stopMessage);
        }
    }
}
