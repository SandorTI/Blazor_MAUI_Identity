using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace BlazorMAUIIdentity.Shared
{
    public class TokenAuthorizationHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;

        public TokenAuthorizationHandler(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Obtener el token del almacenamiento local

            string? token;
            try
            {
                token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "Token");
            }
            catch (Exception ex)
            {
                token = Utilerias.Token;
            }

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
