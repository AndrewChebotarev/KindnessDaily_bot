namespace KindnessDaily_bot._Commands
{
    public class UnknownCommand
    {
        public static async Task RemindAboutButtons(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            string task = GetTasksAsync().Result;

            await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.unknownMessage);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "Выполнено ✅", "Пропустить ❌", "Статистика 📊" }, botClient, userId, cancellationToken, task);
        }

        private static async Task<string> GetTasksAsync()
        {
            await using TelegramBotContext dataBase = new();
            BotTasks? task = await dataBase.Tasks.FindAsync(1);

            return task?.Task ?? "Задача не установлена!";
        }
    }
}
