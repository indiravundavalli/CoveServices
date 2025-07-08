using CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Data.Repository
{
    public interface IServiceRepository
    {
        void AddService(Service newService);

        Task<IEnumerable<Service>> GetServices();

        void DeleteService(int serviceId);
    }
}
