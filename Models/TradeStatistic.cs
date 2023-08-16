namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TradeStatistic
    {
        [Key]
        public int tradeStatisticsID { get; set; }

        [Required]
        [StringLength(50)]
        public string activeTrades { get; set; }

        public int numOfPendingRequests { get; set; }

        public int numOfRequestsReceived { get; set; }

        public int totalTradesCompleted { get; set; }
    }
}
