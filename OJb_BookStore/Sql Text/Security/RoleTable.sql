CREATE TABLE [dbo].[Role]
(
	[RoleId]		 INT            IDENTITY (1, 1) PRIMARY KEY,
	[RoleName]       VARCHAR(150)   NOT NULL,

	/*********** Static fields************/
    [CreatedBy]       VARCHAR(150)   NOT NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);   

