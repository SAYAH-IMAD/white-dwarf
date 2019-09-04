using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Base.DAL;
using EducationAPI.DAL;
using EducationAPI.Model;

namespace EducationAPI.DAL
{
    public static class EducationDataContract
    {
        #region get educations sync
        public static ContractDataSync<Education> GetEducations()
        {
            return new ContractDataSync<Education>(
                connectionString: @"Data Source=DESKTOP-T8R781C\LOCALDB;Initial Catalog=SchoolDataBase;Integrated Security=True",
                dataBaseName: "SchoolDataBase",
                procedureName: "spGetEducations",
                converter: EducationConverter);
        }

        private static Education EducationConverter(DataRow reader)
        {
            return new Education()
            {
                Id = int.Parse(reader["Id"].ToString()),
                City = (string)reader["City"],
                Current = (bool)reader["current"],
                Description = (string)reader["description"],
                EducationType = (string)reader["educationType"],
                FieldOfStudy = (string)reader["fieldOfStudy"],
                From = (string)reader["from"],
                To = (string) reader["to"],
                SchoolName = (string)reader["schoolName"]
            };
        }
        #endregion get education  sync

        #region 
         public static ContractDataSync<Education> GetEducation(int educationId)
        {
            var getGetDataContract = new ContractDataSync<Education>(
                connectionString: @"Data Source=DESKTOP-T8R781C\LOCALDB;Initial Catalog=SchoolDataBase;Integrated Security=True",
                dataBaseName: "SchoolDataBase",
                procedureName: "spGetEducationById",
                converter: EducationConverter);
                getGetDataContract.Parameters.GetEducationAddParameters(educationId);
            return getGetDataContract;
        }

       public static void GetEducationAddParameters(this Dictionary<string, object> parameters, int educationId)
        {
       
            parameters.Add("educationId", educationId);
        }
        #endregion
        #region  post education
        public static ContractDataAsync<Education> PostEducation(Education education)
        {
            var postDataContract = new ContractDataAsync<Education>(
                connectionString: @"Data Source=DESKTOP-T8R781C\LOCALDB;Initial Catalog=SchoolDataBase;Integrated Security=True",
                dataBaseName: "SchoolDataBase",
                procedureName: "spPostEducation"
                );

            postDataContract.Parameters.AddPostEducationParameters(education);

            return postDataContract;
        }

        public static void AddPostEducationParameters(this Dictionary<string,object> parameters,Education education)
        {
            parameters.Add("current", education.Current);
            parameters.Add("description", education.Description);
            parameters.Add("schoolName", education.SchoolName);
            parameters.Add("city", education.City);
            parameters.Add("educationType", education.EducationType);
            parameters.Add("FieldOfStudy", education.FieldOfStudy);
            parameters.Add("from", education.From);
            parameters.Add("to", education.To);
        }

        private static Education EducationConverter(SqlDataReader reader)
        {
            return new Education()
            {
                Id = int.Parse(reader["Id"].ToString()),
                City = (string)reader["City"],
                Current = (bool)reader["current"],
                Description = (string)reader["description"],
                EducationType = (string)reader["educationType"],
                FieldOfStudy = (string)reader["fieldStudy"],
                From = (string)reader["from"],
                To = (string) reader["to"],
                SchoolName = (string)reader["schoolName"]
            };
        }

        #endregion  post education

        #region  put education
        public static ContractDataAsync<Education> PutEducation(Education education, int educationId)
        {
            var postDataContract = new ContractDataAsync<Education>(
                connectionString: @"Data Source=DESKTOP-T8R781C\LOCALDB;Initial Catalog=SchoolDataBase;Integrated Security=True",
                dataBaseName: "SchoolDataBase",
                procedureName: "spPutEducation",
                converter: EducationConverter);

            postDataContract.Parameters.PutEducationAddParameters(education, educationId);

            return postDataContract;
        }

        public static void PutEducationAddParameters(this Dictionary<string, object> parameters, Education education,int educationId)
        {
            parameters.Add("current", education.Current);
            parameters.Add("description", education.Description);
            parameters.Add("schoolName", education.SchoolName);
            parameters.Add("city", education.City);
            parameters.Add("educationType", education.EducationType);
            parameters.Add("FieldOfStudy", education.FieldOfStudy);
            parameters.Add("from", education.From);
            parameters.Add("to", education.To);
            parameters.Add("educationId", educationId);
        }

        #endregion  put education

        #region  delete education
        public static ContractDataAsync<Education> DeleteEducation(int educationId)
        {
            var postDataContract = new ContractDataAsync<Education>(
                connectionString: @"Data Source=DESKTOP-T8R781C\LOCALDB;Initial Catalog=SchoolDataBase;Integrated Security=True",
                dataBaseName: "SchoolDataBase",
                procedureName: "spDeleteEducation"
                );

            postDataContract.Parameters.DeleteEducationAddParameters(educationId);

            return postDataContract;
        }

        public static void DeleteEducationAddParameters(this Dictionary<string, object> parameters, int educationId)
        {
       
            parameters.Add("educationId", educationId);
        }

        #endregion  put education

    }
}
