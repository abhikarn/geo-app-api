using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string UserPassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string authToken { get; set; }

        public static implicit operator UserViewModel(Users user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                EmailId = user.EmailId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CityId = user.CityId,
                StateId = user.StateId,
                CountryId = user.CountryId,
                RoleId = user.RoleId,
            };
        }

        public static implicit operator Users(UserViewModel userViewModel)
        {
            return new Users
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                UserPassword = userViewModel.UserPassword,
                EmailId = userViewModel.EmailId,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                CityId = userViewModel.CityId,
                StateId = userViewModel.StateId,
                CountryId = userViewModel.CountryId,
                RoleId = userViewModel.RoleId,
            };
        }
    }
}