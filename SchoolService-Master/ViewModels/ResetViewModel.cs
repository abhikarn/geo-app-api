using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolService_Master.ViewModels
{
    public class ResetViewModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}