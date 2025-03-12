public class Program
{
    private static readonly string BotToken = "7036590643:AAH7O_qMcgP0_9ZoAGQbyLHh_3aGl3_3lg4"; // Замените на ваш токен
    private static List<long> _chatId = new(); // ID чата, куда будут отправляться сообщения

    static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient(BotToken);

        // Проверка подключения
        var me = await botClient.GetMe();
        Console.WriteLine($"Бот запущен: {me.Username}");

        // Обработчик команды /start
        botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

        Console.WriteLine("Бот запущен и ожидает сообщений...");

        // Запуск фоновой задачи для отправки сообщений каждую секунду
        StartMessageSendingTask(botClient);

        Console.ReadLine(); // Чтобы приложение не завершалось сразу
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Сохраняем ID чата при команде /start
        if (update.Type == UpdateType.Message && update.Message?.Text == "/start")
        {
            if (!_chatId.Contains(update.Message.Chat.Id))
                _chatId.Add(update.Message.Chat.Id);

            await botClient.SendMessage(
                chatId: update.Message.Chat.Id,
                text: "Привет! Я ваш новый бот. Я просто буду вас подъебывать!",
                cancellationToken: cancellationToken);
        }

        // Сохраняем ID чата при команде /start
        if (update.Type == UpdateType.Message && update.Message?.Text == "/stop")
        {
            if (!_chatId.Contains(update.Message.Chat.Id))
                return;

            _chatId.Remove(update.Message.Chat.Id);

            await botClient.SendMessage(
                chatId: update.Message.Chat.Id,
                text: "Соси!",
                cancellationToken: cancellationToken);
        }
    }

    private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // Обработка ошибок
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Ошибка API: {apiRequestException.ErrorCode}\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }

    private static void StartMessageSendingTask(ITelegramBotClient botClient)
    {
        Task.Run(async () =>
        {
            while (true)
            {
                foreach (var t in _chatId)
                {
                    try
                    {
                        await botClient.SendMessage(
                            chatId: t,
                            text: $"Санек, сосал?",
                            cancellationToken: CancellationToken.None);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при отправке сообщения: {ex.Message}");
                    }
                }

                await Task.Delay(1000); // Задержка в 1 секунду
            }
        });
    }
}