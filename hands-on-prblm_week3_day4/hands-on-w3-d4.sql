--lv1 prbm 1

SELECT 
    p.product_name + ' (' + CAST(p.model_year AS VARCHAR) + ')' AS Product_Details,
    p.product_name,
    p.model_year,
    p.list_price,
    
    (SELECT AVG(list_price) 
     FROM products 
     WHERE category_id = p.category_id) AS Category_Avg_Price,

    p.list_price - 
    (SELECT AVG(list_price) 
     FROM products 
     WHERE category_id = p.category_id) AS Price_Difference

FROM products p

WHERE p.list_price >
      (SELECT AVG(list_price) 
       FROM products 
       WHERE category_id = p.category_id);


       --lv1 prblm2

       -- Customers with orders
SELECT 
    c.first_name + ' ' + c.last_name AS Customer_Name,

    (SELECT SUM(oi.quantity * oi.list_price * (1 - oi.discount))
     FROM orders o
     JOIN order_items oi ON o.order_id = oi.order_id
     WHERE o.customer_id = c.customer_id) AS Total_Order_Value,

    CASE
        WHEN (SELECT SUM(oi.quantity * oi.list_price * (1 - oi.discount))
              FROM orders o
              JOIN order_items oi ON o.order_id = oi.order_id
              WHERE o.customer_id = c.customer_id) > 10000 
             THEN 'Premium'

        WHEN (SELECT SUM(oi.quantity * oi.list_price * (1 - oi.discount))
              FROM orders o
              JOIN order_items oi ON o.order_id = oi.order_id
              WHERE o.customer_id = c.customer_id) BETWEEN 5000 AND 10000
             THEN 'Regular'

        ELSE 'Basic'
    END AS Customer_Category

FROM customers c
WHERE c.customer_id IN (SELECT customer_id FROM orders)

UNION

-- Customers without orders
SELECT 
    c.first_name + ' ' + c.last_name AS Customer_Name,
    NULL AS Total_Order_Value,
    'No Orders' AS Customer_Category

FROM customers c
WHERE c.customer_id NOT IN (SELECT customer_id FROM orders);


USE EcommAppDb;

------------------------------------------------------------
-- PROBLEM 3: Store Performance and Stock Validation
------------------------------------------------------------

-- Step 1: Store wise product sales and revenue
SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS Total_Quantity_Sold,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS Total_Revenue
FROM orders o
INNER JOIN order_items oi ON o.order_id = oi.order_id
INNER JOIN stores s ON o.store_id = s.store_id
INNER JOIN products p ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name
ORDER BY s.store_name;


-- Step 2: Find products sold but currently out of stock
SELECT o.store_id, oi.product_id
FROM orders o
INNER JOIN order_items oi ON o.order_id = oi.order_id

INTERSECT

SELECT store_id, product_id
FROM stocks
WHERE quantity = 0;


-- Step 3: Simulate stock update after sales
UPDATE stocks
SET quantity = 0
WHERE product_id IN
(
    SELECT product_id
    FROM order_items
);


------------------------------------------------------------
-- PROBLEM 4: Order Cleanup and Data Maintenance
------------------------------------------------------------

-- Step 1: Create archive table
CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_status TINYINT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    staff_id INT
);


-- Step 2: Insert rejected orders older than 1 year into archive
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


-- Step 3: Delete archived records from main table
DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


-- Step 4: Customers whose all orders are completed
SELECT 
    c.customer_id,
    c.first_name,
    c.last_name
FROM customers c
WHERE NOT EXISTS
(
    SELECT *
    FROM orders o
    WHERE o.customer_id = c.customer_id
    AND o.order_status <> 4
);


-- Step 5: Order processing delay analysis
SELECT 
    order_id,
    order_date,
    shipped_date,
    DATEDIFF(DAY, order_date, shipped_date) AS Processing_Delay,
    CASE
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS Delivery_Status
FROM orders;

