using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolService_Master.Models
{
    public class SchoolMaster
    {
        [Key]
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string LGA { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string LandMark { get; set; }
        public string GeoCoordinate { get; set; }
        public string PrincipalName { get; set; }
        public int PhoneNumber { get; set; }
        public int SchoolPhoneNumber { get; set; }
        public string SchoolType { get; set; }
        public int TotalPopulation { get; set; }
        public string TotalEducationlevel { get; set; }
        public int NursaryToPrimary3Population { get; set; }
        public bool PrincipalConcent { get; set; }
        public bool SingageAvailable { get; set; }
        public string SignageStatus { get; set; }
        public string IfBad { get; set; }
        public string ClassRoomCorex { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}