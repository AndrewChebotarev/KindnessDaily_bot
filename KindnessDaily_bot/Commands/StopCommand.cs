namespace KindnessDaily_bot.Commands
{
    public static class StopCommand
    {
        public static async Task StopCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);

            if (!DataBase.CheckContainsUserId(userId))
                return;

            await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.stopMessage);

            DataBase.RemoveUserId(userId);
        }
    }
}
