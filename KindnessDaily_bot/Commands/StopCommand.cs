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
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken);
                return;
            }

            await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.stopMessage);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken);

            DataBase.RemoveUserId(userId);
        }
    }
}
