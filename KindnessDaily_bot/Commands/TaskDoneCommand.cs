namespace KindnessDaily_bot._Commands
{
    public class TaskDoneCommand
    {
        public static async Task TaskDoneCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "Я умничка!" }, botClient, userId, cancellationToken, DataBase.taskDoneMessage);
        }
    }
}
