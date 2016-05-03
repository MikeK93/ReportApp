using System.Web.Optimization;

namespace ReportApp.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                               "~/Scripts/jquery-{version}.js",
                               "~/Scripts/jquery.validate*",
                               "~/Scripts/jquery-ui.js",
                               "~/Scripts/modernizr-*",
                               "~/Scripts/bootstrap.js",
                               "~/Scripts/calendar.js",
                               "~/Scripts/calendarCommon.js",
                               "~/Scripts/report.js",
                               "~/Scripts/dropdown.js",
                               "~/Scripts/validator.js"
                               ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                              "~/Content/css/bootstrap.min.css",
                              "~/Content/css/smoothness/jquery-ui.css", 
                              "~/Content/css/Site.css",
                              "~/Content/css/calendar.css",
                              "~/Content/css/newRecordDialog.css",
                              "~/Content/css/custom-dropdown.css"
                              ));
        }
    }
}