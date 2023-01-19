using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.Data;
using recruitmentmanagementsystem.ServiceLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        private readonly IRequisitionService _requisitionservice;
        private readonly IResumeService _resumeservice;
        private readonly Recruitmentcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResumeController(IWebHostEnvironment webhostenvironment, IRequisitionService requisitionservice, Recruitmentcontext context, IResumeService resumeservice)
        {
            _requisitionservice = requisitionservice;
            _context = context;
            _resumeservice = resumeservice;
            _webHostEnvironment = webhostenvironment;
        }


        [HttpPost]
        [Authorize]
        [Route("uploadresume")]
        public async Task<bool> uploadfile(List<IFormFile> FormFile)
        {
            return await _resumeservice.uploadfile(FormFile);
        }



        [HttpGet]
        [Authorize]
        [Route("get_all_resumes")]
        public async Task<ActionResult<IEnumerable<CandidateResume>>> fetchAllResumes()
        {
            var resumes = await _resumeservice.fetchAllResumes();
            return Ok(resumes);
        }

        [HttpPut]
        [Authorize]
        [Route("setstatus")]
        public async Task<IActionResult> setStatusCandidate(string email, string status)
        {
         

            var result =  await _resumeservice.setStatusCandidate(email, status);
            return Accepted(result);
        }


        [HttpGet]
        [Authorize]
        [Route("get_date_time")]
        public async Task<ActionResult<DateTime>> get_date_time_from_candidateID(int id)
        {
            var date_time = await _resumeservice.get_date_time(id);
            return Ok(date_time);
        }


        [HttpGet]
        [Authorize]
        [Route("get_resumes_within_range")]
        public async Task<ActionResult<List<CandidateResume>>> get_resumes_within_range(String start, String end)
        {
        
            DateTime ts1;
            DateTime ts2;
            if (DateTime.TryParse(start, out ts1) == false || DateTime.TryParse(end, out ts2) == false)
            {
                throw new Exception("Invalid String format for Timestamp");
            }

            var resumes = await _resumeservice.get_resumes_within_range(ts1, ts2);
            return Ok(resumes);
        }

        



    }

}
