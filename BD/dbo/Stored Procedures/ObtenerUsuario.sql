
CREATE PROCEDURE ObtenerUsuario
    @correo VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idUsuario, nombre, passwordHash, correo, fechaCreacion, fechaModificacion, usuarioCrea, usuarioModifica FROM Usuario WHERE (@correo IS NULL OR correo = @correo);
END 