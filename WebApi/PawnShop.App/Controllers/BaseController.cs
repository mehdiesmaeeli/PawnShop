using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawnShop.App.Common.Models;

namespace PawnShop.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected Guid UserId => Guid.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        protected string UserName => User?.Identity?.Name;
        protected IActionResult ApiOk<T>(T data, string message = "Success") =>
            Ok(ApiResponse<T>.Ok(data, message));

        protected IActionResult ApiError(string message, List<string> errors = null) =>
            BadRequest(ApiResponse<string>.Error(message, errors, HttpContext.TraceIdentifier));

        protected IActionResult ApiUnauthorized(string message, List<string> errors = null) =>
            Unauthorized(ApiResponse<string>.Error(message, errors, HttpContext.TraceIdentifier));

        protected IActionResult ApiNotFound(string message, List<string> errors = null) =>
            NotFound(ApiResponse<string>.Error(message, errors, HttpContext.TraceIdentifier));
    }
}
