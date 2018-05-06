using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolService_Master.Models;

namespace SchoolService_Master.ViewModels
{
    public class SchoolMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string LGA { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string LandMark { get; set; }
        public string GeoCoordinate { get; set; }
        public string PrincipalName { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolPhoneNumber { get; set; }
        public string SchoolType { get; set; }
        public string TotalPopulation { get; set; }
        public string TotalEducationlevel { get; set; }
        public string NursaryToPrimary3Population { get; set; }
        public bool PrincipalConcent { get; set; }
        public bool SingageAvailable { get; set; }
        public string SignageStatus { get; set; }
        public string IfBad { get; set; }
        public string ClassRoomCorex { get; set; }
        public byte[] SchoolImage { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Code { get; set; }

        public static implicit operator SchoolMasterViewModel(SchoolMaster schoolMaster)
        {
            return new SchoolMasterViewModel
            {
                Id = schoolMaster.Id,
                Name = schoolMaster.SchoolName,
                HouseNumber = schoolMaster.Street,
                Street = schoolMaster.SchoolName,
                Area = schoolMaster.Area,
                LGA = schoolMaster.LGA,
                CityId = schoolMaster.CityId,
                StateId = schoolMaster.StateId,
                CountryId = schoolMaster.CountryId,
                LandMark = schoolMaster.LandMark,
                GeoCoordinate = schoolMaster.GeoCoordinate,
                PrincipalName = schoolMaster.PrincipalName,
                PhoneNumber = schoolMaster.PhoneNumber,
                SchoolPhoneNumber = schoolMaster.SchoolPhoneNumber,
                SchoolType = schoolMaster.SchoolType,
                TotalPopulation = schoolMaster.TotalPopulation,
                TotalEducationlevel = schoolMaster.TotalEducationlevel,
                NursaryToPrimary3Population = schoolMaster.NursaryToPrimary3Population,
                PrincipalConcent = schoolMaster.PrincipalConcent,
                SingageAvailable = schoolMaster.SingageAvailable,
                SignageStatus = schoolMaster.SignageStatus,
                IfBad = schoolMaster.IfBad,
                ClassRoomCorex = schoolMaster.ClassRoomCorex,
                SchoolImage = schoolMaster.SchoolImage,
                Code = string.Empty
            };
        }

        public static implicit operator SchoolMaster(SchoolMasterViewModel schoolMasterViewModel)
        {
            return new SchoolMaster
            {
                Id = schoolMasterViewModel.Id,
                SchoolName = schoolMasterViewModel.Name,
                HouseNumber = schoolMasterViewModel.Street,
                Street = schoolMasterViewModel.Street,
                Area = schoolMasterViewModel.Area,
                LGA = schoolMasterViewModel.LGA,
                CityId = schoolMasterViewModel.CityId,
                StateId = schoolMasterViewModel.StateId,
                CountryId = schoolMasterViewModel.CountryId,
                LandMark = schoolMasterViewModel.LandMark,
                GeoCoordinate = schoolMasterViewModel.GeoCoordinate,
                PrincipalName = schoolMasterViewModel.PrincipalName,
                PhoneNumber = schoolMasterViewModel.PhoneNumber,
                SchoolPhoneNumber = schoolMasterViewModel.SchoolPhoneNumber,
                SchoolType = schoolMasterViewModel.SchoolType,
                TotalPopulation = schoolMasterViewModel.TotalPopulation,
                TotalEducationlevel = schoolMasterViewModel.TotalEducationlevel,
                NursaryToPrimary3Population = schoolMasterViewModel.NursaryToPrimary3Population,
                PrincipalConcent = schoolMasterViewModel.PrincipalConcent,
                SingageAvailable = schoolMasterViewModel.SingageAvailable,
                SignageStatus = schoolMasterViewModel.SignageStatus,
                IfBad = schoolMasterViewModel.IfBad,
                ClassRoomCorex = schoolMasterViewModel.ClassRoomCorex,
                SchoolImage = schoolMasterViewModel.SchoolImage
            };
        }
    }
}