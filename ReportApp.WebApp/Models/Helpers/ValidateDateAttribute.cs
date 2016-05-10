﻿using System;
using System.Web.Mvc;
using ReportApp.WebApp.Controllers;

namespace ReportApp.WebApp.Models.Helpers
{
    public class ValidateDateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var y = filterContext.GetActionParameterByKeyOrDefault("year", DateTime.Now.Year);
            var m = filterContext.GetActionParameterByKeyOrDefault("month", DateTime.Now.Month);
            var d = filterContext.GetActionParameterByKeyOrDefault("day", DateTime.Now.Day);

            if (!IsCorrectDate(y, m, d) && !filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.Result = new RedirectResult("~/Views/Shared/_WrongDate");
        }

        private bool IsCorrectDate(int y, int m, int d)
        {
            if (y > DateTime.Now.Year || y <= 2010)
                return false;

            if (m >= 13 || m <= 0)
                return false;

            if (d > DateTime.DaysInMonth(y, m) || d <= 0)
                return false;

            return true;
        }
    }
}
