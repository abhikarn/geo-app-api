using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    [Table("ZoneMaster")]
    public class ZoneMaster
    {
        [Key]
        public int Id { get; set; }
        [Column("ZoneName")]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}