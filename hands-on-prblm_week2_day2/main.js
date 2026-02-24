import { calculateTotal } from "./cart.js";

const cart = [
    { name: "Notebook", price: 50, quantity: 2 },
    { name: "Pen", price: 10, quantity: 5 },
    { name: "Bag", price: 800, quantity: 1 }
];

const invoice = cart
    .map(item =>
        `${item.name} | Price: ₹${item.price} | Qty: ${item.quantity} | Total: ₹${item.price * item.quantity}`
    )
    .join("\n");

const totalAmount = calculateTotal(cart);

console.log(`
------ Invoice ------
${invoice}

Grand Total: ₹${totalAmount}
`);