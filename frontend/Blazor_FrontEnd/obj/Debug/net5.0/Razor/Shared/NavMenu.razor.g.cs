#pragma checksum "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "494f9bb2631ad72110f34b3c842c9c8c3f18669c"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor_FrontEnd.Shared
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
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-m4tq5poyr7");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-m4tq5poyr7>Batterij monitor</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-m4tq5poyr7");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-m4tq5poyr7></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "b-m4tq5poyr7");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddAttribute(16, "b-m4tq5poyr7");
            __builder.OpenElement(17, "li");
            __builder.AddAttribute(18, "class", "nav-item px-3");
            __builder.AddAttribute(19, "b-m4tq5poyr7");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(20);
            __builder.AddAttribute(21, "class", "nav-link");
            __builder.AddAttribute(22, "href", "");
            __builder.AddAttribute(23, "Match", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 11 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(25, "<span class=\"oi oi-home\" aria-hidden=\"true\" b-m4tq5poyr7></span> Home\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n        ");
            __builder.OpenElement(27, "li");
            __builder.AddAttribute(28, "class", "nav-item px-3");
            __builder.AddAttribute(29, "b-m4tq5poyr7");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(30);
            __builder.AddAttribute(31, "class", "nav-link");
            __builder.AddAttribute(32, "href", "Forklift");
            __builder.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(34, "<span class=\"oi oi-info\" aria-hidden=\"true\" b-m4tq5poyr7></span> heftruck\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n        \r\n            \r\n        ");
            __builder.OpenElement(36, "li");
            __builder.AddAttribute(37, "class", "nav-item px-3");
            __builder.AddAttribute(38, "b-m4tq5poyr7");
            __builder.OpenElement(39, "div");
            __builder.AddAttribute(40, "class", 
#nullable restore
#line 23 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                        NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                                                  ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "b-m4tq5poyr7");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(43);
            __builder.AddAttribute(44, "class", "nav-link");
            __builder.AddAttribute(45, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                                                ()=>collapseSubNav = !collapseSubNav

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(46, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(47, "<span class=\"oi oi-fork\" aria-hidden=\"true\" b-m4tq5poyr7></span> instellingen\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 29 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
             if (!collapseSubNav)
            {
                

#line default
#line hidden
#nullable disable
            __builder.OpenElement(48, "ul");
            __builder.AddAttribute(49, "class", "nav flex-column");
            __builder.AddAttribute(50, "b-m4tq5poyr7");
            __builder.OpenElement(51, "li");
            __builder.AddAttribute(52, "class", "nav-item px-3");
            __builder.AddAttribute(53, "b-m4tq5poyr7");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(54);
            __builder.AddAttribute(55, "class", "nav-link");
            __builder.AddAttribute(56, "href", "/settings/email");
            __builder.AddAttribute(57, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(58, "<span class=\"oi oi-envelope-closed\" aria-hidden=\"true\" b-m4tq5poyr7></span>Emails\r\n                            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n                        ");
            __builder.OpenElement(60, "li");
            __builder.AddAttribute(61, "class", "nav-item px-3");
            __builder.AddAttribute(62, "b-m4tq5poyr7");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(63);
            __builder.AddAttribute(64, "class", "nav-link");
            __builder.AddAttribute(65, "href", "/settings/battery");
            __builder.AddAttribute(66, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(67, "<span class=\"oi oi-battery-full\" aria-hidden=\"true\" b-m4tq5poyr7></span>Batterij\r\n                            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n                        ");
            __builder.OpenElement(69, "li");
            __builder.AddAttribute(70, "class", "nav-item px-3");
            __builder.AddAttribute(71, "b-m4tq5poyr7");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(72);
            __builder.AddAttribute(73, "class", "nav-link");
            __builder.AddAttribute(74, "href", "/settings/connection");
            __builder.AddAttribute(75, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(76, "<span class=\"oi oi-cloudy\" aria-hidden=\"true\" b-m4tq5poyr7></span>Verbinding\r\n                            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 49 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
                
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 55 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;
    private bool collapseSubNav = true;
    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private Task ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
        return Task.CompletedTask;
    }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
