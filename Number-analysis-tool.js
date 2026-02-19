
let num = 7;

let result = (num >= 0) ? "Positive Number" : "Negative Number";
console.log(result);

if (num % 2 === 0) {
    console.log("Even Number");
} else {
    console.log("Odd Number");
}

console.log("Numbers from 1 to " + num + ":");

for (let i = 1; i <= num; i++) {
    console.log(i);
}
