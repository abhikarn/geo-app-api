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
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Area { get; set; }
        public string LGA { get; set; }
        public int CityId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int ZoneId { get; set; }
        [Required]
        public int CountryId { get; set; }
        public string LandMark { get; set; }
        public string GeoCoordinate { get; set; }
        public string PrincipalName { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolPhoneNumber { get; set; }
        [Required]
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
        public string Source { get; set; }
    }
}