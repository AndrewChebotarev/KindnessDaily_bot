using System.Threading;
using Telegram.Bot.Types;

namespace KindnessDaily_bot._HelpFunc
{
    public static class HelpFunc
    {
        public static long GetUserId(Update update) => update.Message.Chat.Id;

        public static async void SendMessage(ITelegramBotClient botClient, long userId, CancellationToken cancellationToken, string message)
        {
            await botClient.SendMessage(
                chatId: userId,
                text: message,
                cancellationToken: cancellationToken);
        }
    }
}
