using CS.Models;

namespace CS.Data.Repository
{
    public interface IProviderRepository
    {
        void AddProvider(ServiceProviders newProvider);

        Task<ServiceProviders> GetServiceProvider(int providerId);

        void UpdateProvider(ServiceProviders updateProvider);

        Task<ServiceProviders> SearchProviders(int serviceId);

    }
}
