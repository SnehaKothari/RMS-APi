using Microsoft.AspNetCore.Http;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.ServiceLayer
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _repository;

        public ResumeService(IResumeRepository repository)
        {
            _repository = repository;
        }

        public async Task<DateTime> get_date_time(int id)
        {
            return await _repository.get_date_time(id);
        }

        public async Task<List<CandidateResume>> get_resumes_within_range(DateTime start, DateTime end)
        {
            return await _repository.get_resumes_within_range(start, end);
        }

        public async Task<Boolean> setStatusCandidate(string email, string status) 
        {
            return await _repository.setStatusCandidate(email, status);
        }

        public async Task<IEnumerable<CandidateResume>> fetchAllResumes() {
            return await _repository.fetchAllResumes();
        }

        public async Task<bool> uploadfile(List<IFormFile> FormFile) {
            return await _repository.uploadfile(FormFile);
        }




    }
}
