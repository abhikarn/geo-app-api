using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class SupervisorMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public static implicit operator SupervisorMasterViewModel(SupervisorMaster supervisorMaster)
        {
            return new SupervisorMasterViewModel
            {
                Id = supervisorMaster.Id,
                Name = supervisorMaster.SupervisorName
            };
        }

        public static implicit operator SupervisorMaster(SupervisorMasterViewModel supervisorMasterViewModel)
        {
            return new SupervisorMaster
            {
                Id = supervisorMasterViewModel.Id,
                SupervisorName = supervisorMasterViewModel.Name
            };
        }
    }
}