using Microsoft.AspNetCore.Mvc;
using recruitmentmanagementsystem.CommonModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.RepositoryLayer
{
    public interface IRequisitionRepository
    {
        Task<bool> AddRequisition(Requisition r);

        Task<ActionResult<IEnumerable<Requisition>>> getallrequisition();

        

    }

       
}
    
