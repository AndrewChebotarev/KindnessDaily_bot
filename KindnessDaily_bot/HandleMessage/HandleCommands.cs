using System.Threading;
using Telegram.Bot.Types;

namespace KindnessDaily_bot.HandleCommands
{
    public class HandleCommands
    {
        public HandleCommands(TelegramBotClient botClient)
        {
            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == UpdateType.MyChatMember)
                    await LockCommand.LockCommandAsync(update);
                else
                {
                    string userMessage = HelpFunc.GetMessageUserText(update);
                    HelpFunc.GetInformationUserMessage(update);

                    if (DataBase.userCommands.Contains(userMessage))
                        await ChoiceCommand(botClient, update, cancellationToken, userMessage);
                    else
                        await UnknownCommand.RemindAboutButtons(botClient, update, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!" + ex);
            }
        }

        private static async Task ChoiceCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string userMessage)
        {
            if (update.Type == UpdateType.Message && userMessage == "/start")
                await StartCommand.StartCommandAsync(botClient, update, cancellationToken);
            else if (update.Type == UpdateType.Message && userMessage == "/stop")
                await StopCommand.StopCommandAsync(botClient, update, cancellationToken);
            else if (update.Type == UpdateType.Message && userMessage == "Выполнено ✅")
                await TaskDone.TaskDoneAsync(botClient, update, cancellationToken);
            else if (update.Type == UpdateType.Message && userMessage == "")
                await TaskDone.TaskDoneAsync(botClient, update, cancellationToken);
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Ошибка API: {apiRequestException.ErrorCode}\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);

            return Task.CompletedTask;
        }
    }
}
