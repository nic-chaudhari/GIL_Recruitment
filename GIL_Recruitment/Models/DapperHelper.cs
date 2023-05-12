using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;



namespace GIL_Recruitment.Models

{
    public class DapperHelper
    {
        private static string connectionString = "Server=localhost;port=3306;Database=gil;Uid=root;Pwd=root;";

        public static MySqlConnection GetOpenConnection()
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        //public static int InsertJobpost(Jobpost jobpost)
        //{
        //    using (var connection = GetOpenConnection())
        //    {
        //        string sql = @"INSERT INTO job_overview (posted_date, location,company_name, vacancy, job_nature, salary, application_date, job_description, required_skills, experience)
        //               VALUES (@PostedDate, @Location,@Companyname, @Vacancy, @JobNature, @Salary, @ApplicationDate, @JobDescription, @RequiredSkills, @Experience)";
        //        var parameters = new
        //        {
        //            PostedDate = jobpost.posted_date,
        //            Location = jobpost.location,
        //            Companyname = jobpost.company_name,
        //            Vacancy = jobpost.vacancy,
        //            JobNature = jobpost.job_nature,
        //            Salary = jobpost.salary,
        //            ApplicationDate = jobpost.application_date,
        //            JobDescription = jobpost.job_description,
        //            RequiredSkills = jobpost.required_skills,
        //            Experience = jobpost.experience
        //        };
        //        return connection.Execute(sql, parameters);
        //    }
        //}
        //public static int InsertJobseeker(JobApplication jobseeker, IFormFile resume, int job_id)
        //{
        //    using (var connection = GetOpenConnection())
        //    {
        //        string sql = @"INSERT INTO job_application (jobseeker_name, jobseeker_email, resume_file_path, date_applied, jobpost_id)
        //       VALUES (@Name, @Email, @Resume, @AppliedJobId, @JobpostId)";


        //        var parameters = new
        //        {
        //            Name = jobseeker.jobseeker_name,
        //            Email = jobseeker.jobseeker_email,
        //            Resume = resume.FileName,
        //            AppliedJobId = jobseeker.date_applied,
        //            JobpostId = job_id
        //        };
        //        connection.Execute(sql, parameters);

        //        // Return the ID of the last inserted row
        //        return connection.QuerySingleOrDefault<int>("SELECT LAST_INSERT_ID()");

        //    }
        //}

        public static T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.QueryFirstOrDefault<T>(sql, param);
            }
        }
        public static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.Query<T>(sql, param);
            }
        }

        public static async Task<int> InsertIntoGraduationInfo(GraduationInfo graduationInfo, string[] selectedLanguages)
        {
            using (var connection = DapperHelper.GetOpenConnection())
            {
                string selectedLanguagesStr = string.Join(",", selectedLanguages.Where(x => x != "false"));
                var parameters = new DynamicParameters();
                parameters.Add("@EduDetail", graduationInfo.Edudetail, DbType.String);
                parameters.Add("@DegName", graduationInfo.Degname, DbType.String);
                parameters.Add("@Percentage", graduationInfo.Percentage, DbType.Decimal);
                parameters.Add("@Class", graduationInfo.Class, DbType.String);
                parameters.Add("@University", graduationInfo.University, DbType.String);
                parameters.Add("@NoOfTrials", graduationInfo.Nooftrails, DbType.Int32);
                parameters.Add("@PassMonth", graduationInfo.Passmonth, DbType.String);
                parameters.Add("@PassYear", graduationInfo.Passyear, DbType.String);
                parameters.Add("@UpCerti", graduationInfo.Upcerti, DbType.Binary);
                parameters.Add("@PEduDetail", graduationInfo.pEdudetail, DbType.String);
                parameters.Add("@PDegName", graduationInfo.pDegname, DbType.String);
                parameters.Add("@PPercentage", graduationInfo.pPercentage, DbType.Decimal);
                parameters.Add("@PClass", graduationInfo.pClass, DbType.String);
                parameters.Add("@PUniversity", graduationInfo.pUniversity, DbType.String);
                parameters.Add("@PNoOfTrials", graduationInfo.pNooftrails, DbType.Int32);
                parameters.Add("@PPassMonth", graduationInfo.pPassmonth, DbType.String);
                parameters.Add("@PPassYear", graduationInfo.pPassyear, DbType.String);
                parameters.Add("@PUpCerti", graduationInfo.pUpcerti, DbType.Binary);
                parameters.Add("@Lan", selectedLanguagesStr, DbType.String);

                return await connection.ExecuteAsync("InsertIntoGraduationInfo", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public static int Execute(string sql, object param = null)
        {
            using (var connection = GetOpenConnection())
            {
                return connection.Execute(sql, param);
            }
        }
    }
}

