var obj2= ["element0", "element1","element3"];
var sayings = new Map();
sayings.set('dog', 'woof');
sayings.set(obj2, obj2);
sayings.set(6, 'toot');
sayings.set('fox');

for (var [key, value] of sayings) {
  console.log(key + ' goes ' + value);
}

//verschil map en object: 
//object hebben keys van type strings, map kan een ander type value hebben (vb nr ofzo)
/*
map vs object:
Use maps over objects when keys are unknown until run time, and when all keys are the same type and all values are the same type.

Use maps if there is a need to store primitive values as keys because object treats each key as a string whether it's a number value, boolean value or any other primitive value.

Use objects when there is logic that operates on individual elements.*/



var mySet = new Set();
mySet.add({1:200});
mySet.add('some text');
mySet.add('foo');
mySet.add(2);
mySet.size; // 2

for (let item of mySet) console.log(item);
//value in set mag maar 1 keer voorkomen


var myArray = ['value1', 'value2', 'value3'];

// Use the regular Set constructor to transform an Array into a Set
var mySetnew = new Set(myArray);
console.log(mySetnew);