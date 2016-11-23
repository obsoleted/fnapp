module.exports = function(context, req) {
    context.log('JS_ HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);
    context.log('changed');
    context.res = {
        status: 200,
        body: `Id ${req.params.id} ${ req.params.activearg || true }`
    }
    context.done();
};