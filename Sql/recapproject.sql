USE [ReCapProject]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 15.03.2021 11:39:49 ******/
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
/****** Object:  Table [dbo].[CarImages]    Script Date: 15.03.2021 11:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 15.03.2021 11:39:49 ******/
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
/****** Object:  Table [dbo].[Colors]    Script Date: 15.03.2021 11:39:49 ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 15.03.2021 11:39:49 ******/
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
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 15.03.2021 11:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 15.03.2021 11:39:49 ******/
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
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 15.03.2021 11:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15.03.2021 11:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK__User__3214EC078B220029] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1002, N'Renault')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1003, N'Volvo')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1004, N'Aston Martin')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1005, N'Audi')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1006, N'Porsche')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1007, N'BMW')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1008, N'Bugatti')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1009, N'Hyundai')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1010, N'Mercedes-Benz')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1011, N'Ford')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1012, N'Chevrolet')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1013, N'Citroen')
INSERT [dbo].[Brands] ([Id], [BrandName]) VALUES (1014, N'Fiat')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9027, 3006, N'images\9e45cd7f-b452-4443-9df2-7718cdf3854a.jpg', CAST(N'2021-03-14T20:20:14.8882733' AS DateTime2))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9028, 3007, N'images\ad09f627-a8a9-4216-a6b3-fa8d93c3e279.jpg', CAST(N'2021-03-14T20:21:12.2409191' AS DateTime2))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9029, 3007, N'images\1a7cfa57-b6c2-4978-a41c-c3fbb49fdd6a.jpg', CAST(N'2021-03-14T20:21:12.3049202' AS DateTime2))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9030, 3008, N'images\3a6cfb72-fc08-46bc-bfea-fb020b933fb7.jpg', CAST(N'2021-03-14T20:22:01.1944336' AS DateTime2))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9031, 3009, N'images\052b8af9-404c-42ea-b7e6-9ad047d84d91.jpg', CAST(N'2021-03-14T20:22:13.6539486' AS DateTime2))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3006, 1002, 1002, 2020, CAST(50.25 AS Decimal(10, 2)), N'Araç 1')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3007, 1003, 1003, 2019, CAST(25.75 AS Decimal(10, 2)), N'Araç 2')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3008, 1004, 1004, 2018, CAST(50.25 AS Decimal(10, 2)), N'Araç 3')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3009, 1005, 1005, 2017, CAST(100.00 AS Decimal(10, 2)), N'Araç 4')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3010, 1006, 1006, 2016, CAST(101.00 AS Decimal(10, 2)), N'Araç 5')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3011, 1007, 1007, 2015, CAST(102.00 AS Decimal(10, 2)), N'Araç 6')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3012, 1008, 1008, 2020, CAST(103.00 AS Decimal(10, 2)), N'Araç 7')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3013, 1009, 1002, 2019, CAST(104.00 AS Decimal(10, 2)), N'Araç 8')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3014, 1010, 1003, 2018, CAST(105.00 AS Decimal(10, 2)), N'Araç 9')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3015, 1011, 1004, 2017, CAST(110.00 AS Decimal(10, 2)), N'Araç 10')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3016, 1012, 1005, 2016, CAST(111.00 AS Decimal(10, 2)), N'Araç 11')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3017, 1013, 1006, 2015, CAST(112.00 AS Decimal(10, 2)), N'Araç 12')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3018, 1014, 1007, 2014, CAST(113.00 AS Decimal(10, 2)), N'Araç 13')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3019, 1002, 1008, 2020, CAST(114.00 AS Decimal(10, 2)), N'Araç 14')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3020, 1003, 1002, 2019, CAST(115.00 AS Decimal(10, 2)), N'Araç 15')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3021, 1004, 1003, 2018, CAST(150.00 AS Decimal(10, 2)), N'Araç 16')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3022, 1005, 1004, 2017, CAST(151.00 AS Decimal(10, 2)), N'Araç 17')
INSERT [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3023, 1006, 1005, 2016, CAST(152.00 AS Decimal(10, 2)), N'Araç 18')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1002, N'Siyah')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1003, N'Beyaz')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1004, N'Gri')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1005, N'Gümüs')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1006, N'Kirmizi')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1007, N'Mavi')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1008, N'Kahve')
INSERT [dbo].[Colors] ([Id], [ColorName]) VALUES (1009, N'Yesil')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (1, 5, N'Yenice Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (2, 7, N'Yenice Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (3, 8, N'Yenice Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (4, 9, N'Yenice Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (5, 10, N'Yenice Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (6, 11, N'Yenice Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (7, 12, N'Ünal Ailesi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (8, 13, N'Ünal Ailesi')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'brand')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (3, 3006, 1, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-14' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (4, 3007, 2, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-14' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (5, 3008, 3, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-14' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (6, 3009, 4, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-14' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (7, 3010, 5, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-14' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (8, 3011, 6, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-14' AS Date))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (9, 3012, 7, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (10, 3013, 8, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (11, 3014, 1, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (12, 3015, 2, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (13, 3016, 3, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (14, 3017, 4, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (15, 3018, 5, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (16, 3019, 6, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (17, 3020, 7, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (18, 3021, 8, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (19, 3022, 1, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (20, 3023, 2, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (21, 3006, 3, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (22, 3007, 4, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (23, 3008, 5, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (24, 3009, 6, CAST(N'2021-03-14' AS Date), NULL)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (25, 3010, 7, CAST(N'2021-03-14' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 5, 2)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (5, N'Engin', N'Yenice', N'engin@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (7, N'Ali Talha', N'Yenice', N'alitalha@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (8, N'Muzaffer', N'Yenice', N'muzaffer@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (9, N'Nevin', N'Yenice', N'nevin@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (10, N'Ali Osman', N'Yenice', N'aliosman@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (11, N'Safiye', N'Yenice', N'safiye@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (12, N'Atiye', N'Ünal', N'atiye@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (13, N'Ismail', N'Ünal', N'ismail@demo.com', 0x9645AAA3FF3B0BD4CD30FB83513326034260DF5A8D092A2876540B7665147544D1E61715D1E79397ACC4BE0A87301D9DA3655A7F101CF637630C1EF9AE1CC060, 0x4E6EEDD310D784E97C9B6C71DD245186268FDA968F62AB26F101B20A88E03F2F5C8808567F112200B9A586DC115199DE3941C09552F71F278C30CB1D0023A387FE5CA9087A000C8C51ABDB993A6493FAFD31235591E14FDC9FFF8DAD86D6816C17C3000FAD15B361792762C6B0D45C9E3407F1B3FB476C54C4A09B075992F2EA, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages] ADD  CONSTRAINT [DF_CarImages_Date]  DEFAULT (getdate()) FOR [Date]
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
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
