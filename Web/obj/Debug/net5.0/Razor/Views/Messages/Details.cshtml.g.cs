#pragma checksum "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a66814df3c0d93eb53dd8129f6961709275b5bce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Messages_Details), @"mvc.1.0.view", @"/Views/Messages/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a66814df3c0d93eb53dd8129f6961709275b5bce", @"/Views/Messages/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Messages_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entity.Messages>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h4>");
#nullable restore
#line 9 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <p style=\"word-wrap:break-word;\">");
#nullable restore
#line 11 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml"
                                Write(Model.Context);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p style=\"text-align:end;\">");
#nullable restore
#line 12 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml"
                          Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n            <hr />\r\n            <h6>İletişim Bilgileri</h6>\r\n            <p><small>E-mail: </small>  ");
#nullable restore
#line 17 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml"
                                   Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p><small>Telefon: </small>  ");
#nullable restore
#line 18 "C:\Users\mehme\Desktop\Dosyalar\Projeler\MekhanKuaför\Web\Views\Messages\Details.cshtml"
                                    Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a66814df3c0d93eb53dd8129f6961709275b5bce5339", async() => {
                WriteLiteral("Geri Dön");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entity.Messages> Html { get; private set; }
    }
}
#pragma warning restore 1591
