USE [master]
GO
/****** Object:  Database [TARSDeliveryDB2]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE DATABASE [TARSDeliveryDB2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TARSDeliveryDB2', FILENAME = N'D:\chien pham\MSSQL16.MSSQLSERVER\MSSQL\DATA\TARSDeliveryDB2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TARSDeliveryDB2_log', FILENAME = N'D:\chien pham\MSSQL16.MSSQLSERVER\MSSQL\DATA\TARSDeliveryDB2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TARSDeliveryDB2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TARSDeliveryDB2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TARSDeliveryDB2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET ARITHABORT OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TARSDeliveryDB2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TARSDeliveryDB2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TARSDeliveryDB2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TARSDeliveryDB2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TARSDeliveryDB2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET RECOVERY FULL 
GO
ALTER DATABASE [TARSDeliveryDB2] SET  MULTI_USER 
GO
ALTER DATABASE [TARSDeliveryDB2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TARSDeliveryDB2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TARSDeliveryDB2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TARSDeliveryDB2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TARSDeliveryDB2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TARSDeliveryDB2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TARSDeliveryDB2', N'ON'
GO
ALTER DATABASE [TARSDeliveryDB2] SET QUERY_STORE = ON
GO
ALTER DATABASE [TARSDeliveryDB2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TARSDeliveryDB2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/27/2023 2:05:56 PM ******/
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
/****** Object:  Table [dbo].[AppRoleClaims]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoles]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserClaims]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserLogins]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Create_date] [datetime2](7) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[PincodeId] [nvarchar](450) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserTokens]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[area_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryEmployees]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryEmployees](
	[track_id] [int] NOT NULL,
	[employee_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_HistoryEmployees] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC,
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoneyOrder]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoneyOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[sender_name] [nvarchar](50) NULL,
	[sender_pincode] [nvarchar](450) NULL,
	[sender_address] [nvarchar](200) NULL,
	[sender_phone] [nvarchar](10) NULL,
	[sender_email] [nvarchar](max) NULL,
	[sender_national_identity_number] [nvarchar](20) NULL,
	[receiver_name] [nvarchar](50) NULL,
	[receiver_pincode] [nvarchar](450) NULL,
	[receiver_address] [nvarchar](200) NULL,
	[receiver_phone] [nvarchar](10) NULL,
	[receiver_email] [nvarchar](max) NULL,
	[receiver_national_identity_number] [nvarchar](20) NULL,
	[transfer_status] [int] NOT NULL,
	[note] [nvarchar](500) NULL,
	[transfer_value] [real] NOT NULL,
	[transfer_fee] [real] NOT NULL,
	[payer] [nvarchar](max) NULL,
	[send_date] [datetime2](7) NOT NULL,
	[receive_date] [datetime2](7) NULL,
	[total_charge] [real] NOT NULL,
 CONSTRAINT [PK_MoneyOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoneyScope]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoneyScope](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[min_value] [real] NOT NULL,
	[max_value] [real] NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_MoneyScope] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoneyServicePrice]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoneyServicePrice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[zone_type_id] [int] NOT NULL,
	[money_scope_id] [int] NOT NULL,
	[fee] [real] NOT NULL,
 CONSTRAINT [PK_MoneyServicePrice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfficeBranchs]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficeBranchs](
	[id] [nvarchar](450) NOT NULL,
	[branch_name] [nvarchar](max) NOT NULL,
	[pincode] [nvarchar](450) NOT NULL,
	[district_name] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[branch_phone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OfficeBranchs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](600) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParcelOrder]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[sender_name] [nvarchar](50) NOT NULL,
	[sender_pincode] [nvarchar](450) NOT NULL,
	[sender_address] [nvarchar](200) NOT NULL,
	[sender_phone] [nvarchar](20) NOT NULL,
	[sender_email] [nvarchar](50) NOT NULL,
	[receiver_name] [nvarchar](50) NOT NULL,
	[receiver_pincode] [nvarchar](450) NOT NULL,
	[receiver_address] [nvarchar](200) NOT NULL,
	[receiver_phone] [nvarchar](50) NOT NULL,
	[receiver_email] [nvarchar](50) NOT NULL,
	[order_status] [int] NOT NULL,
	[description] [nvarchar](200) NULL,
	[note] [nvarchar](max) NULL,
	[parcel_length] [real] NOT NULL,
	[parcel_height] [real] NOT NULL,
	[parcel_width] [real] NOT NULL,
	[parcel_weight] [real] NOT NULL,
	[service_id] [int] NOT NULL,
	[parcel_type_id] [int] NOT NULL,
	[payer] [nvarchar](10) NOT NULL,
	[payment_method] [nvarchar](10) NOT NULL,
	[send_date] [datetime2](7) NULL,
	[receive_date] [datetime2](7) NULL,
	[vpp_value] [real] NOT NULL,
	[total_charge] [real] NOT NULL,
 CONSTRAINT [PK_ParcelOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParcelServicePrice]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelServicePrice](
	[parcel_price_id] [int] IDENTITY(1,1) NOT NULL,
	[zone_type_id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
	[parcel_type_id] [int] NOT NULL,
	[scope_weight_id] [int] NOT NULL,
	[service_price] [real] NOT NULL,
 CONSTRAINT [PK_ParcelServicePrice] PRIMARY KEY CLUSTERED 
(
	[parcel_price_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParcelServices]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelServices](
	[service_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[status] [bit] NOT NULL,
	[delivery_time] [int] NOT NULL,
 CONSTRAINT [PK_ParcelServices] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParcelType]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[max_length] [real] NOT NULL,
	[max_width] [real] NOT NULL,
	[max_height] [real] NOT NULL,
	[over_dimension_rate] [real] NOT NULL,
 CONSTRAINT [PK_ParcelType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pincodes]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pincodes](
	[pincode] [nvarchar](450) NOT NULL,
	[city_name] [nvarchar](max) NULL,
	[area_id] [int] NOT NULL,
 CONSTRAINT [PK_Pincodes] PRIMARY KEY CLUSTERED 
(
	[pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrackHistories]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackHistories](
	[track_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[new_status] [nvarchar](max) NULL,
	[update_time] [datetime2](7) NULL,
	[new_location] [nvarchar](max) NULL,
	[employee_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TrackHistories] PRIMARY KEY CLUSTERED 
(
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeightScope]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeightScope](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[min_weight] [real] NOT NULL,
	[max_weight] [real] NOT NULL,
	[description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_WeightScope] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZoneTypes]    Script Date: 10/27/2023 2:05:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZoneTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[zone_description] [nvarchar](600) NULL,
 CONSTRAINT [PK_ZoneTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_AppRoleClaims_RoleId]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AppRoleClaims_RoleId] ON [dbo].[AppRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AppRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AppUserClaims_UserId]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AppUserClaims_UserId] ON [dbo].[AppUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AppUserRoles_RoleId]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AppUserRoles_RoleId] ON [dbo].[AppUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AppUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AppUsers_PincodeId]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_AppUsers_PincodeId] ON [dbo].[AppUsers]
(
	[PincodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AppUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryEmployees_track_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_HistoryEmployees_track_id] ON [dbo].[HistoryEmployees]
(
	[track_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MoneyOrder_receiver_pincode]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_MoneyOrder_receiver_pincode] ON [dbo].[MoneyOrder]
(
	[receiver_pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MoneyOrder_sender_pincode]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_MoneyOrder_sender_pincode] ON [dbo].[MoneyOrder]
(
	[sender_pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MoneyOrder_user_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_MoneyOrder_user_id] ON [dbo].[MoneyOrder]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MoneyServicePrice_money_scope_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_MoneyServicePrice_money_scope_id] ON [dbo].[MoneyServicePrice]
(
	[money_scope_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MoneyServicePrice_zone_type_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_MoneyServicePrice_zone_type_id] ON [dbo].[MoneyServicePrice]
(
	[zone_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OfficeBranchs_pincode]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_OfficeBranchs_pincode] ON [dbo].[OfficeBranchs]
(
	[pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelOrder_order_status]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelOrder_order_status] ON [dbo].[ParcelOrder]
(
	[order_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelOrder_parcel_type_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelOrder_parcel_type_id] ON [dbo].[ParcelOrder]
(
	[parcel_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ParcelOrder_receiver_pincode]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelOrder_receiver_pincode] ON [dbo].[ParcelOrder]
(
	[receiver_pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ParcelOrder_sender_pincode]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelOrder_sender_pincode] ON [dbo].[ParcelOrder]
(
	[sender_pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelOrder_service_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelOrder_service_id] ON [dbo].[ParcelOrder]
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelOrder_user_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelOrder_user_id] ON [dbo].[ParcelOrder]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelServicePrice_parcel_type_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelServicePrice_parcel_type_id] ON [dbo].[ParcelServicePrice]
(
	[parcel_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelServicePrice_scope_weight_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelServicePrice_scope_weight_id] ON [dbo].[ParcelServicePrice]
(
	[scope_weight_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelServicePrice_service_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelServicePrice_service_id] ON [dbo].[ParcelServicePrice]
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParcelServicePrice_zone_type_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParcelServicePrice_zone_type_id] ON [dbo].[ParcelServicePrice]
(
	[zone_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pincodes_area_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pincodes_area_id] ON [dbo].[Pincodes]
(
	[area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrackHistories_order_id]    Script Date: 10/27/2023 2:05:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_TrackHistories_order_id] ON [dbo].[TrackHistories]
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AppRoleClaims_AppRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AppRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppRoleClaims] CHECK CONSTRAINT [FK_AppRoleClaims_AppRoles_RoleId]
GO
ALTER TABLE [dbo].[AppUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AppUserClaims_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUserClaims] CHECK CONSTRAINT [FK_AppUserClaims_AppUsers_UserId]
GO
ALTER TABLE [dbo].[AppUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AppUserLogins_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUserLogins] CHECK CONSTRAINT [FK_AppUserLogins_AppUsers_UserId]
GO
ALTER TABLE [dbo].[AppUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AppUserRoles_AppRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AppRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUserRoles] CHECK CONSTRAINT [FK_AppUserRoles_AppRoles_RoleId]
GO
ALTER TABLE [dbo].[AppUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AppUserRoles_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUserRoles] CHECK CONSTRAINT [FK_AppUserRoles_AppUsers_UserId]
GO
ALTER TABLE [dbo].[AppUsers]  WITH CHECK ADD  CONSTRAINT [FK_AppUsers_Pincodes_PincodeId] FOREIGN KEY([PincodeId])
REFERENCES [dbo].[Pincodes] ([pincode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUsers] CHECK CONSTRAINT [FK_AppUsers_Pincodes_PincodeId]
GO
ALTER TABLE [dbo].[AppUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AppUserTokens_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUserTokens] CHECK CONSTRAINT [FK_AppUserTokens_AppUsers_UserId]
GO
ALTER TABLE [dbo].[HistoryEmployees]  WITH CHECK ADD  CONSTRAINT [FK_HistoryEmployees_AppUsers_employee_id] FOREIGN KEY([employee_id])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistoryEmployees] CHECK CONSTRAINT [FK_HistoryEmployees_AppUsers_employee_id]
GO
ALTER TABLE [dbo].[HistoryEmployees]  WITH CHECK ADD  CONSTRAINT [FK_HistoryEmployees_TrackHistories_track_id] FOREIGN KEY([track_id])
REFERENCES [dbo].[TrackHistories] ([track_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistoryEmployees] CHECK CONSTRAINT [FK_HistoryEmployees_TrackHistories_track_id]
GO
ALTER TABLE [dbo].[MoneyOrder]  WITH CHECK ADD  CONSTRAINT [FK_MoneyOrder_AppUsers_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MoneyOrder] CHECK CONSTRAINT [FK_MoneyOrder_AppUsers_user_id]
GO
ALTER TABLE [dbo].[MoneyOrder]  WITH CHECK ADD  CONSTRAINT [FK_MoneyOrder_Pincodes_receiver_pincode] FOREIGN KEY([receiver_pincode])
REFERENCES [dbo].[Pincodes] ([pincode])
GO
ALTER TABLE [dbo].[MoneyOrder] CHECK CONSTRAINT [FK_MoneyOrder_Pincodes_receiver_pincode]
GO
ALTER TABLE [dbo].[MoneyOrder]  WITH CHECK ADD  CONSTRAINT [FK_MoneyOrder_Pincodes_sender_pincode] FOREIGN KEY([sender_pincode])
REFERENCES [dbo].[Pincodes] ([pincode])
GO
ALTER TABLE [dbo].[MoneyOrder] CHECK CONSTRAINT [FK_MoneyOrder_Pincodes_sender_pincode]
GO
ALTER TABLE [dbo].[MoneyServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_MoneyServicePrice_MoneyScope_money_scope_id] FOREIGN KEY([money_scope_id])
REFERENCES [dbo].[MoneyScope] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MoneyServicePrice] CHECK CONSTRAINT [FK_MoneyServicePrice_MoneyScope_money_scope_id]
GO
ALTER TABLE [dbo].[MoneyServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_MoneyServicePrice_ZoneTypes_zone_type_id] FOREIGN KEY([zone_type_id])
REFERENCES [dbo].[ZoneTypes] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MoneyServicePrice] CHECK CONSTRAINT [FK_MoneyServicePrice_ZoneTypes_zone_type_id]
GO
ALTER TABLE [dbo].[OfficeBranchs]  WITH CHECK ADD  CONSTRAINT [FK_OfficeBranchs_Pincodes_pincode] FOREIGN KEY([pincode])
REFERENCES [dbo].[Pincodes] ([pincode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OfficeBranchs] CHECK CONSTRAINT [FK_OfficeBranchs_Pincodes_pincode]
GO
ALTER TABLE [dbo].[ParcelOrder]  WITH CHECK ADD  CONSTRAINT [FK_ParcelOrder_AppUsers_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelOrder] CHECK CONSTRAINT [FK_ParcelOrder_AppUsers_user_id]
GO
ALTER TABLE [dbo].[ParcelOrder]  WITH CHECK ADD  CONSTRAINT [FK_ParcelOrder_OrderStatus_order_status] FOREIGN KEY([order_status])
REFERENCES [dbo].[OrderStatus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelOrder] CHECK CONSTRAINT [FK_ParcelOrder_OrderStatus_order_status]
GO
ALTER TABLE [dbo].[ParcelOrder]  WITH CHECK ADD  CONSTRAINT [FK_ParcelOrder_ParcelServices_service_id] FOREIGN KEY([service_id])
REFERENCES [dbo].[ParcelServices] ([service_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelOrder] CHECK CONSTRAINT [FK_ParcelOrder_ParcelServices_service_id]
GO
ALTER TABLE [dbo].[ParcelOrder]  WITH CHECK ADD  CONSTRAINT [FK_ParcelOrder_ParcelType_parcel_type_id] FOREIGN KEY([parcel_type_id])
REFERENCES [dbo].[ParcelType] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelOrder] CHECK CONSTRAINT [FK_ParcelOrder_ParcelType_parcel_type_id]
GO
ALTER TABLE [dbo].[ParcelOrder]  WITH CHECK ADD  CONSTRAINT [FK_ParcelOrder_Pincodes_receiver_pincode] FOREIGN KEY([receiver_pincode])
REFERENCES [dbo].[Pincodes] ([pincode])
GO
ALTER TABLE [dbo].[ParcelOrder] CHECK CONSTRAINT [FK_ParcelOrder_Pincodes_receiver_pincode]
GO
ALTER TABLE [dbo].[ParcelOrder]  WITH CHECK ADD  CONSTRAINT [FK_ParcelOrder_Pincodes_sender_pincode] FOREIGN KEY([sender_pincode])
REFERENCES [dbo].[Pincodes] ([pincode])
GO
ALTER TABLE [dbo].[ParcelOrder] CHECK CONSTRAINT [FK_ParcelOrder_Pincodes_sender_pincode]
GO
ALTER TABLE [dbo].[ParcelServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_ParcelServicePrice_ParcelServices_service_id] FOREIGN KEY([service_id])
REFERENCES [dbo].[ParcelServices] ([service_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelServicePrice] CHECK CONSTRAINT [FK_ParcelServicePrice_ParcelServices_service_id]
GO
ALTER TABLE [dbo].[ParcelServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_ParcelServicePrice_ParcelType_parcel_type_id] FOREIGN KEY([parcel_type_id])
REFERENCES [dbo].[ParcelType] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelServicePrice] CHECK CONSTRAINT [FK_ParcelServicePrice_ParcelType_parcel_type_id]
GO
ALTER TABLE [dbo].[ParcelServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_ParcelServicePrice_WeightScope_scope_weight_id] FOREIGN KEY([scope_weight_id])
REFERENCES [dbo].[WeightScope] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelServicePrice] CHECK CONSTRAINT [FK_ParcelServicePrice_WeightScope_scope_weight_id]
GO
ALTER TABLE [dbo].[ParcelServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_ParcelServicePrice_ZoneTypes_zone_type_id] FOREIGN KEY([zone_type_id])
REFERENCES [dbo].[ZoneTypes] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParcelServicePrice] CHECK CONSTRAINT [FK_ParcelServicePrice_ZoneTypes_zone_type_id]
GO
ALTER TABLE [dbo].[Pincodes]  WITH CHECK ADD  CONSTRAINT [FK_Pincodes_Areas_area_id] FOREIGN KEY([area_id])
REFERENCES [dbo].[Areas] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pincodes] CHECK CONSTRAINT [FK_Pincodes_Areas_area_id]
GO
ALTER TABLE [dbo].[TrackHistories]  WITH CHECK ADD  CONSTRAINT [FK_TrackHistories_ParcelOrder_order_id] FOREIGN KEY([order_id])
REFERENCES [dbo].[ParcelOrder] ([id])
GO
ALTER TABLE [dbo].[TrackHistories] CHECK CONSTRAINT [FK_TrackHistories_ParcelOrder_order_id]
GO
USE [master]
GO
ALTER DATABASE [TARSDeliveryDB2] SET  READ_WRITE 
GO
