using KeywordTag.Database.SQLServer.SeedDatabase;
using KeywordTag.Database.SQLServer.Tables;
using KeywordTag.Database.SQLServer.Views;
using Microsoft.EntityFrameworkCore;

namespace KeywordTag.Database.SQLServer.Contexts
{
    public class KeywordTagContext : DbContext
    {
        // Tables
        public DbSet<Checkin> Checkins { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // Views
        public DbSet<TopKeywordIdView> TopKeywordIdView { get; set; }

        //public KeywordTagContext(DbContextOptions<KeywordTagContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=HOME-PC;User Id=keywordtag;Password=123456a@;Database=KeywordTagDB;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("kt");
            base.OnModelCreating(modelBuilder);

            var seedMessage = new SeedMessage();
            modelBuilder.Entity<Message>().HasData(seedMessage.messages);

            // Views
            //var topKeywordIdViewQuery = File.ReadAllText("SeedDatabase/Views/TopKeywordViewId.sql");
            modelBuilder.Entity<TopKeywordIdView>(c => {
                c.HasNoKey();
                c.ToView("TopKeywordIdView", "kt");
                //c.ToSqlQuery(topKeywordIdViewQuery);
            });
            // End views

        }
    }
}
