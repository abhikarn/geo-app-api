using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    [Table("StateMaster")]
    public class StateMaster
    {
        [Key]
        public int Id { get; set; }
        [Column("StateName")]
        public string Name { get; set; }
        public int BranchId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}