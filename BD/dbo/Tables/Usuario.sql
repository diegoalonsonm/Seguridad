CREATE TABLE [dbo].[Usuario] (
    [idUsuario]         UNIQUEIDENTIFIER NOT NULL,
    [nombre]            NVARCHAR (MAX)   NOT NULL,
    [passwordHash]      NVARCHAR (MAX)   NOT NULL,
    [correo]            NVARCHAR (MAX)   NOT NULL,
    [fechaCreacion]     DATETIME         NULL,
    [fechaModificacion] DATETIME         NULL,
    [usuarioCrea]       UNIQUEIDENTIFIER NULL,
    [usuarioModifica]   UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC)
);

