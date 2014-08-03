USE [master]
GO
/****** Object:  Database [PointSale]    Script Date: 02/08/2014 20:02:27 ******/
CREATE DATABASE [PointSale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PointSale', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PointSale.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PointSale_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PointSale_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PointSale] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PointSale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PointSale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PointSale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PointSale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PointSale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PointSale] SET ARITHABORT OFF 
GO
ALTER DATABASE [PointSale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PointSale] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PointSale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PointSale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PointSale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PointSale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PointSale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PointSale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PointSale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PointSale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PointSale] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PointSale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PointSale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PointSale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PointSale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PointSale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PointSale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PointSale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PointSale] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PointSale] SET  MULTI_USER 
GO
ALTER DATABASE [PointSale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PointSale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PointSale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PointSale] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PointSale]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Client] [int] NULL,
	[Employee] [int] NULL,
	[Tax] [int] NULL,
	[Discount] [int] NULL,
	[SubTotal] [int] NULL,
	[Total] [int] NULL,
	[State] [varchar](20) NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BillDetail](
	[Bill] [int] NOT NULL,
	[Code] [int] NULL,
	[Product] [varchar](30) NULL,
	[Qty] [int] NULL,
	[UnitCost] [int] NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[Bill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Client]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Lastname1] [varchar](30) NULL,
	[Lastname2] [varchar](30) NULL,
	[Address] [text] NULL,
	[Telephone] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Lastname1] [varchar](30) NULL,
	[Lastname2] [varchar](30) NULL,
	[Address] [text] NULL,
	[Telephone] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[CostPrice] [varchar](30) NOT NULL,
	[Category] [varchar](30) NOT NULL,
	[Brand] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductSuppliers]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSuppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NULL,
	[Product] [int] NULL,
	[Supplier] [varchar](30) NULL,
 CONSTRAINT [PK_ProductSuppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Telephone] [int] NULL,
	[Address] [text] NULL,
	[Detail] [varchar](50) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NULL,
	[Address] [text] NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WarehouseProducts]    Script Date: 02/08/2014 20:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Product] [int] NOT NULL,
	[QtyAvailable] [int] NOT NULL,
	[Warehouse] [int] NOT NULL,
 CONSTRAINT [PK_WarehouseProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Client] FOREIGN KEY([Client])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Client]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Employee] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Employee]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY([Bill])
REFERENCES [dbo].[Bill] ([Id])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brand] FOREIGN KEY([Brand])
REFERENCES [dbo].[Brand] ([Name])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brand]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([Name])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category]
GO
ALTER TABLE [dbo].[ProductSuppliers]  WITH CHECK ADD  CONSTRAINT [FK_ProductSuppliers_Product] FOREIGN KEY([Product])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductSuppliers] CHECK CONSTRAINT [FK_ProductSuppliers_Product]
GO
ALTER TABLE [dbo].[ProductSuppliers]  WITH CHECK ADD  CONSTRAINT [FK_ProductSuppliers_Supplier] FOREIGN KEY([Supplier])
REFERENCES [dbo].[Suppliers] ([Name])
GO
ALTER TABLE [dbo].[ProductSuppliers] CHECK CONSTRAINT [FK_ProductSuppliers_Supplier]
GO
ALTER TABLE [dbo].[WarehouseProducts]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseProducts_Product] FOREIGN KEY([Product])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[WarehouseProducts] CHECK CONSTRAINT [FK_WarehouseProducts_Product]
GO
ALTER TABLE [dbo].[WarehouseProducts]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseProducts_Warehouse] FOREIGN KEY([Warehouse])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[WarehouseProducts] CHECK CONSTRAINT [FK_WarehouseProducts_Warehouse]
GO
USE [master]
GO
ALTER DATABASE [PointSale] SET  READ_WRITE 
GO
