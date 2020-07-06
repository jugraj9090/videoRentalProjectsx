USE [master]
GO
/****** Object:  Database [Movie_Project]    Script Date: 5/15/2020 7:16:04 PM ******/
CREATE DATABASE [Movie_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Movie_Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Movie_Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Movie_Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Movie_Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Movie_Project] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Movie_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Movie_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Movie_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Movie_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Movie_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Movie_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [Movie_Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Movie_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Movie_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Movie_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Movie_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Movie_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Movie_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Movie_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Movie_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Movie_Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Movie_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Movie_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Movie_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Movie_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Movie_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Movie_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Movie_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Movie_Project] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Movie_Project] SET  MULTI_USER 
GO
ALTER DATABASE [Movie_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Movie_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Movie_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Movie_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Movie_Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Movie_Project] SET QUERY_STORE = OFF
GO
USE [Movie_Project]
GO
/****** Object:  Table [dbo].[Booking_data]    Script Date: 5/15/2020 7:16:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_data](
	[Rent_Id] [int] IDENTITY(1,1) NOT NULL,
	[Movie_Id] [int] NULL,
	[Customer_Id] [int] NULL,
	[BookingDate] [varchar](50) NULL,
	[ReturnDate] [varchar](50) NULL,
 CONSTRAINT [PK_Booking_data] PRIMARY KEY CLUSTERED 
(
	[Rent_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_data]    Script Date: 5/15/2020 7:16:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_data](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Customer_data] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_data]    Script Date: 5/15/2020 7:16:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_data](
	[Movie_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Stars] [varchar](50) NULL,
	[Year] [int] NULL,
	[Copies] [int] NULL,
	[Cost] [int] NULL,
	[Plot] [varchar](50) NULL,
	[Production] [varchar](50) NULL,
 CONSTRAINT [PK_Movie_data] PRIMARY KEY CLUSTERED 
(
	[Movie_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Movie_Project] SET  READ_WRITE 
GO
