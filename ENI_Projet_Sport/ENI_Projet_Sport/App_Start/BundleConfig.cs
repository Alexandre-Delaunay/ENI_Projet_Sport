using System.Web;
using System.Web.Optimization;

namespace ENI_Projet_Sport
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles, bool IsDarkTheme)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-confirm.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/leaflet").Include(
                      "~/Scripts/leaflet.js",
                      "~/Scripts/Control.Geocoder.js",
                      "~/Scripts/leaflet-routing-machine.js"));

            bundles.Add(new StyleBundle("~/Content/leaflet").Include(
                      "~/Content/leaflet.css",
                      "~/Content/Control.Geocoder.css",
                      "~/Content/leaflet-routing-machine.css"));

            if (IsDarkTheme)
            {
                bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/jquery-confirm.css"));
            }
            else
            {
                bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootswatchlux.min.css",
                "~/Content/site.css",
                "~/Content/jquery-confirm.css"));
            }
        }
    }
}
