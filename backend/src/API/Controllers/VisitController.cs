using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VisitController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetComplaintsByPhoneNumber(string phoneNumber) 
        {
            var customers = await _unitOfWork.CsCustomers.FindAsync(e=>e.Mobile == phoneNumber || e.Home == phoneNumber);

            if (customers.Count()<= 0)
                return BadRequest($"no customer existing with this phone {phoneNumber}");

            //get visits
            var targetCustomer = customers.SingleOrDefault();
            var visits = await _unitOfWork.CsVisits.GetVisitsByCustomerIdAsync(targetCustomer.CustomerId);
            return Ok( new { customer = targetCustomer, visits = visits });
        }
    }
}
