module.exports = function(context, req) {
    context.log('JS HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);
    context.log(JSON.stringify(context));

    context.res = {
        status: 200,
        body: `Id ${req.query.id} ${ req.query.activearg || true }`
    }

    context.done();
};