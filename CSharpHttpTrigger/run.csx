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
    StringBuilder responseContent = new StringBuilder($"Id: {id} Active: {active}");
    var currentClaimsPrincipal = ClaimsPrincipal.Current;
    if(currentClaimsPrincipal != null) {
        responseContent.Append($"Oh, Hey {currentClaimsPrincipal.Identity.Name}.");
    } else {
        responseContent.Append($"{System.Environment.NewLine}I don't know you.");
    }
    return httpTrigger.CreateResponse(HttpStatusCode.OK, responseContent.ToString());
}