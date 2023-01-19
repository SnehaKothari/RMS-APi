using Microsoft.AspNetCore.Mvc;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.ServiceLayer
{
    public interface IRequisitionService
    {

         Task<bool> AddRequisition(Requisition r);


        Task<ActionResult<IEnumerable<Requisition>>> getallrequisition();

      

    }
}
