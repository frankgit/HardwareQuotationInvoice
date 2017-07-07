using System.Web;
using System.Web.Optimization;

namespace HardwareQuotationInvoice
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-table/bootstrap-table.css",
                      "~/Content/group-by-v2/bootstrap-table-group-by.css"
                      ));

            //bundles.Add(new StyleBundle("~/Content/group-by-v2").Include(
            //   "~/Content/group-by-v2/bootstrap-table-group-by.css"));

            bundles.Add(new ScriptBundle("~/bundles/group-by-v2").Include(
            "~/Scripts/group-by-v2/bootstrap-table-group-by.js"));

            //bundles.Add(new StyleBundle("~/Content/bootstrap-table").Include(
            //"~/Content/bootstrap-table/bootstrap-table.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-table").Include(
            "~/Scripts/bootstrap-table/bootstrap-table.js"));
        }
    }
}
