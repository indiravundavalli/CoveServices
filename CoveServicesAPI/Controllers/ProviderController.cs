using CS.Data.Repository;
using CS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoveServicesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : Controller
    {
        private readonly IProviderRepository _providerRepo;
        public ProviderController(IProviderRepository providerRepository)
        {
            _providerRepo = providerRepository;
        }

        [HttpPost]
        public IActionResult AddProvider([FromBody] ServiceProviders newProvider)
        {
            _providerRepo.AddProvider(newProvider);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProvider(int providerId)
        {
            var provider = await _providerRepo.GetServiceProvider(providerId);
            if (provider == null)
            {
                return NotFound();
            }
            return Ok(provider);
        }
    }
}
