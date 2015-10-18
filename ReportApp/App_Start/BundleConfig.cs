using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                               "~/Scripts/reportCommon.js"
                               ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                              "~/Content/bootstrap.min.css",
                              "~/Content/Site.css",
                              "~/Content/calendar.css"
                              ));
        }
    }
}