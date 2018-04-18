using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class CountryMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public static implicit operator CountryMasterViewModel(CountryMaster countryMaster)
        {
            return new CountryMasterViewModel
            {
                Id = countryMaster.Id,
                Name = countryMaster.CountryrName
            };
        }

        public static implicit operator CountryMaster(CountryMasterViewModel countryMasterViewModel)
        {
            return new CountryMaster
            {
                Id = countryMasterViewModel.Id,
                CountryrName = countryMasterViewModel.Name
            };
        }
    }
}