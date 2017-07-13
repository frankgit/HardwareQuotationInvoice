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
                      "~/Content/site.css"

                      ));

            bundles.Add(new StyleBundle("~/Content/bootstrap-table").Include(
                    "~/Content/bootstrap-table/bootstrap-table.css",
                    "~/Content/group-by-v2/bootstrap-table-group-by.css",
                    "~/Content/editable/bootstrap-editable.css"

                    ));

            //bundles.Add(new StyleBundle("~/Content/group-by-v2").Include(
            //   "~/Content/group-by-v2/bootstrap-table-group-by.css"));

            bundles.Add(new ScriptBundle("~/bundles/group-by-v2").Include(
            "~/Scripts/group-by-v2/bootstrap-table-group-by.js"));

            //bundles.Add(new StyleBundle("~/Content/bootstrap-table").Include(
            //"~/Content/bootstrap-table/bootstrap-table.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-table").Include(
            "~/Scripts/bootstrap-table/bootstrap-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/ConfigQuotationDisplay").Include(
                "~/Scripts/ConfigQuotation.js"));

            bundles.Add(new ScriptBundle("~/bundles/editable").Include(
            "~/Scripts/editable/bootstrap-editable.js",
            "~/Scripts/editable/bootstrap-table-editable.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsexport").Include(
           "~/Scripts/jsexport/tableExport.js",
           "~/Scripts/jsexport/bootstrap-table-export.js",
           "~/Scripts/jsexport/jspdf.min.js",
           "~/Scripts/jsexport/FileSaver.min.js",
           "~/Scripts/jsexport/jspdf.plugin.autotable.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/ComputerCategory").Include(
                "~/Scripts/ComputerCategory.js"));
        }
    }
}
