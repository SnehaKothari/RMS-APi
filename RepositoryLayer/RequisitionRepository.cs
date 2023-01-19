using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.RepositoryLayer
{
    public class RequisitionRepository : IRequisitionRepository
    {

        private readonly Recruitmentcontext _context;
        public RequisitionRepository(Recruitmentcontext context)
        {
            _context = context;
        }

        public async Task<bool> AddRequisition(Requisition r)
        {
            if (r.jobdescription == null)
            {
                r.jobdescription = "";
            }
            else
            {
                r.jobdescription = r.jobdescription;
            }
            if (r.vacancies == 0)
            {
                throw new Exception("Vaccancy cannot be Left Empty");

            }
            else
            {
                r.vacancies = r.vacancies;
            }

            if (r.requiredexperience == null)
            {
                throw new Exception("Expirence cannot be Left Empty");

            }
            else
            {
                r.requiredexperience = r.requiredexperience;
            }

            await _context.requisition.AddAsync(r);
            await _context.SaveChangesAsync();
            return true;
        }


       public async Task<ActionResult<IEnumerable<Requisition>>> getallrequisition()
        {
            var result = await _context.requisition.ToListAsync();

            return result;
        }

    }
    
}




        
