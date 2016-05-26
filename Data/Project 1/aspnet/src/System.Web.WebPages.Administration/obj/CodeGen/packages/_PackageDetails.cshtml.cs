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
    
    #line 3 "..\..\packages\_PackageDetails.cshtml"
    using NuGet;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/packages/_PackageDetails.cshtml")]
    public class PackageDetails : System.Web.WebPages.WebPage
    {

                // Resolve package relative syntax
                // Also, if it comes from a static embedded resource, change the path accordingly
                public override string Href(string virtualPath, params object[] pathParts) {
                    virtualPath = ApplicationPart.ProcessVirtualPath(GetType().Assembly, VirtualPath, virtualPath);
                    return base.Href(virtualPath, pathParts);
                }
        public PackageDetails()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");


WriteLiteral("\r\n");


            
            #line 5 "..\..\packages\_PackageDetails.cshtml"
  
    IPackage package = Page.Package;


            
            #line default
            #line hidden
WriteLiteral("<div class=\"package-info\">\r\n<h4>\r\n    ");


            
            #line 10 "..\..\packages\_PackageDetails.cshtml"
Write(package.GetDisplayName());

            
            #line default
            #line hidden
WriteLiteral("\r\n</h4>\r\n");


            
            #line 12 "..\..\packages\_PackageDetails.cshtml"
 if (!String.IsNullOrEmpty(package.Description)) {

            
            #line default
            #line hidden
WriteLiteral("    <p class=\"package-description\">");


            
            #line 13 "..\..\packages\_PackageDetails.cshtml"
                              Write(package.Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");


            
            #line 14 "..\..\packages\_PackageDetails.cshtml"
}

            
            #line default
            #line hidden

            
            #line 15 "..\..\packages\_PackageDetails.cshtml"
  
    var authors = package.Authors as IEnumerable<string>;
    if (authors.Any()) {

            
            #line default
            #line hidden
WriteLiteral("        <p>\r\n            <strong>");


            
            #line 19 "..\..\packages\_PackageDetails.cshtml"
               Write(PackageManagerResources.AuthorsLabel);

            
            #line default
            #line hidden
WriteLiteral(": </strong><span class=\"package-author\">");


            
            #line 19 "..\..\packages\_PackageDetails.cshtml"
                                                                                            Write(String.Join(PackageManagerResources.WordSeparator, authors));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </p>\r\n");


            
            #line 21 "..\..\packages\_PackageDetails.cshtml"
    }


            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


        }
    }
}
#pragma warning restore 1591
