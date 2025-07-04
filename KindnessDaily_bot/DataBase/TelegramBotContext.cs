﻿namespace KindnessDaily_bot._DataBase
{
    public class TelegramBotContext : DbContext
    {
        public DbSet<BotTasks> Tasks { get; set; }
        public DbSet<BotStartMessage> BotStartMessage { get; set; }
        public DbSet<BotStopMessage> BotStopMessage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql
            ("Host=localhost;Port=5432;Database=kindness_bot_db;Username=postgres;Password=andrew19991");
    }
}
