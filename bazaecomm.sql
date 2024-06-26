USE [master]
GO
/****** Object:  Database [ecomm]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE DATABASE [ecomm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ecomm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ecomm.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ecomm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ecomm_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ecomm] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ecomm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ecomm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ecomm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ecomm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ecomm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ecomm] SET ARITHABORT OFF 
GO
ALTER DATABASE [ecomm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ecomm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ecomm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ecomm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ecomm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ecomm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ecomm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ecomm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ecomm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ecomm] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ecomm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ecomm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ecomm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ecomm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ecomm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ecomm] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ecomm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ecomm] SET RECOVERY FULL 
GO
ALTER DATABASE [ecomm] SET  MULTI_USER 
GO
ALTER DATABASE [ecomm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ecomm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ecomm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ecomm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ecomm] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ecomm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ecomm', N'ON'
GO
ALTER DATABASE [ecomm] SET QUERY_STORE = OFF
GO
USE [ecomm]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PricePerUnit] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[ConfirmedAt] [datetime2](7) NULL,
	[UserId] [int] NOT NULL,
	[CartStatusId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartStatus]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CartStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountBrands]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountBrands](
	[DiscountId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_DiscountBrands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC,
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Percent] [decimal](5, 2) NOT NULL,
	[StartAt] [datetime2](7) NOT NULL,
	[EndAt] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UseCaseName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[UseCaseData] [nvarchar](max) NOT NULL,
	[ExecutedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 6/12/2024 7:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCases](
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCases] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UseCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240611161803_init', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (1, N'Adidas', CAST(N'2024-06-11T16:40:15.6282552' AS DateTime2), NULL)
INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (2, N'Puma', CAST(N'2024-06-11T16:40:21.9317668' AS DateTime2), NULL)
INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (3, N'Nike', CAST(N'2024-06-11T16:40:27.7113987' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([Id], [CartId], [ProductId], [Quantity], [PricePerUnit], [TotalPrice], [CreatedAt], [UpdatedAt]) VALUES (1, 1, 1, 6, CAST(20.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), CAST(N'2024-06-11T16:58:36.7087357' AS DateTime2), CAST(N'2024-06-11T16:58:57.9975385' AS DateTime2))
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [TotalPrice], [ConfirmedAt], [UserId], [CartStatusId], [CreatedAt], [UpdatedAt]) VALUES (1, CAST(120.00 AS Decimal(18, 2)), CAST(N'2024-06-11T17:02:55.6829755' AS DateTime2), 2, 2, CAST(N'2024-06-11T16:58:36.5287102' AS DateTime2), CAST(N'2024-06-11T17:02:55.7043874' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[CartStatus] ON 

INSERT [dbo].[CartStatus] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (1, N'Active', CAST(N'2024-06-11T18:56:30.9000000' AS DateTime2), NULL)
INSERT [dbo].[CartStatus] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (2, N'Confirmed', CAST(N'2024-06-11T18:56:35.0033333' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[CartStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (1, N'Accessories', CAST(N'2024-06-11T16:40:53.0957468' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (2, N'Footwear', CAST(N'2024-06-11T16:41:01.3704080' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (3, N'Clothing', CAST(N'2024-06-11T16:41:21.0198022' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[DiscountBrands] ([DiscountId], [BrandId]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Discounts] ON 

INSERT [dbo].[Discounts] ([Id], [Percent], [StartAt], [EndAt], [CreatedAt], [UpdatedAt]) VALUES (1, CAST(10.00 AS Decimal(5, 2)), CAST(N'2024-06-11T12:10:48.1090000' AS DateTime2), CAST(N'2024-07-29T12:10:48.1090000' AS DateTime2), CAST(N'2024-06-11T16:55:24.1720620' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Discounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (1, N'Male', CAST(N'2024-06-11T18:44:47.6900000' AS DateTime2), NULL)
INSERT [dbo].[Genders] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (2, N'Female', CAST(N'2024-06-11T18:44:51.8800000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Img], [Description], [Price], [BrandId], [CategoryId], [GenderId], [CreatedAt], [UpdatedAt]) VALUES (1, N'Air Force 1', N'6151cc3b-71d5-483a-8fd2-04c420cebc5a.jpg', N'Air Force sneakers, also known as Air Force 1 or AF1, are a popular line of athletic shoes produced by Nike. These sneakers were first introduced in 1982 and were named after the aircraft that carries the President of the United States, the Air Force One. The Air Force 1 sneakers are known for their classic design, featuring a low-cut silhouette with a leather upper and a thick rubber sole. They are often available in a variety of colorways and are highly regarded for their comfort and durability. Air Force sneakers have become a cultural icon and are a popular choice for both casual wear and athletic activities.', CAST(20.00 AS Decimal(18, 2)), 3, 2, 1, CAST(N'2024-06-11T16:50:12.3640185' AS DateTime2), NULL)
INSERT [dbo].[Products] ([Id], [Name], [Img], [Description], [Price], [BrandId], [CategoryId], [GenderId], [CreatedAt], [UpdatedAt]) VALUES (2, N'Originals Retro', N'3a9f4b47-877e-4130-927d-731d521fc286.jpg', N'Adidas retro sweatshirts, also known as Adidas Originals, are a classic and iconic style of sweatshirt that harkens back to the brand''s heritage. These sweatshirts often feature the trefoil logo or the classic three stripes along the sleeves, paying homage to Adidas'' roots in sportswear and athletic apparel. The retro sweatshirts are typically made from soft and comfortable materials, making them perfect for casual wear or light workouts. They come in a variety of colors and designs, allowing wearers to express their personal style while sporting a timeless and nostalgic look. Adidas retro sweatshirts are popular among fashion enthusiasts and sports fans alike, adding a touch of vintage flair to any wardrobe.', CAST(80.00 AS Decimal(18, 2)), 1, 3, 1, CAST(N'2024-06-11T16:51:05.1218818' AS DateTime2), NULL)
INSERT [dbo].[Products] ([Id], [Name], [Img], [Description], [Price], [BrandId], [CategoryId], [GenderId], [CreatedAt], [UpdatedAt]) VALUES (3, N'Air Jordan', N'e3889bbb-3ccb-49f5-840c-94faef20178c.jpg', N'Jordan retro sweatshirts, inspired by the legendary basketball player Michael Jordan, are a stylish and iconic addition to any wardrobe. These sweatshirts often feature the Jumpman logo, which has become synonymous with the Jordan brand, along with bold designs and colorways that pay tribute to Jordan''s legacy on and off the court. Made from high-quality materials, Jordan retro sweatshirts are known for their comfort and durability, making them ideal for both athletic activities and casual wear. Whether you''re a basketball fan or simply appreciate classic sportswear style, a Jordan retro sweatshirt is a must-have piece that combines heritage and fashion effortlessly', CAST(180.00 AS Decimal(18, 2)), 3, 3, 1, CAST(N'2024-06-11T16:52:01.3815175' AS DateTime2), NULL)
INSERT [dbo].[Products] ([Id], [Name], [Img], [Description], [Price], [BrandId], [CategoryId], [GenderId], [CreatedAt], [UpdatedAt]) VALUES (4, N'RS-X', N'44e64544-0525-4c54-b7fd-467161f26482.jpg', N'Puma RS-X, which is part of Puma''s Running System line. The RS-X features a chunky silhouette with a mix of materials, including mesh, leather, and suede. The RS-X is known for its retro-inspired design and comfortable cushioning, making it a stylish and functional choice for both fashion and performance.', CAST(180.00 AS Decimal(18, 2)), 2, 3, 2, CAST(N'2024-06-11T16:53:08.7893491' AS DateTime2), NULL)
INSERT [dbo].[Products] ([Id], [Name], [Img], [Description], [Price], [BrandId], [CategoryId], [GenderId], [CreatedAt], [UpdatedAt]) VALUES (5, N'Jordan cap', N'88d93ea2-bfc1-453d-9512-d1f4d3733225.jpg', N'Jordan hat, or a Jordan cap, is a stylish and functional accessory that complements the Jordan brand''s athletic and streetwear-inspired aesthetic. These caps often feature the iconic Jumpman logo, representing the Jordan brand, along with the Nike Swoosh, symbolizing the partnership between the two brands.', CAST(15.00 AS Decimal(18, 2)), 3, 1, 2, CAST(N'2024-06-11T16:54:18.0852790' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (1, N'Registration user command.', N'unauthorized', N'{"FirstName":"Admin","LastName":"Admin","Email":"admin@mail.com","Username":"admin22","Password":"adminpass22"}', CAST(N'2024-06-11T16:36:18.2553291' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (2, N'Create brand command', N'admin22', N'{"Name":"Adidas"}', CAST(N'2024-06-11T16:40:15.5862792' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (3, N'Create brand command', N'admin22', N'{"Name":"Puma"}', CAST(N'2024-06-11T16:40:21.9167264' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (4, N'Create brand command', N'admin22', N'{"Name":"Nike"}', CAST(N'2024-06-11T16:40:27.7011180' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (5, N'Get all brand.', N'unauthorized', N'{"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:40:34.2429603' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (6, N'Create new category command.', N'admin22', N'{"Name":"Accessories"}', CAST(N'2024-06-11T16:40:53.0694449' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (7, N'Create new category command.', N'admin22', N'{"Name":"Footwear"}', CAST(N'2024-06-11T16:41:01.3549459' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (8, N'Create new category command.', N'admin22', N'{"Name":"Clothing"}', CAST(N'2024-06-11T16:41:21.0121228' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (9, N'Get all category query.', N'unauthorized', N'{"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:41:24.4724784' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (10, N'Create product command.', N'admin22', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"FJ4146-100_900_900px.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"FJ4146-100_900_900px.jpg\""],"Content-Type":["image/jpeg"]},"Length":55604,"Name":"Image","FileName":"FJ4146-100_900_900px.jpg"},"Name":"Air Force 1","Img":"6151cc3b-71d5-483a-8fd2-04c420cebc5a.jpg","Description":"Air Force sneakers, also known as Air Force 1 or AF1, are a popular line of athletic shoes produced by Nike. These sneakers were first introduced in 1982 and were named after the aircraft that carries the President of the United States, the Air Force One. The Air Force 1 sneakers are known for their classic design, featuring a low-cut silhouette with a leather upper and a thick rubber sole. They are often available in a variety of colorways and are highly regarded for their comfort and durability. Air Force sneakers have become a cultural icon and are a popular choice for both casual wear and athletic activities.","Price":20.0,"BrandId":3,"CategoryId":2,"GenderId":1}', CAST(N'2024-06-11T16:50:07.6196038' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (11, N'Create product command.', N'admin22', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"IM9407_900_900px.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"IM9407_900_900px.jpg\""],"Content-Type":["image/jpeg"]},"Length":78518,"Name":"Image","FileName":"IM9407_900_900px.jpg"},"Name":"Originals Retro","Img":"3a9f4b47-877e-4130-927d-731d521fc286.jpg","Description":"Adidas retro sweatshirts, also known as Adidas Originals, are a classic and iconic style of sweatshirt that harkens back to the brand''s heritage. These sweatshirts often feature the trefoil logo or the classic three stripes along the sleeves, paying homage to Adidas'' roots in sportswear and athletic apparel. The retro sweatshirts are typically made from soft and comfortable materials, making them perfect for casual wear or light workouts. They come in a variety of colors and designs, allowing wearers to express their personal style while sporting a timeless and nostalgic look. Adidas retro sweatshirts are popular among fashion enthusiasts and sports fans alike, adding a touch of vintage flair to any wardrobe.","Price":80.0,"BrandId":1,"CategoryId":3,"GenderId":1}', CAST(N'2024-06-11T16:51:05.0749420' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (12, N'Create product command.', N'admin22', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"FB7290-436_900_900px.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"FB7290-436_900_900px.jpg\""],"Content-Type":["image/jpeg"]},"Length":75971,"Name":"Image","FileName":"FB7290-436_900_900px.jpg"},"Name":"Air Jordan","Img":"e3889bbb-3ccb-49f5-840c-94faef20178c.jpg","Description":"Jordan retro sweatshirts, inspired by the legendary basketball player Michael Jordan, are a stylish and iconic addition to any wardrobe. These sweatshirts often feature the Jumpman logo, which has become synonymous with the Jordan brand, along with bold designs and colorways that pay tribute to Jordan''s legacy on and off the court. Made from high-quality materials, Jordan retro sweatshirts are known for their comfort and durability, making them ideal for both athletic activities and casual wear. Whether you''re a basketball fan or simply appreciate classic sportswear style, a Jordan retro sweatshirt is a must-have piece that combines heritage and fashion effortlessly","Price":180.0,"BrandId":3,"CategoryId":3,"GenderId":1}', CAST(N'2024-06-11T16:52:01.3561698' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (13, N'Create product command.', N'admin22', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"392730-19_900_900px.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"392730-19_900_900px.jpg\""],"Content-Type":["image/jpeg"]},"Length":46789,"Name":"Image","FileName":"392730-19_900_900px.jpg"},"Name":"RS-X","Img":"44e64544-0525-4c54-b7fd-467161f26482.jpg","Description":"Puma RS-X, which is part of Puma''s Running System line. The RS-X features a chunky silhouette with a mix of materials, including mesh, leather, and suede. The RS-X is known for its retro-inspired design and comfortable cushioning, making it a stylish and functional choice for both fashion and performance.","Price":180.0,"BrandId":2,"CategoryId":3,"GenderId":2}', CAST(N'2024-06-11T16:53:08.7695912' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (14, N'Create product command.', N'admin22', N'{"Image":{"ContentDisposition":"form-data; name=\"Image\"; filename=\"9A0791-782_900_900px.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"Image\"; filename=\"9A0791-782_900_900px.jpg\""],"Content-Type":["image/jpeg"]},"Length":120101,"Name":"Image","FileName":"9A0791-782_900_900px.jpg"},"Name":"Jordan cap","Img":"88d93ea2-bfc1-453d-9512-d1f4d3733225.jpg","Description":"Jordan hat, or a Jordan cap, is a stylish and functional accessory that complements the Jordan brand''s athletic and streetwear-inspired aesthetic. These caps often feature the iconic Jumpman logo, representing the Jordan brand, along with the Nike Swoosh, symbolizing the partnership between the two brands.","Price":15.0,"BrandId":3,"CategoryId":1,"GenderId":2}', CAST(N'2024-06-11T16:54:18.0691748' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (15, N'Get all products', N'unauthorized', N'{"GenderId":null,"CategoryIds":null,"BrandIds":null,"MinPrice":null,"MaxPrice":null,"OrderBy":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:54:21.9973747' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (16, N'Get all confirmed purchase', N'admin22', N'{"StartConfirmedAt":null,"EndConfirmedAt":null,"MinTotalPrice":null,"MaxTotalPrice":null,"MinItemCount":null,"MaxItemCount":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:54:39.7768847' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (17, N'Get audit log', N'admin22', N'{"StartExecutedAt":null,"EndExecutedAt":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:54:43.0650738' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (18, N'', N'admin22', N'{"Percentage":10.0,"StartAt":"2024-06-11T12:10:48.109Z","EndAt":"2024-07-29T12:10:48.109Z","BrandIds":[1]}', CAST(N'2024-06-11T16:55:24.1244414' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (19, N'Get all products', N'unauthorized', N'{"GenderId":null,"CategoryIds":null,"BrandIds":null,"MinPrice":null,"MaxPrice":null,"OrderBy":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:55:31.4964174' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (20, N'Get all discount', N'admin22', N'{"StartAtMin":null,"StartAtMax":null,"EndAtMin":null,"EndAtMax":null,"PercentMin":null,"PercentMax":null,"MinProducts":null,"MaxProducts":null,"IsActive":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T16:55:45.9228127' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (21, N'Registration user command.', N'unauthorized', N'{"FirstName":"Pera","LastName":"Peric","Email":"pera@mail.com","Username":"pera123","Password":"perapass22"}', CAST(N'2024-06-11T16:57:30.1501311' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (22, N'Create cart command or add item to existing cart', N'pera123', N'{"UserId":0,"CartItems":[{"ProductId":1,"Quantity":2}]}', CAST(N'2024-06-11T16:58:36.4085405' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (23, N'Create cart command or add item to existing cart', N'pera123', N'{"UserId":0,"CartItems":[{"ProductId":1,"Quantity":4}]}', CAST(N'2024-06-11T16:58:57.9603228' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (24, N'Find cart query', N'pera123', N'{"Id":4}', CAST(N'2024-06-11T16:59:22.8398740' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (25, N'Find cart query', N'pera123', N'{"Id":1}', CAST(N'2024-06-11T16:59:50.3603809' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (26, N'Confirm order command.', N'pera123', N'1', CAST(N'2024-06-11T17:02:53.0946527' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (27, N'Get all confirmed purchase', N'admin22', N'{"StartConfirmedAt":null,"EndConfirmedAt":null,"MinTotalPrice":null,"MaxTotalPrice":null,"MinItemCount":null,"MaxItemCount":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-11T17:03:36.1129944' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (28, N'Get all products', N'unauthorized', N'{"GenderId":null,"CategoryIds":null,"BrandIds":null,"MinPrice":null,"MaxPrice":null,"OrderBy":null,"PerPage":10,"Page":1,"Keyword":null}', CAST(N'2024-06-12T17:11:00.2616036' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (29, N'Registration user command.', N'unauthorized', N'{"FirstName":"Test","LastName":"Test","Email":"test@mail.com","Username":"test123","Password":"testpass22"}', CAST(N'2024-06-12T17:21:09.5686454' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (30, N'Modify user access', N'admin22', N'{"UserId":3,"UseCaseIds":[1,2]}', CAST(N'2024-06-12T17:21:28.2659202' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [CreatedAt], [UpdatedAt]) VALUES (1, N'Admin', N'Admin', N'admin22', N'admin@mail.com', N'$2a$11$hcX8okGuKJsVYTHepNdLhuNCvxfb7YXIUajuieYiuYiUPLTNGQjkm', CAST(N'2024-06-11T16:37:00.8621251' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [CreatedAt], [UpdatedAt]) VALUES (2, N'Pera', N'Peric', N'pera123', N'pera@mail.com', N'$2a$11$L.3h4sEw1G33MQeW/1Do5eT6HQchvRBiLHGFOalTOjkpIDfkRFG1u', CAST(N'2024-06-11T16:57:39.6951206' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Email], [Password], [CreatedAt], [UpdatedAt]) VALUES (3, N'Test', N'Test', N'test123', N'test@mail.com', N'$2a$11$l1/9SZ2a1WJYrb8tlw3ikOCxWMn54VGHQVPsZez11PdaI9flEGzge', CAST(N'2024-06-12T17:21:12.5775638' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 1)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 2)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 3)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 4)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 9)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 10)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 15)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 16)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 17)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 18)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 19)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 20)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 23)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 24)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 26)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 27)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 28)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 30)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 31)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 37)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 39)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 3)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 4)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 7)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 8)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 9)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 10)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 11)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 13)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 14)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 21)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 23)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 24)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 27)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 28)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 33)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 37)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (3, 1)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (3, 2)
GO
/****** Object:  Index [IX_CartItems_CartId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_CartId] ON [dbo].[CartItems]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItems_ProductId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItems_ProductId] ON [dbo].[CartItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_CartStatusId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_CartStatusId] ON [dbo].[Carts]
(
	[CartStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_UserId] ON [dbo].[Carts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DiscountBrands_DiscountId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_DiscountBrands_DiscountId] ON [dbo].[DiscountBrands]
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_BrandId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_BrandId] ON [dbo].[Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_GenderId]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_GenderId] ON [dbo].[Products]
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UseCaseLogs_Username_UseCaseName_ExecutedAt]    Script Date: 6/12/2024 7:24:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UseCaseLogs_Username_UseCaseName_ExecutedAt] ON [dbo].[UseCaseLogs]
(
	[Username] ASC,
	[UseCaseName] ASC,
	[ExecutedAt] ASC
)
INCLUDE([UseCaseData]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Brands] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CartItems] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Carts] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CartStatus] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Discounts] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Genders] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Carts_CartId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Products_ProductId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_CartStatus_CartStatusId] FOREIGN KEY([CartStatusId])
REFERENCES [dbo].[CartStatus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_CartStatus_CartStatusId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users_UserId]
GO
ALTER TABLE [dbo].[DiscountBrands]  WITH CHECK ADD  CONSTRAINT [FK_DiscountBrands_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountBrands] CHECK CONSTRAINT [FK_DiscountBrands_Brands_BrandId]
GO
ALTER TABLE [dbo].[DiscountBrands]  WITH CHECK ADD  CONSTRAINT [FK_DiscountBrands_Discounts_DiscountId] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountBrands] CHECK CONSTRAINT [FK_DiscountBrands_Discounts_DiscountId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Genders_GenderId]
GO
ALTER TABLE [dbo].[UserUseCases]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCases] CHECK CONSTRAINT [FK_UserUseCases_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [ecomm] SET  READ_WRITE 
GO
