
using CreateData.DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectApp.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectApp.Services
{
    public class Data
    {
        //////////////////////// APO EDW NA TA VALOUME SE ALLO ARXEIO ST FAKELO DATABASE///////////////////////
        public IEnumerable<ProjectItem> GetDataProject()
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\projects.json";
            Projects projects = new Projects();
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // diavazw to json arheio kai vazw mesa 
                projects.ProjectList = JsonConvert.DeserializeObject<List<ProjectItem>>(json);
            }
            return projects.ProjectList;
        }
        public IEnumerable<User> GetDataUser()
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\users.json";
            Users users = new Users();
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd();
                users.UserList = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return users.UserList;
        }
        public IEnumerable<Funding> GetDataFunding()
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\fundings.json";
            Fundings fundings = new Fundings(); //
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                fundings.FundingList = JsonConvert.DeserializeObject<List<Funding>>(json); // 
            }
            return fundings.FundingList; // 
        }
        public IEnumerable<PackageItemAsking> GetDataPackage() // 
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\packages.json";
            Packages packages = new Packages(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                packages.PackageAskingList = JsonConvert.DeserializeObject<List<PackageItemAsking>>(json); // 
            }
            return packages.PackageAskingList; // 
        }
        ////////////////////////////////////////////////////////////////////////////////

        public string LoadProjectsToDB() // FORTWNOUME STH VASH TO KATHE ENTITY KAI EXOUME MIA LOAD GIA KATHE PINAKA
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\projects.json";
            Projects projects = new Projects(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // diavazw to json arheio kai vazw mesa 
                projects.ProjectList = JsonConvert.DeserializeObject<List<ProjectItem>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                projects.ProjectList.ForEach(project =>
                {

                    string usercode = project.UserCode;
                    User user = db.Users.Where(u => u.UserCode.Equals(usercode)).First();
                    if (user != null)
                    {
                        project.User = user;
                        db.Projects.Add(project);
                    }

                });

                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }
        public string LoadPackageItemAskingToDB()
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\packages.json";
            Packages packages = new Packages(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                packages.PackageAskingList = JsonConvert.DeserializeObject<List<PackageItemAsking>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                db.PackagesAsking.AddRange(packages.PackageAskingList);
                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }
        public string LoadPackageItemReceivedToDB()
        {
            Packages packages = new Packages();
            using (var db = new CrowDoDB())
            {
                packages.PackageReceivedList.ForEach(pack =>
                {
                    int? projectid = pack.ProjectItemId;
                    ProjectItem project = db.Projects.Where(p => p.ProjectItemId.Equals(projectid)).First();
                    if (project != null)
                    {
                        pack.ProjectItem = project;
                        db.PackagesReceived.Add(pack);
                    }
                });
                packages.PackageReceivedList.ForEach(pack =>
                {
                    int? userid = pack.UserId;
                    User user = db.Users.Where(u => u.UserId.Equals(userid)).First();
                    if (user != null)
                    {
                        pack.User = user;
                        db.PackagesReceived.Add(pack);
                    }
                });
                packages.PackageReceivedList.ForEach(pack =>
                {
                    int? packageaskingid = pack.PackageItemAskingId;
                    PackageItemAsking packageasking = db.PackagesAsking.Where(p => p.PackageItemAskingId.Equals(packageaskingid)).First();
                    if (packageasking != null)
                    {
                        pack.PackageItemAsking = packageasking;
                        db.PackagesReceived.Add(pack);
                    }
                });
                db.SaveChanges();
            }
            return "data transfered";
        }
        public string LoadFundingsToDB()
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\fundings.json";
            Fundings fundings = new Fundings(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                fundings.FundingList = JsonConvert.DeserializeObject<List<Funding>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                fundings.FundingList.ForEach(funding =>
                { // FK project item

                    string projectcode = funding.ProjectCode;
                    ProjectItem project = db.Projects.Where(p => p.ProjectCode.Equals(projectcode)).First();
                    if (project != null)
                    {
                        funding.ProjectItem = project;
                        db.Fundings.Add(funding);
                    }

                });
                fundings.FundingList.ForEach(funding => // gia to FK tou user
                {

                    string usercode = funding.UserCode;
                    User user = db.Users.Where(u => u.UserCode.Equals(usercode)).First();
                    if (user != null)
                    {
                        funding.User = user;
                        db.Fundings.Add(funding);
                    }

                });

                db.SaveChanges();
            }
            return "data transfered";
        }
        public string LoadUsersToDB()
        {
            string filepath = @"C:\Users\User-SL\OneDrive\Υπολογιστής\users.json";
            Users users = new Users(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                users.UserList = JsonConvert.DeserializeObject<List<User>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                db.Users.AddRange(users.UserList);
                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string AddProject(ProjectItem project) // na kalw tin add 
        {
            using (var db = new CrowDoDB())
            {
                 db.Projects.Add(project);
                 db.SaveChanges();
            }
            return "project added";
        }
        public List<ProjectItem> GetAllProjects()
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.ToList();
            }
        }
        public ProjectItem GetDataProjectByCode(string code) // na gurizei to project me sugkekrimeno code
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.ProjectCode.Equals(code)).FirstOrDefault();
            }
        }
        public List<ProjectItem> GetDataProjectByYear(int year) // search by year
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.StartDate.Year.Equals(year)).ToList();
            }
        }
        public ProjectItem GetDataProjectByTitle(string title) // search by title
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.Title.Equals(title)).FirstOrDefault();
            }
        }
        public List<ProjectItem> GetDataProjectByCreator(string name) // epistrefei ta projects searched by creator
        {
            using (var db = new CrowDoDB())
            {
                List<ProjectItem> projects = db.Projects.Where(item => item.User.Name.Equals(name)).ToList();
                return projects;
           
            }
        }
        
        public string UpdateProject(ProjectItem p) //
        {
            using (var db = new CrowDoDB())
            {
                ProjectItem proj1 = db.Projects.Where(item => item.ProjectCode.Equals(p.ProjectCode)).First();
                if (proj1 == null) return "NOT exists";
                proj1.Title = p.Title;
                proj1.Description = p.Description;

                db.SaveChanges();
            }
            return "project updated";
           
        }
        public string InactiveProject(ProjectItem project)
        {
            if (project.User.Status == true)
            {
                using (var db = new CrowDoDB())
                {
                    ProjectItem proj = db.Projects.Where(item => item.Title
                    .Equals(project.Title)).FirstOrDefault();
                    
                    if (proj == null) return "NOT exists";
                    proj.Title = "Inactive";
                    db.SaveChanges();
                }
                return "The project has been inactive";
            }
            else return "You are not logged in";
        }
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public User Login(string username, string password)
        {
            using (var db = new CrowDoDB())
            {
                User user = db.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password)).First();
                if (user != null)
                {
                    user.Status = true;
                    db.SaveChanges();
                    return user;
                }
                else return null;
            }
        }

        public void AddUser(User user) // sign up 
        {
            using (var db = new CrowDoDB())
            {
                user.Status = true;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public List<User> GetCreators() // NA TH GEMISW
        {
            using (var db = new CrowDoDB())
            {
                List<User> creators = db.Users.Include(u=> u.ProjectCreations).ToList();
                return creators;
            }
        }

        public List<ProjectItem> GetCreations (string usercode) // NA TH GEMISW
        {
            using (var db = new CrowDoDB())
            {
                User x = db.Users.Where(us => us.UserCode == usercode).Include(us=>us.ProjectCreations).First();
                 
                return x.ProjectCreations;
            }
        }

        /*public string AddCreation(User user, ProjectItem p)
        {
            //if (user.Status == true)
            //{
                using (var db = new CrowDoDB())
                {
                    user.ProjectCreations.Add(p);
                    db.SaveChanges();
                }
                return "Project added to your creations";
            //}
           // else return "You are not logged in";
        }

        public List<ProjectItem> FillingCreatios() // gurizei olous tous users
        {
            using (var db = new CrowDoDB())
            {
                List<User> users = db.Users.ToList();

                foreach (var user in users)
                {
                    List<ProjectItem> proj = db.Projects.Where(item => item.UserCode.Equals(user.UserCode)).ToList();
                    if (!proj.Equals(null))
                    {
                        foreach (var project in proj)
                        {
                            user.ProjectCreations.Add(project);
                        }
                        proj.Clear();
                        return user.ProjectCreations;

                    }
                    else return null;
                }
                db.SaveChanges();

            }

        }*/

 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public string AddFund(FundingDTO fund)
        {
            using (var db = new CrowDoDB())
            {
                ProjectItem projectItem = db.Projects.Where(p => p.ProjectCode.Equals(fund.ProjectCode)).First();
                if (projectItem == null) return "no";
                User user = db.Users.Where(u => u.UserCode.Equals(fund.UserCode)).First();
                if (user == null) return "no";
                PackageItemAsking p = db.PackagesAsking.Where(pa => pa.PackageCode.Equals(fund.PackageCode)).First();
                if (p == null) return "no";
                Funding fundEnt = new Funding
                {
                    User = user,
                    ProjectItem = projectItem,
                    PackageCode = fund.PackageCode,
                    NumberOfPackages = 1,
                    ProjectCode = fund.ProjectCode,
                    UserCode = fund.UserCode
                };
                db.Fundings.Add(fundEnt);
                db.SaveChanges();
                return "You have now funded a new Project";
            }
        }
        public dynamic GetProjectsFunding(User user)
        {
            using (var db = new CrowDoDB())
            {
                return db.Users.Where(u => u.UserCode.Equals(user.UserCode))
                    .Select(i => new { i.ProjectFunding }).ToList();
            }
        }
        
      /*  public dynamic GetCreatorProjects(User user)
        {
            using (var db = new CrowDoDB())
            {
                return db.Users.Where(u => u.UserCode.Equals(user.UserCode))
                    .Select(i => new { i.ProjectCreations }).ToList();
            }
        }
*/
 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        public double GetTotalAskingFunds(ProjectItem p)
        {
            double result = 0.00;
            using (var db = new CrowDoDB()) // sto front tha vazei auta pou thelei
            {
                string values1 = p.NumberOfRequestedPackages;
                string[] tokens1 = values1.Split(',');
                int[] noOfRequestedPacks = Array.ConvertAll<string, int>(tokens1, int.Parse);
                string values2 = p.PackageCode.ToUpper();
                string[] tokens2 = values2.Split(',');
                int[] costs = new int[tokens2.Length];
                List<PackageItemAsking> packages = db.PackagesAsking.ToList();
                for (int i = 0; i < tokens2.Length; i++)
                {
                    PackageItemAsking package = packages.Where(pack => pack.PackageCode.Equals(tokens2[i].Trim())).First();
                    if (package == null)
                    {
                        Console.WriteLine("The pack was not found");
                        continue;
                    }
                    costs[i] = package.Cost;
                    result += costs[i] * noOfRequestedPacks[i];
                }
            }
            p.TotalAskingFunds = result;
            return p.TotalAskingFunds;
        }

        public double GetTotalReceivingFunds(ProjectItem p)
        {
            double result = 0.00;
            using (var db = new CrowDoDB())
            {
                string values1 = p.NumberOfRequestedPackages;
                string[] tokens1 = values1.Split(',');
                int[] noOfRequestedPacks = Array.ConvertAll<string, int>(tokens1, int.Parse);
                string values2 = p.PackageCode.ToUpper();
                string[] tokens2 = values2.Split(',');
                int[] costs = new int[tokens2.Length];
                var packages = db.PackagesReceived
                    .Include(i => i.PackageItemAsking)
                    .Select(i => new { i.PackageItemAsking }).ToList();
                for (int i = 0; i < tokens2.Length; i++)
                {
                    var package = packages.Where(pack => pack.PackageItemAsking.PackageCode.Equals(tokens2[i].Trim())).First();
                    if (package == null)
                    {
                        Console.WriteLine("The pack was not found");
                        continue;
                    }
                    costs[i] = package.PackageItemAsking.Cost;
                    result += costs[i] * noOfRequestedPacks[i];
                }
            }
            Console.WriteLine("Total Fund is ", result);
            return result;
        }



    }
}
