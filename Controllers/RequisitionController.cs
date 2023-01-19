using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.Data;
using recruitmentmanagementsystem.ServiceLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RequisitionController : ControllerBase
    {
        private readonly IRequisitionService _requisitionservice;

        private readonly Recruitmentcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RequisitionController(IWebHostEnvironment webhostenvironment, IRequisitionService requisitionservice, Recruitmentcontext context)
        {
            _requisitionservice = requisitionservice;   
            _context = context;
            _webHostEnvironment = webhostenvironment;
        }


        [HttpPost]
        [Authorize]
        [Route("Requisition")]

        public async Task<bool> AddRequisition(string role, string jobdescription, string skillset,string notrequired, string requiredexperience, string qualification, int vacancies)
        {
            try
            {
                Requisition can = new Requisition();
                can.role = role;
                can.jobdescription = jobdescription;
                can.skillset = skillset;
                can.notrequired = notrequired;
                can.requiredexperience = requiredexperience;
                can.qualification = qualification;
                can.vacancies = vacancies;
                var result = await _requisitionservice.AddRequisition(can);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Adding Requisition Failed {ex.Message}");
            }
        }


        [HttpGet]
        [Authorize]
        [Route("All_Requisitions")]

        public async Task<ActionResult<IEnumerable<Requisition>>> GetALL()
        {

            var requestion = await _requisitionservice.getallrequisition();
            return requestion;
        }

    }

}
