USE [master]
GO
/****** Object:  Database [ReservasDB]    Script Date: 17/06/2024 9:30:06 ******/
CREATE DATABASE [ReservasDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReservasDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ReservasDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReservasDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ReservasDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ReservasDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReservasDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReservasDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReservasDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReservasDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReservasDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReservasDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReservasDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ReservasDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReservasDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReservasDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReservasDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReservasDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReservasDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReservasDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReservasDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReservasDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ReservasDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReservasDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReservasDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReservasDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReservasDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReservasDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReservasDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReservasDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReservasDB] SET  MULTI_USER 
GO
ALTER DATABASE [ReservasDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReservasDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReservasDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReservasDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReservasDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReservasDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ReservasDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ReservasDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ReservasDB]
GO
/****** Object:  Table [dbo].[Espacios]    Script Date: 17/06/2024 9:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Espacios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[clave] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[imagen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 17/06/2024 9:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[clave] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[imagen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 17/06/2024 9:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[correo] [nvarchar](100) NOT NULL,
	[departamento] [nvarchar](100) NOT NULL,
	[contrasena] [nvarchar](255) NOT NULL,
	[rango_administrador] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservasEspacios]    Script Date: 17/06/2024 9:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservasEspacios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[profesor_id] [int] NOT NULL,
	[espacio_id] [int] NOT NULL,
	[dia] [date] NOT NULL,
	[hora_inicio] [int] NOT NULL,
	[hora_fin] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservasMaterial]    Script Date: 17/06/2024 9:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservasMaterial](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[profesor_id] [int] NOT NULL,
	[material_id] [int] NOT NULL,
	[dia] [date] NOT NULL,
	[hora_inicio] [int] NOT NULL,
	[hora_fin] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Espacios] ON 

INSERT [dbo].[Espacios] ([id], [nombre], [clave], [descripcion], [imagen]) VALUES (2, N'Zona 1', N'B01', N'Zona de abajo', N'abajo.png')
INSERT [dbo].[Espacios] ([id], [nombre], [clave], [descripcion], [imagen]) VALUES (3, N'Zona 2', N'B02', N'Zona cristal', N'cristal.png')
INSERT [dbo].[Espacios] ([id], [nombre], [clave], [descripcion], [imagen]) VALUES (4, N'Espacio Maker', N'B05', N'Zona de hacer cosas', N'maker.png')
SET IDENTITY_INSERT [dbo].[Espacios] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesores] ON 

INSERT [dbo].[Profesores] ([id], [nombre], [correo], [departamento], [contrasena], [rango_administrador]) VALUES (5, N'Juan Palomo', N'jpalomo@iesteis.es', N'Informática', N'123', N'usuario')
INSERT [dbo].[Profesores] ([id], [nombre], [correo], [departamento], [contrasena], [rango_administrador]) VALUES (7, N'Maria Sanchez', N'msanchex@iesteis.es', N'Lengua', N'123', N'administrador')
SET IDENTITY_INSERT [dbo].[Profesores] OFF
GO
ALTER TABLE [dbo].[ReservasEspacios]  WITH CHECK ADD FOREIGN KEY([espacio_id])
REFERENCES [dbo].[Espacios] ([id])
GO
ALTER TABLE [dbo].[ReservasEspacios]  WITH CHECK ADD FOREIGN KEY([profesor_id])
REFERENCES [dbo].[Profesores] ([id])
GO
ALTER TABLE [dbo].[ReservasMaterial]  WITH CHECK ADD FOREIGN KEY([material_id])
REFERENCES [dbo].[Material] ([id])
GO
ALTER TABLE [dbo].[ReservasMaterial]  WITH CHECK ADD FOREIGN KEY([profesor_id])
REFERENCES [dbo].[Profesores] ([id])
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD CHECK  (([rango_administrador]='administrador' OR [rango_administrador]='usuario'))
GO
USE [master]
GO
ALTER DATABASE [ReservasDB] SET  READ_WRITE 
GO
