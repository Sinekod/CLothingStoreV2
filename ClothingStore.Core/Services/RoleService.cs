using ClothingStore.Core.Contracts;
using Microsoft.AspNetCore.Identity;

namespace ClothingStore.Core.Services
{
    public class RoleService : IRoleManagerService
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string roleName)
        {
            var role = new IdentityRole(roleName);
            if (await roleManager.FindByNameAsync(roleName)==null)
            {
                await roleManager.CreateAsync(role);
                return true;
            }

            return false;
          

        }

        public async Task<bool> DeleteRole(string roleName)
        {
            var role = roleManager.FindByNameAsync(roleName);
            if (role.Result==null)
            {
                return false;
            }
            await roleManager.DeleteAsync(role.Result);
            return true;
            
        }

        public async Task<IEnumerable<IdentityRole>> GetAllAvailableRoles()
        {
           return roleManager.Roles.ToList();
        }
    }
}