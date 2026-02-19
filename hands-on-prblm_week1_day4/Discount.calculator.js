
let amount = 4200;
let discount = 0;
let finalAmount;

if (amount >= 5000) {
    discount = amount * 0.20;
}
else if (amount >= 3000) {
    discount = amount * 0.10;
}
else {
    discount = 0;
}

finalAmount = amount - discount;

document.write("Purchase Amount: ₹" + amount + "<br>");
document.write("Discount: ₹" + discount + "<br>");
document.write("Final Payable Amount: ₹" + finalAmount);

console.log("Amount:", amount);
console.log("Discount:", discount);
console.log("Final:", finalAmount);
