module.exports = function (context, req) {
    context.log('JS_ HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);
    context.res = {
        status: 200,
        body: {
            req: req,
            env: process.env
        }
    }

    context.done();
};