using Telegram.Bot.Types.ReplyMarkups;

namespace KindnessDaily_bot
{
    public class DataBase
    {
        public static readonly string BotToken = "7036590643:AAH7O_qMcgP0_9ZoAGQbyLHh_3aGl3_3lg4";

        public static List<long> usersIdList = new();

        public static string startMessage = "Здарова, епт!";
        public static string stopMessage = "Пока, епта!";
        public static string kindnessTask = "Задачка, пососи!";
        public static string unknownMessage = "Выбери кнопку!";
        public static List<string> userCommands = new() { "/start", "/stop" };

        public static void AddUserId(long userId)
        {
            usersIdList.Add(userId);
            Console.WriteLine($"Добавлен новый пользователь с Id: {userId}.");
        }
        public static void RemoveUserId(long userId)
        {
            usersIdList.Remove(userId);
            Console.WriteLine($"Удален пользователь с Id: {userId}.");
        }

        public static bool CheckContainsUserId(long userId) => usersIdList.Contains(userId);
    }
}
