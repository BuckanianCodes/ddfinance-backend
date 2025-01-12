using backend.DTO;
using backend.Interfaces;
using backend.models;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
 

    public class InsuranceController : ControllerBase
    {
        //private readonly IMapper mapper;
        private readonly InsuranceInterface _insuranceInterface;
        public InsuranceController(InsuranceInterface insuranceInterface)
        {
          _insuranceInterface = insuranceInterface ;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Insurance>>> GetInsurances([FromQuery] string search = "")
        {
          var insurances = await _insuranceInterface.ListInsurancesAsync(search);
          return Ok(insurances);
        }
        [HttpDelete("{insuranceId}")]
        public async Task<IActionResult> DeleteInsurance(int insuranceId)
        {
          var status = new Status();
          try
          {
            var insuranceResult = await _insuranceInterface.DeleteInsuranceAsync(insuranceId);
            if(insuranceResult){
               status.StatusCode = 200;
              status.Message = "Policy Deleted successfully";
            }
            else{
                status.StatusCode = 404;
                status.Message = "Error deleting policy";
              }
              return Ok(status);
          }
           catch (Exception ex)
                {
                     return StatusCode(StatusCodes.Status500InternalServerError, new Status
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
                }
        }
        [HttpPut("{insuranceId}")]
        public async Task<IActionResult> UpdateInsurance(int insuranceId,InsuranceDto model)
        {
           var status = new Status(); 
            if(!ModelState.IsValid){
                status.StatusCode = 400;
                status.Message = "Please pass valid data";
                return Ok(status);
            }
            try
            {
              var insuranceResult = await _insuranceInterface.UpdateInsuranceAsync(insuranceId,model);
               if(insuranceResult)
              {
                status.StatusCode = 201;
                status.Message = "Updated successfully";
              }
              else{
                status.StatusCode = 404;
                status.Message = "Error updating policy";
              }
              return Ok(status);
            }
             catch (Exception ex)
                {
                     return StatusCode(StatusCodes.Status500InternalServerError, new Status
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
                }
        }
        [HttpPost]
        public async Task<IActionResult> AddInsurance([FromForm] InsuranceDto model) 
         {
            var status = new Status(); 
            if(!ModelState.IsValid){
                status.StatusCode = 400;
                status.Message = "Please pass valid data";
                return Ok(status);
            }
            try
            {
              var insuranceResult = await _insuranceInterface.AddInsuranceAsync(model); 
            if(insuranceResult)
              {
                status.StatusCode = 201;
                status.Message = "Added successfully";
              }
              else{
                status.StatusCode = 404;
                status.Message = "Error adding a policy";
              }
              return Ok(status);
            }
           catch (Exception ex)
                {
                     return StatusCode(StatusCodes.Status500InternalServerError, new Status
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
                }

         }
    }
}