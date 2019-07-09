using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Helpers
{
    public class Auth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["IsLogin"] == null || (bool)HttpContext.Current.Session["IsLogin"] == false)
            {
                filterContext.Result = new RedirectResult("Login/Index");
            }
          
          
            base.OnActionExecuting(filterContext);
        }
    }
}