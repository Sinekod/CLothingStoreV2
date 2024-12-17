using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreAgain.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult Error404()
        {
            Response.StatusCode = 404;
            return View(); // View/Error/Error404.cshtml
        }

        [Route("Error/500")]
        public IActionResult Error500()
        {
            Response.StatusCode = 500;
            return View(); // View/Error/Error500.cshtml
        }
    }
}
