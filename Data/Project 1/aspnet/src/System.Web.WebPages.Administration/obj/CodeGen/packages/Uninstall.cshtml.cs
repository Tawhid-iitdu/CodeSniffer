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
    
    #line 3 "..\..\packages\Uninstall.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    #line 4 "..\..\packages\Uninstall.cshtml"
    using System.Text.RegularExpressions;
    
    #line default
    #line hidden
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Web.WebPages.Html;
    
    #line 5 "..\..\packages\Uninstall.cshtml"
    using NuGet;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/packages/Uninstall.cshtml")]
    public class Uninstall : System.Web.WebPages.WebPage
    {

                // Resolve package relative syntax
                // Also, if it comes from a static embedded resource, change the path accordingly
                public override string Href(string virtualPath, params object[] pathParts) {
                    virtualPath = ApplicationPart.ProcessVirtualPath(GetType().Assembly, VirtualPath, virtualPath);
                    return base.Href(virtualPath, pathParts);
                }
        public Uninstall()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");




WriteLiteral("\r\n");


DefineSection("PackageHead", () => {

WriteLiteral(" \r\n    <script type=\"text/javascript\" src=\"");


            
            #line 8 "..\..\packages\Uninstall.cshtml"
                                   Write(Href("scripts/PackageAction.js"));

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n    <noscript>");


            
            #line 9 "..\..\packages\Uninstall.cshtml"
         Write(PackageManagerResources.JavascriptRequired);

            
            #line default
            #line hidden
WriteLiteral("</noscript>\r\n");


});

WriteLiteral("\r\n\r\n");


            
            #line 12 "..\..\packages\Uninstall.cshtml"
  
    // Read from request  
    var packageId = Request["package"];
    var version = Request["version"];

    WebProjectManager projectManager;
    try {
        projectManager = new WebProjectManager(PackageManagerModule.ActiveSource.Source, PackageManagerModule.SiteRoot);
    } catch (Exception exception) {

            
            #line default
            #line hidden
WriteLiteral("        <div class=\"error message\">");


            
            #line 21 "..\..\packages\Uninstall.cshtml"
                              Write(exception.Message);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


            
            #line 22 "..\..\packages\Uninstall.cshtml"
        return;
    }

    IPackage package = projectManager.LocalRepository.FindPackage(packageId, version != null ? SemanticVersion.Parse(version) : null);

    if (package == null) {
        ModelState.AddFormError(PackageManagerResources.BadRequest);
        
            
            #line default
            #line hidden
            
            #line 29 "..\..\packages\Uninstall.cshtml"
   Write(Html.ValidationSummary());

            
            #line default
            #line hidden
            
            #line 29 "..\..\packages\Uninstall.cshtml"
                                 
        return; 
    }

    // Set up layout values
    var packagesHomeUrl = Href(PageUtils.GetPackagesHome(), Request.Url.Query);
    Page.SectionTitle = String.Format(CultureInfo.CurrentCulture, PackageManagerResources.UninstallPackageDesc, package.GetDisplayName());

    if (IsPost) {
        AntiForgery.Validate();
        bool removeDependencies = Request.Form["removeDependencies"].AsBool(false);
        try { 
            projectManager.UninstallPackage(package, removeDependencies: removeDependencies);
        } catch (Exception exception) {
            ModelState.AddFormError(exception.Message);
        }
        
        if (ModelState.IsValid) {
            Response.Redirect(packagesHomeUrl + "&action-completed=Uninstall");
        }
        else {
            
            
            #line default
            #line hidden
            
            #line 50 "..\..\packages\Uninstall.cshtml"
       Write(Html.ValidationSummary(String.Format(CultureInfo.CurrentCulture, PackageManagerResources.PackageUninstallationError, package.GetDisplayName())));

            
            #line default
            #line hidden
            
            #line 50 "..\..\packages\Uninstall.cshtml"
                                                                                                                                                            
        }
        return;
    }


            
            #line default
            #line hidden

            
            #line 55 "..\..\packages\Uninstall.cshtml"
  
    var encodedPackageName = Html.Encode(package.GetDisplayName());

            
            #line default
            #line hidden
WriteLiteral("    <h4>");


            
            #line 57 "..\..\packages\Uninstall.cshtml"
   Write(Html.Raw(String.Format(CultureInfo.CurrentCulture, PackageManagerResources.AreYouSureUninstall, encodedPackageName)));

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");


            
            #line 58 "..\..\packages\Uninstall.cshtml"


            
            #line default
            #line hidden
WriteLiteral("<form method=\"post\" action=\"\" id=\"submitForm\">\r\n<fieldset class=\"no-border\">\r\n   " +
" ");


            
            #line 61 "..\..\packages\Uninstall.cshtml"
Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n    <input type=\"hidden\" name=\"package\" value=\"");


            
            #line 62 "..\..\packages\Uninstall.cshtml"
                                          Write(packageId);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n    <input type=\"hidden\" name=\"version\" value=\"");


            
            #line 63 "..\..\packages\Uninstall.cshtml"
                                          Write(version);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 64 "..\..\packages\Uninstall.cshtml"
     if (package.Dependencies.Any()) {

            
            #line default
            #line hidden
WriteLiteral("        <div>\r\n            <label><input type=\"checkbox\" name=\"removeDependencies" +
"\" value=\"true\" checked=\"checked\"/>");


            
            #line 66 "..\..\packages\Uninstall.cshtml"
                                                                                               Write(PackageManagerResources.RemoveDependencies);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n        </div>\r\n");



WriteLiteral("        <br />\r\n");


            
            #line 69 "..\..\packages\Uninstall.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <input type=\"submit\" value=\"");


            
            #line 70 "..\..\packages\Uninstall.cshtml"
                           Write(PackageManagerResources.UninstallPackage);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n    &nbsp;\r\n    <input type=\"reset\" value=\"");


            
            #line 72 "..\..\packages\Uninstall.cshtml"
                          Write(PackageManagerResources.Cancel);

            
            #line default
            #line hidden
WriteLiteral("\" data-returnurl=\"");


            
            #line 72 "..\..\packages\Uninstall.cshtml"
                                                                           Write(packagesHomeUrl);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n</fieldset>\r\n</form>");


        }
    }
}
#pragma warning restore 1591
