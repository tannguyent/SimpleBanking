'use strict';

const environment = (process.env.NODE_ENV || 'development').trim();

if (environment === 'development') {
    module.exports = require('./build/webpack.dev.config');
} else {
    module.exports = require('./build/webpack.prod.config');
}