using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    [Table("SupervisorMaster")]
    public class SupervisorMaster
    {
        [Key]
        public int Id { get; set; }
        [Column("SupervisorName")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}