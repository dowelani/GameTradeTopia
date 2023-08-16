namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trader")]
    public partial class Trader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trader()
        {
            GameReviews = new HashSet<GameReview>();
            gameToTrades = new HashSet<gameToTrade>();
            Trades = new HashSet<Trade>();
            traderRatings = new HashSet<traderRating>();
        }

        public int traderID { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string emailAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime traderDOB { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string blacklisted { get; set; }

        [StringLength(50)]
        public string approved { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string suburb { get; set; }

        [Required]
        [StringLength(50)]
        public string streetAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string phoneNumber { get; set; }

        public string appealFeedback { get; set; }

        public string adminComments { get; set; }

        [StringLength(50)]
        public string registrationDate { get; set; }

        public byte[] idCopy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameReview> GameReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gameToTrade> gameToTrades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trade> Trades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<traderRating> traderRatings { get; set; }
    }
}
