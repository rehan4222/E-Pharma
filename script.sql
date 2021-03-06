USE [master]
GO
/****** Object:  Database [POS_db]    Script Date: 4/17/2018 12:51:16 PM ******/
CREATE DATABASE [POS_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POS_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\POS_db.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'POS_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\POS_db_log.ldf' , SIZE = 35712KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [POS_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POS_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [POS_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [POS_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [POS_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [POS_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [POS_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [POS_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [POS_db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [POS_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [POS_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [POS_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [POS_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [POS_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [POS_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [POS_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [POS_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [POS_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [POS_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [POS_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [POS_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [POS_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [POS_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [POS_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [POS_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [POS_db] SET RECOVERY FULL 
GO
ALTER DATABASE [POS_db] SET  MULTI_USER 
GO
ALTER DATABASE [POS_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [POS_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [POS_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [POS_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'POS_db', N'ON'
GO
USE [POS_db]
GO
/****** Object:  Table [dbo].[BankRecords]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankRecords](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Bank_FK] [int] NOT NULL,
	[Debit] [float] NOT NULL,
	[Credit] [float] NOT NULL,
	[User_FK] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_BankRecords] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banks]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cash]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cash](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Debit] [float] NOT NULL,
	[Credit] [float] NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_Cash] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Contact_No] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerDues]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_FK] [int] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_CustomerDues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CNIC] [nvarchar](50) NOT NULL,
	[Designation] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Contact_No] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expense Category]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Expense Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Exp_Category_FK] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fix Assets]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fix Assets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Asset_Name] [nvarchar](50) NOT NULL,
	[Asset_Worth] [float] NOT NULL,
 CONSTRAINT [PK_Fix Assets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LogDesc] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](7) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Openning] [float] NOT NULL,
	[Amount] [float] NOT NULL,
	[Remaining] [float] NOT NULL,
	[Invoice] [int] NOT NULL,
	[User_FK] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentsLedger]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentsLedger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Openning] [float] NOT NULL,
	[Amount] [float] NOT NULL,
	[Remaining] [float] NOT NULL,
	[Invoice] [int] NOT NULL,
	[User_FK] [int] NOT NULL,
 CONSTRAINT [PK_PaymentsLedger] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product Stock]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product Stock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_FK] [int] NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Product Stock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product Sub Category]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product Sub Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Category_FK] [int] NOT NULL,
	[Sub_Category_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product Sub Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCompany]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCompany](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Product_Sub_Category_FK] [int] NOT NULL,
	[Purchase_Cost] [float] NOT NULL,
	[Tax] [float] NOT NULL,
	[Sale_Cost] [float] NOT NULL,
	[Barcode_Value] [nvarchar](50) NOT NULL,
	[Product_Company_FK] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products Category]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_FK] [int] NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[Invoice] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [float] NOT NULL,
	[User_FK] [int] NOT NULL,
 CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchReturns]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchReturns](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_FK] [int] NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[Invoice] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [float] NOT NULL,
	[User_FK] [int] NOT NULL,
 CONSTRAINT [PK_PurchReturns] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recievings]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recievings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_FK] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Openning] [float] NOT NULL,
	[Amount] [float] NOT NULL,
	[Remaining] [float] NOT NULL,
	[Invoice] [int] NOT NULL,
	[User_FK] [int] NOT NULL,
 CONSTRAINT [PK_Recievings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rpt_Bank]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rpt_Bank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Bank] [nvarchar](50) NOT NULL,
	[Debit] [float] NOT NULL,
	[Credit] [float] NOT NULL,
	[Balance] [float] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_rpt_Bank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rpt_ProfitLoss]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rpt_ProfitLoss](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[Product] [nvarchar](50) NOT NULL,
	[TotalPurchase] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalSale] [float] NOT NULL,
	[Profit] [float] NOT NULL,
 CONSTRAINT [PK_rpt_ProfitLoss] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rpt_Purchases]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rpt_Purchases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[ProdName] [nvarchar](50) NOT NULL,
	[Cost] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [float] NOT NULL,
	[Invoice] [int] NOT NULL,
 CONSTRAINT [PK_rpt_Purchases] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rpt_Sale]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rpt_Sale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[Product] [nvarchar](50) NOT NULL,
	[Customer] [nvarchar](50) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_rpt_Sale] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rpt_StockCompanyWise]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rpt_StockCompanyWise](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](50) NOT NULL,
	[Item] [nvarchar](max) NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_rpt_StockCompanyWise] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salaries]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salaries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_FK] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Salaries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sales]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Sales_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_FK] [int] NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Customer_Name] [nvarchar](50) NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Invoice] [int] NOT NULL,
	[Unit_Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[Misc] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[User_FK] [int] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Sales_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Contact_No] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierDues]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierDues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_FK] [int] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_SupplierDues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/17/2018 12:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BankRecords] ADD  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Cash] ADD  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[BankRecords]  WITH CHECK ADD  CONSTRAINT [FK_BankRecords_Banks] FOREIGN KEY([Bank_FK])
REFERENCES [dbo].[Banks] ([ID])
GO
ALTER TABLE [dbo].[BankRecords] CHECK CONSTRAINT [FK_BankRecords_Banks]
GO
ALTER TABLE [dbo].[BankRecords]  WITH CHECK ADD  CONSTRAINT [FK_BankRecords_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[BankRecords] CHECK CONSTRAINT [FK_BankRecords_Users]
GO
ALTER TABLE [dbo].[CustomerDues]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDues_Customer] FOREIGN KEY([Customer_FK])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[CustomerDues] CHECK CONSTRAINT [FK_CustomerDues_Customer]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Expense Category] FOREIGN KEY([Exp_Category_FK])
REFERENCES [dbo].[Expense Category] ([ID])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Expense Category]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Supplier]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Users]
GO
ALTER TABLE [dbo].[PaymentsLedger]  WITH CHECK ADD  CONSTRAINT [FK_PaymentsLedger_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[PaymentsLedger] CHECK CONSTRAINT [FK_PaymentsLedger_Supplier]
GO
ALTER TABLE [dbo].[PaymentsLedger]  WITH CHECK ADD  CONSTRAINT [FK_PaymentsLedger_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PaymentsLedger] CHECK CONSTRAINT [FK_PaymentsLedger_Users]
GO
ALTER TABLE [dbo].[Product Stock]  WITH CHECK ADD  CONSTRAINT [FK_Product Stock_Products] FOREIGN KEY([Product_FK])
REFERENCES [dbo].[Products] ([Product_ID])
GO
ALTER TABLE [dbo].[Product Stock] CHECK CONSTRAINT [FK_Product Stock_Products]
GO
ALTER TABLE [dbo].[Product Stock]  WITH CHECK ADD  CONSTRAINT [FK_Product Stock_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[Product Stock] CHECK CONSTRAINT [FK_Product Stock_Supplier]
GO
ALTER TABLE [dbo].[Product Sub Category]  WITH CHECK ADD  CONSTRAINT [FK_Product Sub Category_Products Category] FOREIGN KEY([Product_Category_FK])
REFERENCES [dbo].[Products Category] ([ID])
GO
ALTER TABLE [dbo].[Product Sub Category] CHECK CONSTRAINT [FK_Product Sub Category_Products Category]
GO
ALTER TABLE [dbo].[ProductCompany]  WITH CHECK ADD  CONSTRAINT [FK_ProductCompany_ProductCompany] FOREIGN KEY([ID])
REFERENCES [dbo].[ProductCompany] ([ID])
GO
ALTER TABLE [dbo].[ProductCompany] CHECK CONSTRAINT [FK_ProductCompany_ProductCompany]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCompany] FOREIGN KEY([Product_Company_FK])
REFERENCES [dbo].[ProductCompany] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCompany]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Products] FOREIGN KEY([Product_Sub_Category_FK])
REFERENCES [dbo].[Product Sub Category] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Products]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Products] FOREIGN KEY([Product_FK])
REFERENCES [dbo].[Products] ([Product_ID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Products]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Supplier]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Users]
GO
ALTER TABLE [dbo].[PurchReturns]  WITH CHECK ADD  CONSTRAINT [FK_PurchReturns_Products] FOREIGN KEY([Product_FK])
REFERENCES [dbo].[Products] ([Product_ID])
GO
ALTER TABLE [dbo].[PurchReturns] CHECK CONSTRAINT [FK_PurchReturns_Products]
GO
ALTER TABLE [dbo].[PurchReturns]  WITH CHECK ADD  CONSTRAINT [FK_PurchReturns_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[PurchReturns] CHECK CONSTRAINT [FK_PurchReturns_Supplier]
GO
ALTER TABLE [dbo].[PurchReturns]  WITH CHECK ADD  CONSTRAINT [FK_PurchReturns_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PurchReturns] CHECK CONSTRAINT [FK_PurchReturns_Users]
GO
ALTER TABLE [dbo].[Recievings]  WITH CHECK ADD  CONSTRAINT [FK_Recievings_Customer] FOREIGN KEY([Customer_FK])
REFERENCES [dbo].[Recievings] ([ID])
GO
ALTER TABLE [dbo].[Recievings] CHECK CONSTRAINT [FK_Recievings_Customer]
GO
ALTER TABLE [dbo].[Recievings]  WITH CHECK ADD  CONSTRAINT [FK_Recievings_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Recievings] CHECK CONSTRAINT [FK_Recievings_Users]
GO
ALTER TABLE [dbo].[Salaries]  WITH CHECK ADD  CONSTRAINT [FK_Salaries_Employees] FOREIGN KEY([Employee_FK])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Salaries] CHECK CONSTRAINT [FK_Salaries_Employees]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Products] FOREIGN KEY([Product_FK])
REFERENCES [dbo].[Products] ([Product_ID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Products]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Supplier]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Users] FOREIGN KEY([User_FK])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Users]
GO
ALTER TABLE [dbo].[SupplierDues]  WITH CHECK ADD  CONSTRAINT [FK_SupplierDues_Supplier] FOREIGN KEY([Supplier_FK])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[SupplierDues] CHECK CONSTRAINT [FK_SupplierDues_Supplier]
GO
USE [master]
GO
ALTER DATABASE [POS_db] SET  READ_WRITE 
GO
