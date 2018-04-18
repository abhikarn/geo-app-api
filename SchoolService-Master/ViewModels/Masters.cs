using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolService_Master.ViewModels
{
    public class Masters
    {
        public IList<CountryMasterViewModel> CountryMaster { get; set; }
        public IList<ZoneMasterViewModel> ZoneMaster { get; set; }
        public IList<BranchMasterViewModel> BranchMaster { get; set; }
        public IList<StateMasterViewModel> StateMaster { get; set; }
        public IList<SupervisorMasterViewModel> SupervisorMaster { get; set; }
        public IList<CityViewModel> CityNewMaster { get; set; }
        public IList<RoleMasterViewModel> RoleMaster { get; set; }
        public IList<SchoolMasterMultiSelect> SchoolMaster { get; set; }
    }
}