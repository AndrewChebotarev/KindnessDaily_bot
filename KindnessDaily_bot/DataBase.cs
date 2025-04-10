using Telegram.Bot.Types.ReplyMarkups;

namespace KindnessDaily_bot
{
    public class DataBase
    {
        public static readonly string BotToken = "7036590643:AAH7O_qMcgP0_9ZoAGQbyLHh_3aGl3_3lg4";

        public static List<long> usersIdList = new();

        public static string startMessage = "С этого момента ты будешь получать добрые повседневные задачи каждый день, которые помогут сделать мир вокруг тебя лучше! 🌍✨ Эти задания — не просто рутина, а настоящие квесты, которые наполнят твою жизнь смыслом и радостью.\r\n\r\nКаждая выполненная задача — это шаг к улучшению окружающего мира и к твоему личному росту! 💪💕 А чтобы ты мог отслеживать свои успехи, у тебя будет возможность смотреть статистику своих выполненных дел. Так ты сможешь видеть, как твои усилия меняют мир к лучшему! 📈🌈\r\n\r\nГотов принять вызов? Давай сделаем этот мир ярче вместе! 💖🚀 Не упусти шанс стать героем своего дня!";
        public static string stopMessage = "Пока, епта!";
        public static string kindnessTask = "Задачка на сегодня: пивко 0.5!";
        public static string unknownMessage = "Я тебя не понимаю(";
        public static string taskDoneMessage = "Умничка моя, ну просто заячка!";
        public static List<string> userCommands = new() { "/start", "/stop", "Выполнено ✅" };


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
