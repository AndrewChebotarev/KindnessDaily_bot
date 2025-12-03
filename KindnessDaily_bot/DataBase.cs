namespace KindnessDaily_bot
{
    public class DataBase
    {
        public static readonly string BotToken = "7036590643:AAEUbT7mq3kqeuwsUorYgnVdeIGWUuJcd20";

        public static List<long> usersIdList = new();

        private static int taskDone = 2;
        private static int taskLose = 1;

        public static string unknownMessage = "Я тебя не понимаю(";
        public static string taskDoneMessage = "Умничка моя, ну просто заячка!";
        public static string taskSkipMessage = "Ну ничего! В след. раз сможешь!";
        public static string statisticsMessage = $"Твоя статистика! \n\n ✅ Выполнено - {taskDone.ToString()} \n\n  ❌ Пропущено - {taskLose.ToString()} \n";
        public static List<string> userCommands = new() { "/start", "/stop", "Выполнено ✅", "Пропустить ❌", "Статистика 📊" };

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
