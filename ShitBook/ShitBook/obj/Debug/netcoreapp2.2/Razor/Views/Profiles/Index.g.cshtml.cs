#pragma checksum "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6307a3c5fa256a9a13a2417dd84471f28fe6212c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_Index), @"mvc.1.0.view", @"/Views/Profiles/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Profiles/Index.cshtml", typeof(AspNetCore.Views_Profiles_Index))]
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
#line 5 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
using ShitBook.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6307a3c5fa256a9a13a2417dd84471f28fe6212c", @"/Views/Profiles/Index.cshtml")]
    public class Views_Profiles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
  
  Layout = "_Layout";

#line default
#line hidden
            BeginContext(27, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(52, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 7 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
 foreach(About about in Model)
{

#line default
#line hidden
            BeginContext(86, 10, true);
            WriteLiteral("<h1>About ");
            EndContext();
            BeginContext(97, 10, false);
#line 9 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
     Write(about.Name);

#line default
#line hidden
            EndContext();
            BeginContext(107, 6, true);
            WriteLiteral("</h1>\n");
            EndContext();
            BeginContext(114, 13, true);
            WriteLiteral("<p>Birthday: ");
            EndContext();
            BeginContext(128, 15, false);
#line 11 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
        Write(about.BirthDate);

#line default
#line hidden
            EndContext();
            BeginContext(143, 19, true);
            WriteLiteral("</p>\n<p>Home City: ");
            EndContext();
            BeginContext(163, 14, false);
#line 12 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
         Write(about.HomeCity);

#line default
#line hidden
            EndContext();
            BeginContext(177, 13, true);
            WriteLiteral("</p>\n<p>Age: ");
            EndContext();
            BeginContext(191, 9, false);
#line 13 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
   Write(about.Age);

#line default
#line hidden
            EndContext();
            BeginContext(200, 5, true);
            WriteLiteral("</p>\n");
            EndContext();
            BeginContext(206, 39, true);
            WriteLiteral("<button type =\"button\" name=\"button\"><a");
            EndContext();
            BeginWriteAttribute("href", " href =\'", 245, "\'", 276, 3);
            WriteAttributeValue("", 253, "/profile/", 253, 9, true);
#line 15 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
WriteAttributeValue("", 262, about.Id, 262, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 271, "/edit", 271, 5, true);
            EndWriteAttribute();
            BeginContext(277, 19, true);
            WriteLiteral(">Edit</a></button>\n");
            EndContext();
#line 16 "/Users/Guest/Desktop/ShitBook/ShitBook/Views/Profiles/Index.cshtml"
}

#line default
#line hidden
            BeginContext(298, 32, true);
            WriteLiteral("\n\n\n<a  href=\"/profile\">Home</a>\n");
            EndContext();
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