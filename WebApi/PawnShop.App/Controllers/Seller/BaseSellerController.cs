using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawnShop.App.Controllers.Seller
{
    [Authorize(Roles = "Seller")]
    public abstract class BaseSellerController : BaseController
    {
        protected string SellerId => User?.Identity?.Name;

        protected string? GetClaim(string claimType)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}
