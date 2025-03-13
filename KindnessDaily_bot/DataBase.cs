namespace KindnessDaily_bot
{
    public class DataBase
    {
        public static List<long> usersIdList = new();

        public static string startMessage = "Здарова, епт!";

        public static void AddUserId(long userId) => usersIdList.Add(userId);
        public static void RemoveUserId(long userId) => usersIdList.Remove(userId);
        public static bool CheckContainsUserId(long userId) => usersIdList.Contains(userId);
    }
}
