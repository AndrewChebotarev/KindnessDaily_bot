using Telegram.Bot.Types;

namespace KindnessDaily_bot.Commands
{
    public static class StartCommand
    {
        public static async Task StartCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);

            if (!DataBase.CheckContainsUserId(userId))
                DataBase.AddUserId(userId);

            HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.startMessage);
        }
    }
}
