using GIL_Recruitment.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Connections;
using System.Diagnostics.Metrics;
using System.Data.SqlClient;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static GIL_Recruitment.Models.jobpost;

namespace GIL_Recruitment.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(adminmodel admin)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var sql = "SELECT * FROM tbladmin WHERE Username = @Username AND Password = @Password";
                var user = connection.QueryFirstOrDefault<adminmodel>(sql, new { username = admin.Username, password = admin.Password });
                if (user != null)
                {
                    return RedirectToAction("Admin", "Admin");
                }
                return View();
            }
        }
        public IActionResult Job_post()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Job_post(jobpost model, IFormFile file)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                
                var rowsAffected = connection.Execute("InsertJobPost", new
                {
                    Title = model.title,
                    Description = model.description,
                    AgeLimit = model.age_limit,
                    StartDate = model.start_date,
                    EndDate = model.end_date,
                    Qualification = model.qualification,
                    Desirable = model.desirable,
                    Experience = model.experience
                },
                commandType: CommandType.StoredProcedure);

                return RedirectToAction("Admin", "Admin");
            }
        }

        public IActionResult All_candidates()
        {
            return View();
        }

        public IActionResult Application_received()
        {
            return View();
        }

        public IActionResult Post_application()
        {
            return View();
        }

        public IActionResult Send_calllater()
        {
            return View();
        }

     

    }
}
