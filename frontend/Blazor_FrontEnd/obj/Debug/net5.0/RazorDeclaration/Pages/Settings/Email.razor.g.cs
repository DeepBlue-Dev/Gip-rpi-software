// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Settings\Email.razor"
       
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