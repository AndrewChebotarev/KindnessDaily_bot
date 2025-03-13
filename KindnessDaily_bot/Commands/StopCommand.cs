namespace KindnessDaily_bot.Commands
{
    public static class StopCommand
    {
        public static async Task StopCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (!DataBase.usersIdList.Contains(update.Message.Chat.Id))
                return;

            DataBase.usersIdList.Remove(update.Message.Chat.Id);

            await botClient.SendMessage(
                chatId: update.Message.Chat.Id,
                text: "Соси!",
                cancellationToken: cancellationToken);
        }
    }
}
