﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace BlogMVC.Custom_Attributes
{
    public class MyAuthenticationAttribute:FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new ContentResult { Content = "<b>You must <a href='/Account/Login'>log in</a></b>" };
                
            }
            if (user == null || user.IsInRole("Blocked User"))
            {
                filterContext.Result = new ContentResult { Content = "<b>You're blocked" };

            }

        }
    }
}