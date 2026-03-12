--lv1 prblm1

---------------------------------------------------------------------------------------------trigger to reduce stock
CREATE TRIGGER trg_ReduceStock
ON order_items
AFTER INSERT
AS
BEGIN

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
AND s.store_id = (
    SELECT store_id
    FROM orders
    WHERE order_id = i.order_id
)

IF EXISTS (
    SELECT 1
    FROM stocks
    WHERE quantity < 0
)
BEGIN
    RAISERROR('Stock cannot be negative',16,1)
    ROLLBACK TRANSACTION
END

END

------------------------------------------------------------------------------------------------transaction to place order

BEGIN TRY

BEGIN TRANSACTION

DECLARE @OrderId INT

-- Insert new order
INSERT INTO orders
(customer_id, order_status, order_date, required_date, store_id, staff_id)
VALUES
(1,1,GETDATE(),DATEADD(day,3,GETDATE()),1,1)

SET @OrderId = SCOPE_IDENTITY()

-- Check stock availability for products being ordered
IF EXISTS(
SELECT 1
FROM stocks s
JOIN products p ON p.product_id = s.product_id
WHERE s.product_id = 1
AND s.store_id = 1
AND s.quantity < 2
)
BEGIN
    RAISERROR('Insufficient Stock',16,1)
    ROLLBACK TRANSACTION
    RETURN
END

-- Insert order items
INSERT INTO order_items
(order_id,item_id,product_id,quantity,list_price,discount)
VALUES
(@OrderId,1,1,2,379.99,0),
(@OrderId,2,2,1,749.99,0)

COMMIT TRANSACTION

PRINT 'Order placed successfully'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT 'Order failed due to error'

END CATCH


--lv2 prblm2
DECLARE @OrderId INT = 1

BEGIN TRY

BEGIN TRANSACTION

-- Savepoint before stock restoration
SAVE TRANSACTION RestorePoint

-- Restore stock from cancelled order
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi
     ON s.product_id = oi.product_id
JOIN orders o
     ON o.order_id = oi.order_id
    AND s.store_id = o.store_id
WHERE oi.order_id = @OrderId

-- Check for unexpected errors
IF EXISTS(
SELECT 1
FROM stocks
WHERE quantity < 0
)
BEGIN
    PRINT 'Stock restoration failed'
    ROLLBACK TRANSACTION RestorePoint
END

-- Update order status to Rejected
UPDATE orders
SET order_status = 3
WHERE order_id = @OrderId

COMMIT TRANSACTION

PRINT 'Order cancelled successfully'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT 'Error occurred during cancellation'

END CATCH
