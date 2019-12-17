using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreateData.DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectApp.Services;

namespace ProjectApp.Controllers
{

    [ApiController]
    [Route("Crowdo")]
    public class CrowDoController : ControllerBase
    {
        private readonly ILogger<CrowDoController> _logger;
        private readonly Data _context;

        public CrowDoController(Data context, ILogger<CrowDoController> logger)
        {
            _context = context;
            _logger = logger;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public string GetHome()
        {
            return "hello";
        }
        /////////////////////////////////////////////////////////////////////////////
        [HttpGet("load_projects")]
        public string GetProjectsToDB()
        {
            return _context.LoadProjectsToDB();
        }
        [HttpGet("load_packagesasking")]
        public string GetPackagesToDB()
        {
            return _context.LoadPackageItemAskingToDB();
        }
        [HttpGet("load_packagesreceiving")] // 
        public string GetPackagesReceivingToDB()
        {
            return _context.LoadPackageItemReceivedToDB();
        }
        [HttpGet("load_fundings")]
        public string GetFundingsToDB()
        {
            return _context.LoadFundingsToDB();
        }
        [HttpGet("load_users")]
        public string GetUsersToDB()
        {
            return _context.LoadUsersToDB();
        }

        
        //////////////////////////////////////////// LOAD //////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("projects")]
        public IEnumerable<ProjectItem> GetDataProject()
        {
            return _context.GetDataProject();
        }
        [HttpGet("users")]
        public IEnumerable<User> GetDataUser()
        {
            return _context.GetDataUser();
        }
        [HttpGet("fundings")]
        public IEnumerable<Funding> GetDataFunding()
        {
            return _context.GetDataFunding();
        }
        [HttpGet("packages")]
        public IEnumerable<PackageItemAsking> GetDataPackage()
        {
            return _context.GetDataPackage();
        }

 ////////////////////////////////////////////////////// LOAD //////////////////////////////////////////////////////////////////////////

        [HttpGet("all_projects")] // 
        public List<ProjectItem> GetProjects()
        {
            return _context.GetAllProjects();
        }

        [HttpGet("projectcode/{code}")] // 
        public ActionResult<ProjectItem> GetProjectByCode(string code)
        {
            return _context.GetDataProjectByCode(code);
        }

        [HttpGet("projectyear/{year}")] // 
        public List<ProjectItem> GetProjectsByYear(int year)
        {
            return _context.GetDataProjectByYear(year);
        }

        [HttpGet("projecttitle/{title}")] // 
        public ActionResult<ProjectItem> GetProjectsByTitle(string title)
        {
            return _context.GetDataProjectByTitle(title);
        }

        [HttpGet("projectcreator/{name}")] // 
        public List<ProjectItem> GetProjectsByCreator(string name)
        {
            return _context.GetDataProjectByCreator(name);
        }

        [HttpPut("update_project")] // 
        public string UpdateProj(ProjectItem project)
        {
            return _context.UpdateProject(project);
        }

        [HttpPost("add_project")]
        public string SetProject(ProjectItem p)
        {
            return _context.AddProject(p);
        }

        [HttpGet("funded_projects")]
        public string GetDataProjectsFunding(User user)
        {
            return _context.GetProjectsFunding(user);
        }

        [HttpPut("projectoff")] // 
        public string InactivatedProject(ProjectItem p)
        {
            string result = _context.InactiveProject(p);
            return result;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("creators")] 
        public List<User> GetCreatorsUsers()
        {
            return _context.GetCreators();
        }

        [HttpGet("creations/{usercode}")]
        public List<ProjectItem> GetCreatorProjects(string usercode)
        {
            return _context.GetCreations(usercode);
        }

        [HttpPost("login")]
        public User Login(User u)
        {
           return  _context.Login(u.Username, u.Password);
            
        }


        [HttpPost("add_user")] 
        public string SignUp(User user)
        {
            _context.AddUser(user);
            return "User has been added !";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("add_project_funding")]
        public string AddFund(FundingDTO fund)
        {
            return _context.AddFund(fund);
        }
       
        [HttpGet("total_asking_funds/{projectcode}")]
        public double TotalAskingFundsOfAProject(string projectcode)
        {
            return _context.GetTotalAskingFunds(projectcode);
        }

        [HttpGet("total_received_funds/{projectcode}")]
        public double TotalReceivedFundsOfAProject(string projectcode)
        {
            return _context.GetTotalReceivingFunds(projectcode);
        }
    }
}
