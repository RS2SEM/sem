#pragma checksum "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6169ba6bd5a3932ed2f4c343071952f221b8ac19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Komentar_Lista), @"mvc.1.0.view", @"/Views/Komentar/Lista.cshtml")]
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
#line 1 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
using ClassLibrary1.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
using ClassLibrary1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
using WebApplication1.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6169ba6bd5a3932ed2f4c343071952f221b8ac19", @"/Views/Komentar/Lista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Komentar_Lista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-spy", new global::Microsoft.AspNetCore.Html.HtmlString("scroll"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#ftco-navbar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-offset", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
   

    var komentari = (List<KomentarVM>)ViewData["komentariVD"];
    User aktivan = Autenfikacija.GetLogiraniKorisnik(Context);


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6169ba6bd5a3932ed2f4c343071952f221b8ac195239", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6169ba6bd5a3932ed2f4c343071952f221b8ac196209", async() => {
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n    <div class=\"container\">\r\n        \r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12 text-center mb-5 ftco-animate\" id=\"unosKomentarPlaceholder\">\r\n\r\n\r\n");
#nullable restore
#line 31 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
                   if (aktivan != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <button class=\"display-4\" style=\"border:none; color:orangered; background-color:white \" ajax-poziv=\"da\" ajax-rezultat=\"unosKomentarPlaceholder\"");
                BeginWriteAttribute("ajax-url", " ajax-url=\"", 775, "\"", 818, 1);
#nullable restore
#line 33 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
WriteAttributeValue("", 786, Url.Action("Dodaj", "Komentar"), 786, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">dodaj komentar</button>\r\n");
#nullable restore
#line 34 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <button type=\"button\" class=\"display-4\" style=\"border:none; color:orangered; background-color:white \" ajax-modalni=\"da\" ajax-rezultat=\"PrijavaPlaceholder\"");
                BeginWriteAttribute("ajax-url", " ajax-url=\"", 1083, "\"", 1125, 1);
#nullable restore
#line 37 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
WriteAttributeValue("", 1094, Url.Action("Index", "Prijava"), 1094, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> dodaj komentar</button>\r\n");
#nullable restore
#line 38 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n\r\n\r\n        </div>\r\n\r\n\r\n");
#nullable restore
#line 46 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
         foreach (var x in komentari)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-md-12 text-center mb-5 ftco-animate\">\r\n\r\n                    <h2 class=\"display-4\">");
#nullable restore
#line 51 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
                                     Write(x.Username);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                    <div class=\"row justify-content-center\">\r\n                        <div class=\"col-md-7\">\r\n                            <p class=\"lead\">");
#nullable restore
#line 54 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
                                       Write(x.Sadrzaj);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <h4 class=\"ftco-sub-title\">");
#nullable restore
#line 57 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
                                          Write(x.vrijemePostavljanja);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                </div>\r\n\r\n\r\n            </div>\r\n");
#nullable restore
#line 62 "C:\Users\pc\Desktop\rapsudic\webapp\WebApplication1\Views\Komentar\Lista.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    </div>\r\n\r\n    \r\n\r\n\r\n    <!-- END section -->\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
