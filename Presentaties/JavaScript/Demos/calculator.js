"use strict";
exports.__esModule = true;
function add() {
    var values = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        values[_i] = arguments[_i];
    }
    var result = 0;
    for (var i = 0, l = values.length; i < l; i++) {
        result += values[i];
    }
    return result;
}
exports.add = add;
function multiply() {
    var values = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        values[_i] = arguments[_i];
    }
    var result = 1;
    for (var i = 0, l = values.length; i < l; i++) {
        result *= values[i];
    }
    return result;
}
exports.multiply = multiply;
//let sum = add(1,6,7); // 14
//sum = add(8,9);       // 17
//console.info(sum);
/*
npm install -g typescript
You can test your install by checking the version or help.

tsc --version
tsc --help

https://code.visualstudio.com/docs/languages/typescript

*/ 
