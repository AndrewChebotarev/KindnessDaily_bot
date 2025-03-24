using Telegram.Bot.Types.ReplyMarkups;

namespace KindnessDaily_bot.Commands
{
    public static class StopCommand
    {
        public static async Task StopCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);

            if (!DataBase.CheckContainsUserId(userId))
            {
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken, DataBase.stopMessage);
                return;
            }

            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken, DataBase.stopMessage);
            DataBase.RemoveUserId(userId);
        }
    }
}
