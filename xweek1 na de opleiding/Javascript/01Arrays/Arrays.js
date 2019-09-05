//from tutorial: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Indexed_collections


var obj = {};
// ...
obj.prop = ["element0", "element1","element3"];

// OR
var obj2= ["element0", "element1","element3"];

console.log(obj,obj2)
console.log(obj2)

var emp = [];
emp[0] = 'Casey Jones';
emp[1] = 'Phil Lesh';
emp[2] = 'August West';
console.log(emp)


var arr = ['one', 'two', 'three'];
arr[30]="four";
let arraysize =arr['length']; 
console.log(arr,arraysize)

var myArray = new Array('Wind', 'Rain', 'Fire');
myArray.sort(); 
console.log(myArray);
var sortFn = function(a, b) {
    if (a[a.length - 1] < b[b.length - 1]) return -1;
    if (a[a.length - 1] > b[b.length - 1]) return 1;
    if (a[a.length - 1] == b[b.length - 1]) return 0;
  }
  myArray.sort(sortFn);
  console.log(myArray);


  var a = ['a', 'b', 'a', 'b', 'a'];
console.log(a.indexOf('b')); // logs 1
// kijkt in welke index de opgegeven waarde zit , bij b,2 de 2de b 
console.log(a.indexOf('b', 2)); // logs 3


var a = ['a', 'b', 'c'];
a.forEach(function(element) { console.log(element); }); 
// logs each item in turn