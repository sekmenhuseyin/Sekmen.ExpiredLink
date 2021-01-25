using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sekmen.ExpiredLink.Database.Entity
{
    [Table("Links")]
    public class LinksTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Link { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
