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
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController: ControllerBase
    {
        private readonly ICalendarService _calendarservice;
        private readonly Recruitmentcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CalendarController(IWebHostEnvironment webhostenvironment,  Recruitmentcontext context, ICalendarService calendarService)
        {
            _context = context;
            _webHostEnvironment = webhostenvironment;
            _calendarservice = calendarService;
        }

        [HttpGet]
        [Authorize]
        [Route("get_calendar_entries_within_range")]
        public async Task<ActionResult<List<Calendar>>> get_calendar_entries_within_range(String start, String end)
        {


            DateTime ts1;
            DateTime ts2;
            if (DateTime.TryParse(start, out ts1) == false || DateTime.TryParse(end, out ts2) == false)
            {
                throw new Exception("Invalid String format for Timestamp");
            }

            var calendar_entries = await _calendarservice.get_calendar_entries_within_range(ts1, ts2);
            return Ok(calendar_entries);

        }

        [HttpGet]
        [Authorize]
        [Route("get_calander_entry_from_email")]
        public async Task<IActionResult> get_calander_entry_from_email(String email)
        {
            var calander_entry = await _calendarservice.get_calander_entry_from_email(email);
            if (calander_entry == null)
            {
                throw new Exception("No calander entry found!");
            }
            return Ok(calander_entry);
        }

        [HttpPost]
        [Authorize]
        [Route("addcalendar")]
        public async Task<ActionResult<Boolean>> addCalendarData(List<Calendar> cal)
        {
            System.Diagnostics.Debug.WriteLine(cal[0].starttime);
            var result = await _calendarservice.addCalendarData(cal);
            System.Diagnostics.Debug.WriteLine(result);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("getcalendar")]
        public async Task<ActionResult<IEnumerable<Calendar>>> getCalendarData()
        {
            
            var result = await _calendarservice.getCalendarData();
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("setstatus")]
        public async Task<IActionResult> setCalendarStatus(string email, string status)
        {
            var result = await _calendarservice.setCalendarStatus(email, status);
            return Ok(result);
        }

        [HttpPost]
    //    [Authorize]
        [Route("send_interview_email")]
        public async Task<SendGrid.Response> send_inteview_email(string from_email, string to_email, string url, string startdate, string enddate)
        {
            System.Diagnostics.Debug.WriteLine(to_email);

            return await _calendarservice.send_inteview_email(from_email, to_email, url, startdate, enddate);
        }


    }
}
