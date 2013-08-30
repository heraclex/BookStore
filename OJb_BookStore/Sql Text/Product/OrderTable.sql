CREATE TABLE [dbo].[Order]
(
	[OrderId]				INT           IDENTITY (1, 1) PRIMARY KEY,
	[OrderDate]				DATETIME      NOT NULL,
	[EmployeeId]			INT			  NOT NULL, -- This is User ID in Security DB
	[CustomerName]			VARCHAR (100) NOT NULL,
	[CustomerAddress]		VARCHAR (100) NOT NULL,
	[CustomerPhoneNumber]	VARCHAR (100) NOT NULL,	

	/*********** Static fields************/
    [CreatedBy]       VARCHAR(150)   NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);