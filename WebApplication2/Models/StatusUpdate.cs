namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StatusUpdate
    {
        public int Id { get; set; }

        public string Topic { get; set; }

        public string Status { get; set; }

        public DateTime AddDate { get; set; }
    }
}
