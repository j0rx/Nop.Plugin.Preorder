using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Preorder
{
    public class PreorderPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            //if (widgetZone== "admin_product_details_block")
            //{

            //    return "PreorderAdminComponent";
            //}
            //else if (widgetZone== "productdetails_top")
            //{
            //    return "PreorderPageViewComponent";
            //}
            return "";
        }
        public override void Install()
        {
            //Logic during installation goes here...

            base.Install();
        }

        public override void Uninstall()
        {
            //Logic during uninstallation goes here...

            base.Uninstall();
        }


        public IList<string> GetWidgetZones()
        {
            return new List<string> { AdminWidgetZones.ProductDetailsBlock, PublicWidgetZones.ProductDetailsTop };
        }
    }
}
