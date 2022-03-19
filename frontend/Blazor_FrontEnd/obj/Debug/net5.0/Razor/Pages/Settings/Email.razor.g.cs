#pragma checksum "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2d6e550851fd3d701998292c6a57cc9e5fd19e2"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazor_FrontEnd.Pages.Settings
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
#nullable restore
#line 2 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/settings/email")]
    public partial class Email : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Email adressen</h3>\r\n\r\n");
            __builder.OpenElement(1, "table");
            __builder.AddAttribute(2, "class", "table");
            __builder.AddMarkupContent(3, "<thead><tr><th>Emails</th></tr></thead>\r\n    ");
            __builder.OpenElement(4, "tbody");
#nullable restore
#line 14 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
         foreach(var addr in Adresses)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "tr");
            __builder.OpenElement(6, "td");
#nullable restore
#line 17 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
__builder.AddContent(7, addr.ToString());

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n                ");
            __builder.AddMarkupContent(9, "<td>remove</td>");
            __builder.CloseElement();
#nullable restore
#line 20 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n\r\n");
            __builder.OpenElement(11, "form");
            __builder.AddAttribute(12, "onsubmit", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.EventArgs>(this, 
#nullable restore
#line 24 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
                 AddToList

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(13, "<label for=\"emailInput\"> Voeg een email toe</label>\r\n    ");
            __builder.OpenElement(14, "input");
            __builder.AddAttribute(15, "id", "emailInput");
            __builder.AddAttribute(16, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 26 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
                  addedEmail

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => addedEmail = __value, addedEmail));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddElementReferenceCapture(18, (__value) => {
#nullable restore
#line 26 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
                                                    emailInputField_ref = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
       
    private string addedEmail;
    private List<string> Adresses = new();
    private ElementReference emailInputField_ref;

    private void AddToList()
    {
        if (!String.IsNullOrWhiteSpace(addedEmail) && !Adresses.Contains(addedEmail))    //  check for doubles and empty strings 
        {
            if(new EmailAddressAttribute().IsValid(addedEmail)) //  validate email
            {
                Adresses.Add(addedEmail);  
            }

        }
        addedEmail = null; 
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
