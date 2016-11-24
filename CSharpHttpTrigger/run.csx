using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Security;
using System.Security.Claims;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage httpTrigger, string id, bool? activearg, TraceWriter log, CancellationToken cancellationToken)
{
    log.Info($"CSharpHttpTrigger invoked. RequestUri={httpTrigger.RequestUri}");
    bool active = activearg ?? false;
    var currentClaimsPrincipal = ClaimsPrincipal.Current;
    List<string> responseContentStrings = new List<string>();
    responseContentStrings.Add($"Id: {id} Active: {active}");
    if(currentClaimsPrincipal.Identity.IsAuthenticated) {
        responseContentStrings.Add($"Oh, Hey {currentClaimsPrincipal.Identity.Name}.");
    } else {
        responseContentStrings.Add($"I don't know you.");
    }
    return httpTrigger.CreateResponse(HttpStatusCode.OK, responseContentStrings);
}