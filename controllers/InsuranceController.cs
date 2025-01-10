using backend.DTO;
using backend.Interfaces;
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
        [HttpPost]
        public async Task<IActionResult> AddInsurance([FromForm] InsuranceDto model) 
         {
            var status = new Status(); 
            if(!ModelState.IsValid){
                status.StatusCode = 0;
                status.Message = "Please pass valid data";
                return Ok(status);
            }
            try
            {
              var insuranceResult = await _insuranceInterface.AddInsuranceAsync(model); 
            if(insuranceResult)
              {
                status.StatusCode = 1;
                status.Message = "Added successfully";
              }
              else{
                status.StatusCode = 0;
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