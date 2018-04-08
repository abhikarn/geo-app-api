using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class StateMaster
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}