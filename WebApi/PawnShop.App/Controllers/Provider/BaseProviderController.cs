using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawnShop.App.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    public abstract class BaseProviderController : BaseController
    {
        protected string ProviderId => User?.Identity?.Name;

        protected string? GetClaim(string claimType)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}
