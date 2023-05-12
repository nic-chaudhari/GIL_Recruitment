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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
                if (ModelState.IsValid) { 
                var rowsAffected = connection.Execute("InsertJobPost", new
                {
                    Title = model.title,

                    AgeLimit = Convert.ToInt32(model.age_limit),
                    StartDate = model.start_date,
                    EndDate = model.end_date,
                    Qualification = model.qualification,
                    Desirable = model.desirable,
                    Experience = model.experience
                },
                commandType: CommandType.StoredProcedure);

                return RedirectToAction("Admin", "Admin");
                }
                else { return View(); }
            }
        }

        public IActionResult All_candidates()
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {

                var results = connection.Query<AllDetails>("spGetPersonalEducationProfessional", commandType: CommandType.StoredProcedure);


                return View(results);
            }

        }

        public IActionResult Application_received()
        {
            return View();
        }

       
        public IActionResult Job_list(jobpost jobpost)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var sql = "SELECT id, title,start_date, end_date FROM jobpost";
                var records = connection.Query<jobpost>(sql);
                return View(records.ToList());
            }
        }
        public IActionResult Send_calllater()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var sql = "SELECT * FROM jobpost WHERE id = @id";
                var jobpost = connection.QueryFirstOrDefault<jobpost>(sql, new { id });
                if (jobpost != null)
                {
                    return View(jobpost);
                }
                return RedirectToAction("Job_list", "Admin");
            }
        }
        [HttpPost]
        public IActionResult Edit(jobpost model)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var rowsAffected = connection.Execute("UpdateJobPost", new
                {
                    p_Id = model.id,
                    p_Title = model.title,
                    p_AgeLimit = model.age_limit,
                    p_StartDate = model.start_date,
                    p_EndDate = model.end_date,
                    p_Qualification = model.qualification,
                    p_Desirable = model.desirable,
                    p_Experience = model.experience
                },
                commandType: CommandType.StoredProcedure);

                return RedirectToAction("Job_list", "Admin");
            }
        }


        public IActionResult Logout()
        {
            // Clear the authentication cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect the user to the login page
            return RedirectToAction("Login","Admin");
        }

        [HttpPost]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var rowsAffected = connection.Execute("DELETE FROM jobpost WHERE id=@id", new { id = id });
                return RedirectToAction("Job_list", "Admin");
            }
        }

    }
}
