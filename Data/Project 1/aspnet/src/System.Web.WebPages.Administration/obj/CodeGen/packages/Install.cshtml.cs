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
    
    #line 3 "..\..\packages\Install.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    
    #line 4 "..\..\packages\Install.cshtml"
    using System.IO;
    
    #line default
    #line hidden
    
    #line 5 "..\..\packages\Install.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Web.WebPages.Html;
    
    #line 6 "..\..\packages\Install.cshtml"
    using NuGet;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/packages/Install.cshtml")]
    public class Install : System.Web.WebPages.WebPage
    {

                // Resolve package relative syntax
                // Also, if it comes from a static embedded resource, change the path accordingly
                public override string Href(string virtualPath, params object[] pathParts) {
                    virtualPath = ApplicationPart.ProcessVirtualPath(GetType().Assembly, VirtualPath, virtualPath);
                    return base.Href(virtualPath, pathParts);
                }
        public Install()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");





WriteLiteral("\r\n");


DefineSection("PackageHead", () => {

WriteLiteral(" \r\n    <script type=\"text/javascript\" src=\"");


            
            #line 9 "..\..\packages\Install.cshtml"
                                   Write(Href("scripts/PackageAction.js"));

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n    <noscript>");


            
            #line 10 "..\..\packages\Install.cshtml"
         Write(PackageManagerResources.JavascriptRequired);

            
            #line default
            #line hidden
WriteLiteral("</noscript>\r\n");


});

WriteLiteral("\r\n");


            
            #line 12 "..\..\packages\Install.cshtml"
  
    // Read params from request
    var sourceName = Request["source"];
    var packageId = Request["package"];
    var version = Request["version"];

    var packageSource = PageUtils.GetPackageSource(sourceName);
    
    WebProjectManager projectManager;
    try {
        projectManager = new WebProjectManager(packageSource.Source, PackageManagerModule.SiteRoot);
    } catch (Exception exception) {

            
            #line default
            #line hidden
WriteLiteral("        <div class=\"error message\">");


            
            #line 24 "..\..\packages\Install.cshtml"
                              Write(exception.Message);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");


            
            #line 25 "..\..\packages\Install.cshtml"
        return;
    }
    IPackage package = projectManager.SourceRepository.FindPackage(packageId, version != null ? SemanticVersion.Parse(version) : null);

    if (package == null) {
        ModelState.AddFormError(PackageManagerResources.BadRequest);
        
            
            #line default
            #line hidden
            
            #line 31 "..\..\packages\Install.cshtml"
   Write(Html.ValidationSummary());

            
            #line default
            #line hidden
            
            #line 31 "..\..\packages\Install.cshtml"
                                 
        return; 
    } 
    
    Page.SectionTitle = String.Format(CultureInfo.CurrentCulture, PackageManagerResources.InstallPackageDesc, package.GetDisplayName());

    var packagesHomeUrl = Href(PageUtils.GetPackagesHome(), Request.Url.Query);
    if (IsPost) {
        AntiForgery.Validate();
        try {
            projectManager.InstallPackage(package);   
        } catch (Exception exception) {
            ModelState.AddFormError(exception.Message);
        }
        
        if (ModelState.IsValid) {
            Response.Redirect(packagesHomeUrl + "&action-completed=Install");
        }
        else {
            
            
            #line default
            #line hidden
            
            #line 50 "..\..\packages\Install.cshtml"
       Write(Html.ValidationSummary(String.Format(CultureInfo.CurrentCulture, PackageManagerResources.PackageInstallationError, package.GetDisplayName())));

            
            #line default
            #line hidden
            
            #line 50 "..\..\packages\Install.cshtml"
                                                                                                                                                          
            return;
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 56 "..\..\packages\Install.cshtml"
Write(RenderPage("_PackageDetails.cshtml", new Dictionary<string, object>{ {"Package", package} }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


            
            #line 58 "..\..\packages\Install.cshtml"
  
    var licensePackages = projectManager.GetPackagesRequiringLicenseAcceptance(package);
    if (licensePackages.Any()) {

            
            #line default
            #line hidden
WriteLiteral("       <hr />\r\n");



WriteLiteral("       <ul>\r\n");


            
            #line 63 "..\..\packages\Install.cshtml"
             foreach(var licensePackage in licensePackages.Where(p => PageUtils.IsValidLicenseUrl(p.LicenseUrl))){

            
            #line default
            #line hidden
WriteLiteral("                <li>\r\n                    <strong>");


            
            #line 65 "..\..\packages\Install.cshtml"
                       Write(licensePackage.Id);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 65 "..\..\packages\Install.cshtml"
                                          Write(licensePackage.Version);

            
            #line default
            #line hidden
WriteLiteral("</strong> \r\n                    (");


            
            #line 66 "..\..\packages\Install.cshtml"
                Write(PackageManagerResources.AuthorsLabel);

            
            #line default
            #line hidden
WriteLiteral(": <span class=\"package-author\">");


            
            #line 66 "..\..\packages\Install.cshtml"
                                                                                    Write(String.Join(PackageManagerResources.WordSeparator, licensePackage.Authors));

            
            #line default
            #line hidden
WriteLiteral("</span>)\r\n                    <br />\r\n                    <a href=\"");


            
            #line 68 "..\..\packages\Install.cshtml"
                        Write(licensePackage.LicenseUrl);

            
            #line default
            #line hidden
WriteLiteral("\" target=\"_blank\">");


            
            #line 68 "..\..\packages\Install.cshtml"
                                                                    Write(PackageManagerResources.ViewLicenseTerms);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </li>\r\n");


            
            #line 70 "..\..\packages\Install.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("       </ul>   \r\n");


            
            #line 72 "..\..\packages\Install.cshtml"
    }else {

            
            #line default
            #line hidden
WriteLiteral("        <br />\r\n");



WriteLiteral("        <hr />\r\n");


            
            #line 75 "..\..\packages\Install.cshtml"
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n<form method=\"post\" action=\"\" id=\"submitForm\">\r\n<p>");


            
            #line 79 "..\..\packages\Install.cshtml"
Write(PackageManagerResources.Disclaimer);

            
            #line default
            #line hidden
WriteLiteral("</p>    \r\n<fieldset class=\"no-border install\">\r\n    <input type=\"hidden\" name=\"so" +
"urce\" value=\"");


            
            #line 81 "..\..\packages\Install.cshtml"
                                         Write(sourceName);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n    <input type=\"hidden\" name=\"package\" value=\"");


            
            #line 82 "..\..\packages\Install.cshtml"
                                          Write(packageId);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n    <input type=\"hidden\" name=\"version\" value=\"");


            
            #line 83 "..\..\packages\Install.cshtml"
                                          Write(version);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n    ");


            
            #line 84 "..\..\packages\Install.cshtml"
Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <input type=\"submit\" value=\"");


            
            #line 86 "..\..\packages\Install.cshtml"
                           Write(PackageManagerResources.InstallPackage);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n    <input type=\"reset\" value=\"");


            
            #line 87 "..\..\packages\Install.cshtml"
                          Write(PackageManagerResources.Cancel);

            
            #line default
            #line hidden
WriteLiteral("\" data-returnurl=\"");


            
            #line 87 "..\..\packages\Install.cshtml"
                                                                           Write(packagesHomeUrl);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n</fieldset>\r\n    \r\n\r\n</form>");


        }
    }
}
#pragma warning restore 1591
