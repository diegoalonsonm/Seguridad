CREATE PROCEDURE ObtenerPerfilesPorUsuario
    @nombre nvarchar(maX),
	@correo nvarchar(max)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Perfil.idPerfil, Perfil.nombre from Perfil inner join UsuarioPerfil on Perfil.idPerfil = UsuarioPerfil.idPerfil inner join Usuario on UsuarioPerfil.idUsuario = Usuario.idUsuario where (Usuario.nombre = @nombre) or (Usuario.correo = @correo)
END