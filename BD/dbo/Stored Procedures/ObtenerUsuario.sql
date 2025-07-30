
CREATE PROCEDURE ObtenerUsuario
    @NombreUsuario VARCHAR(MAX) = NULL,
    @CorreoElectronico VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idUsuario, nombre, passwordHash, correo, fechaCreacion, fechaModificacion, usuarioCrea, usuarioModifica FROM Usuario WHERE (@NombreUsuario IS NULL OR nombre = @NombreUsuario) 
	AND (@CorreoElectronico IS NULL OR correo = @CorreoElectronico);
END