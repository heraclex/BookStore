CREATE TABLE [dbo].[OrderDetail]
(
	[OrderDetailId]		INT     IDENTITY (1, 1) PRIMARY KEY,
	[OrderId]			INT     NOT NULL,
	[ProductId]			INT     NOT NULL, 
	[UnitPrice]			MONEY	NOT NULL, -- Will be copied from Product detail
	[Quantity]			INT		NOT NULL,
	[Discount]			MONEY		NULL,

	/*********** Static fields************/
    [CreatedBy]       VARCHAR(150)   NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);