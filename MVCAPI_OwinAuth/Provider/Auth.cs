using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVCAPI_OwinAuth.Provider
{
    //public class Auth : AuthorizeAttribute
    //{
    //    protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
    //    {
    //        return false;
    //        //if (!HttpContext.Current.User.Identity.IsAuthenticated)
    //        //{
    //        //    base.HandleUnauthorizedRequest(actionContext);
    //        //}
    //        //else
    //        //{
    //        //    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
    //        //}
    //    }
    //    protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
    //    {
    //        if (!HttpContext.Current.User.Identity.IsAuthenticated)
    //        {
    //            base.HandleUnauthorizedRequest(actionContext);
    //        }
    //        else
    //        {
    //            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
    //        }
    //    }
    //}
}