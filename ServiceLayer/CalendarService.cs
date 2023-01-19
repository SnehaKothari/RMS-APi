using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.ServiceLayer
{
    public class CalendarService : ICalendarService
    {
        private readonly  ICalendarRepository _repository;

        public CalendarService(ICalendarRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<Calendar>> get_calendar_entries_within_range(DateTime start, DateTime end)
        {
            return await _repository.get_calendar_entries_within_range(start, end);
        }

        public async Task<List<Calendar>> get_calander_entry_from_email(string email)
        {
            return await _repository.get_calander_entry_from_email(email);
        }

        public async Task<IEnumerable<Calendar>> getCalendarData() 
        {
            return await _repository.getCalendarData();
        }

        public async Task<Boolean> addCalendarData(List<Calendar> cal) {
            return await _repository.addCalendarData(cal);
        }

        public async Task<Boolean> setCalendarStatus(string email, string status) {
            return await _repository.setCalendarStatus(email, status);
        }

        public async Task<SendGrid.Response> send_inteview_email(string from_email, string to_email, string url, string startdate, string enddate) {
            return await _repository.send_inteview_email(from_email, to_email, url, startdate, enddate);
        }

    }
}
