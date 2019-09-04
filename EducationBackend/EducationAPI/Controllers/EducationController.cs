using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interface;
using EducationAPI.DAL;
using EducationAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace EductionAPI.Controllers
{
    [Route("api/v1/user/{userId}/[controller]/[action]")]
    [EnableCors("corsPolicy")]
    public class EducationController: Controller
    {
        public readonly IDALProvider _dal = null;
        
        public EducationController(IDALProvider dALProvider)
        {
            _dal = dALProvider;
        }

        [HttpGet("{educationId}")]
        public Education GetEducation(int userId, int educationId)
        {
            return  _dal.Get(EducationDataContract.GetEducation(educationId));
        }

        [HttpGet()]
        public IEnumerable<Education> GetEducations(int userId)
        {
            return  _dal.GetList(EducationDataContract.GetEducations());
        }

        //[HttpPost("api/v1/user/{userId}/education/createEducation")]
        [HttpPost()]
        public async Task CreateEducation([FromBody] Education education)
        {
            await _dal.PostAsync<Education>(EducationDataContract.PostEducation(education));
        }

        //[HttpPut("api/v1/user/{userId}/education/putEducation/{educationId}")]
        [HttpPut("{educationId}")]
        public async Task PutEducation(int userId, int educationId, [FromBody] Education education)
        {
            await _dal.PostAsync<Education>(EducationDataContract.PutEducation(education,educationId));
        }

        //[HttpDelete("api/v1/user/{userId}/education/deleteEducation/{educationId}")]
        [HttpDelete("{educationId}")]
        public async Task DeleteEducation(int userId,int educationId)
        {
            await _dal.PostAsync<Education>(EducationDataContract.DeleteEducation(educationId));
        }
    }
}