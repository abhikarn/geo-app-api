using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolService_Master.ViewModels
{
    public class UserViewModel
    {
        //[Column("UserId")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Column(TypeName = "VARCHAR")]
        public string EmailId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> LastLoginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}