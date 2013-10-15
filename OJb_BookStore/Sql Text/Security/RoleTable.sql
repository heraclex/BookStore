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


/******
-- Created on 15/10/2013
USE [OnlinePortalFoundationIntegration]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_AccountRoleDetail_AccountRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountRoleDetail]'))
ALTER TABLE [dbo].[AccountRoleDetail] DROP CONSTRAINT fk_AccountRoleDetail_AccountRole;
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_AccountRoleDetail_FunctionalUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountRoleDetail]'))
ALTER TABLE [dbo].[AccountRoleDetail] DROP CONSTRAINT fk_AccountRoleDetail_FunctionalUnit;
GO

/****** Object:  Table [dbo].[AccountRoleDetail]    Script Date: 10/15/2013 11:32:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountRoleDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccountRoleDetail]
GO

CREATE TABLE [dbo].[AccountRoleDetail] (
    [AccountRoleDetailId]   INT			IDENTITY (1, 1) PRIMARY KEY,
    [AccountRoleId]			INT			NOT NULL,
    [FunctionalUnitId]		INT			NOT NULL,    
    [CanRead]				BIT			NOT NULL,
    [CanWrite]				BIT			NOT NULL,
    [CreatedDate]			DATETIME		NULL,
    [CreatedBy]				INT				NULL,
    [ModifiedDate]			DATETIME		NULL,
    [ModifiedBy]			INT				NULL,
    [IsDeleted]				BIT			NOT NULL
);

ALTER TABLE [dbo].[AccountRoleDetail]
ADD CONSTRAINT fk_AccountRoleDetail_AccountRole FOREIGN KEY(AccountRoleId) REFERENCES [dbo].[AccountRole](AccountRoleId)
GO 

ALTER TABLE [dbo].[AccountRoleDetail]
ADD CONSTRAINT fk_AccountRoleDetail_FunctionalUnit FOREIGN KEY(FunctionalUnitId) REFERENCES [dbo].[FunctionalUnit](FunctionalUnitId)
GO 

-- INSERT DATA --
SET IDENTITY_INSERT [dbo].[AccountRoleDetail] ON;

INSERT [dbo].[AccountRoleDetail]([AccountRoleDetailId], [AccountRoleId], [FunctionalUnitId], [CanRead], [CanWrite], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsDeleted]) VALUES (1, 1, 1, 1, 1, '2013-10-15', 1, null, null, 0)

SET IDENTITY_INSERT [dbo].[AccountRoleDetail] OFF;



******/
