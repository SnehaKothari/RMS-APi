using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.Data;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.RepositoryLayer
{
    public class CalanderRepository : ICalendarRepository
    {
        private readonly Recruitmentcontext _context;

        public CalanderRepository(Recruitmentcontext context) {
            _context = context;
        }

        public Task<List<Calendar>> get_calendar_entries_within_range(DateTime start, DateTime end)
        {
            var calendar_entry = _context.calendar.Where(x => x.starttime >= start && x.starttime <= end).ToListAsync();
            return calendar_entry;
        }

        public Task<List<Calendar>> get_calander_entry_from_email(String email)
        {
            var calander_entry = _context.calendar.Where(x => x.email == email).ToListAsync();
            return calander_entry;
            //  return calander_entry;

        }

        public async Task<IEnumerable<Calendar>> getCalendarData() {
            return await _context.calendar.ToListAsync();
        }

        public async Task<Boolean> addCalendarData(List<Calendar> cal) {
            foreach (Calendar x in cal)
            {
                var exist = _context.calendar.Any(o => o.id == x.id);
                if (!exist) await _context.calendar.AddAsync(x);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Boolean> setCalendarStatus(string email, string status) {
            var result1 = _context.candidateresume.FirstOrDefault(resume => resume.email == email);
            var result2 = _context.calendar.FirstOrDefault(o => o.email == email);

            if (result1 != null && result2 != null)
            {
                result1.status = status;
                result2.status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<SendGrid.Response> send_inteview_email(string from_email, string to_email, string url, string startdate, string enddate)
        {

            System.Diagnostics.Debug.WriteLine(to_email);
            startdate = startdate.Substring(0, 19);
            enddate = enddate.Substring(0, 19);
            // System.Diagnostics.Debug.WriteLine(startdate);
            //   System.Diagnostics.Debug.WriteLine(enddate);


            var start = DateTime.Parse(startdate);
            var end = DateTime.Parse(enddate);


            var date = start.ToShortDateString();
            var starttime = start.ToShortTimeString();
            var endtime = end.ToShortTimeString();
            //    System.Diagnostics.Debug.WriteLine(date + starttime + endtime);

            var sendGridClient = new SendGridClient("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");

            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(from_email, "AugmentoLabs");
            // for multiple emails 
            var email_list = to_email.Split(',');
            foreach (var email in email_list)
            {
                sendGridMessage.AddTo(email);
            }

            sendGridMessage.SetTemplateId("d-dbca16e645254e2994d3dc297945b64f");

            sendGridMessage.SetTemplateData(new InterviewEmail
            {
                // Name = "sujith",
                // Url = "https://meet.google.com/gqn-tuap-inz"
                Url = url,
                Date = date,
                StartTime = starttime,
                EndTime = endtime

            });

            var response = sendGridClient.SendEmailAsync(sendGridMessage).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {

                System.Diagnostics.Debug.WriteLine("email sent");
            }


            return response;
        }


    }
}
