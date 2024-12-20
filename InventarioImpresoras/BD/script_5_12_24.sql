USE [master]
GO
/****** Object:  Database [InventarioImpresoras]    Script Date: 05/12/2024 11:53:50 a. m. ******/
CREATE DATABASE [InventarioImpresoras]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventarioImpresoras', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\InventarioImpresoras.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventarioImpresoras_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\InventarioImpresoras_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InventarioImpresoras] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventarioImpresoras].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventarioImpresoras] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventarioImpresoras] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventarioImpresoras] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventarioImpresoras] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventarioImpresoras] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventarioImpresoras] SET  MULTI_USER 
GO
ALTER DATABASE [InventarioImpresoras] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventarioImpresoras] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventarioImpresoras] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventarioImpresoras] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventarioImpresoras] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventarioImpresoras] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InventarioImpresoras] SET QUERY_STORE = ON
GO
ALTER DATABASE [InventarioImpresoras] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InventarioImpresoras]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 05/12/2024 11:53:50 a. m. ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[idArea] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[idArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impresoras]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impresoras](
	[idImpresora] [int] IDENTITY(1,1) NOT NULL,
	[numeroSerie] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idMarca] [int] NOT NULL,
	[idModelo] [int] NOT NULL,
	[idArea] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Impresoras] PRIMARY KEY CLUSTERED 
(
	[idImpresora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecturas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturas](
	[idLectura] [int] IDENTITY(1,1) NOT NULL,
	[fechaLectura] [datetime] NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[obervaciones] [varchar](250) NOT NULL,
	[numeroCopias] [int] NULL,
	[idImpresora] [int] NULL,
 CONSTRAINT [PK_Lecturas] PRIMARY KEY CLUSTERED 
(
	[idLectura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelos]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelos](
	[idModelo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED 
(
	[idModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](100) NOT NULL,
	[apellidoPaterno] [varchar](50) NOT NULL,
	[apellidoMaterno] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](250) NOT NULL,
	[idRol] [int] NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([idArea], [nombre], [activo]) VALUES (1, N'area uno', 1)
INSERT [dbo].[Areas] ([idArea], [nombre], [activo]) VALUES (2, N'area dos', 1)
INSERT [dbo].[Areas] ([idArea], [nombre], [activo]) VALUES (3, N'area tres cambiado', 0)
INSERT [dbo].[Areas] ([idArea], [nombre], [activo]) VALUES (4, N'area cuatro cambiado dos', 0)
INSERT [dbo].[Areas] ([idArea], [nombre], [activo]) VALUES (5, N'ded', 0)
INSERT [dbo].[Areas] ([idArea], [nombre], [activo]) VALUES (6, N'area seis', 1)
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([idMarca], [nombre], [activo]) VALUES (1, N'marca uno editado cambiado', 1)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [activo]) VALUES (2, N'marca editado', 1)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [activo]) VALUES (4, N'marca cinco', 0)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [activo]) VALUES (5, N'marca siete editado', 1)
INSERT [dbo].[Marcas] ([idMarca], [nombre], [activo]) VALUES (6, N'marcas ed', 1)
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelos] ON 

INSERT [dbo].[Modelos] ([idModelo], [nombre], [activo]) VALUES (1, N'modelo uno', 1)
INSERT [dbo].[Modelos] ([idModelo], [nombre], [activo]) VALUES (2, N'modelo dos cam', 1)
INSERT [dbo].[Modelos] ([idModelo], [nombre], [activo]) VALUES (4, N'modelo seis cambiado', 1)
INSERT [dbo].[Modelos] ([idModelo], [nombre], [activo]) VALUES (5, N'modelo actualizado', 1)
SET IDENTITY_INSERT [dbo].[Modelos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (1, N'Administrador', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (2, N'capturista nvo w', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (3, N'capturista', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (4, N'editor nuevo ciend 2', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (5, N'invitado', 0)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (6, N'cambiado cien', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (7, N'inivitado tres', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (8, N'invitado seis', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (9, N'inivitado 8', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (10, N'inivitado once', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (11, N'nuevo jueves', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (12, N'jueves once', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (13, N'jueves trece', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (14, N'jueves quince', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (15, N'jueves 16', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (16, N'jueves 18', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (17, N'jueves veinte', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (18, N'jueves 22 cambiado', 1)
INSERT [dbo].[Roles] ([idRol], [nombre], [activo]) VALUES (19, N'modelo siete', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (1, N'DANIEL', N'GONZALEZ', N'GONZALEZ', N'daniel.gonzalez', N'98765', 1, 1)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (2, N'JESUS ALBERTO', N'MATA', N'ACOSTA', N'jalberto.mata', N'98765', 1, 1)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (3, N'ANDREL BALDEMIRO', N'GALLEGOS', N'CERDA', N'andrel.gallegos', N'98765', 1, 0)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (4, N'irineo antonio', N'calderon', N'aguilar', N'irineo.calderon', N'98765', 1, 1)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (5, N'jose del pilar', N'perez', N'aguilar', N'jose.perez', N'98765', 1, 0)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (6, N'jayce', N'sierra', N'lopez', N'jayce.sierra', N'98765', 1, 0)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (7, N'orlando', N'mota', N'hernandez', N'orlando.mota', N'98765', 1, 1)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (8, N'santiago seis cambiado', N'sanchez tres seis', N'sanchez tres seis', N'santigo tres', N'369', 1, 1)
INSERT [dbo].[Usuarios] ([idUsuario], [nombres], [apellidoPaterno], [apellidoMaterno], [usuario], [password], [idRol], [activo]) VALUES (9, N'santiago tres', N'sanchez tres', N'sanchez tres', N'santigo tres', N'369', 1, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Areas] ADD  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[Impresoras]  WITH CHECK ADD  CONSTRAINT [FK_Impresoras_Areas] FOREIGN KEY([idArea])
REFERENCES [dbo].[Areas] ([idArea])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Impresoras] CHECK CONSTRAINT [FK_Impresoras_Areas]
GO
ALTER TABLE [dbo].[Impresoras]  WITH CHECK ADD  CONSTRAINT [FK_Impresoras_Marcas] FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marcas] ([idMarca])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Impresoras] CHECK CONSTRAINT [FK_Impresoras_Marcas]
GO
ALTER TABLE [dbo].[Impresoras]  WITH CHECK ADD  CONSTRAINT [FK_Impresoras_Modelos] FOREIGN KEY([idModelo])
REFERENCES [dbo].[Modelos] ([idModelo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Impresoras] CHECK CONSTRAINT [FK_Impresoras_Modelos]
GO
ALTER TABLE [dbo].[Lecturas]  WITH CHECK ADD  CONSTRAINT [FK_Lecturas_Impresoras] FOREIGN KEY([idImpresora])
REFERENCES [dbo].[Impresoras] ([idImpresora])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lecturas] CHECK CONSTRAINT [FK_Lecturas_Impresoras]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[spActivarArea]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 3/12/24
-- Description:	activar area de la tabla areas
-- =============================================
CREATE PROCEDURE [dbo].[spActivarArea]
@IdArea int
AS
BEGIN
	UPDATE Areas set activo = 1 WHERE idArea = @IdArea;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spActivarMarca]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 4/12/24
-- Description:	activar marca de la tabla marcas
-- =============================================
CREATE PROCEDURE [dbo].[spActivarMarca]
@IdMarca int
AS
BEGIN
	UPDATE Marcas set activo = 1 WHERE idMarca = @IdMarca;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spActivarModelo]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 5/12/24
-- Description:	activar marca de la tabla marcas
-- =============================================
CREATE PROCEDURE [dbo].[spActivarModelo]
@IdModelo int
AS
BEGIN
	UPDATE Modelos set activo = 1 WHERE idModelo = @IdModelo;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spActivarRol]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 28/11/24
-- Description:	activar rol de la tabla roles
-- =============================================
CREATE PROCEDURE [dbo].[spActivarRol]
@IdRol int
AS
BEGIN
	UPDATE Roles set activo = 1 WHERE idRol = @IdRol;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spActivarUsuario]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 21/11/24
-- Description:	Desactiva usuario de la tabla usuarios
-- =============================================
CREATE PROCEDURE [dbo].[spActivarUsuario]
@IdUsuario int
AS
BEGIN
	UPDATE Usuarios set activo = 1 WHERE idUsuario = @IdUsuario;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spDesactivarArea]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 3/12/24
-- Description:	desactivar area de la tabla areas
-- =============================================
CREATE PROCEDURE [dbo].[spDesactivarArea]
@IdArea int
AS
BEGIN
	UPDATE Areas set activo = 0 WHERE idArea = @IdArea;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spDesactivarMarca]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 4/12/24
-- Description:	activar marca de la tabla marcas
-- =============================================
CREATE PROCEDURE [dbo].[spDesactivarMarca]
@IdMarca int
AS
BEGIN
	UPDATE Marcas set activo = 0 WHERE idMarca = @IdMarca;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spDesactivarModelo]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 5/12/24
-- Description:	activar marca de la tabla marcas
-- =============================================
CREATE PROCEDURE [dbo].[spDesactivarModelo]
@IdModelo int
AS
BEGIN
	UPDATE Modelos set activo = 0 WHERE idModelo = @IdModelo;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spDesactivarRol]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 28/11/24
-- Description:	Desactiva rol de la tabla roles
-- =============================================
CREATE PROCEDURE [dbo].[spDesactivarRol]
@IdRol int
AS
BEGIN
	UPDATE Roles set activo = 0 WHERE idRol = @IdRol;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spDesactivarUsuario]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 21/11/24
-- Description:	Desactiva usuario de la tabla usuarios
-- =============================================
CREATE PROCEDURE [dbo].[spDesactivarUsuario]
@IdUsuario int
AS
BEGIN
	UPDATE Usuarios set activo = 0 WHERE idUsuario = @IdUsuario;
	SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarArea]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 3/12/24
-- Description:	Edita una area en especifico de la tabla de areas
-- =============================================
CREATE PROCEDURE [dbo].[spEditarArea]
	@idArea int,
	@nombre varchar(50)
AS
BEGIN
	UPDATE Areas set 
		nombre = @nombre
		WHERE idArea = @idArea;

		SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarMarca]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 04/12/24
-- Description:	Edita una marca en especifico de la tabla de marca
-- =============================================
CREATE PROCEDURE [dbo].[spEditarMarca]
	@idMarca int,
	@nombre varchar(50)
AS
BEGIN
	UPDATE Marcas set 
		nombre = @nombre
		WHERE idMarca = @idMarca;

		SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarModelo]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 5/12/24
-- Description:	Edita un modelo en especifico de la tabla de modelos
-- =============================================
CREATE PROCEDURE [dbo].[spEditarModelo]
	@idModelo int,
	@nombre varchar(50)
AS
BEGIN
	UPDATE Modelos set 
		nombre = @nombre
		WHERE idModelo = @idModelo;

		SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarRol]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Chavos CBTis
-- Create date: 28/11/24
-- Description:	Edita un rol en especifico de la tabla de roles
-- =============================================
CREATE PROCEDURE [dbo].[spEditarRol]
	@idRol int,
	@nombre varchar(50)
AS
BEGIN
	UPDATE Roles set 
		nombre = @nombre
		WHERE idRol = @idRol;

		SELECT 1 AS resultado;
END
GO
/****** Object:  StoredProcedure [dbo].[spEditarUsuario]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon/ Santiago Sanchez
-- Create date: 12/11/24
-- Description:	Edita el un usuario en especifico de la tabla usuarios
-- =============================================
CREATE PROCEDURE [dbo].[spEditarUsuario]
	@idUsuario int,
	@nombre varchar(50),
	@apellidoPaterno varchar(50),
	@apellidoMaterno varchar(50),
	@usuario varchar(50),
	@password varchar(50),
	@idRol int--,
	--@activo bit
AS
BEGIN
	UPDATE Usuarios set 
		nombres = @nombre,
		apellidoPaterno = @apellidoPaterno,
		apellidoMaterno = @apellidoMaterno,
		usuario = @usuario,
		password = @password,
		idRol = @idRol--,
		--activo = @activo
		WHERE idUsuario = @idUsuario;

		SELECT 1 AS resultado;

END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarAreas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Insercion de las areas de la auditoria
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarAreas]
	@nombre varchar(50)
AS
BEGIN
	INSERT INTO Areas (nombre) VALUES (@nombre);

	SELECT SCOPE_IDENTITY() As 'idArea';
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarImpresoras]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Insercion de las impresoras
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarImpresoras]
	@numeroSerie varchar(50),
	@nombre varchar(50),
	@idMarca int,
	@idModelo int,
	@idArea int
AS
BEGIN
	INSERT INTO Impresoras(numeroSerie, nombre, idMarca, idModelo, idArea, activo) VALUES (@numeroSerie, @nombre, @idMarca, @idModelo, @idArea, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarLecturas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Insercion de las lecturas de las impresoras
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarLecturas]
	@fechaLectura dateTime,
	@fechaRegistro dateTime,
	@observaciones varchar(250),
	@numeroCopias int,
	@idImpresora int
AS
BEGIN
	INSERT INTO Lecturas(fechaLectura, fechaRegistro, obervaciones, numeroCopias, idImpresora) VALUES (@fechaLectura, @fechaRegistro, @observaciones, @numeroCopias, @idImpresora);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarMarcas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Insercion de marcas de impresoras
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarMarcas]
	@nombre varchar(50)
AS	
BEGIN
	INSERT INTO Marcas(nombre, activo) VALUES(@nombre, 1);
	
	SELECT SCOPE_IDENTITY() As idMarca
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarModelos]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Insercion de modelos de impresoras
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarModelos]
	@nombre varchar(50)
AS	
BEGIN
	INSERT INTO Modelos(nombre, activo) VALUES(@nombre, 1);

	SELECT SCOPE_IDENTITY() AS idModelo;
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarRoles]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Insercion de roles
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarRoles]
	@nombre varchar(50)
AS
BEGIN
	INSERT INTO Roles(nombre) VALUES (@nombre);

	SELECT SCOPE_IDENTITY() AS idRol;
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarUsuarios]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 12/11/24
-- Description:	Insercion de usuarios
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarUsuarios]
	@nombres varchar(50),
	@apellidoPaterno varchar(50),
	@apellidoMaterno varchar(50),
	@usuario varchar(50),
	@password varchar(50),
	@idRol int
AS
BEGIN
	INSERT INTO Usuarios (
		nombres,
		apellidoPaterno,
		apellidoMaterno,
		usuario,
		password,
		idRol,
		activo
		) VALUES (@nombres, @apellidoPaterno, @apellidoMaterno, @usuario, @password, @idRol, 1)

		select SCOPE_IDENTITY()  as idUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 07/11/24
-- Description:	Iniciar sesion
-- =============================================
CREATE PROCEDURE [dbo].[spLogin]

	@usuario varchar(50),
	@password varchar(50)

AS 
BEGIN
	SELECT idUsuario, usuario, idRol FROM Usuarios WHERE usuario = @usuario AND password = @password AND activo = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerAreas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon y Chavos CBTis
-- Create date: 03/12/24
-- Description:	Obtener el listado de areas
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerAreas]
AS
BEGIN
	SELECT idArea, nombre, activo FROM Areas;
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMarcas]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon y Chavos CBTis
-- Create date: 04/12/24
-- Description:	Obtener el listado de marcas
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerMarcas]
AS
BEGIN
	SELECT idMarca, nombre, activo FROM Marcas;
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerModelos]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon y Chavos CBTis
-- Create date: 05/12/24
-- Description:	Obtener el listado de modelos
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerModelos]
AS
BEGIN
	SELECT idModelo, nombre, activo FROM Modelos;
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerRoles]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 11/11/24
-- Description:	Obtener el listado de roles
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerRoles]
AS
BEGIN
	SELECT idRol, nombre, activo FROM Roles;
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerUsuario]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon / chavos CBTis
-- Create date: 12/11/24
-- Description:	Obtener informacion basica del usuario
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerUsuario]
	@idUsuario int
AS
BEGIN
	SELECT 
		idUsuario,
		nombres,
		apellidoPaterno,
		apellidoMaterno,
		usuario,
		password,
		idRol,
		activo 
			FROM Usuarios WHERE idUsuario = @idUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerUsuarios]    Script Date: 05/12/2024 11:53:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Irineo Calderon
-- Create date: 11/11/24
-- Description:	Obtener informacion basica de los usuario
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerUsuarios]
AS
BEGIN
	SELECT 
		t1.idUsuario,
		t1.nombres,
		t1.apellidoPaterno,
		t1.apellidoMaterno,
		t1.usuario,
		t2.idRol,
		t2.nombre AS 'rol',
		t1.activo
			FROM Usuarios AS t1
				INNER JOIN Roles AS t2 ON t2.idRol = t1.idRol; 
END
GO
USE [master]
GO
ALTER DATABASE [InventarioImpresoras] SET  READ_WRITE 
GO
