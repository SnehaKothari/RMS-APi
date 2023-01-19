using Microsoft.AspNetCore.Mvc;
using recruitmentmanagementsystem.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.RepositoryLayer
{
    public interface ICalendarRepository
    {
        Task<List<Calendar>> get_calendar_entries_within_range(DateTime start, DateTime end);
        Task<List<Calendar>> get_calander_entry_from_email(String email);
        Task<IEnumerable<Calendar>> getCalendarData();
        Task<Boolean> addCalendarData(List<Calendar> cal);
        Task<Boolean> setCalendarStatus(string email, string status);
        Task<SendGrid.Response> send_inteview_email(string from_email, string to_email, string url, string startdate, string enddate);

    }
}
