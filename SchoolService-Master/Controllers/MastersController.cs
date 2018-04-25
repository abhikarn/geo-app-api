using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolService_Master.Models;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    public class MastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();
        // GET: webapi/Masters
        public Masters GetMasters(int countryId, int stateId, int cityId)
        {
            Masters masters = new Masters();
            List<CountryMaster> countryMaster = db.Countries.ToList();
            List<ZoneMaster> zoneMaster = db.Zones.ToList();
            List<BranchMaster> branchMaster = db.Branches.ToList();
            List<StateMaster> stateMaster = db.States.ToList();
            List<SupervisorMaster> supervisorMaster = db.Supervisors.ToList();
            List<CityMaster> cityMaster = db.City.ToList();
            List<Role> role = db.Roles.ToList();
            //List<SchoolMaster> LstShoolMaster = db.Schools.ToList();
            List<SchoolMaster> LstShoolMaster = (new SchoolMastersController().GetSchools(countryId, stateId, cityId)).ToList();
            masters.CountryMaster = countryMaster.Select<CountryMaster, CountryMasterViewModel>(x => x).ToList();
            masters.ZoneMaster = zoneMaster.Select<ZoneMaster, ZoneMasterViewModel>(x => x).ToList();
            masters.BranchMaster = branchMaster.Select<BranchMaster, BranchMasterViewModel>(x => x).ToList();
            masters.StateMaster = stateMaster.Select<StateMaster, StateMasterViewModel>(x => x).ToList();
            masters.SupervisorMaster = supervisorMaster.Select<SupervisorMaster, SupervisorMasterViewModel>(x => x).ToList();
            masters.CityNewMaster = cityMaster.Select<CityMaster, CityViewModel>(x => x).ToList();
            masters.RoleMaster = role.Select<Role, RoleMasterViewModel>(x => x).ToList();
            List<SchoolMasterViewModel> LstSchoolMasterViewModel = new List<SchoolMasterViewModel>();
            List<SchoolMasterMultiSelect> LstSchoolMasterMultiSelect = new List<SchoolMasterMultiSelect>();
            foreach (SchoolMaster item in LstShoolMaster)
            {
                LstSchoolMasterViewModel.Add(new SchoolMasterViewModel { Name = item.SchoolName, Id = item.Id, Code = string.Empty });
            }
            foreach (SchoolMasterViewModel item in LstSchoolMasterViewModel)
            {
                LstSchoolMasterMultiSelect.Add(new SchoolMasterMultiSelect { Label = item.Name, Value = item });
            }
            masters.SchoolMaster = LstSchoolMasterMultiSelect;
            return masters;
        }
    }
}
