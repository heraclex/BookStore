ALTER TABLE OrderDetail
DROP CONSTRAINT fk_OrderDetail_OrderId;
GO

ALTER TABLE OrderDetail
DROP CONSTRAINT fk_OrderDetail_ProductId;
GO

ALTER TABLE OrderDetail
ADD CONSTRAINT fk_OrderDetail_OrderId FOREIGN KEY(OrderId)REFERENCES dbo.[Order](OrderId)
GO 

ALTER TABLE OrderDetail
ADD CONSTRAINT fk_OrderDetail_ProductId FOREIGN KEY(ProductId)REFERENCES dbo.[Product](ProductId)
GO 