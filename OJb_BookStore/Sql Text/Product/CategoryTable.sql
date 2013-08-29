CREATE TABLE [dbo].[Category]
(
	[CategoryId]	 INT            IDENTITY (1, 1) PRIMARY KEY,
	[Name]			 VARCHAR (1000)		NULL,

	/*********** Static fields************/
    [CreateBy]       VARCHAR(150)   NOT NULL,
    [CreateDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);