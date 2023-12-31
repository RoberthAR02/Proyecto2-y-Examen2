USE [Datos2]
GO
/****** Object:  Table [dbo].[Asignaciones]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaciones](
	[AsignacionID] [int] IDENTITY(1,1) NOT NULL,
	[ReparacionID] [int] NULL,
	[TecnicoID] [int] NULL,
	[FechaAsignacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[AsignacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesDeReparacion]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesDeReparacion](
	[DetalleID] [int] IDENTITY(1,1) NOT NULL,
	[ReparacionID] [int] NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaInicio] [date] NULL,
	[FechaFin] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[EquipoID] [int] IDENTITY(1,1) NOT NULL,
	[TipoEquipo] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NULL,
	[UsuarioID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reparaciones]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reparaciones](
	[ReparacionID] [int] IDENTITY(1,1) NOT NULL,
	[EquipoID] [int] NULL,
	[FechaSolicitud] [date] NULL,
	[Estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ReparacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tecnicos]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tecnicos](
	[TecnicoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Especialidad] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TecnicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CorreoElectronico] [varchar](50) NULL,
	[Telefono] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asignaciones] ADD  DEFAULT (getdate()) FOR [FechaAsignacion]
GO
ALTER TABLE [dbo].[DetallesDeReparacion] ADD  DEFAULT (getdate()) FOR [FechaInicio]
GO
ALTER TABLE [dbo].[Reparaciones] ADD  DEFAULT (getdate()) FOR [FechaSolicitud]
GO
ALTER TABLE [dbo].[Asignaciones]  WITH CHECK ADD  CONSTRAINT [fk_asignaciones_reparacionId] FOREIGN KEY([ReparacionID])
REFERENCES [dbo].[Reparaciones] ([ReparacionID])
GO
ALTER TABLE [dbo].[Asignaciones] CHECK CONSTRAINT [fk_asignaciones_reparacionId]
GO
ALTER TABLE [dbo].[Asignaciones]  WITH CHECK ADD  CONSTRAINT [fk_asignaciones_tecnicoId] FOREIGN KEY([TecnicoID])
REFERENCES [dbo].[Tecnicos] ([TecnicoID])
GO
ALTER TABLE [dbo].[Asignaciones] CHECK CONSTRAINT [fk_asignaciones_tecnicoId]
GO
ALTER TABLE [dbo].[DetallesDeReparacion]  WITH CHECK ADD  CONSTRAINT [fk_detallesDeReparacion_reparacionId] FOREIGN KEY([ReparacionID])
REFERENCES [dbo].[Reparaciones] ([ReparacionID])
GO
ALTER TABLE [dbo].[DetallesDeReparacion] CHECK CONSTRAINT [fk_detallesDeReparacion_reparacionId]
GO
ALTER TABLE [dbo].[Equipos]  WITH CHECK ADD  CONSTRAINT [fk_equipos_usuarioId] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Equipos] CHECK CONSTRAINT [fk_equipos_usuarioId]
GO
ALTER TABLE [dbo].[Reparaciones]  WITH CHECK ADD  CONSTRAINT [fk_reparaciones_equipoId] FOREIGN KEY([EquipoID])
REFERENCES [dbo].[Equipos] ([EquipoID])
GO
ALTER TABLE [dbo].[Reparaciones] CHECK CONSTRAINT [fk_reparaciones_equipoId]
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_ASIGNACION_ID]    Script Date: 28/11/2023 20:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_ASIGNACION_ID]
@ID INT,
@REPARACIONID INT,
@TECNICOID INT

AS
	BEGIN
		UPDATE Asignaciones SET ReparacionID = @REPARACIONID, TecnicoID = @TECNICOID WHERE AsignacionID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_DETALLESREPARACION_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_DETALLESREPARACION_ID]
@ID INT,
@REPARACIONID INT,
@DESCRIPCION VARCHAR(50),
@FECHAFIN DATE

AS
	BEGIN
		UPDATE DetallesReparacion SET ReparacionID = @REPARACIONID, Descripcion = @DESCRIPCION, FechaFin = @FECHAFIN WHERE DetalleID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_EQUIPO_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_EQUIPO_ID]
@ID INT,
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		UPDATE Equipos SET TipoEquipo = @TIPOEQUIPO, Modelo = @MODELO, UsuarioID = @USUARIOID WHERE EquipoID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_REPARACION_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_REPARACION_ID]
@ID INT,
@EQUIPOID INT,
@ESTADO CHAR

AS
	BEGIN
		UPDATE Reparaciones SET EquipoID = @EQUIPOID, Estado = @ESTADO WHERE ReparacionID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_TECNICO_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_TECNICO_ID]
@ID INT,
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		UPDATE Tecnicos SET Nombre = @NOMBRE, Especialidad = @ESPECIALIDAD WHERE TecnicoID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_USUARIO_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ACTUALIZAR_USUARIO_ID]
@ID INT,
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		UPDATE Usuarios SET Nombre = @NOMBRE, CorreoElectronico = @CORREO, Telefono = @TELEFONO WHERE UsuarioID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_ASIGNACIONES_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BORRAR_ASIGNACIONES_ID]
@ID INT
AS
	BEGIN
		DELETE Asignaciones WHERE AsignacionID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_DETALLESREPARACION_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BORRAR_DETALLESREPARACION_ID]
@ID INT
AS
	BEGIN
		DELETE DetallesReparacion WHERE DetalleID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_EQUIPOS_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BORRAR_EQUIPOS_ID]
@ID INT
AS
	BEGIN
		DELETE Equipos WHERE EquipoID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_REPARACIONES_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BORRAR_REPARACIONES_ID]
@ID INT
AS
	BEGIN
		DELETE Reparaciones WHERE ReparacionID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_TECNICOS_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BORRAR_TECNICOS_ID]
@ID INT
AS
	BEGIN
		DELETE Tecnicos WHERE TecnicoID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_USUARIOS_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BORRAR_USUARIOS_ID]
@ID INT
AS
	BEGIN
		DELETE Usuarios WHERE UsuarioID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_ASIGNACIONES]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_ASIGNACIONES]
AS
	BEGIN
		SELECT AsignacionID, Reparaciones.Estado as EstadoDeReparacion, Tecnicos.Nombre as Tecnico, FechaAsignacion 
		FROM Asignaciones
		JOIN Reparaciones ON Asignaciones.ReparacionID = Reparaciones.ReparacionID
		JOIN Tecnicos ON Asignaciones.TecnicoID = Tecnicos.TecnicoID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_ASIGNACIONES_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_ASIGNACIONES_ID]
@ID INT
AS
	BEGIN
		SELECT AsignacionID, Reparaciones.Estado as EstadoDeReparacion, Tecnicos.Nombre as Tecnico, FechaAsignacion
		FROM Asignaciones 
		JOIN Reparaciones ON Asignaciones.ReparacionID = Reparaciones.ReparacionID
		JOIN Tecnicos ON Asignaciones.TecnicoID = Tecnicos.TecnicoID
		WHERE AsignacionID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_DETALLESREPARACION]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_DETALLESREPARACION]
AS
	BEGIN
		SELECT DetalleID, Reparaciones.ReparacionID as Reparacion, Descripcion, FechaInicio, FechaFin
		FROM DetallesReparacion 
		JOIN Reparaciones ON DetallesReparacion.ReparacionID = Reparaciones.ReparacionID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_DETALLESREPARACION_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_DETALLESREPARACION_ID]
@ID INT
AS
	BEGIN
		SELECT DetalleID, Reparaciones.ReparacionID as Reparacion, Descripcion, FechaInicio, FechaFin 
		FROM DetallesReparacion 
		JOIN Reparaciones ON DetallesReparacion.ReparacionID = Reparaciones.ReparacionID
		WHERE DetalleID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_EQUIPOS]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPOS]
AS
	BEGIN
		SELECT EquipoID, TipoEquipo, Modelo, Usuarios.Nombre as Usuario 
		FROM Equipos
		JOIN Usuarios ON Usuarios.UsuarioID = Equipos.UsuarioID 
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_EQUIPOS_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPOS_ID]
@ID INT
AS
	BEGIN
		SELECT EquipoID, TipoEquipo, Modelo, Usuarios.Nombre as Usuario 
		FROM Equipos 
		JOIN Usuarios ON Usuarios.UsuarioID = Equipos.UsuarioID 
		WHERE EquipoID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_REPARACIONES]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_REPARACIONES]
AS
	BEGIN
		SELECT ReparacionID, Equipos.TipoEquipo as Equipo, FechaSolicitud, Estado 
		FROM Reparaciones
		JOIN Equipos ON Equipos.EquipoID = Reparaciones.EquipoID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_REPARACIONES_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_REPARACIONES_ID]
@ID INT
AS
	BEGIN
		SELECT ReparacionID, Equipos.EquipoID as Equipo, FechaSolicitud, Estado 
		FROM Reparaciones
		JOIN Equipos ON Equipos.EquipoID = Reparaciones.EquipoID
		WHERE ReparacionID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_TECNICOS]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_TECNICOS]
AS
	BEGIN
		SELECT * FROM Tecnicos
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_TECNICOS_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_TECNICOS_ID]
@ID INT
AS
	BEGIN
		SELECT * FROM Tecnicos WHERE TecnicoID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_USUARIOS]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_USUARIOS]
AS
	BEGIN
		SELECT * FROM Usuarios
	END
GO
/****** Object:  StoredProcedure [dbo].[CONSULTAR_USUARIOS_ID]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTAR_USUARIOS_ID]
@ID INT
AS
	BEGIN
		SELECT * FROM Usuarios WHERE UsuarioID = @ID
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_ASIGNACION]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERTAR_ASIGNACION]
@REPARACIONID INT,
@TECNICOID INT

AS
	BEGIN
		INSERT INTO Asignaciones(ReparacionID, TecnicoID) VALUES (@REPARACIONID, @TECNICOID)
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_DETALLESREPARACION]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERTAR_DETALLESREPARACION]
@REPARACIONID INT,
@DESCRIPCION VARCHAR(50)

AS
	BEGIN
		INSERT INTO DetallesReparacion(ReparacionID, Descripcion) VALUES (@REPARACIONID, @DESCRIPCION)
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_EQUIPO]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERTAR_EQUIPO]
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES (@TIPOEQUIPO, @MODELO, @USUARIOID)
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_REPARACION]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERTAR_REPARACION]
@EQUIPOID INT,
@ESTADO CHAR

AS
	BEGIN
		INSERT INTO Reparaciones(EquipoID, Estado) VALUES (@EQUIPOID, @ESTADO)
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_TECNICO]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERTAR_TECNICO]
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		INSERT INTO Tecnicos(Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO]    Script Date: 28/11/2023 20:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERTAR_USUARIO]
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES (@NOMBRE, @CORREO, @TELEFONO)
	END
GO
