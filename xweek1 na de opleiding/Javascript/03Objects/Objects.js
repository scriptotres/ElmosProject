var myCar = new Object();
myCar.make = 'Ford';
myCar.model = 'Mustang';
myCar.year = 1969;
myCar.color='black';

console.log(myCar);

function Car(make, model, year, owner) {
    this.make = make
    this.model = model;
    this.year = year;
    this.owner = owner;
    this.displayCar = displayCar;
    }
     
function Person(name, age, sex) {
    this.name = name;
    this.age = age;
    this.sex = sex;
    }
var ken = new Person('Ken Jones', 39, 'M');
var car2 = new Car('Nissan', '300ZX', 1992, ken);
console.log(car2);
car2.displayCar();

function displayCar() {
    var result = `A Beautiful ${this.year} ${this.make} ${this.model} from ${this.owner.name}`;
    console.log(result);
  }



  function validate(obj, lowval, hival) {
    if ((obj.value < lowval) || (obj.value > hival)) {
      alert('Invalid Value!');
    }
    else{
        alert('valid value!');
    }
  }

  function Hobbyist(hobby) {
    this.hobby = hobby || 'scuba';
    console.log(hobby);
 }
 


 
 //PROMISE
 //createAudioFileAsync(audioSettings, successCallback, failureCallback); 
 //-->createAudioFileAsync(audioSettings).then(successCallback, failureCallback);
 
 
//Chaining promises

 doSomething(function(result) {
    doSomethingElse(result, function(newResult) {
      doThirdThing(newResult, function(finalResult) {
        console.log('Got the final result: ' + finalResult);
      }, failureCallback);
    }, failureCallback);
  }, failureCallback);

  //kan omgevormd worden naar

  doSomething()
.then(result => doSomethingElse(result))
.then(newResult => doThirdThing(newResult))
.then(finalResult => {
  console.log(`Got the final result: ${finalResult}`);
})
.catch(failureCallback);






new Promise((resolve, reject) => {
    console.log('Initial');

    resolve();
})
.then(() => {
    throw new Error('Something failed');
        
    console.log('Do this');
})
.catch(() => {
    console.log('Do that');
})
.then(() => {
    console.log('Do this, no matter what happened before');
});