using ReportApp.Controllers;
using ReportApp.Models.Helpers;
using System;
using System.Web.Mvc;

namespace ReportApp.Models.Helpers
{
    public class ValidateDateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as ReportController;

            var y = filterContext.GetActionParameterByKeyOrDefault("year", DateTime.Now.Year);
            var m = filterContext.GetActionParameterByKeyOrDefault("month", DateTime.Now.Month);
            var d = filterContext.GetActionParameterByKeyOrDefault("day", DateTime.Now.Day);

            if (!IsCorrectDate(y, m, d))
                filterContext.Result = controller.ToAction("WrongDate");

            base.OnActionExecuting(filterContext);
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
