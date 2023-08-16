namespace GameTradeTopia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class notification
    {
        [Key]
        public int notificationsID { get; set; }

        [Required]
        public string descriptions { get; set; }
    }
}
