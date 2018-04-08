using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolService_Master.ViewModels
{
    public class StateMasterViewModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}