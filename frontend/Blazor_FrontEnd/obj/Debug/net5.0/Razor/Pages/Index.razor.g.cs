#pragma checksum "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c682bc6499de322157de7c997c1168b776a2b60"
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
#nullable restore
#line 2 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
using Blazor_FrontEnd.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
using Blazor_FrontEnd.Data.RequestCodes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
using NetMQ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
using NetMQ.Sockets;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Batterij monitoring</h1>");
#nullable restore
#line 12 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
 if (!Connected)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p style=\"overflow-wrap:break-word\">Heftruck is niet verbonden</p>");
#nullable restore
#line 15 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"

} else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p style=\"overflow-wrap:break-word\">Heftruck is verbonden</p>");
#nullable restore
#line 19 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "C:\Users\arthu\Documents\Rider Projects\gip rpi\frontend\Blazor_FrontEnd\Pages\Index.razor"
      
	private bool Connected = false;
	private string? response;
	private CancellationTokenSource tokenSource;

	protected async override Task OnInitializedAsync()
	{
		using(var client = new RequestSocket())
		{
			client.Connect("tcp://localhost:2100");
			client.SendFrame(new byte[] { Convert.ToByte(RequestCodes.GetOnlineStatus) });
			if(client.ReceiveFrameString() == bool.TrueString)
			{
				Connected = true;
			} else
			{
				Connected = false;
			}
		}
		await base.OnInitializedAsync();	
	}

	public void Dispose()
	{
		
		//tokenSource.Dispose();
	}

	
	

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPCClient BackendComm { get; set; }
    }
}
#pragma warning restore 1591
