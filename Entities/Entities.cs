using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<ProjectItem> ProjectCreations { get; set; }//8a einai null otan einai backer
        public List<Funding> ProjectFunding { get; set; } // mporoume kai apla ena funding anti gia lista?// ta projects pou ginontai fund. tha pigainei diladi kai tha ftiahnei ena fund sto pinaka fundings
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

    }
    

    public class ProjectItem
    {
        public int ProjectItemId { get; set; }//PK
        public string ProjectCode { get; set; }
        public string UserCode { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public string PackageCode { get; set; } // o pinakas me ta packages tou excel, osa diladi pairnei to kathe projects
        public string NumberOfRequestedPackages { get; set; } // osa packages pairnei to kathe project
        public string Description { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; } // to user pou tha einai eite backer eite creator(pou mporei na nai kai backer)

        
        public double TotalAskingFunds { get; set; }
       
        public double TotalReceivingFunds { get; set; }
        public List<PackageItemAsking> PackagesAsking { get; set; }
        public List<PackageItemReceived> PackagesReceived { get; set; }

    }

    
    public class Funding
    {
        public int FundingId { get; set; }//PK
        public string UserCode { get; set; }
        public string ProjectCode { get; set; }
        public string PackageCode { get; set; }
        public int NumberOfPackages { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? ProjectItemId { get; set; }//FK
        public ProjectItem ProjectItem { get; set; }


    }
    public class PackageItemAsking
    {
        public int PackageItemAskingId { get; set; }//PK
        public string PackageCode { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public string Details { get; set; }
        public string Rewards { get; set; }
    }
    public class PackageItemReceived
    {
        public int PackageItemReceivedId { get; set; }//PK
        public int? PackageItemAskingId { get; set; }//FK
        public PackageItemAsking PackageItemAsking { get; set; }
        public int? ProjectItemId { get; set; }//FK
        public ProjectItem ProjectItem { get; set; }
        public int? UserId { get; set; }//FK
        public User User { get; set; }
        private DateTime date;
        public DateTime DateReceived { get { return date; } set { date = DateTime.Now; } }
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
        public List<PackageItemAsking> PackageAskingList { get; set; }
        public List<PackageItemReceived> PackageReceivedList { get; set; }
    }
    public class Fundings
    {
        public List<Funding> FundingList { get; set; }
    }
}
