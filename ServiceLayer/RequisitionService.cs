using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.Data;
using recruitmentmanagementsystem.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.ServiceLayer
{
    public class RequisitionService: IRequisitionService
    {
        private readonly IRequisitionRepository _repository;
        public RequisitionService(IRequisitionRepository repository)
        {
            _repository = repository;
        }

       
        public async Task<bool> AddRequisition(Requisition r)
        {

            return await _repository.AddRequisition(r);
           

        }

        public async Task<ActionResult<IEnumerable<Requisition>>> getallrequisition()
        {

            return await _repository.getallrequisition();
           
        }

       
    }
}
