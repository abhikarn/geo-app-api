using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolService_Master.Models;
using SchoolService_Master.Provider;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    [ClientIdAuthorizationProvider]
    public class MastersMobileController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        [HttpGet]
        //[Route("webapi/Masters/{countryId}/{stateId}/{cityId}")]
        // GET: webapi/Masters
        public Masters GetMasters(int countryId, int stateId, int cityId)
        {
            Masters masters = new Masters();
            List<CountryMaster> countryMaster = db.Countries.ToList();
            //List<ZoneMaster> zoneMaster= db.Zones.ToList();
            //List<BranchMaster> branchMaster = db.Branches.ToList();
            List<StateMaster> stateMaster = db.States.ToList();
            //List<SupervisorMaster> supervisorMaster = db.Supervisors.ToList();
            //List<CityMaster> cityMaster= db.City.ToList();
            List<Role> role = db.Roles.ToList();
            //List<SchoolMaster> LstShoolMaster = db.Schools.ToList();
            List<SchoolMaster> LstShoolMaster = (new SchoolMastersController().GetSchools(countryId, stateId, cityId)).OrderBy(x => x.SchoolName).ToList();
            masters.CountryMaster = countryMaster.Select<CountryMaster, CountryMasterViewModel>(x => x).OrderBy(x => x.Name).ToList();
            masters.RoleMaster = role.Select<Role, RoleMasterViewModel>(x => x).OrderBy(x => x.Name).ToList();
            //masters.ZoneMaster = zoneMaster.Select<ZoneMaster, ZoneMasterViewModel>(x => x).ToList();
            //masters.BranchMaster = branchMaster.Select<BranchMaster, BranchMasterViewModel>(x => x).ToList();
            masters.StateMaster = stateMaster.Select<StateMaster, StateMasterViewModel>(x => x).OrderBy(x => x.Name).ToList();
            //masters.SupervisorMaster = supervisorMaster.Select<SupervisorMaster, SupervisorMasterViewModel>(x => x).ToList();
            //masters.CityNewMaster = cityMaster.Select<CityMaster, CityViewModel>(x => x).ToList();

            masters.ZoneMaster = new List<ZoneMasterViewModel> { new ZoneMasterViewModel() };
            masters.BranchMaster = new List<BranchMasterViewModel> { new BranchMasterViewModel() };
            masters.SupervisorMaster = new List<SupervisorMasterViewModel> { new SupervisorMasterViewModel() };
            masters.CityNewMaster = new List<CityViewModel> { new CityViewModel() };

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
