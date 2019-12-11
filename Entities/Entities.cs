using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Entities
{
    public class User
    {
        public int UserId { get; set; }//PK
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ProjectItem> ProjectFunding { get; set; }
        public List<ProjectItem> ProjectCreations { get; set; }//8a einai null otan einai backer
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class ProjectItem
    {
        public int ProjectItemId { get; set; }//PK
        public string ProjectCode { get; set; }
        public string UserCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string PackageCode { get; set; }//na ginei lista me thn split
        public string NumberOfRequestedPackages { get; set; }//na ginei lista me thn split////////////
        public double TotalAskingFunds { get; set; }
        public double TotalReceivingFunds { get; set; }

    }

    public class Funding
    {
        public int FundingId { get; set; }//PK
        public string UserCode { get; set; }
        public string ProjectCode { get; set; }
        public string PackageCode { get; set; }
        public int NumberOfPackages { get; set; }

    }
    public class PackageItem
    {
        public int PackageItemId { get; set; }//PK
        public string PackageCode { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public string Details { get; set; }
        public string Rewards { get; set; }
    }

    public class Projects
    {
        public List<ProjectItem> ProjectList { get; set; }
    }
    public class Users
    {
        public List<User> UserList { get; set; }
    }
    public class Packages
    {
        public List<PackageItem> PackageList { get; set; }
    }
    public class Fundings
    {
        public List<Funding> FundingList { get; set; }
    }
}
