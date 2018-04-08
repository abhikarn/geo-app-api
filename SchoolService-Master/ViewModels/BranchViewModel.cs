using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolService_Master.ViewModels
{
    public class BranchMasterViewModel
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}