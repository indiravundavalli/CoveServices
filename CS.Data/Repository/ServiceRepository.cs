using CS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public readonly DataContext _dbContext;
        public ServiceRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddService(Service newService)
        {
            _dbContext.Services.AddAsync(newService);
            _dbContext.SaveChanges();
        }

        public void DeleteService(int serviceId)
        {
            var service = _dbContext.Services.FirstOrDefault(i => i.Id == serviceId);
            if (service != null)
                _dbContext.Services.Remove(service);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _dbContext.Services.ToListAsync();
        }
    }
}
