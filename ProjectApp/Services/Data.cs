
using Entities;
using Newtonsoft.Json;
using ProjectApp.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApp.Services
{
    public class Data
    {
        public IEnumerable<ProjectItem> GetData() // 
        {
            string filepath = @"C:\Users\Christina\Desktop\projects.json";
            Projects projects = new Projects(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // diavazw to json arheio kai vazw mesa 
                projects.ProjectList = JsonConvert.DeserializeObject<List<ProjectItem>>(json); // 
            }
            return projects.ProjectList; // 
        }
        public IEnumerable<User> GetDataUser() // 
        {
            string filepath = @"C:\Users\Christina\Desktop\users.json";
            Users users = new Users(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                users.UserList = JsonConvert.DeserializeObject<List<User>>(json); // 
            }
            return users.UserList; // 
        }
        public IEnumerable<Funding> GetDataFunding() // 
        {
            string filepath = @"C:\Users\Christina\Desktop\fundings.json";
            Fundings fundings = new Fundings(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                fundings.FundingList = JsonConvert.DeserializeObject<List<Funding>>(json); // 
            }
            return fundings.FundingList; // 
        }
        public IEnumerable<PackageItem> GetDataPackage() // 
        {
            string filepath = @"C:\Users\Christina\Desktop\packages.json";
            Packages packages = new Packages(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                packages.PackageList = JsonConvert.DeserializeObject<List<PackageItem>>(json); // 
            }
            return packages.PackageList; // 
        }
        public string LoadProjectsToDb()
        {
            string filepath = @"C:\Users\Christina\Desktop\projects.json";
            Projects projects = new Projects(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // diavazw to json arheio kai vazw mesa 
                projects.ProjectList = JsonConvert.DeserializeObject<List<ProjectItem>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                db.Projects.AddRange(projects.ProjectList);
                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }

        public ProjectItem GetDataProjects(string code)
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.ProjectCode.Equals(code)).ToList().FirstOrDefault();
            }
        }

        public ProjectItem GetDataProjects(int year)
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.StartDate.Year.Equals(year)).ToList().FirstOrDefault();
            }
        }
        public ProjectItem GetDataProjectsByTitle(string title)
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.Title.Equals(title)).ToList().FirstOrDefault();
            }
        }
        public string LoadProjectsToDB() // FORTWNOUME STH VASH TO KATHE ENTITY KAI EXOUME MIA LOAD GIA KATHE PINAKA
        {
            string filepath = @"C:\Users\Christina\Desktop\projects.json";
            Projects projects = new Projects(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // diavazw to json arheio kai vazw mesa 
                projects.ProjectList = JsonConvert.DeserializeObject<List<ProjectItem>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                db.Projects.AddRange(projects.ProjectList);
                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }
        public string LoadPackagesToDB()
        {
            string filepath = @"C:\Users\Christina\Desktop\packages.json";
            Packages packages = new Packages(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                packages.PackageList = JsonConvert.DeserializeObject<List<PackageItem>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                db.Packages.AddRange(packages.PackageList);
                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }
        public string LoadFundingsToDB()
        {
            string filepath = @"C:\Users\Christina\Desktop\fundings.json";
            Fundings fundings = new Fundings(); // 
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd(); // 
                fundings.FundingList = JsonConvert.DeserializeObject<List<Funding>>(json); // 
            }
            using (var db = new CrowDoDB()) // gia na kanei automata to dispose
            {
                db.Fundings.AddRange(fundings.FundingList);
                db.SaveChanges(); // Kanei insert sti db kai to vazoume MONO otan grafei
            }
            return "data transfered";
        }
        public string LoadUsersToDB()
        {
            string filepath = @"C:\Users\Christina\Desktop\users.json";
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
        /////////////////////////////////////////////////////////////////////////////////////////////
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
                return db.Projects.Where(item => item.ProjectCode.Equals(code)).ToList().First();
            }
        }
        public ProjectItem GetDataProjectByTitle(string title) // na gurizei to project me sugkekrimeno code
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.Title.Equals(title)).ToList().First();
            }
        }
        public ProjectItem GetDataProjectByYear(int year) // searched by year
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.StartDate.Year.Equals(year)).ToList().FirstOrDefault();
            }
        }
        public List<ProjectItem> GetDataProjectsByCreator(string usercode) // epistrefei ta projects searched by creator
        {
            using (var db = new CrowDoDB())
            {
                return db.Projects.Where(item => item.UserCode.Equals(usercode)).ToList();
            }
        }
        public List<User> GetDataUsers() // gurizei olous tous users
        {
            using (var db = new CrowDoDB())
            {
                return db.Users.ToList(); //
            }
        }
        public List<Funding> GetFundingProjects(string projectcode) // gurizei olous tous users
        {
            using (var db = new CrowDoDB())
            {
                return db.Fundings.Where(p => p.ProjectCode.Equals(projectcode)).ToList();
            }
        }
        public void AddProject(ProjectItem p) // MONO O CREATOR TO KANEI AYTO 
        {
            using (var db = new CrowDoDB()) // sto front tha vazei auta pou thelei
            {
                db.Projects.Add(p); // 
                db.SaveChanges(); // 
            }
        }
        public string UpdateProjectByDescription(string description) // allzei to description
        {
            using (var db = new CrowDoDB())
            {
                ProjectItem proj = db.Projects.Where(p => p.Description.Equals(description)).FirstOrDefault();
                if (proj == null) return "NOT exists";
                proj.Description = description;
                db.SaveChanges();
            }
            return "updated description";
        }
        public string UpdateProjectByTitle(string title) // allazei to title
        {
            using (var db = new CrowDoDB())
            {
                ProjectItem proj = db.Projects.Where(p => p.Title.Equals(title)).FirstOrDefault();
                if (proj == null) return "NOT exists";
                proj.Title = title;
                db.SaveChanges();
            }
            return "updated title";
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public string InactiveProject(string title)
        {
            using (var db = new CrowDoDB())
            {
                ProjectItem proj = db.Projects.Where(item => item.Title.Equals(title)).FirstOrDefault();
                proj.Title = "Inactive";
                if (proj == null) return "NOT exists";
                db.SaveChanges();
            }
            return "The project has been inactive";
        }

        public double TotalFundOfOneProject(ProjectItem p)
        {
            double result = 0.00;
            using (var db = new CrowDoDB()) // sto front tha vazei auta pou thelei
            {
                string values1 = p.NumberOfRequestedPackages;
                string[] tokens1 = values1.Split(',');
                int[] noOfRequestedPacks = Array.ConvertAll<string, int>(tokens1, int.Parse);
                string values2 = p.PackageCode;
                string[] tokens2 = values2.Split(',');
                int[] costs = new int[tokens2.Length];
                List<PackageItem> packages = db.Packages.ToList();

                for (int i = 0; i < tokens2.Length; i++)
                {
                    PackageItem package = packages.Where(p => p.PackageCode.Equals(tokens2[i])).First();
                    if (package == null)
                    {
                        Console.WriteLine("The pack was not found");
                        continue;
                    }
                    costs[i] = package.Cost;
                    result += costs[i] * noOfRequestedPacks[i];

                }

            }
            Console.WriteLine("Total Fund is ", result);
            return result;
        }

        //////////////////////////////////////////////////////////////////
        public List<PackageItem> GetListOfPackages()
        {
            using (var db = new CrowDoDB())
            {
                return db.Packages.ToList();
            }
        }
        public PackageItem GetOnePackage(string packagecode) // mou kanei return to 1o package pou ehei auto to packagecode 
        {
            using (var db = new CrowDoDB())
            {
                return db.Packages.First(item => item.PackageCode.Equals(packagecode));
            }
        }
        public PackageItem GetOnePackageFromList(string packageCode)
        {
            List<PackageItem> ListOfPackageItem = GetListOfPackages(); // mporw na ftiahnw ti lista sto constructor na nai global (ki epeidi den einai static i sunartisi) na hrisimopoiw ti lista mesa hwris kan na ti vazw ws parametro
            return ListOfPackageItem.First();
            // kai edw mporw na kanw oti allo thelw me ti listofpackageitem
        }
        ///////////////////////////////////////////////////////

    }
}
