CREATE TABLE [dbo].[UsuarioPerfil] (
    [idUsuario] UNIQUEIDENTIFIER NOT NULL,
    [idPerfil]  INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([idUsuario] ASC, [idPerfil] ASC),
    FOREIGN KEY ([idPerfil]) REFERENCES [dbo].[Perfil] ([idPerfil]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario])
);

