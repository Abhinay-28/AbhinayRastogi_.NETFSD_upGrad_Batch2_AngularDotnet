export const calculateTotal = cart =>
    cart.reduce(
        (total, item) => total + item.price * item.quantity,
        0
    );
