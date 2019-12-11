using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public string GetHome()
        {
            return "hello";
        }


        [HttpGet("projects/{code}")]
        public ActionResult<ProjectItem> GetProjects(string code) // Mia lista apo auto to interface
        {
            return _context.GetDataProjects(code);
        }

        [HttpGet("projects")]
        public IEnumerable<ProjectItem> GetDataProject()
        {
            return _context.GetData();
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
        public IEnumerable<PackageItem> GetDataPackage()
        {
            return _context.GetDataPackage();
        }
        //////////////////////////////////////////// LOAD 
        [HttpGet("load_projects")]
        public void GetProjectsToDB()
        {
            _context.LoadProjectsToDB();
        }
        [HttpGet("load_packages")]
        public void GetPackagesToDB()
        {
            _context.LoadPackagesToDB();
        }
        [HttpGet("load_fundings")]
        public void GetFundingsToDB()
        {
            _context.LoadFundingsToDB();
        }
        [HttpGet("load_users")]
        public void GetUsersToDB()
        {
            _context.LoadUsersToDB();
        }
        //////////////////////////////////////////// LOAD 
        [HttpGet("all projects")] // emfanizei ola ta projects apo database
        public List<ProjectItem> GetProjects() // 
        {
            return _context.GetAllProjects();
        }
        [HttpGet("projectcode/{code}")] // search in database by code
        public ActionResult<ProjectItem> GetProjectByCode(string code) // 
        {
            return _context.GetDataProjectByCode(code);
        }
        [HttpGet("projectyear/{year}")] // search in database by year
        public ActionResult<ProjectItem> GetProjects(int year) // 
        {
            return _context.GetDataProjectByYear(year);
        }
        [HttpGet("projecttitle/{title}")] // search in database by title
        public ActionResult<ProjectItem> GetProjectsByTitle(string title)
        {
            return _context.GetDataProjectByTitle(title);
        }
        [HttpGet("projectcreator/{usercode}")] // search in database by creator
        public List<ProjectItem> GetProjectsByCreator(string usercode)
        {
            return _context.GetDataProjectsByCreator(usercode);
        }
        [HttpGet("all users")] // returns all users
        public List<User> GetAllUsers()
        {
            return _context.GetDataUsers();
        }
        [HttpGet("total fund")]
        public double TotalFundOfAProject(ProjectItem p)
        {
            return _context.TotalFundOfOneProject(p);
        }
        [HttpPost("project")]
        public string SetProject(ProjectItem p)
        {
            _context.AddProject(p);
            return "project has been added !";
        }
        [HttpPut("project/{description}")] // to put einai gia update // sto path de hreiazetai na grafw to agents, vazw tis times tou kathena
        public string SetProjectsDescription(string description)
        {
            string result = _context.UpdateProjectByDescription(description);
            return result;
        }
        [HttpPut("project/{title}")] // to put einai gia update // sto path de hreiazetai na grafw to agents, vazw tis times tou kathena
        public string SetProjectsTitle(string title)
        {
            string result = _context.UpdateProjectByTitle(title);
            return result;
        }

    }
}
