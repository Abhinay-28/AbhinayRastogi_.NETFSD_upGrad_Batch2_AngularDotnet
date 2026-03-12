-----------------------------------------------------lv1 prblm1

---req1
CREATE DATABASE EcommDb
use EcommDb

---req2
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id;

---req3
SELECT 
    first_name,
    last_name,
    email,
    city
FROM customers
WHERE city = 'Los Angeles';


---req4
SELECT 
    c.category_name,
    COUNT(p.product_id) AS Total_Products
FROM categories c
LEFT JOIN products p 
    ON c.category_id = p.category_id
GROUP BY c.category_name;


------------------------------------------------lv1 prblm2

---req1
CREATE VIEW vw_ProductDetails
AS
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id;

    SELECT * FROM vw_ProductDetails;

---req2

CREATE VIEW vw_OrderDetails
AS
SELECT 
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_status,
    o.order_date,
    o.required_date,
    o.shipped_date
FROM orders o
INNER JOIN customers c 
    ON o.customer_id = c.customer_id
INNER JOIN stores s 
    ON o.store_id = s.store_id
INNER JOIN staffs st 
    ON o.staff_id = st.staff_id;

    SELECT * FROM vw_OrderDetails;

----req3
---product table indexes
CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

---order table indexes
CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);


----order items table indexs
CREATE INDEX idx_orderitems_product
ON order_items(product_id);

---req4
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id;
