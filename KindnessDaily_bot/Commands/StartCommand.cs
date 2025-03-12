namespace KindnessDaily_bot.Commands
{
    public class StartCommand
    {
        public static async Task StartCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendMessage(
                chatId: update.Message.Chat.Id,
                text: "Привет! Я ваш новый бот. Я просто буду вас подъебывать!",
                cancellationToken: cancellationToken);
        }
    }
}
