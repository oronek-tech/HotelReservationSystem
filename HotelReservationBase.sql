USE [master]
GO
/****** Object:  Database [HotelReservationBase]    Script Date: 11.08.2020 23:41:27 ******/
CREATE DATABASE [HotelReservationBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelReservationBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelReservationBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelReservationBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelReservationBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelReservationBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelReservationBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelReservationBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelReservationBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelReservationBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelReservationBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelReservationBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelReservationBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelReservationBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelReservationBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelReservationBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelReservationBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelReservationBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelReservationBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelReservationBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelReservationBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelReservationBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelReservationBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelReservationBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelReservationBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelReservationBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelReservationBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelReservationBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelReservationBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelReservationBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelReservationBase] SET  MULTI_USER 
GO
ALTER DATABASE [HotelReservationBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelReservationBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelReservationBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelReservationBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelReservationBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelReservationBase] SET QUERY_STORE = OFF
GO
USE [HotelReservationBase]
GO
/****** Object:  Table [dbo].[People]    Script Date: 11.08.2020 23:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[IdOsoby] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[IdOsoby] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 11.08.2020 23:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[IdReservation] [int] IDENTITY(1,1) NOT NULL,
	[IdNumber] [int] NOT NULL,
	[IdOsoby] [int] NOT NULL,
	[InDate] [date] NOT NULL,
	[OutDate] [date] NOT NULL,
	[NumberOfGuest] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[IdReservation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 11.08.2020 23:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[IdNumber] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Size] [int] NOT NULL,
	[NumberOfBeds] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[IdNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_People] FOREIGN KEY([IdOsoby])
REFERENCES [dbo].[People] ([IdOsoby])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_People]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Rooms] FOREIGN KEY([IdNumber])
REFERENCES [dbo].[Rooms] ([IdNumber])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Rooms]
GO
USE [master]
GO
ALTER DATABASE [HotelReservationBase] SET  READ_WRITE 
GO
