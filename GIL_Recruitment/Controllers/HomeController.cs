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
                var sql = "SELECT id, title, qualification, description, experience,start_date, end_date FROM jobpost";
                var jobPosts = connection.Query<jobpost>(sql).ToList();

                return View(jobPosts);
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
        public async Task<IActionResult> Personal_Info(personal_infomodel model)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                // Store the uploaded files on the server
                var photoPath = await StoreUploadedFileAsync(model.Upphoto);
                var signPath = await StoreUploadedFileAsync(model.Upsign);
                var proofPath = await StoreUploadedFileAsync(model.Upproof);

                var rowsAffected = connection.Execute("InsertRecord", new
                {
                    Title = model.Title,
                    Firstname = model.FirstName,
                    Middlename = model.MiddleName,
                    Surname = model.Surname,
                    Mothername = model.MotherName,
                    Gender = model.Gender,
                    Dateofbirth = model.DateOfBirth,
                    Nationality = model.Nationality,
                    ContactNo = model.ContactNo,
                    AlternateNo = model.AlternateNo,
                    Cast = model.Cast,
                    Phychall = model.Phychall,
                    PresentAdd = model.PresentAdd,
                    PermanentAdd = model.PermanentAdd,
                    Maritial = model.Maritial,
                    Upphoto = photoPath, // Pass the path of the uploaded file
                    Upsign = signPath, // Pass the path of the uploaded file
                    Upproof = proofPath, // Pass the path of the uploaded file
                },
               commandType: CommandType.StoredProcedure);

                return RedirectToAction("Index", "Home");
            }
        }

        private async Task<string> StoreUploadedFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}