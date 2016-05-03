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
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/modernizr-*",
                "~/Scripts/select2/select2.min.js",
                "~/Scripts/calendar.js",
                "~/Scripts/calendarCommon.js",
                "~/Scripts/report.js",
                "~/Scripts/validator.js",
                "~/Scripts/newRecordDialog.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/smoothness/jquery-ui.css",
                "~/Content/css/select2/select2.min.css",
                "~/Content/css/Site.css",
                "~/Content/css/calendar.css"
            ));
        }
    }
}