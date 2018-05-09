using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class Masters
    {
        public IList<CountryMaster> CountryMaster { get; set; }
        public IList<ZoneMaster> ZoneMaster { get; set; }
        public IList<BranchMaster> BranchMaster { get; set; }
        public IList<StateMaster> StateMaster { get; set; }
        public IList<SupervisorMaster> SupervisorMaster { get; set; }
        public IList<CityViewModel> CityNewMaster { get; set; }
        public IList<Role> RoleMaster { get; set; }
        public IList<SchoolMasterMultiSelect> SchoolMaster { get; set; }
    }
}