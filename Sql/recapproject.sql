USE [master]
GO
/****** Object:  Database [ReCapProject]    Script Date: 25.02.2021 18:06:38 ******/
CREATE DATABASE [ReCapProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReCapProject', FILENAME = N'C:\Users\engin\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ReCapProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReCapProject_log', FILENAME = N'C:\Users\engin\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ReCapProject.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ReCapProject] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReCapProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReCapProject] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [ReCapProject] SET ANSI_NULLS ON 
GO
ALTER DATABASE [ReCapProject] SET ANSI_PADDING ON 
GO
ALTER DATABASE [ReCapProject] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [ReCapProject] SET ARITHABORT ON 
GO
ALTER DATABASE [ReCapProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReCapProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReCapProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReCapProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReCapProject] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [ReCapProject] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [ReCapProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReCapProject] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [ReCapProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReCapProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReCapProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReCapProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReCapProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReCapProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReCapProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReCapProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReCapProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReCapProject] SET RECOVERY FULL 
GO
ALTER DATABASE [ReCapProject] SET  MULTI_USER 
GO
ALTER DATABASE [ReCapProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReCapProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReCapProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReCapProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReCapProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReCapProject] SET QUERY_STORE = OFF
GO
USE [ReCapProject]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ReCapProject]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NULL,
	[DailyPrice] [decimal](10, 2) NULL,
	[Description] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RentDate] [date] NULL,
	[ReturnDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.02.2021 18:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [PK__User__3214EC078B220029] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1002, N'Renault')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2, 3006, N'DemoPath', CAST(N'2021-02-25T17:23:07.590' AS DateTime))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3006, 1002, 1002, 2020, CAST(50.25 AS Decimal(10, 2)), N'Deneme araç')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3007, 1002, 1002, 2019, CAST(25.75 AS Decimal(10, 2)), N'Deneme araç 2')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1002, N'Siyah')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1003, N'Beyaz')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (3, 2, N'Firma Adi')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1010, 3006, 3, CAST(N'2021-02-15' AS Date), CAST(N'2021-02-16' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1011, 3006, 3, CAST(N'2021-02-16' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Engin', N'Yenice', N'enginyenice2626@gmail.com', N'1234')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages] ADD  CONSTRAINT [DF_CarImages_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [FK_CarImages_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [FK_CarImages_CarId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Car_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Car_Brand]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Car_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Car_Color]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rental_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rental_Car]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rental_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rental_Customer]
GO
USE [master]
GO
ALTER DATABASE [ReCapProject] SET  READ_WRITE 
GO
