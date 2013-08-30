CREATE TABLE [dbo].[Product]
(
	[ProductId]		 INT            IDENTITY (1, 1) PRIMARY KEY,
	[Description]	 VARCHAR (1000)		NULL,
    [ImagePath]		 VARCHAR(50)		NULL,
    [UnitPrice]		 MONEY			NOT NULL,
    [CategoryId]	 INT			NOT NULL,

	/*********** Static fields************/
    [CreatedBy]       VARCHAR(150)   NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);