public class Program
{
    static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient(DataBase.BotToken);

        var testConnection = await botClient.GetMe();
        Console.WriteLine($"Бот запущен: {testConnection.Username}");

        HandleCommands handleCommands = new(botClient);
        Console.WriteLine("Бот запущен и ожидает сообщений...");

        Console.ReadLine();
    }
}