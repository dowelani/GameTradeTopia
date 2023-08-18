namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class traderRating
    {
        [Key]
        public int traderRatingsID { get; set; }

        public int traderStars { get; set; }

        public string traderComments { get; set; }

        public int traderID { get; set; }

        public int numOfRaters { get; set; }

        public int sumOfRates { get; set; }

        public virtual Trader Trader { get; set; }
    }
}
