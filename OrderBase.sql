USE [master]
GO
/****** Object:  Database [OrderBase]    Script Date: 23.01.2023 13:53:20 ******/
CREATE DATABASE [OrderBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OrderBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OrderBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OrderBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderBase] SET  MULTI_USER 
GO
ALTER DATABASE [OrderBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderBase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OrderBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderBase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OrderBase] SET QUERY_STORE = OFF
GO
USE [OrderBase]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[PenId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pen]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PenTypeId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Pen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PenType]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PenType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_PenType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23.01.2023 13:53:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (1, N'Bic')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (2, N'Berlingo')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (3, N'ErichKrause')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (4, N'ProEcoPen')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (5, N'Beifa')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (6, N'Brauberg')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (7, N'Centrum')
GO
INSERT [dbo].[Company] ([Id], [Name]) VALUES (8, N'Pilot')
GO
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [TypeId], [Name], [Address]) VALUES (1, 1, N'Михаил', N'Казань')
GO
INSERT [dbo].[Customer] ([Id], [TypeId], [Name], [Address]) VALUES (6, 1, N'ertert', N'ertet')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerType] ON 
GO
INSERT [dbo].[CustomerType] ([Id], [Name]) VALUES (1, N'Оптовый')
GO
INSERT [dbo].[CustomerType] ([Id], [Name]) VALUES (2, N'Розничный')
GO
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([Id], [Date], [PenId], [CustomerId], [Count]) VALUES (1, CAST(N'2023-01-11' AS Date), 1, 1, 11)
GO
INSERT [dbo].[Order] ([Id], [Date], [PenId], [CustomerId], [Count]) VALUES (2, CAST(N'2023-01-17' AS Date), 1, 1, 1111)
GO
INSERT [dbo].[Order] ([Id], [Date], [PenId], [CustomerId], [Count]) VALUES (3, CAST(N'2023-01-23' AS Date), 2, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Pen] ON 
GO
INSERT [dbo].[Pen] ([Id], [Name], [PenTypeId], [CompanyId], [Price], [Color]) VALUES (1, N'Ручка', 1, 1, CAST(132.00 AS Decimal(10, 2)), N'Черная')
GO
INSERT [dbo].[Pen] ([Id], [Name], [PenTypeId], [CompanyId], [Price], [Color]) VALUES (2, N'Не карандаш', 4, 7, CAST(43.00 AS Decimal(10, 2)), N'Черная')
GO
INSERT [dbo].[Pen] ([Id], [Name], [PenTypeId], [CompanyId], [Price], [Color]) VALUES (3, N'Карандаш', 2, 3, CAST(1.00 AS Decimal(10, 2)), N'Черная')
GO
INSERT [dbo].[Pen] ([Id], [Name], [PenTypeId], [CompanyId], [Price], [Color]) VALUES (4, N'Хорошая ручка', 2, 3, CAST(21.00 AS Decimal(10, 2)), N'Желтый')
GO
INSERT [dbo].[Pen] ([Id], [Name], [PenTypeId], [CompanyId], [Price], [Color]) VALUES (5, N'Ручка типа «927»', 2, 8, CAST(10.00 AS Decimal(10, 2)), N'Синий')
GO
SET IDENTITY_INSERT [dbo].[Pen] OFF
GO
SET IDENTITY_INSERT [dbo].[PenType] ON 
GO
INSERT [dbo].[PenType] ([Id], [Name]) VALUES (1, N'Перьевая')
GO
INSERT [dbo].[PenType] ([Id], [Name]) VALUES (2, N'Шариковая')
GO
INSERT [dbo].[PenType] ([Id], [Name]) VALUES (3, N'Капиллярная')
GO
INSERT [dbo].[PenType] ([Id], [Name]) VALUES (4, N'Гелевая')
GO
SET IDENTITY_INSERT [dbo].[PenType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Login], [Password], [CustomerId]) VALUES (1, N'111', N'111', 1)
GO
INSERT [dbo].[User] ([Id], [Login], [Password], [CustomerId]) VALUES (6, N'ertrtg', N'123', 6)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 23.01.2023 13:53:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[CustomerType] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerType]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Pen] FOREIGN KEY([PenId])
REFERENCES [dbo].[Pen] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Pen]
GO
ALTER TABLE [dbo].[Pen]  WITH CHECK ADD  CONSTRAINT [FK_Pen_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Pen] CHECK CONSTRAINT [FK_Pen_Company]
GO
ALTER TABLE [dbo].[Pen]  WITH CHECK ADD  CONSTRAINT [FK_Pen_PenType] FOREIGN KEY([PenTypeId])
REFERENCES [dbo].[PenType] ([Id])
GO
ALTER TABLE [dbo].[Pen] CHECK CONSTRAINT [FK_Pen_PenType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Customer]
GO
USE [master]
GO
ALTER DATABASE [OrderBase] SET  READ_WRITE 
GO
