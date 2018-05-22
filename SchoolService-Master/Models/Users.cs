using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class Users
    {

        /// <summary>
        /// 
        /// </summary>
        [Key]
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
        [StringLength(100)]
        [Index(IsUnique = true)]
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
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
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

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int ZoneId { get; set; }
        public int BranchId { get; set; }
        public bool NotFirstLogin { get; set; }
    }
}