using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EARGE.Team.Controllers
{
    public class BaseAuthController : BaseController
    {
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state) {
            if (this.CURRENT_TEAM_MEMBER == null)
                System.Web.HttpContext.Current.Response.Redirect("~/account/login?returnUrl="+System.Web.HttpContext.Current.Request.RawUrl);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}