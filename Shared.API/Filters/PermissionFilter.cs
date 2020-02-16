using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Shared.API.Filters
{
    public class PermissionFilter : Attribute, IActionFilter
    {
             public PermissionFilter(){ }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var per = new ClsUserPermission(_db, _userService).GetUserPermissions().GetAwaiter().GetResult();
            //if (!per.Permissions.Any())
            //{
            //    //context.Result = new RedirectResult("~/MyPage");
            //    // return;
            //    Redirect(context);
            //}
            //else
            //{
            //    var check = per.Permissions.Where(x => x.SubPermissions.Any(t => t.ControllerName.ToLower() == _controller.ControllerName.ToLower()
            //    && t.ActionName.ToLower() == _controller.ActionName.ToLower())).ToList();
            //    if (!check.Any())
            //        Redirect(context);
            //}
        }

        private void Redirect(ActionExecutingContext context)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "auth", "Login" }, { "action", "Unauthorized" } });
            var url = context.HttpContext.Request.Host.Value + "/";
            var returnUrl = Convert.ToString(url);
            if (string.IsNullOrEmpty(returnUrl)) return;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
            return;
        }
    }
}
