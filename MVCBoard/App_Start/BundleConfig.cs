using System.Web;
using System.Web.Optimization;

namespace MVCBoard
{
    public class BundleConfig
    {
        // 묶음에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301862를 참조하세요.
        public static void RegisterBundles(BundleCollection bundles)
        {
          //  bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
          //              "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션에 사용할 준비를 하고 https://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하세요.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

          //  bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            // Custom Calendar.
            bundles.Add(new ScriptBundle("~/bundles/Script-calendar").Include(
                                 "~/Scripts/script-custom-calendar.js"));

           // bundles.Add(new StyleBundle("~/Content/css").Include(
           //           "~/Content/bootstrap.css",
           //           "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
               // "~/Content/bootstrap.css",
                "~/Content/theme01/vendor/fontawesome-free/css/all.min.css",
                "~/Content/theme01/vendor/datatables/dataTables.bootstrap4.css",
                "~/Content/theme01/css/sb-admin.css", 
                "~/Content/theme01/css/Site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/theme01").Include(
                     "~/Content/theme01/vendor/jquery/jquery.min.js",
                      "~/Content/theme01/vendor/bootstrap/js/bootstrap.bundle.min.js",
                       "~/Content/theme01/vendor/jquery-easing/jquery.easing.min.js",
                        
                         "~/Content/theme01/vendor/datatables/jquery.dataTables.js",
                          "~/Content/theme01/vendor/datatables/dataTables.bootstrap4.js",
                           "~/Content/theme01/js/sb-admin.min.js",
                            "~/Content/theme01/js/demo/datatables-demo.js"
                        //    "~/Content/theme01/js/demo/chart-area-demo.js"



                     ));


        }
    }
}
