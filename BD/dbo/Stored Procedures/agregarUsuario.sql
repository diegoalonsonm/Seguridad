
CREATE PROCEDURE [dbo].[agregarUsuario]
	@nombre nvarchar(max),
	@passwordHash nvarchar(max),
	@correo nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	declare @idUsuario as uniqueidentifier  = newid();
	begin tran
		insert into Usuario (idUsuario, nombre, correo, passwordHash) values (@idUsuario, @nombre, @correo, @passwordHash)
		select @idUsuario

		insert into UsuarioPerfil(idUsuario, idPerfil) values (@idUsuario, 2);
    commit tran
END