using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LaboBackEnd.Filters
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {

        public AuthorizationAttribute(params string[] authorizationRoles)
        {
            _authorizationRoles = authorizationRoles;
        }
        private string[] _authorizationRoles;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_authorizationRoles.Length == 0)
            {
                if (!(context.HttpContext.User.Identity?.IsAuthenticated?? false))
                {
                    if (!context.HttpContext.Request.Path.StartsWithSegments("Account") && ! context.HttpContext.Request.Path.StartsWithSegments("User")) 
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            else
            {
                if (!_authorizationRoles.Any(r=> context.HttpContext.User.IsInRole(r)))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
