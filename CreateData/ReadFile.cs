using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using CreateData.DTO;
using Entities;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CreateData
{
    public class ReadFile
    {

        public static List<User> LoadFromXlUsers(string pathUsers)  // SHEET USERS
        {
            List<User> Users = new List<User>();
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@"C:\Users\User-SL\Documents\Training\demodataForCrowdo.xlsx",
                FileMode.Open,
                FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheet("Users");
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                //null is when the row only contains empty cells
                if (sheet.GetRow(row) != null)
                {
                    UserDTO userdto = new UserDTO
                    {
                        UserCode = sheet.GetRow(row).GetCell(0).StringCellValue,
                        FirstName = sheet.GetRow(row).GetCell(1).StringCellValue,
                        LastName = sheet.GetRow(row).GetCell(2).StringCellValue,
                        Address = sheet.GetRow(row).GetCell(3).StringCellValue
                    };
                    //
                    User user = new User();
                    user = Converter.ConvertUserFromDto(userdto);
                    Users.Add(user);
                    //Console.WriteLine("edw mpaneis?", user.Name);
                }
            }
            /////////////// EDW METRATREPW TO EXCEL SE JSON ARHEIO
            using (StreamWriter file = File.CreateText(pathUsers))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Users);
            }
            return Users;
            ////////PANTA TRY CATCH SE OLES TIS ME8ODOUS
        }
        public static List<ProjectItem> LoadFromXlProjects(string pathProjects)  // SHEET PROJECTS
        {
            List<ProjectItem> Projects = new List<ProjectItem>();
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@"C:\Users\User-SL\Documents\Training\demodataForCrowdo.xlsx",
                FileMode.Open,
                FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheet("Projects");
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                //null is when the row only contains empty cells
                if (sheet.GetRow(row) != null)
                {
                    ProjectDTO projectdto = new ProjectDTO
                    {
                        ProjectCode = sheet.GetRow(row).GetCell(0).StringCellValue,
                        UserCode = sheet.GetRow(row).GetCell(1).StringCellValue,
                        Title = sheet.GetRow(row).GetCell(2).StringCellValue,
                        StartDate = sheet.GetRow(row).GetCell(3).DateCellValue,
                        PackageCode = sheet.GetRow(row).GetCell(4).StringCellValue,
                        NumberOfRequestedPackages = sheet.GetRow(row).GetCell(5).StringCellValue
                    };
                    ProjectItem projectitem = new ProjectItem();
                    projectitem = Converter.ConvertProjectFromDto(projectdto);
                    Projects.Add(projectitem);
                }
            }
            using (StreamWriter file = File.CreateText(pathProjects))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Projects);
            }
            /// otan diavazeis to excel na vlepeis oi creators poia projects ehoun ftiaksei
            return Projects;
            ////////PANTA TRY CATCH SE OLES TIS ME8ODOUS
        }
        public static List<Funding> LoadFromXlFunding(string pathFunding)  // SHEET FUNDING
        {
            List<Funding> Fundings = new List<Funding>();
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@"C:\Users\User-SL\Documents\Training\demodataForCrowdo.xlsx",
                FileMode.Open,
                FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheet("Funding");
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    FundingDTO fundingdto = new FundingDTO
                    {
                        UserCode = sheet.GetRow(row).GetCell(0).StringCellValue,
                        ProjectCode = sheet.GetRow(row).GetCell(1).StringCellValue,
                        PackageCode = sheet.GetRow(row).GetCell(2).StringCellValue,
                        NumberOfPackages = sheet.GetRow(row).GetCell(3).NumericCellValue // vazei double
                    };
                    Funding funding = new Funding();
                    funding = Converter.ConvertFundingFromDto(fundingdto);
                    Fundings.Add(funding);
                }
            }
            using (StreamWriter file = File.CreateText(pathFunding))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Fundings);
            }
            return Fundings;
            ////////PANTA TRY CATCH SE OLES TIS ME8ODOUS
        }
        public static List<PackageItemAsking> LoadFromXlPackages(string pathPackages) // SHEET PACKAGES
        {
            List<PackageItemAsking> Packages = new List<PackageItemAsking>();
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@"C:\Users\User-SL\Documents\Training\demodataForCrowdo.xlsx",
                FileMode.Open,
                FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheet("Packages");
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    PackageDTO packagedto = new PackageDTO
                    {
                        PackageCode = sheet.GetRow(row).GetCell(0).StringCellValue,
                        Title = sheet.GetRow(row).GetCell(1).StringCellValue,
                        Cost = sheet.GetRow(row).GetCell(2).NumericCellValue,
                        Details = sheet.GetRow(row).GetCell(3).StringCellValue,
                        Rewards = sheet.GetRow(row).GetCell(4).StringCellValue
                    };
                    PackageItemAsking packageItem = new PackageItemAsking();
                    packageItem = Converter.ConvertPackageFromDto(packagedto);
                    Packages.Add(packageItem);
                }
            }
            using (StreamWriter file = File.CreateText(pathPackages))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Packages);
            }
            return Packages;
            ////////PANTA TRY CATCH SE OLES TIS ME8ODOUS
        }
    }
}
