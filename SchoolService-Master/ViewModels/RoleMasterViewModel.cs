using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class RoleMasterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? RoleType { get; set; }

        public int? RoleStatusId { get; set; }

        public bool IsActive { get; set; }

        public static implicit operator RoleMasterViewModel(Role role)
        {
            return new RoleMasterViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static implicit operator Role(RoleMasterViewModel roleMasterViewModel)
        {
            return new Role
            {
                Id = roleMasterViewModel.Id,
                Name = roleMasterViewModel.Name
            };
        }
    }
}