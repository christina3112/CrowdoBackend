using System;
using System.Collections.Generic;
using System.Text;

namespace CreateData.DTO
{
    public class UserDTO
    {
        public string UserCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
    public class ProjectDTO
    {
        public string ProjectCode { get; set; }
        public string UserCode { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public string PackageCode { get; set; }
        public string NumberOfRequestedPackages { get; set; }//////////////////htan string
    }
    public class FundingDTO
    {
        public string UserCode { get; set; }
        public string ProjectCode { get; set; }
        public string PackageCode { get; set; }
        public double NumberOfPackages { get; set; }
    }
    public class PackageDTO
    {
        public string PackageCode { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Rewards { get; set; }
        public double Cost { get; set; }
    }
}
