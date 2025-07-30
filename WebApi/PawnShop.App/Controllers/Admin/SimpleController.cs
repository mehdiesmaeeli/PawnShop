using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawnShop.App.Controllers.Admin
{
    public class SimpleController : BaseAdminController
    {
        [HttpGet("super-only")]
        [Authorize(Policy = "SuperAdminOnly")]
        public IActionResult GetSensitiveData()
        {
            var adminLevel = GetClaim("AccessLevel");

            return Ok(new
            {
                message = "This is only for Super Admins",
                UserId,
                adminLevel,
                UserName,
            });
        }

        // این متد برای همه ادمین‌ها باز است
        [HttpGet("basic")]
        public IActionResult GetBasicData()
        {
            return Ok("All admins can access this.");
        }
    }
}
