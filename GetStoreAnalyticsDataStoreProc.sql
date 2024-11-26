CREATE PROCEDURE GetStoreAnalyticsData
AS
BEGIN
SELECT 
        s.Id AS StoreId,
        s.Name AS StoreName,
        COUNT(o.ClientId) AS ClientCount,
        COUNT(o.Id) AS OrderCount,
        SUM(o.PurchasePrice) AS TotalPrice,
        AVG(o.PurchasePrice) AS AveragePrice,
		YEAR(o.OrderDate) AS Year,
        MONTH(o.OrderDate) AS Month
    FROM [CarDealership].[dbo].[Order] as o
    INNER JOIN [CarDealership].[dbo].[Store] as s ON s.Id = o.StoreId
	WHERE o.OrderDate >= DATEADD(MONTH, -12, GETDATE())
    GROUP BY s.Id, s.Name, YEAR(o.OrderDate), MONTH(o.OrderDate)
END;

drop proc GetStoreAnalyticsData