ALTER TABLE Product
DROP CONSTRAINT fk_Product_CategoryId;
GO


ALTER TABLE Product
ADD CONSTRAINT fk_Product_CategoryId FOREIGN KEY(CategoryId)REFERENCES dbo.[Category](CategoryId)
GO 