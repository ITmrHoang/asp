#pragma checksum "C:\Users\ITMrHoang\Desktop\NauAn\NauAn\Views\Categories\ListCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32be0de1ed58cc8738d70979bfa8640a3bf82e45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_ListCategory), @"mvc.1.0.view", @"/Views/Categories/ListCategory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/ListCategory.cshtml", typeof(AspNetCore.Views_Categories_ListCategory))]
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
#line 1 "C:\Users\ITMrHoang\Desktop\NauAn\NauAn\Views\_ViewImports.cshtml"
using NauAn;

#line default
#line hidden
#line 2 "C:\Users\ITMrHoang\Desktop\NauAn\NauAn\Views\_ViewImports.cshtml"
using NauAn.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32be0de1ed58cc8738d70979bfa8640a3bf82e45", @"/Views/Categories/ListCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e84a90750fbe0cd465be97ebce0f845ef89c440", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_ListCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NauAn.Models.Entities.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("nav", async() => {
                BeginContext(65, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 3 "C:\Users\ITMrHoang\Desktop\NauAn\NauAn\Views\Categories\ListCategory.cshtml"
     foreach (var item in Model)
    {
        

#line default
#line hidden
                BeginContext(117, 39, false);
#line 5 "C:\Users\ITMrHoang\Desktop\NauAn\NauAn\Views\Categories\ListCategory.cshtml"
   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
                EndContext();
#line 5 "C:\Users\ITMrHoang\Desktop\NauAn\NauAn\Views\Categories\ListCategory.cshtml"
                                                
    }

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NauAn.Models.Entities.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591