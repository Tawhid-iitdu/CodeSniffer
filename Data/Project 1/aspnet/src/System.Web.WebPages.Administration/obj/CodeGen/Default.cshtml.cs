#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Web.WebPages.Administration
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..\Default.cshtml"
    using System.Web.WebPages.Administration.PackageManager;
    
    #line default
    #line hidden
    using System.Web.WebPages.Html;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Default.cshtml")]
    public class Default : System.Web.WebPages.WebPage
    {

                // Resolve package relative syntax
                // Also, if it comes from a static embedded resource, change the path accordingly
                public override string Href(string virtualPath, params object[] pathParts) {
                    virtualPath = ApplicationPart.ProcessVirtualPath(GetType().Assembly, VirtualPath, virtualPath);
                    return base.Href(virtualPath, pathParts);
                }
        public Default()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");



            
            #line 4 "..\..\Default.cshtml"
      
    Page.Title = AdminResources.Modules;
    var adminModules = from p in SiteAdmin.Modules
                       where !p.StartPageVirtualPath.Equals(SiteAdmin.AdminVirtualPath, StringComparison.OrdinalIgnoreCase)
                       orderby p.DisplayName
                       select p;


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 12 "..\..\Default.cshtml"
 if (!adminModules.Any() && !PackageManagerModule.Available) {

            
            #line default
            #line hidden
WriteLiteral("    <h3>");


            
            #line 13 "..\..\Default.cshtml"
   Write(AdminResources.NoAdminModulesInstalled);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n");


            
            #line 14 "..\..\Default.cshtml"
}
else if (PackageManagerModule.Available && !adminModules.Any()) {
    // If no other module is available, take the user directly to the package manager
    Response.Redirect(Href("packages"));
    return;
}
else {

            
            #line default
            #line hidden
WriteLiteral("    <ul class=\"modules\">\r\n");


            
            #line 22 "..\..\Default.cshtml"
     if (PackageManagerModule.Available) {

            
            #line default
            #line hidden
WriteLiteral("        <li>    \r\n            <a href=\"");


            
            #line 24 "..\..\Default.cshtml"
                Write(Href("packages"));

            
            #line default
            #line hidden
WriteLiteral("\" title=\"");


            
            #line 24 "..\..\Default.cshtml"
                                          Write(PackageManagerModule.ModuleName);

            
            #line default
            #line hidden
WriteLiteral("\"><strong>");


            
            #line 24 "..\..\Default.cshtml"
                                                                                    Write(PackageManagerModule.ModuleName);

            
            #line default
            #line hidden
WriteLiteral("</strong></a>\r\n            <div class=\"description\">");


            
            #line 25 "..\..\Default.cshtml"
                                Write(PackageManagerModule.ModuleDescription);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </li>\r\n");


            
            #line 27 "..\..\Default.cshtml"
    }

            
            #line default
            #line hidden

            
            #line 28 "..\..\Default.cshtml"
     if (adminModules.Any()) {
        foreach (var module in adminModules) {

            
            #line default
            #line hidden
WriteLiteral("            <li>\r\n                <a href=\"");


            
            #line 31 "..\..\Default.cshtml"
                    Write(Href(module.StartPageVirtualPath));

            
            #line default
            #line hidden
WriteLiteral("\"><strong>");


            
            #line 31 "..\..\Default.cshtml"
                                                                Write(module.DisplayName);

            
            #line default
            #line hidden
WriteLiteral("</strong></a>\r\n                <div class=\"description\">\r\n                    ");


            
            #line 33 "..\..\Default.cshtml"
               Write(module.Description);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </li>\r\n");


            
            #line 36 "..\..\Default.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n");


            
            #line 39 "..\..\Default.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591