using System.Threading;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace KindnessDaily_bot._HelpFunc
{
    public static class HelpFunc
    {
        public static long GetUserId(Update update) => update.Message.Chat.Id;
        public static string GetMessageUserText(Update update) => update.Message?.Text;

        public static void GetInformationUserMessage(Update update)
        {
            long userId = HelpFunc.GetUserId(update);
            string userMessage = HelpFunc.GetMessageUserText(update);

            Console.WriteLine($"Принято сообщение от пользователя с Id: {userId}, с текстом: {userMessage}.");
        }

        public static async Task SendMessage(ITelegramBotClient botClient, long userId, CancellationToken cancellationToken, string message)
        {
            await botClient.SendMessage(
                chatId: userId,
                text: message,
                cancellationToken: cancellationToken);

            Console.WriteLine($"Отправлено сообщение пользователю с Id: { userId }, с текстом: { message }.");
        }

        public static async Task CreateKeyboard(KeyboardButton[] keyboardButtons, ITelegramBotClient botClient, long userId, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(keyboardButtons);
            replyKeyboard.ResizeKeyboard = true;

            await botClient.SendMessage(
                chatId: userId,
                text: "Выберите действие:",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}
