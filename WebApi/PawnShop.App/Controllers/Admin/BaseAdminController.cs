using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawnShop.App.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public abstract class BaseAdminController : BaseController
    {
        protected string? GetClaim(string claimType)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}
