using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GameTradeTopia.Models
{
    public partial class GameTradeTopia : DbContext
    {
        public GameTradeTopia()
            : base("name=GameTradeTopia")
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
