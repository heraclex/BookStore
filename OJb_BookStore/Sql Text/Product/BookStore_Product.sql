USE [master]
GO
/****** Object:  Database [BookStore_Product]    Script Date: 08/29/2013 16:38:22 ******/
CREATE DATABASE [BookStore_Product] 
GO
ALTER DATABASE [BookStore_Product] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore_Product].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore_Product] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BookStore_Product] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BookStore_Product] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BookStore_Product] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BookStore_Product] SET ARITHABORT OFF
GO
ALTER DATABASE [BookStore_Product] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BookStore_Product] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BookStore_Product] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BookStore_Product] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BookStore_Product] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BookStore_Product] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BookStore_Product] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BookStore_Product] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BookStore_Product] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BookStore_Product] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BookStore_Product] SET  DISABLE_BROKER
GO
ALTER DATABASE [BookStore_Product] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BookStore_Product] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BookStore_Product] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BookStore_Product] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BookStore_Product] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BookStore_Product] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BookStore_Product] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BookStore_Product] SET  READ_WRITE
GO
ALTER DATABASE [BookStore_Product] SET RECOVERY FULL
GO
ALTER DATABASE [BookStore_Product] SET  MULTI_USER
GO
ALTER DATABASE [BookStore_Product] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BookStore_Product] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookStore_Product', N'ON'
GO
USE [BookStore_Product]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 08/29/2013 16:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[EmployeeId] [datetime] NOT NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[CustomerAddress] [varchar](100) NOT NULL,
	[CustomerPhoneNumber] [varchar](100) NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 08/29/2013 16:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1000) NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([CategoryId], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, N'Cat 1', N'Toan Le', CAST(0x0000A22800000000 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Product]    Script Date: 08/29/2013 16:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](1000) NULL,
	[ImagePath] [varchar](50) NULL,
	[UnitPrice] [money] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([ProductId], [Description], [ImagePath], [UnitPrice], [CategoryId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, N'Pro 1', NULL, 10.0000, 1, N'Toan Le', CAST(0x0000A22800000000 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 08/29/2013 16:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [money] NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](150) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [fk_Product_CategoryId]    Script Date: 08/29/2013 16:38:23 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_Product_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_Product_CategoryId]
GO
/****** Object:  ForeignKey [fk_OrderDetail_OrderId]    Script Date: 08/29/2013 16:38:23 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [fk_OrderDetail_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [fk_OrderDetail_OrderId]
GO
/****** Object:  ForeignKey [fk_OrderDetail_ProductId]    Script Date: 08/29/2013 16:38:23 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [fk_OrderDetail_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [fk_OrderDetail_ProductId]
GO
