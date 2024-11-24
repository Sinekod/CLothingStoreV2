using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Contracts
{
    public interface IRoleManagerService
    {
        public Task<bool> CreateRole(string roleName);
        public Task<bool> DeleteRole(string roleName);
        
        public Task<IEnumerable<IdentityRole>> GetAllAvailableRoles();



    }
}
