
namespace DRBlog.Web.Framework.Controllers
{
    using System;
    using System.Web.Routing;
    using Web.Controllers;

    public class AsyncController : BaseController
    {
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            // custom Authentication 
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}