using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SICS___WEB_2._0.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/bundles/inputmask").Include(
                //~/Scripts/inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
                "~/Scripts/inputmask/inputmask.js",
                "~/Scripts/inputmask/jquery.inputmask.js",
                "~/Scripts/inputmask/inputmask.extensions.js",
                "~/Scripts/inputmask/inputmask.date.extensions.js",
                //and other extensions you want to include
                "~/Scripts/inputmask/inputmask.numeric.extensions.js"));
        }
    }
}