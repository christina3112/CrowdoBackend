using System;

namespace CreateData
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathUsers = @"C:\Users\Christina\Desktop\users.json";
            string pathProjects = @"C:\Users\Christina\Desktop\projects.json";
            string pathFunding = @"C:\Users\Christina\Desktop\fundings.json";
            string pathPackages = @"C:\Users\Christina\Desktop\packages.json";
            ReadFile.LoadFromXlUsers(pathUsers);
            ReadFile.LoadFromXlProjects(pathProjects);
            ReadFile.LoadFromXlPackages(pathPackages);
            ReadFile.LoadFromXlFunding(pathFunding);
        }
    }
}
