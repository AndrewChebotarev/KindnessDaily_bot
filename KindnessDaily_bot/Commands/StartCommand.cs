using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace KindnessDaily_bot.Commands
{
    public static class StartCommand
    {
        public static async Task StartCommandAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = HelpFunc.GetUserId(update);

            if (!DataBase.CheckContainsUserId(userId))
            {
                DataBase.AddUserId(userId);
                await HelpFunc.SendMessage(botClient, userId, cancellationToken, DataBase.startMessage);

                await Task.Delay(3000);

                // Создаем клавиатуру
                var replyKeyboard = new ReplyKeyboardMarkup(new[]
                {
        new[] { new KeyboardButton("Кнопка 1"), new KeyboardButton("Кнопка 2") },
        new[] { new KeyboardButton("Кнопка 3") }
    })
                {
                    ResizeKeyboard = true // Клавиатура подстраивается под размер экрана
                };

                // Отправляем сообщение с клавиатурой
                await botClient.SendTextMessageAsync(
                    chatId: userId,
                    text: "Выберите действие:",
                    replyMarkup: replyKeyboard,
                    cancellationToken: cancellationToken);

                KindnessSendingTask.StartMessageSendingTask(botClient, cancellationToken, userId);
            }
        }
    }
}
