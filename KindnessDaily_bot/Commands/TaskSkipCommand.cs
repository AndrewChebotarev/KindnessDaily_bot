namespace KindnessDaily_bot._Commands
{
    public class TaskSkipCommand
    {
        public static async Task TaskSkipCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "В следущий раз!" }, botClient, userId, cancellationToken, DataBase.taskSkipMessage);
        }
    }
}
