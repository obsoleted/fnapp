using System.Net;
using System;
using System.Linq;
using System.Collections;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    return req.CreateResponse(HttpStatusCode.OK, new {
        ClaimsPrincpal = ClaimsPrincipal.Current,
        Identities = ClaimsPrincipal.Current.Identities.Select((id) => new {Identity = id, Authenticated = id.IsAuthenticated}),
        EnvironmentVariables = System.Environment.GetEnvironmentVariables(),
        Request = new {
            RequestUri = req.RequestUri,
            Method = req.Method,
            Headers = req.Headers,
            Cookies = req.Headers.GetCookies(),
            QueryNVPairs = req.GetQueryNameValuePairs(),
            Content = new {
                Headers = req.Content.Headers,
                AsString = await req.Content.ReadAsStringAsync()
            }
        }
    });
}