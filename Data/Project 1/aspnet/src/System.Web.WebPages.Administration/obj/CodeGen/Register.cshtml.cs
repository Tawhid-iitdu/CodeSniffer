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
    
    #line 3 "..\..\Register.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Register.cshtml")]
    public class Register : System.Web.WebPages.WebPage
    {

                // Resolve package relative syntax
                // Also, if it comes from a static embedded resource, change the path accordingly
                public override string Href(string virtualPath, params object[] pathParts) {
                    virtualPath = ApplicationPart.ProcessVirtualPath(GetType().Assembly, VirtualPath, virtualPath);
                    return base.Href(virtualPath, pathParts);
                }
        public Register()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n\r\n");



            
            #line 4 "..\..\Register.cshtml"
  
    Page.Title = AdminResources.RegisterTitle;
    var adminPath = SiteAdmin.AdminVirtualPath.TrimStart('~');
    Page.Desc = String.Format(CultureInfo.CurrentCulture, AdminResources.RegisterDesc, Html.Encode(adminPath));

    // If the password is already set the redirect to login
    if(AdminSecurity.HasAdminPassword()) {
        SiteAdmin.RedirectToLogin(Response);
        return;
    }

    if (IsPost) {
        AntiForgery.Validate();

        var password = Request.Form["password"];
        var reenteredPassword = Request.Form["repassword"];
        if (password.IsEmpty()) {
            ModelState.AddError("password", AdminResources.Validation_PasswordRequired); 
        }
        else if (password != reenteredPassword) {
            ModelState.AddError("repassword", AdminResources.Validation_PasswordsDoNotMatch);
        }

        if (ModelState.IsValid) {
            // Save the admin password
            if(AdminSecurity.SaveTemporaryPassword(password)) {
                // Get the return url
                var returnUrl = SiteAdmin.GetReturnUrl(Request) ?? SiteAdmin.AdminVirtualPath;

                // Redirect to the return url
                Response.Redirect(returnUrl);
            }
            else {
                // Add a validation error since creating the password.txt failed
                ModelState.AddFormError(AdminResources.AdminModuleRequiresAccessToAppData);
            }
            
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n<br/>\r\n\r\n");


            
            #line 47 "..\..\Register.cshtml"
Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<form method=\"post\" action=\"\">\r\n");


            
            #line 50 "..\..\Register.cshtml"
Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n<fieldset>\r\n    <ol>\r\n        <li class=\"password\">\r\n            <label for=\"pa" +
"ssword\">");


            
            #line 54 "..\..\Register.cshtml"
                             Write(AdminResources.EnterPassword);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            ");


            
            #line 55 "..\..\Register.cshtml"
       Write(Html.Password("password"));

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 55 "..\..\Register.cshtml"
                                  Write(Html.ValidationMessage("password", "*"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </li>\r\n        <li class=\"password\">\r\n            <label>");


            
            #line 58 "..\..\Register.cshtml"
              Write(AdminResources.ReenterPassword);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n            ");


            
            #line 59 "..\..\Register.cshtml"
       Write(Html.Password("repassword"));

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 59 "..\..\Register.cshtml"
                                    Write(Html.ValidationMessage("repassword", "*"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </li>\r\n    </ol>\r\n    <p class=\"form-actions\">\r\n        <input type=\"su" +
"bmit\" value=\"");


            
            #line 63 "..\..\Register.cshtml"
                               Write(AdminResources.CreatePassword);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"long-input\" />\r\n    </p>\r\n</fieldset>\r\n</form>\r\n");


        }
    }
}
#pragma warning restore 1591
