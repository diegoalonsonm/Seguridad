
CREATE PROCEDURE ObtenerUsuario
    @nombre VARCHAR(MAX) = NULL,
    @correo VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idUsuario, nombre, passwordHash, correo, fechaCreacion, fechaModificacion, usuarioCrea, usuarioModifica FROM Usuario WHERE (@nombre IS NULL OR nombre = @nombre) 
	AND (@correo IS NULL OR correo = @correo);
END