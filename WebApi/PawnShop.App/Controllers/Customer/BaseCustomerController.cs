using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawnShop.App.Controllers.Customer
{
    [Authorize(Roles = "Customer")]
    public abstract class BaseCustomerController : BaseController
    {
        protected string CustomerId => User?.Identity?.Name;

        protected string? GetClaim(string claimType)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}
