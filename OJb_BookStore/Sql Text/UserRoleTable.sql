CREATE TABLE [dbo].[UserRole]
(
	[UserRoleId]	 INT            IDENTITY (1, 1) PRIMARY KEY,
	[UserId]		 INT			NOT NULL,
	[RoleId]		 INT			NOT NULL,

	/*********** Static fields************/
    [CreateBy]       VARCHAR(150)   NOT NULL,
    [CreateDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);   

