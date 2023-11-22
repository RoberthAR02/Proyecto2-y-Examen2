CREATE DATABASE rarExamen
GO

use rarExamen
go

-- Tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    CorreoElectronico NVARCHAR(50),
    Telefono NVARCHAR(15) UNIQUE
);
GO

-- Tabla Tecnicos
CREATE TABLE Tecnicos (
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Especialidad NVARCHAR(50)
);
GO

-- Tabla Equipos
CREATE TABLE Equipos (
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    TipoEquipo NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50),
    UsuarioID INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

-- Tabla Reparaciones
CREATE TABLE Reparaciones (
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    Estado CHAR(1),
    FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
);
GO

-- Tabla Asignaciones
CREATE TABLE Asignaciones (
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    TecnicoID INT,
    FechaAsignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
);
GO

-- Tabla DetallesReparacion
CREATE TABLE DetallesReparacion (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    Descripcion NVARCHAR(50),
    FechaInicio DATETIME DEFAULT GETDATE(),
    FechaFin DATETIME,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
);
GO

-- Agregar Usuario
INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) 
VALUES

('Empresa#1', 'correoelectronico@empresa1.com', '11223344'),

('Empresa#2', 'correoelectronico@empresa2.com', '44332211'),

('Empresa#3', 'correoelectronico@empresa3.com', '12345678'),

('Empresa#4', 'correoelectronico@empresa4.com', '87654321');
GO

-- Agregar Tecnico
INSERT INTO Tecnicos (Nombre, Especialidad)
VALUES 
('Tecnico#1', 'Hardware'),

('Tecnico#2', 'Web'),

('Tecnico#3', 'Licencias'),

('Tecnico#4', 'Impresoras');
GO


-- Agregar Equipo
INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
VALUES
('Laptop Gerencia', 'DellX', 1),

('Laptop Contabilidad', 'DellM', 2),

('Laptop Calidad', 'HPZ', 3),

('Laptop RRHH', 'HPR', 4);
GO

-- Agregar Reparacion
INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado)
VALUES 
(1, GETDATE(), 'a' ),

(2, GETDATE(), 'b' ),

(3, GETDATE(), 'c' ),

(4, GETDATE(), 'd' );
GO

-- Agregar Asignacion
INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion)
VALUES 
(4, 1, GETDATE()),

(3, 2, GETDATE()),

(2, 3, GETDATE()),

(1, 4, GETDATE());
GO

-- Agregar DetalleReparacion
INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin)
VALUES 
(1, 'Actualizacion de equipo de impresion', GETDATE(), GETDATE()),

(2, 'Actualizacion de version de Windows', GETDATE(), GETDATE()),

(3, 'Intalacion de nuevo navegador', GETDATE(), GETDATE()),

(4, 'Cambio de tarjeta de video', GETDATE(), GETDATE());
GO

CREATE PROCEDURE CONSULTAR_USUARIOS
AS
	BEGIN
		SELECT * FROM Usuarios
	END
GO

CREATE PROCEDURE CONSULTAR_USUARIOS_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Usuarios WHERE UsuarioID = @ID
	END
GO

CREATE PROCEDURE BORRAR_USUARIOS_ID
@ID INT
AS
	BEGIN
		DELETE Usuarios WHERE UsuarioID = @ID
	END
GO

CREATE PROCEDURE INSERTAR_USUARIO
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES (@NOMBRE, @CORREO, @TELEFONO)
	END
GO

CREATE PROCEDURE ACTUALIZAR_USUARIO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		UPDATE Usuarios SET Nombre = @NOMBRE, CorreoElectronico = @CORREO, Telefono = @TELEFONO WHERE UsuarioID = @ID
	END
GO

CREATE PROCEDURE CONSULTAR_TECNICOS
AS
	BEGIN
		SELECT * FROM Tecnicos
	END
GO

CREATE PROCEDURE CONSULTAR_TECNICOS_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Tecnicos WHERE TecnicoID = @ID
	END
GO

CREATE PROCEDURE BORRAR_TECNICOS_ID
@ID INT
AS
	BEGIN
		DELETE Tecnicos WHERE TecnicoID = @ID
	END
GO

CREATE PROCEDURE INSERTAR_TECNICO
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		INSERT INTO Tecnicos(Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END
GO

CREATE PROCEDURE ACTUALIZAR_TECNICO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		UPDATE Tecnicos SET Nombre = @NOMBRE, Especialidad = @ESPECIALIDAD WHERE TecnicoID = @ID
	END
GO

CREATE PROCEDURE CONSULTAR_EQUIPOS
AS
	BEGIN
		SELECT * FROM Equipos
	END
GO

CREATE PROCEDURE CONSULTAR_EQUIPOSID
@ID INT
AS
	BEGIN
		SELECT * FROM Equipos WHERE EquipoID = @ID
	END
GO

CREATE PROCEDURE BORRAR_EQUIPOS_ID
@ID INT
AS
	BEGIN
		DELETE Equipos WHERE EquipoID = @ID
	END
GO

CREATE PROCEDURE INSERTAR_EQUIPO
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES (@TIPOEQUIPO, @MODELO, @USUARIOID)
	END
GO

CREATE PROCEDURE ACTUALIZAR_EQUIPOO_ID
@ID INT,
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		UPDATE Equipos SET TipoEquipo = @TIPOEQUIPO, Modelo = @MODELO, UsuarioID = @USUARIOID WHERE EquipoID = @ID
	END
GO