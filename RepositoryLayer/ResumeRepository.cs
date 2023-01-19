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

namespace recruitmentmanagementsystem.RepositoryLayer
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly Recruitmentcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResumeRepository(Recruitmentcontext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
  
        public Task<DateTime> get_date_time(int id)
        {
            var temp = _context.candidateresume.FirstOrDefault(x => x.id == id);
            if (temp == null) {
                throw new Exception("Candidate does not exists!");
            }
            return Task.FromResult(temp.date_time_of_creation);
        }


        public Task<List<CandidateResume>> get_resumes_within_range(DateTime start, DateTime end)
          {
              var resumes = _context.candidateresume.Where(x => x.date_time_of_creation >= start && x.date_time_of_creation <= end).ToListAsync();
              return resumes;
          }

        public async Task<Boolean>  setStatusCandidate(string email, string status)
        {
           
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

        public async Task<IEnumerable<CandidateResume>> fetchAllResumes() { 
            return await _context.candidateresume.ToListAsync(); 
        }

        public async Task<bool> uploadfile(List<IFormFile> FormFile)
        {
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Resumes\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Resumes\\");
            }


            foreach (var file in FormFile)
            {

                var dir = _webHostEnvironment.WebRootPath + "\\Resumes\\";



                using (var fileStream = new FileStream(Path.Combine(dir, file.FileName), FileMode.Create, FileAccess.Write))

                {
                    file.CopyTo(fileStream);


                    string candiadte_before, candiadte_after;
                    candiadte_before = file.FileName;


                    candiadte_after = candiadte_before.Remove(candiadte_before.Length - 4, 4);

                    double probability_matching = 0;

                    string matched_jd = "";



                    Resumes r = new Resumes();
                    r.resume_name = file.FileName;
                    await _context.resume.AddAsync(r);

                    await _context.SaveChangesAsync();

                }


            }


            return true;

        }

    }
}
