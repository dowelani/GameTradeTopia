namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gameToTrade")]
    public partial class gameToTrade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gameToTrade()
        {
            Trades = new HashSet<Trade>();
        }

        public int gameToTradeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateUploaded { get; set; }

        public int gameID { get; set; }

        public int traderID { get; set; }

        public virtual Game Game { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trade> Trades { get; set; }

        public virtual Trader Trader { get; set; }
    }
}
