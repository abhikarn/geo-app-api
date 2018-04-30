using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class BranchMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public static implicit operator BranchMasterViewModel(BranchMaster branchMaster)
        {
            return new BranchMasterViewModel
            {
                Id = branchMaster.Id,
                Name = branchMaster.BranchName,
                ZoneId = branchMaster.ZoneId
            };
        }

        public static implicit operator BranchMaster(BranchMasterViewModel branchMasterViewModel)
        {
            return new BranchMaster
            {
                Id = branchMasterViewModel.Id,
                BranchName = branchMasterViewModel.Name,
                ZoneId = branchMasterViewModel.ZoneId
            };
        }

    }
}