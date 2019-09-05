export function add(...values:number[]):number{
    let result:number = 0;
    for(let i = 0, l = values.length ; i < l ; i ++){
        result+=values[i];
    }

    return result;
}

export function multiply(...values:number[]):number{
    let result:number = 1;
    for(let i = 0, l = values.length ; i < l ; i ++){
        result*=values[i];
    }

    return result;
}

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