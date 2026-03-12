--lv2 prblm1
--Stored Procedure: Total Sales per Store
CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalSales
    FROM orders o
    JOIN order_items oi ON o.order_id = oi.order_id
    JOIN stores s ON o.store_id = s.store_id
    WHERE o.order_status = 4
    GROUP BY s.store_name
END;

EXEC sp_TotalSalesPerStore;

--Stored Procedure: Orders by Date Range
CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_date,
        order_status
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
END;

EXEC sp_GetOrdersByDateRange '2016-01-01','2016-01-05';

--Scalar Function: Calculate Price After Discount
CREATE FUNCTION fn_CalcDiscountPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN (@price - (@price * ISNULL(@discount,0)))
END;

SELECT 
product_id,
list_price,
discount,
dbo.fn_CalcDiscountPrice(list_price,discount) AS FinalPrice
FROM order_items;

--Table-Valued Function: Top 5 Selling Products
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS TotalSold
    FROM order_items oi
    JOIN products p ON oi.product_id = p.product_id
    GROUP BY p.product_name
    ORDER BY SUM(oi.quantity) DESC
);

SELECT * FROM fn_Top5SellingProducts();


--lv2 prblm2
CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        IF EXISTS (
            SELECT *
            FROM inserted i
            JOIN stocks s
            ON i.product_id = s.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock available',16,1)
            ROLLBACK TRANSACTION
            RETURN
        END

        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT ERROR_MESSAGE()
    END CATCH
END

--lv2 prblm3

CREATE TRIGGER trg_CheckOrderCompletion
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        IF EXISTS (
            SELECT *
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Order cannot be completed without shipped date',16,1)
            ROLLBACK TRANSACTION
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT ERROR_MESSAGE()
    END CATCH
END


--lv2 prblm4

CREATE PROCEDURE sp_CalculateStoreRevenue
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(10,2)

CREATE TABLE #StoreRevenue
(
store_id INT,
order_id INT,
revenue DECIMAL(10,2)
)

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id,@store_id

WHILE @@FETCH_STATUS = 0
BEGIN

SELECT @revenue =
SUM(quantity * list_price * (1 - discount))
FROM order_items
WHERE order_id = @order_id

INSERT INTO #StoreRevenue
VALUES(@store_id,@order_id,@revenue)

FETCH NEXT FROM order_cursor INTO @order_id,@store_id
END

CLOSE order_cursor
DEALLOCATE order_cursor

SELECT 
store_id,
SUM(revenue) AS TotalRevenue
FROM #StoreRevenue
GROUP BY store_id

COMMIT TRANSACTION

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT ERROR_MESSAGE()
END CATCH

END

EXEC sp_CalculateStoreRevenue
