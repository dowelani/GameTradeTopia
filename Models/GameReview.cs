namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GameReview
    {
        [Key]
        public int reviewID { get; set; }

        [Column(TypeName = "date")]
        public DateTime reviewDate { get; set; }

        public string reviewComments { get; set; }

        public int gameID { get; set; }

        public int traderID { get; set; }

        public virtual Game Game { get; set; }

        public virtual Trader Trader { get; set; }
    }
}
