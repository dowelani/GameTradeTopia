namespace GameTradeTopia.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Administration> Administrations { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameReview> GameReviews { get; set; }
        public virtual DbSet<gameToTrade> gameToTrades { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }
        public virtual DbSet<Trader> Traders { get; set; }
        public virtual DbSet<traderRating> traderRatings { get; set; }
        public virtual DbSet<TradeStatistic> TradeStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<gameToTrade>()
                .HasMany(e => e.Trades)
                .WithRequired(e => e.gameToTrade)
                .WillCascadeOnDelete(false);
        }
    }
}
