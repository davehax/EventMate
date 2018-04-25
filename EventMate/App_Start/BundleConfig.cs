using System.Web;
using System.Web.Optimization;

namespace EventMate
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Common
            bundles.Add(new ScriptBundle("~/bundles/eventmate-common").Include(
                    "~/Scripts/eventmate-common.js"
                ));

            // Datetime Picker
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                    "~/Scripts/moment-with-locales.min.js",
                    "~/Scripts/bootstrap-datetimepicker.min.js"
                ));

            bundles.Add(new StyleBundle("~/content/datetimepicker").Include(
                    "~/Content/bootstrap-datetimepicker.min.css"
                ));

            // Events
            bundles.Add(new ScriptBundle("~/bundles/events-create").Include(
                    "~/Scripts/Events/events-create.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/events-edit").Include(
                    "~/Scripts/Events/events-edit.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/attendees-table").Include(
                    "~/Scripts/Attendances/attendees-table.js"
                ));

            // Quill JS/CSS
            bundles.Add(new ScriptBundle("~/bundles/quill").Include(
                    "~/Scripts/quill.min.js"
                ));

            bundles.Add(new StyleBundle("~/content/quill").Include(
                    "~/Content/quill.snow.css"
                ));
        }
    }
}
