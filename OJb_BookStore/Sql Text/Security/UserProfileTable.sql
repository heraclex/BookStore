CREATE TABLE [dbo].[UserProfile]
(
	[UserProfileId]	 INT            IDENTITY (1, 1) PRIMARY KEY,
	[FirstName]      VARCHAR(50)    NOT NULL,
	[LastName]       VARCHAR(50)    NOT NULL,
	[MiddleName]     VARCHAR(50)        NULL,
	[Address]        VARCHAR(150)		NULL,
	[PhoneNumber]    VARCHAR(50)        NULL,
	[UserId]		 INT            NOT NULL,

	/*********** Static fields************/
    [CreateBy]       VARCHAR(150)   NOT NULL,
    [CreateDate]     DATETIME       NOT NULL,
    [ModifiedBy]	 VARCHAR(150)		NULL,
    [ModifiedDate]   DATETIME			NULL,
    [IsDeleted]      BIT			NOT NULL
);   

