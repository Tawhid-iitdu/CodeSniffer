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

namespace System.Web.WebPages.Administration.PackageManager
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
    using System.Web.WebPages.Html;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/packages/_Layout.cshtml")]
    public class Layout : System.Web.WebPages.WebPage
    {

                // Resolve package relative syntax
                // Also, if it comes from a static embedded resource, change the path accordingly
                public override string Href(string virtualPath, params object[] pathParts) {
                    virtualPath = ApplicationPart.ProcessVirtualPath(GetType().Assembly, VirtualPath, virtualPath);
                    return base.Href(virtualPath, pathParts);
                }
        public Layout()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");


            
            #line 3 "..\..\packages\_Layout.cshtml"
  
    Layout = "../_Layout.cshtml";
    Page.Title = PackageManagerResources.ModuleTitle;


            
            #line default
            #line hidden

DefineSection("Head", () => {

WriteLiteral("\r\n    <link href=\"");


            
            #line 8 "..\..\packages\_Layout.cshtml"
           Write(Href("Site.css"));

            
            #line default
            #line hidden
WriteLiteral("\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <script src=\"http://ajax.microsoft.com" +
"/ajax/jquery/jquery-1.4.2.js\" type=\"text/javascript\"></script>\r\n\r\n    ");


            
            #line 11 "..\..\packages\_Layout.cshtml"
Write(RenderSection("PackageHead", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


});

WriteLiteral("\r\n\r\n");


DefineSection("PageSettings", () => {

WriteLiteral("\r\n    <a href=\"");


            
            #line 15 "..\..\packages\_Layout.cshtml"
        Write(Href("PackageSources"));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 15 "..\..\packages\_Layout.cshtml"
                                 Write(PackageManagerResources.ManageSourcesTitle);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");


});

WriteLiteral("\r\n\r\n");


            
            #line 18 "..\..\packages\_Layout.cshtml"
Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


DefineSection("Footer", () => {

WriteLiteral("\r\n    <a href=\"http://go.microsoft.com/fwlink/?LinkID=205205\" target=\"_blank\">");


            
            #line 21 "..\..\packages\_Layout.cshtml"
                                                                       Write(PackageManagerResources.PrivacyStatement);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");


});


        }
    }
}
#pragma warning restore 1591
