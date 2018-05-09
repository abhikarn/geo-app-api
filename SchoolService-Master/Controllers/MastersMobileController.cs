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
            List<Role> role = db.Roles.ToList();
            //List<SchoolMaster> LstShoolMaster = db.Schools.ToList();
            List<SchoolMasterViewModel> LstShoolMaster = (new SchoolMastersController().GetSchools()).ToList();
            masters.CountryMaster = db.Countries.ToList();
            masters.RoleMaster = db.Roles.ToList();
            masters.ZoneMaster = db.Zones.ToList();
            masters.BranchMaster = db.Branches.ToList();
            masters.StateMaster = db.States.ToList();
            masters.CityNewMaster = new List<CityViewModel> { new CityViewModel() };

            List<SchoolMasterMultiSelect> LstSchoolMasterMultiSelect = new List<SchoolMasterMultiSelect>();

            foreach (SchoolMasterViewModel item in LstShoolMaster)
            {
                LstSchoolMasterMultiSelect.Add(new SchoolMasterMultiSelect { name = item.SchoolName, code = item.Id });
            }
            masters.SchoolMaster = LstSchoolMasterMultiSelect;
            return masters;
        }
    }
}
