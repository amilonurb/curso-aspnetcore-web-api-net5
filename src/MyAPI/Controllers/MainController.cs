using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            return CustomResponse();
        }

        protected IActionResult CustomResponse(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}