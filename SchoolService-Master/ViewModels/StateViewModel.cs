using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class StateMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public static implicit operator StateMasterViewModel(StateMaster stateMaster)
        {
            return new StateMasterViewModel
            {
                Id = stateMaster.Id,
                Name = stateMaster.StateName
            };
        }

        public static implicit operator StateMaster(StateMasterViewModel stateMasterViewModel)
        {
            return new StateMaster
            {
                Id = stateMasterViewModel.Id,
                StateName = stateMasterViewModel.Name
            };
        }
    }
}