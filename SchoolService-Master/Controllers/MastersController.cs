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

        [HttpGet]
        //[Authorize]
        //[Route("webapi/Masters/{countryId}/{stateId}/{cityId}")]
        // GET: webapi/Masters
        public Masters GetMasters(int stateId)
        {
            Masters masters = new Masters();
            List<Role> role = db.Roles.ToList();
            //List<SchoolMaster> LstShoolMaster = db.Schools.ToList();
            List<SchoolMasterViewModel> LstShoolMaster = (new SchoolMastersController().GetSchools()).ToList();
            masters.CountryMaster = db.Countries.OrderBy(x => x.Name).ToList();
            masters.RoleMaster = db.Roles.OrderBy(x => x.Name).ToList();
            masters.ZoneMaster = db.Zones.OrderBy(x => x.Name).ToList();
            masters.BranchMaster = db.Branches.OrderBy(x => x.Name).ToList();
            masters.StateMaster = db.States.OrderBy(x => x.Name).ToList();
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
