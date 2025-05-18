namespace KindnessDaily_bot.Commands
{
    public class StatisticsCommand
    {
        public static async Task StatisticsCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "Выполнено ✅", "Пропустить ❌", "Статистика 📊" }, botClient, userId, cancellationToken, DataBase.statisticsMessage);
        }
    }
}
