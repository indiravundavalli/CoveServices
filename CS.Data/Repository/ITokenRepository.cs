using CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Data.Repository
{
    public interface ITokenRepository
    {
        Task<string> CreateTokenAsync(User user);
    }
}
