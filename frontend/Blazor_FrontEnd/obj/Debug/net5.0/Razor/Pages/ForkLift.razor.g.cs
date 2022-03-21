#pragma checksum "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6eb13fe1b12c625292f48db4e76729435145aeb"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor_FrontEnd.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Blazor_FrontEnd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\_Imports.razor"
using Blazor_FrontEnd.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Forklift")]
    public partial class ForkLift : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Heftruck status</h1>\r\n<hr>\r\n<br>\r\n");
            __builder.AddMarkupContent(1, "<h3>Batterijniveau</h3> \r\n");
            __builder.OpenElement(2, "label");
            __builder.AddAttribute(3, "for", "batteryGauge");
            __builder.AddContent(4, "Resterende lading ( ");
#nullable restore
#line 7 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor"
__builder.AddContent(5, percentage);

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, " %): ");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n");
            __builder.OpenElement(8, "meter");
            __builder.AddAttribute(9, "style", "width:80%;");
            __builder.AddAttribute(10, "id", "batteryGauge");
            __builder.AddAttribute(11, "min", "0");
            __builder.AddAttribute(12, "max", "100");
            __builder.AddAttribute(13, "value", 
#nullable restore
#line 8 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor"
                                                                      percentage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n\r\n<hr>\r\n\r\n");
            __builder.AddMarkupContent(15, "<h3>Handrem</h3>\r\n<br>");
#nullable restore
#line 14 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor"
 if (handbrakeActivated)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(16, "<p style=\"color:forestgreen\">Handrem geactiveerd</p>");
#nullable restore
#line 17 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor"
} else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(17, "<p style=\"color:firebrick\">Handrem gedeactiveerd</p>");
#nullable restore
#line 20 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(18, "<br>\r\n");
            __builder.AddMarkupContent(19, "<label for=\"handbrakeToggle\">Handrem: </label>\r\n<input type=\"checkbox\" data-toggle=\"toggle\" data-on=\"aan\" data-off=\"uit\" data-onstyle=\"success\" data-offstyle=\"danger\">\r\n<hr>");
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\ForkLift.razor"
       
    private float percentage;
    private bool handbrakeActivated = false;


    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();
        percentage = 100F;
        var timer = new System.Threading.Timer((_) =>
        {
            InvokeAsync(async () =>
            {
                percentage -= (percentage > 0)?5F:0;   //  create real updater
                StateHasChanged();  //  re-render the component
            });

        }, null, 0, 1000);
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
