using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;
using Web.DAL;
using Web.Models;

namespace Web.Business
{
    public class UrlAuthorizeAttribute : AuthorizeAttribute
    {
        ERPDAL db = new ERPDAL();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            //登录
            if (controllerName == "Authentication")
            {
                return;
            }

            //登录
            if (!filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                RedirectToLogin(filterContext);
                return;
            }

            string requestUrl = filterContext.HttpContext.Request.Url.AbsolutePath.ToLower();
            requestUrl = Regex.Replace(requestUrl, @"(&|\?)f=\d+", "", RegexOptions.IgnoreCase);

            //确定当前用户是否属于指定角色
            string query = @"select * from SysFunc where SysFuncID in (select SysFuncID from SysPower where SysRoleID in (select ID from SysRole where ID in (select SysRoleID from SysUserRole where UserName='@userName')))";
            string currentUser = filterContext.HttpContext.User.Identity.Name;
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@userName",currentUser)
            };
            IList<SysFunc> userFuncs = db.Database.SqlQuery<SysFunc>(query, paras).ToList();

            if (userFuncs == null || userFuncs.Count == 0)
                RedirectToUnauthorized(filterContext);
            else
            {
                SysFunc func = userFuncs.Where(
                    p => !string.IsNullOrEmpty(p.URL)
                         && p.LowerUrls.Where(u => u.StartsWith(requestUrl)).Count() > 0)
                        .FirstOrDefault();

                if (func == null)
                    RedirectToUnauthorized(filterContext);
            }
        }

        /// <summary>
        /// 跳转到未授权页面
        /// </summary>
        /// <param name="filterContext"></param>
        void RedirectToUnauthorized(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new EmptyResult();
                HttpResponseBase response = filterContext.HttpContext.Response;
                response.StatusCode = 403;
                response.Clear();
                response.Write("没有权限使用该功能！");
                response.End();
            }
            else
                RedirectToLogin(filterContext);
        }

        /// <summary>
        /// 跳转到登录页面
        /// </summary>
        /// <param name="filterContext"></param>
        void RedirectToLogin(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl);
        }
        
    }
}