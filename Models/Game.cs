namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            GameReviews = new HashSet<GameReview>();
            gameToTrades = new HashSet<gameToTrade>();
        }

        public int gameID { get; set; }

        [Display(Name = "Name of game")]
        [Required]
        [StringLength(50)]
        public string gameName { get; set; }

        [Display(Name = "Age Rating")]
        public int ageRating { get; set; }

        [Display(Name = "Theme")]
        [StringLength(50)]
        public string theme { get; set; }

        [Required]
        [Display(Name = "Game Type")]
        [StringLength(50)]
        public string gameType { get; set; }

        [Required]
        [Display(Name = "Year Published")]
        [StringLength(50)]
        public string yearPublished { get; set; }

        [Display(Name = "Select Image")]
        public byte[] image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameReview> GameReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gameToTrade> gameToTrades { get; set; }
    }
}
