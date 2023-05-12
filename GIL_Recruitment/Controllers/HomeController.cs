using GIL_Recruitment.Models;
using Microsoft.AspNetCore.Hosting;
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
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.Xml;
using Google.Protobuf.WellKnownTypes;

namespace GIL_Recruitment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Recruitment()
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var sql = "SELECT id, title, qualification, experience,start_date, end_date FROM jobpost";
                var jobPosts = connection.Query<jobpost>(sql).ToList();

                return View(jobPosts);
            }
        }

        public IActionResult Delete(int id)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var sql = "SELECT * FROM jobpost WHERE id = @id";
                var jobpost = connection.QueryFirstOrDefault<jobpost>(sql, new { id });

                if (jobpost == null)
                {
                    return NotFound();
                }

                return View(jobpost);
            }
        }
        public IActionResult Details(int id)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var sql = "SELECT * FROM jobpost WHERE id = @id";
                var jobpost = connection.QueryFirstOrDefault<jobpost>(sql, new { id });

                if (jobpost == null)
                {
                    return NotFound();
                }
                HttpContext.Session.SetInt32("pid", id);
                return View(jobpost);
            }
        }

        public IActionResult Personal_Info()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Personal_Info(personal_infomodel model)
        //{
        //    using (var connection = DapperHelper.GetOpenConnection())
        //    {

        //        var rowsAffected = connection.Execute("inspersonaldatainfo", new
        //        {
        //            pTitle = model.Title,
        //            pFirstname = model.FirstName,
        //            pMiddlename = model.MiddleName,
        //            pSurname = model.Surname,
        //            pMothername = model.MotherName,
        //            pGender = model.Gender,
        //            pDateofbirth = model.DateOfBirth,
        //            pNationality = model.Nationality,
        //            pContactNo = model.ContactNo,
        //            pAlternateNo = model.AlternateNo,
        //            pCast = model.Cast,
        //            pPhychall = model.Phychall,
        //            pPresentAdd = model.PresentAdd,
        //            pPermanentAdd = model.PermanentAdd,
        //            pMaritial = model.Maritial,
        //            pUpphoto = model.Upphoto,
        //            pUpsign = model.Upsign,
        //            pUpproof = model.Upproof,
        //        },
        //        commandType: CommandType.StoredProcedure);

        //        return RedirectToAction("Index", "Home");
        //    }


        //}

        [HttpPost]
        public IActionResult Personal_Info(personal_infomodel model)
        {
            int postid = HttpContext.Session.GetInt32("pid")??0;
            using (var connection = DapperHelper.GetOpenConnection())
            {
             
                var rowsAffected = connection.Execute("inspersonaldatainfo", new
                {
                    p_postid=postid,
                    p_Title = model.Title,
                    p_Firstname = model.FirstName,
                    p_Middlename = model.MiddleName,
                    p_Surname = model.Surname,
                    p_Mothername = model.MotherName,
                    p_Gender = model.Gender,
                    p_Dateofbirth = model.DateOfBirth,
                    p_Nationality = model.Nationality,
                    p_ContactNo = model.ContactNo,
                    p_AlternateNo = model.AlternateNo,
                    p_Cast = model.Cast,
                    p_Phychall = model.Phychall,
                    p_PresentAdd = model.PresentAdd,
                    p_PermanentAdd = model.PermanentAdd,
                    p_Maritial = model.Maritial,
                    p_Upphoto = model.Upphoto, // Pass the path of the uploaded file
                    p_Upsign = model.Upsign, // Pass the path of the uploaded file
                    p_Upproof = model.Upproof, // Pass the path of the uploaded file
                },
       commandType: CommandType.StoredProcedure);
                if (rowsAffected > 0)
                {
                    int id = connection.ExecuteScalar<int>("SELECT LAST_INSERT_ID()"); // Get the ID of the inserted record
                    HttpContext.Session.SetInt32("perid", id); // Store the ID in the session
                }
                return RedirectToAction("GraduationInfo", "Home");
            }

        }



        //public IActionResult GraduationInfo()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> GraduationInfo(GraduationInfo graduationInfo, IFormFile file, string[] selectedLanguages)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(graduationInfo);

        //    }
        //    else {
        //        var result = await DapperHelper.InsertIntoGraduationInfo(graduationInfo, selectedLanguages);
        //        return RedirectToAction("Index");

        //    }
        //}

        public IActionResult GraduationInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GraduationInfo(GraduationInfo graduationInfo)
        {

            int postid = HttpContext.Session.GetInt32("pid") ?? 0; 
            int perid = HttpContext.Session.GetInt32("perid") ?? 0;
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var parameters = new
                {
                    g_postid = postid,
                    g_perid = perid,
                    g_edudetail = graduationInfo.Edudetail,
                    g_degname = graduationInfo.Degname,
                    g_percentage = graduationInfo.Percentage,
                    g_class = graduationInfo.Class,
                    g_university = graduationInfo.University,
                    g_nooftrails = graduationInfo.Nooftrails,
                    g_passmonth = graduationInfo.Passmonth,
                    g_passyear = graduationInfo.Passyear,
                    g_upcerti = graduationInfo.Upcerti,
                    edudetail_p = graduationInfo.pEdudetail,
                    degname_p = graduationInfo.pDegname,
                    percentage_p = graduationInfo.pPercentage,
                    class_p = graduationInfo.pClass,
                    university_p = graduationInfo.pUniversity,
                    nooftrails_p = graduationInfo.pNooftrails,
                    passmonth_p = graduationInfo.pPassmonth,
                    passyear_p = graduationInfo.pPassyear,
                    upcerti_p = graduationInfo.pUpcerti,
                    lang = graduationInfo.languagelist
                };

                connection.Execute("InsertIntoGraduationInfo", parameters, commandType: CommandType.StoredProcedure);

                // Debugging info: check the number of rows affected
                System.Diagnostics.Debug.WriteLine("Rows affected: " + parameters);

                return RedirectToAction("professional", "Home");
            }
        }

        public IActionResult professional()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProfessionalInfo(professional professional)
        {
            int postid = HttpContext.Session.GetInt32("pid") ?? 0;
            int perid = HttpContext.Session.GetInt32("perid") ?? 0;
            using (var connection = DapperHelper.GetOpenConnection())
            {
                var parameters = new
                {
                    p_postid=postid,
                    p_perid=perid,
                    p_jobsector = professional.jobsector,
                    p_nameofpost = professional.nameofpost,
                    p_startfrom = professional.startfrom,
                    p_endto = professional.endto,
                    p_empname = professional.empname,
                    p_empcontactno = professional.empcontactno,
                    p_empadd = professional.empadd,
                    p_emppincode = professional.emppincode,
                    p_jobdescription = professional.jobdescription,
                    p_salary = professional.salary,
                    p_upexpcerti = professional.upexpcerti
                };
                connection.Execute("InsertProfessionalInfo", parameters, commandType: CommandType.StoredProcedure);
                return RedirectToAction("finalconfirmation","Home");
            }
        }

        public IActionResult finalconfirmation()
        {
            int pid = HttpContext.Session.GetInt32("pid") ?? 0;
            int prid = HttpContext.Session.GetInt32("perid") ?? 0;
            using (var connection = DapperHelper.GetOpenConnection())
            {
                // Retrieve personal info
                var personalInfo = connection.QueryFirstOrDefault<personal_infomodel>("SELECT * FROM tblpersonal_info WHERE id = @prid", new { prid });

                // Retrieve graduation info
                var graduationInfo = connection.QueryFirstOrDefault<GraduationInfo>("SELECT * FROM tbleducationmaster WHERE postid = @pid AND perid = @prid", new { pid, prid });

                // Retrieve professional info
                var professionalInfo = connection.QueryFirstOrDefault<professional>("SELECT * FROM tblprofessional WHERE postid = @pid AND perid = @prid", new { pid, prid });

                // Create the ViewModel
                var viewModel = new finalconfirmation
                {
                    PersonalInfo = personalInfo,
                    Education = graduationInfo,
                    professional = professionalInfo
                };

                return View(viewModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}