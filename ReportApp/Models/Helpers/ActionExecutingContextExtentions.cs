using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportApp.Models.Helpers
{
    public static class ActionExecutingContextExtentions
    {
        public static T GetActionParameterByKeyOrDefault<T>(this ActionExecutingContext filterContext, string key, T defaultValue)
        {
            return filterContext.ActionParameters[key] == null ? defaultValue : (T)filterContext.ActionParameters[key];
        }
    }
}