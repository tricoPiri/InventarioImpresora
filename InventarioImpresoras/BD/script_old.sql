USE [master]
GO
/****** Object:  Database [InventarioImpresoras]    Script Date: 07/11/2024 03:52:41 p. m. ******/
CREATE DATABASE [InventarioImpresoras]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventarioImpresoras', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\InventarioImpresoras.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventarioImpresoras_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\InventarioImpresoras_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 07/11/2024 03:52:41 p. m. ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[idArea] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[idArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impresoras]    Script Date: 07/11/2024 03:52:41 p. m. ******/
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
/****** Object:  Table [dbo].[Lecturas]    Script Date: 07/11/2024 03:52:41 p. m. ******/
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
/****** Object:  Table [dbo].[Marcas]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelos]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelos](
	[idModelo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED 
(
	[idModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](100) NULL,
	[apellidoPaterno] [varchar](50) NOT NULL,
	[apellidoMaterno] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NULL,
	[password] [varchar](250) NULL,
	[idRol] [int] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[spInsertarAreas]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarAreas]
	@nombre varchar(50)
AS
BEGIN
	INSERT INTO Areas (nombre) VALUES (@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarImpresoras]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[spInsertarLecturas]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[spInsertarMarcas]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarMarcas]
	@nombre varchar(50)
AS	
BEGIN
	INSERT INTO Marcas(nombre) VALUES(@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarModelos]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarModelos]
	@nombre varchar(50)
AS	
BEGIN
	INSERT INTO Modelos(nombre) VALUES(@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarRoles]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertarRoles]
	@nombre varchar(50)
AS
BEGIN
	INSERT INTO Roles(nombre) VALUES (@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 07/11/2024 03:52:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLogin]

	@usuario varchar(50),
	@password varchar(50)

AS 
BEGIN
	SELECT idUsuario, usuario, idRol FROM Usuarios WHERE usuario = @usuario AND password = @password;
END
GO
USE [master]
GO
ALTER DATABASE [InventarioImpresoras] SET  READ_WRITE 
GO
