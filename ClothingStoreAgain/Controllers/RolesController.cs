using ClothingStore.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreAgain.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        private readonly IRoleManagerService roleManagerService;

        public RolesController(IRoleManagerService roleManagerService)
        {
            this.roleManagerService = roleManagerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromForm]string roleName)
        { 
          var created = await roleManagerService.CreateRole(roleName);

            if (created==false)
            {
                return BadRequest("Role already exists");
            }

            return View("RoleAddedSuccesfully");

        }
        [HttpGet]
        public async Task<IActionResult> AddRole() 
        {
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole([FromForm] string roleName)
        {
            var created = await roleManagerService.DeleteRole(roleName);

            if (created == false)
            {
                return BadRequest("Role does not exists");
            }

            return View("RoleDeletedSuccesfully");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole()
        {
            var roles = await roleManagerService.GetAllAvailableRoles();
            return View(roles);

        }





    }
}
