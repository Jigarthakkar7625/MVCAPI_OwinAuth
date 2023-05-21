using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVCAPI_OwinAuth.Provider
{
    //public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    //{
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated(); // 
    //    }
    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    //        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

    //        using (var db = new TestDBMAJwtEntities())
    //        {
    //            if (db != null)
    //            {
    //                var empl = db.Employees.ToList();
    //                var user = db.Users.ToList();
    //                if (user != null)
    //                {
    //                    if (!string.IsNullOrEmpty(user.Where(u => u.UserName == context.UserName && u.Password == context.Password).FirstOrDefault().Name))
    //                    {
    //                        identity.AddClaim(new Claim("Age", "16"));
    //                        identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
    //                        context.Validated(identity);
    //                    }
    //                    else
    //                    {
    //                        context.SetError("invalid_grant", "Provided username and password is incorrect");
    //                        context.Rejected();
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                context.SetError("invalid_grant", "Provided username and password is incorrect");
    //                context.Rejected();
    //            }
    //            return;
    //        }

    //    }
    //}
}