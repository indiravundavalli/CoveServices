using CS.Models;
using Microsoft.EntityFrameworkCore;

namespace CS.Data.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly DataContext _dbContext;
        public ProviderRepository (DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProvider(ServiceProviders newProvider)
        {
            int newUserId = 0; 
            if(newProvider.User != null)
            {
                User newUser = new User
                {
                    Name = newProvider.User.Name,
                    UserName = newProvider.User.UserName,
                    Password = newProvider.User.Password,
                    Email = newProvider.User.Email,
                    Phone = newProvider.User.Phone,
                    RoleId = newProvider.User.RoleId
                };
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                newUserId = newUser.ID;
            }
        

            if(newProvider.services != null && newUserId > 0)
            {
                foreach(var service in newProvider.services)
                {
                    var serviceProvider = new ServiceProviders
                    {
                        UserId = newUserId,
                        ServiceId = service.Id
                    };

                    _dbContext.ServiceProviders.Add(serviceProvider);
                    
                }
            }
            _dbContext.SaveChanges();            
            
        }

        public async Task<ServiceProviders> GetServiceProvider(int providerId)
        {
            ServiceProviders provider = new ServiceProviders();
            provider.User = await _dbContext.Users.FirstOrDefaultAsync(i => i.ID == providerId);
            provider.services = await _dbContext.ServiceProviders
                                .Where(sp => sp.UserId == providerId)
                                .Join(
                                    _dbContext.Services,
                                    sp => sp.ServiceId,
                                    s => s.Id,
                                    (sp, s) => s
                                )
                                .ToListAsync();
            return provider;
        }

        public void UpdateProvider(ServiceProviders updateProvider)
        {
            throw new NotImplementedException();
        }

        Task<ServiceProviders> IProviderRepository.SearchProviders(int serviceId)
        {
            throw new NotImplementedException();
        }
    }
}
