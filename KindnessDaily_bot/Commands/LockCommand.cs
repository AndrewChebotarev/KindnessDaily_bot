namespace KindnessDaily_bot.Commands
{
    public class LockCommand
    {
        public static async Task LockCommandAsync(Update update)
        {
            ChatMemberUpdated? chatMember = update.MyChatMember;

            if (chatMember?.NewChatMember.Status == ChatMemberStatus.Kicked)
            {
                long userId = chatMember.Chat.Id;
                DataBase.RemoveUserId(userId);

                Console.WriteLine($"Пользователь {userId} заблокировал бота.");
            }
        }
    }
}
