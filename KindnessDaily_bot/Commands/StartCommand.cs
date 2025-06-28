namespace KindnessDaily_bot._Commands
{
    public class StartCommand
    {
        public static async Task StartCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            string startMessage = GetStartMessageAsync().Result;

            if (!DataBase.CheckContainsUserId(userId))
            {
                DataBase.AddUserId(userId);
                await HelpFunc.SendMessage(botClient, userId, cancellationToken, startMessage);

                await Task.Delay(2000);

                KindnessSendingTask.StartMessageSendingTask(botClient, cancellationToken, userId);
            }
            else
                await HelpFunc.CreateKeyboard(new KeyboardButton[] { "/stop" }, botClient, userId, cancellationToken, startMessage);
        }

        private static async Task<string> GetStartMessageAsync()
        {
            await using TelegramBotContext dataBase = new();
            BotStartMessage? task = await dataBase.BotStartMessage.FindAsync(1);

            return task?.StartMessage ?? "Ошибка при старте работы с ботом!";
        }
    }
}
