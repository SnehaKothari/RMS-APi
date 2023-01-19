using Microsoft.AspNetCore.Http;
using recruitmentmanagementsystem.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.ServiceLayer
{
    public interface IResumeService
    {
       Task<DateTime> get_date_time(int id);

       Task<List<CandidateResume>> get_resumes_within_range(DateTime start, DateTime end);

        Task<Boolean> setStatusCandidate(string email, string status);

        Task<IEnumerable<CandidateResume>> fetchAllResumes();

        Task<bool> uploadfile(List<IFormFile> FormFile);

    }
}
