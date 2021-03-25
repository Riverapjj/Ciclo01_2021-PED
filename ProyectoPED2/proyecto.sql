use [master]
GO
IF (SELECT count(*) FROM DBO.SYSDATABASES WHERE NAME = 'PROYECTO') = 0
BEGIN
	CREATE DATABASE [PROYECTO];
END
GO
USE [PROYECTO];

------------------------------------TABLAS-------------------------------------------

---------------------------------Tabla Estado------------------------------------------
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Estado')
BEGIN
	CREATE TABLE [Estado](
		[ID] INT PRIMARY KEY IDENTITY(1,1),
		[Estado] nvarchar(255) not null
	)
END
IF (SELECT COUNT(*) FROM [Estado]) = 0
BEGIN
	INSERT INTO [Estado] ([Estado]) VALUES ('Espera'),('Aprobada'),('Denegada'),('Ausente'),('Activa'),('Cancelada'),('Terminada');
END

---------------------------------Tabla Clase------------------------------------------
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Clase')
BEGIN
	CREATE TABLE [Clase](
		[ID] INT PRIMARY KEY IDENTITY(1,1),
		[Nombre] varchar(255) not null,
		[Capacidad] int not null
	)
END
IF (SELECT COUNT(*) FROM [Clase]) = 0
BEGIN
	INSERT INTO [Clase] ([Nombre],[Capacidad]) VALUES ('Small',4),('Big',8),('Giant',12);
END

---------------------------------Tabla Mesa------------------------------------------
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Mesa')
BEGIN
	CREATE TABLE [Mesa](
		[ID] INT PRIMARY KEY IDENTITY(1,1),
		[ID_Clase] int not null,
		CONSTRAINT FK_Clase FOREIGN KEY ([ID_Clase]) REFERENCES [Clase]([ID]) ON DELETE CASCADE ON UPDATE CASCADE
	)
END
IF (SELECT COUNT(*) FROM [Mesa]) = 0
BEGIN
	INSERT INTO [Mesa] ([ID_Clase]) VALUES (1),(2),(3),(1),(2),(3),(1),(2),(3),(1),(2),(3);
END

---------------------------------Tabla Usuario------------------------------------------
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Usuario')
BEGIN
	CREATE TABLE [Usuario](
		[ID] INT PRIMARY KEY IDENTITY(1,1),
		[Nombre] varchar(255) not null,
		[Documento] char(50) not null,
		[Correo] varchar(255) not null,
		[Telefono] char(9) not null,
	)
END
IF (SELECT COUNT(*) FROM [Usuario]) = 0
BEGIN
	INSERT INTO [Usuario] ([Nombre],[Correo],[Documento],[Telefono]) VALUES ('Admin','admin@admin.com','-','-');
END

---------------------------------Tabla Solicitud------------------------------------------
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Solicitud')
BEGIN
	CREATE TABLE [Solicitud](
		[ID] INT PRIMARY KEY IDENTITY(1,1),
		[Fecha] date not null,
		[Hora] time not null,
		[ID_Usuario] int not null,
		[ID_Mesa] int not null,
		[ID_Estado] int not null,
		CONSTRAINT FK_Usu FOREIGN KEY ([ID_Usuario]) REFERENCES [Usuario]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
		CONSTRAINT FK_Mes FOREIGN KEY ([ID_Mesa]) REFERENCES [Mesa]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
		CONSTRAINT FK_Est FOREIGN KEY ([ID_Estado]) REFERENCES [Estado]([ID]) ON DELETE CASCADE ON UPDATE CASCADE
	)
END

------------------------------------PROCEDIMIENTOS ALMACENADOS-------------------------------------------
/*Obtiene todas las solicitudes ingresadas*/
CREATE PROCEDURE sp_solicitudes
AS
BEGIN
	SELECT ID_Mesa AS Mesa, U.Nombre AS Usuario, C.Nombre AS Capacidad, Hora, Fecha, Estado
	FROM Solicitud S
	INNER JOIN Mesa M ON M.ID = S.ID_Mesa
	INNER JOIN Estado E ON E.ID = S.ID_Estado
	INNER JOIN Usuario U ON U.ID = S.ID_Usuario
	INNER JOIN Clase C ON C.ID = M.ID_Clase
END
