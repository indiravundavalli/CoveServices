using CS.Data.Repository;
using CS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoveServicesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepo = serviceRepository;
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddService([FromBody] Service newService)
        {
            _serviceRepo.AddService(newService);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _serviceRepo.GetServices();
            return Ok(services);
            
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteService(int serviceId)
        {
            _serviceRepo.DeleteService(serviceId);
            return Ok();
        }
    }
}
