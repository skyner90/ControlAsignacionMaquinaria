USE [master]
GO
/****** Object:  Database [AsignacionMaquinariaDB]    Script Date: 5/1/2022 2:25:09 ******/
CREATE DATABASE [AsignacionMaquinariaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AsignacionMaquinariaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AsignacionMaquinariaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AsignacionMaquinariaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AsignacionMaquinariaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AsignacionMaquinariaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET  MULTI_USER 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET QUERY_STORE = OFF
GO
USE [AsignacionMaquinariaDB]
GO
/****** Object:  Table [dbo].[Asi_Empleado]    Script Date: 5/1/2022 2:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asi_Empleado](
	[empId] [int] IDENTITY(1,1) NOT NULL,
	[empNombre] [varchar](250) NULL,
	[empCargo] [varchar](250) NULL,
	[empCedula] [varchar](250) NULL,
	[empArea] [varchar](250) NULL,
	[empFechaCreacion] [datetime2](7) NULL,
	[empEstado] [bit] NULL,
 CONSTRAINT [PK_Asi_Empleado] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asi_Maquinaria]    Script Date: 5/1/2022 2:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asi_Maquinaria](
	[maqId] [int] IDENTITY(1,1) NOT NULL,
	[maqSerie] [varchar](150) NULL,
	[maqDescripcion] [varchar](500) NULL,
	[maqEstado] [bit] NULL,
	[maqFechaCreacion] [datetime2](7) NULL,
	[empId] [int] NULL,
	[maqDisponible] [bit] NULL,
 CONSTRAINT [PK_Asi_Maquinaria] PRIMARY KEY CLUSTERED 
(
	[maqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asi_Empleado] ON 

INSERT [dbo].[Asi_Empleado] ([empId], [empNombre], [empCargo], [empCedula], [empArea], [empFechaCreacion], [empEstado]) VALUES (1, N'Paul', N'Gerente', N'1723228569', N'Sistemas', CAST(N'2022-01-04T19:22:10.7494173' AS DateTime2), 1)
INSERT [dbo].[Asi_Empleado] ([empId], [empNombre], [empCargo], [empCedula], [empArea], [empFechaCreacion], [empEstado]) VALUES (2, N'Alejandro', N'Tesorero', N'1425362514', N'Contabilidad', CAST(N'2022-01-04T19:24:10.4356806' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Asi_Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Asi_Maquinaria] ON 

INSERT [dbo].[Asi_Maquinaria] ([maqId], [maqSerie], [maqDescripcion], [maqEstado], [maqFechaCreacion], [empId], [maqDisponible]) VALUES (1, N'SE001', N'Maquinaria de corte de césped', 1, CAST(N'2022-01-04T22:01:40.8279438' AS DateTime2), 2, 0)
INSERT [dbo].[Asi_Maquinaria] ([maqId], [maqSerie], [maqDescripcion], [maqEstado], [maqFechaCreacion], [empId], [maqDisponible]) VALUES (2, N'SE002', N'Maquina de corte de madera', 1, CAST(N'2022-01-04T23:25:45.8597045' AS DateTime2), 2, 0)
INSERT [dbo].[Asi_Maquinaria] ([maqId], [maqSerie], [maqDescripcion], [maqEstado], [maqFechaCreacion], [empId], [maqDisponible]) VALUES (3, N'SQ001', N'Maquina renovadora de asfalto', 1, CAST(N'2022-01-04T23:26:04.8926070' AS DateTime2), 1, 0)
SET IDENTITY_INSERT [dbo].[Asi_Maquinaria] OFF
GO
ALTER TABLE [dbo].[Asi_Maquinaria]  WITH CHECK ADD  CONSTRAINT [FK_Asi_Maquinaria_Asi_Empleado] FOREIGN KEY([empId])
REFERENCES [dbo].[Asi_Empleado] ([empId])
GO
ALTER TABLE [dbo].[Asi_Maquinaria] CHECK CONSTRAINT [FK_Asi_Maquinaria_Asi_Empleado]
GO
USE [master]
GO
ALTER DATABASE [AsignacionMaquinariaDB] SET  READ_WRITE 
GO
