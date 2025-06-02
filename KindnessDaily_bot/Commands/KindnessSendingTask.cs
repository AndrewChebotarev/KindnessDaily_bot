using KindnessDaily_bot._DataBase;

namespace KindnessDaily_bot._Commands
{
    public class KindnessSendingTask
    {
        public static async Task StartMessageSendingTask(ITelegramBotClient botClient, CancellationToken cancellationToken, long userId)
        {
            while (true)
            {
                try
                {
                    if (!DataBase.usersIdList.Contains(userId))
                        return;

                    string task = GetTasksAsync().Result;

                    await HelpFunc.CreateKeyboard(new KeyboardButton[] { "Выполнено ✅", "Пропустить ❌", "Статистика 📊" }, botClient, userId, cancellationToken, task);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при отправке сообщения: {ex.Message}");
                }

                await Task.Delay(5000);
            }
        }

        private static async Task<string> GetTasksAsync()
        {
            await using TelegramBotContext dataBase = new();
            BotTasks? task = await dataBase.Tasks.FindAsync(1);

            return task?.Task ?? "Задача не установлена!";
        }
    }
}
