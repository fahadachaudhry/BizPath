using BizPath.Interfaces;
using Common.Enums;
using Common.Exceptions;
using Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace BizPath.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : Controller
    {
        private readonly IBusinessWorkflowService _businessWorkflowService;

        public BusinessController(IBusinessWorkflowService businessWorkflowService)
        {
            this._businessWorkflowService = businessWorkflowService;
        }

        [HttpPost]
        [Route("/create-new")]
        public IActionResult CreateNew()
        {
            return Ok(_businessWorkflowService.CreateNew());
        }

        [HttpPut]
        [Route("/move-next")]
        public IActionResult MoveNext([FromBody] Business business)
        {
            //************* START ASSUMPTION **************//
            // Assuming that the industry is the starting point and a deciding factor for the
            // Workflow Engine's Polymorphic Strategy (Bahavioural Pattern) - It is kept mandatory
            // For a successful workflow triggering
            //************* END ASSUMPTION **************//

            if (business.Industry == null)
            {
                return BadRequest(ExceptionLookup.InvalidWorkflowExceptionMessage);
            }
            return Ok(_businessWorkflowService.MoveNext(business));
        }

        [HttpPut]
        [Route("/won")]
        public IActionResult Won([FromBody] Business business)
        {
            if (business.Industry == null
                || business.Contact == null
                || business.WorkflowStatus != WorkflowStatusEnum.MARKET_APPROVED)
            {
                return BadRequest(ExceptionLookup.InvalidWorkflowExceptionMessage);
            }
            return Ok(_businessWorkflowService.Win(business));
        }

        [HttpPut]
        [Route("/lost")]
        public IActionResult Lost([FromBody] Business business)
        {
            if (business.Industry == null
                || business.Contact == null
                || business.WorkflowStatus != WorkflowStatusEnum.MARKET_APPROVED)
            {
                return BadRequest(ExceptionLookup.InvalidWorkflowExceptionMessage);
            }
            return Ok(_businessWorkflowService.Lose(business));
        }
    }
}
