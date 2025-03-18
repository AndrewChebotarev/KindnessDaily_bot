using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/stop" }, botClient, userId, cancellationToken);

                await Task.Delay(1000);

                KindnessSendingTask.StartMessageSendingTask(botClient, cancellationToken, userId);
            }
            else
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/stop" }, botClient, userId, cancellationToken);
        }
    }
}
