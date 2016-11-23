using System;
using System.Net;
using System.Net.Http;
using System.Threading;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage httpTrigger, string id, bool? activearg, TraceWriter log, CancellationToken cancellationToken)
{
    log.Info($"CSharpHttpTrigger invoked. RequestUri={httpTrigger.RequestUri}");
    bool active = activearg ?? false;
    return httpTrigger.CreateResponse(HttpStatusCode.OK, $"Id: {id} Active: {active}");
}