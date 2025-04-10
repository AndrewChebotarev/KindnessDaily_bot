namespace KindnessDaily_bot.Commands
{
    public static class TaskDone
    {
        public static async Task TaskDoneAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);
            await HelpFunc.CreateKeyboard(new KeyboardButton[] { "Я умничка!" }, botClient, userId, cancellationToken, DataBase.taskDoneMessage);
        }
    }
}
