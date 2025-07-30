CREATE TABLE [dbo].[Perfil] (
    [idPerfil]          INT              NOT NULL,
    [nombre]            NVARCHAR (MAX)   NOT NULL,
    [fechaCreacion]     DATETIME         NULL,
    [fechaModificacion] DATETIME         NULL,
    [usuarioCrea]       UNIQUEIDENTIFIER NULL,
    [usuarioModifica]   UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([idPerfil] ASC)
);

