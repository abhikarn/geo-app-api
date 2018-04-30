using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class CityMaster
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}