namespace KindnessDaily_bot._Commands
{
    public class StopCommand
    {
        public static async Task StopCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            string stopMessage = GetStopMessageAsync().Result;

            if (!DataBase.CheckContainsUserId(userId))
            {
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken, stopMessage);
                return;
            }

            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/start" }, botClient, userId, cancellationToken, stopMessage);
            DataBase.RemoveUserId(userId);
        }

        private static async Task<string> GetStopMessageAsync()
        {
            await using TelegramBotContext dataBase = new();
            BotStopMessage? stopMessage = await dataBase.BotStopMessage.FindAsync(1);

            return stopMessage?.StopMessage ?? "Задача не установлена!";
        }
    }
}
