namespace KindnessDaily_bot.Commands
{
    public class UnknownCommand
    {
        public static async Task RemindAboutButtons(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.unknownMessage);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "Выполнено ✅", "Пропустить ❌", "Статистика 📊" }, botClient, userId, cancellationToken, DataBase.kindnessTask);
        }
    }
}
