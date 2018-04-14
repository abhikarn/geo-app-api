using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Role")]
    public class Role
    {

        [Key]
        [Column("RoleId")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? RoleType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? RoleStatusId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
    }
}