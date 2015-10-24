using System.Web.Optimization;

namespace ReportApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                               "~/Scripts/jquery-{version}.js",
                               "~/Scripts/jquery.validate*",
                               "~/Scripts/modernizr-*",
                               "~/Scripts/bootstrap.js",
                               "~/Scripts/calendar.js",
                               "~/Scripts/calendarCommon.js"
                               ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                              "~/Content/css/bootstrap.min.css",
                              "~/Content/css/Site.css",
                              "~/Content/css/calendar.css"
                              ));
        }
    }
}