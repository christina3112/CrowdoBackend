
using CreateData.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateData
{
    public class Converter
    {

        public static User ConvertUserFromDto(UserDTO userDTO)
        {
            return new User
            {
                UserCode = userDTO.UserCode,//den einai ths klashs einai tou antikeimenou
                Name = userDTO.FirstName + ' ' + userDTO.LastName,//////////////////////////////////////////////////////////////
                Address = userDTO.Address,
                Username = userDTO.FirstName + userDTO.LastName,
                Password = "123456"
            };
        }
        public static ProjectItem ConvertProjectFromDto(ProjectDTO projectDTO)
        {
            return new ProjectItem
            {
                ProjectCode = projectDTO.ProjectCode,//den einai ths klashs einai tou antikeimenou
                UserCode = projectDTO.UserCode,
                Title = projectDTO.Title,
                StartDate = Convert.ToDateTime(projectDTO.StartDate),
                PackageCode = projectDTO.PackageCode,//.Split(' ').ToList(),
                NumberOfRequestedPackages = projectDTO.NumberOfRequestedPackages//.Split(',').Select(Int32.Parse).ToList()
            };
        }
        public static Funding ConvertFundingFromDto(FundingDTO fundingDTO)
        {
            return new Funding
            {
                UserCode = fundingDTO.UserCode,//den einai ths klashs einai tou antikeimenou
                ProjectCode = fundingDTO.ProjectCode,
                PackageCode = fundingDTO.PackageCode,
                NumberOfPackages = Convert.ToInt32(fundingDTO.NumberOfPackages)
            };
        }
        public static PackageItem ConvertPackageFromDto(PackageDTO packageDTO)
        {
            return new PackageItem
            {
                PackageCode = packageDTO.PackageCode,//den einai ths klashs einai tou antikeimenou
                Title = packageDTO.Title,
                Details = packageDTO.Details,
                Rewards = packageDTO.Rewards,
                Cost = Convert.ToInt32(packageDTO.Cost)
            };
        }
    }
}
