module.exports = function(context, req) {
    context.log('JS_ HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);
    // context.log(JSON.stringify(context));
    context.log("req");
    context.log(req);
    context.log(context.req);
    context.log('---');
    context.log(req.params);
    context.log(req.params.id);
    context.log(req.params['id']);
    context.log('---');

    context.log(context.req.params);
    context.log(context.req.params.id);
    context.log(context.req.params['id']);
    context.res = {
        status: 200,
        body: `Id ${req.params.id} ${ req.params.activearg || true }`
    }

    context.done();
};