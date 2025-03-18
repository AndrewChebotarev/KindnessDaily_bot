using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace KindnessDaily_bot.Commands
{
    public static class UnknownCommand
    {
        public static async Task RemindAboutButtons(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.unknownMessage);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken);
        }
    }
}
