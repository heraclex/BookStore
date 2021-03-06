USE [master]
GO
/****** Object:  Database [BookStore_Security]    Script Date: 08/29/2013 15:26:01 ******/
CREATE DATABASE [BookStore_Security] 
GO
ALTER DATABASE [BookStore_Security] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore_Security].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore_Security] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BookStore_Security] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BookStore_Security] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BookStore_Security] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BookStore_Security] SET ARITHABORT OFF
GO
ALTER DATABASE [BookStore_Security] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BookStore_Security] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BookStore_Security] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BookStore_Security] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BookStore_Security] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BookStore_Security] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BookStore_Security] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BookStore_Security] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BookStore_Security] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BookStore_Security] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BookStore_Security] SET  DISABLE_BROKER
GO
ALTER DATABASE [BookStore_Security] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BookStore_Security] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BookStore_Security] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BookStore_Security] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BookStore_Security] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BookStore_Security] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BookStore_Security] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BookStore_Security] SET  READ_WRITE
GO
ALTER DATABASE [BookStore_Security] SET RECOVERY FULL
GO
ALTER DATABASE [BookStore_Security] SET  MULTI_USER
GO
ALTER DATABASE [BookStore_Security] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BookStore_Security] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookStore_Security', N'ON'
GO
USE [BookStore_Security]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/29/2013 15:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [UserName], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, N'Administrator', N'123456', N'SystemAdmin', CAST(0x0000A22800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (2, N'ToanLe', N'123456', N'Administrator', CAST(0x0000A22800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (3, N'NormalUser1', N'123456', N'Administrator', CAST(0x0000A22800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (4, N'NormalUser2', N'123456', N'Administrator', CAST(0x0000A22900000000 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 08/29/2013 15:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](150) NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 08/29/2013 15:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 08/29/2013 15:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserProfileId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[Address] [varchar](150) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[UserId] [int] NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [fk_UserRole_RoleId]    Script Date: 08/29/2013 15:26:02 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [fk_UserRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [fk_UserRole_RoleId]
GO
/****** Object:  ForeignKey [fk_UserRole_UserId]    Script Date: 08/29/2013 15:26:02 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [fk_UserRole_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [fk_UserRole_UserId]
GO
/****** Object:  ForeignKey [fk_UserProfile_UserId]    Script Date: 08/29/2013 15:26:02 ******/
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [fk_UserProfile_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [fk_UserProfile_UserId]
GO
