using System;

namespace CreateData
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathUsers = @"C:\Users\User-SL\OneDrive\Υπολογιστής\users.json";
            string pathProjects = @"C:\Users\User-SL\OneDrive\Υπολογιστής\projects.json";
            string pathFunding = @"C:\Users\User-SL\OneDrive\Υπολογιστής\fundings.json";
            string pathPackages = @"C:\Users\User-SL\OneDrive\Υπολογιστής\packages.json";
            ReadFile.LoadFromXlUsers(pathUsers);
            ReadFile.LoadFromXlProjects(pathProjects);
            ReadFile.LoadFromXlPackages(pathPackages);
            ReadFile.LoadFromXlFunding(pathFunding);
        }
    }
}
