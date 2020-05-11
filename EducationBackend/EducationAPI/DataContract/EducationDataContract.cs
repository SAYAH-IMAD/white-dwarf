using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Base.DAL;
using EducationAPI.Model;
using EducationAPI.Extensions;

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
                Id = reader["Id"].IsDBNull<int>(),
                City = (string)reader["City"].IsDBNull<string>(),
                Current = (bool)reader["current"].IsDBNull<bool>(),
                Description = (string)reader["description"].IsDBNull<string>(),
                EducationType = (string)reader["educationType"].IsDBNull<string>(),
                FieldOfStudy = (string)reader["fieldOfStudy"].IsDBNull<string>(),
                From = (string)reader["from"].IsDBNull<string>(),
                To = (string) reader["to"].IsDBNull<string>(),
                SchoolName = (string)reader["schoolName"].IsDBNull<string>(),
            };
        }
        #endregion get education  sync

        #region get education sync
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
        #endregion get education sync

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
                Id = reader["Id"].IsDBNull<int>(),
                City = reader["City"].IsDBNull<string>(),
                Current = reader["current"].IsDBNull<bool>(),
                Description = reader["description"].IsDBNull<string>(),
                EducationType = reader["educationType"].IsDBNull<string>(),
                FieldOfStudy = reader["fieldStudy"].IsDBNull<string>(),
                From = reader["from"].IsDBNull<string>(),
                To =  reader["to"].IsDBNull<string>(),
                SchoolName = reader["schoolName"].IsDBNull<string>()
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
