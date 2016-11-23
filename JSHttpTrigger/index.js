module.exports = function(context, req) {
    context.log('JS HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);
    context.log(JSON.stringify(context));
    context.log(req.params);
    context.log(req.params.id);
    context.log(req.params['id']);

    context.res = {
        status: 200,
        body: `Id ${req.params.id} ${ req.params.activearg || true }`
    }

    context.done();
};