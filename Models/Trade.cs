namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trade")]
    public partial class Trade
    {
        public int tradeID { get; set; }

        public TimeSpan startTime { get; set; }

        public TimeSpan finishTime { get; set; }

        public int numOfTrades { get; set; }

        [Required]
        [StringLength(50)]
        public string active { get; set; }

        [Required]
        [StringLength(50)]
        public string tradeFufilled { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        public int traderID { get; set; }

        public int gameToTradeID { get; set; }

        public virtual gameToTrade gameToTrade { get; set; }

        public virtual Trader Trader { get; set; }
    }
}
