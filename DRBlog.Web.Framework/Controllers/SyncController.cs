
using DRBlog.Web.Framework.Controllers;

namespace DRBlog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class SyncController : BaseController<T> where T RequestInvokeType
{
}
}