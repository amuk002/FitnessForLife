using System.Web;
using System.Web.Optimization;

namespace FitnessForLife
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-mytheme.css",
                      "~/Content/site.css",
                      "~/Content/fullcalendar.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css" +
                      "~/Contents/bootstrap-datepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                     "~/Scripts/lib/jquery.min.js",
                     "~/Scripts/lib/moment.min.js",
                     "~/Scripts/fullcalendar.js",
                     "~/Scripts/calendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapbox").Include(
                     "~/Scripts/location.js"));
        }
    }
}
