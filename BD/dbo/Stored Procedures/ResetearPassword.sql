
CREATE PROCEDURE [dbo].[ResetearPassword]
	@correo nvarchar(max),
	@nuevoPasswordHash nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @usuarioEncontrado INT = 0;

	-- Verificar si el usuario existe
	SELECT @usuarioEncontrado = COUNT(*)
	FROM Usuario
	WHERE correo = @correo;

	IF @usuarioEncontrado = 0
	BEGIN
		-- Usuario no encontrado
		SELECT 0 as Exitoso;
		RETURN;
	END

	BEGIN TRY
		BEGIN TRAN
			-- Actualizar la contraseña
			UPDATE Usuario
			SET passwordHash = @nuevoPasswordHash,
				fechaModificacion = GETDATE()
			WHERE correo = @correo;

			-- Retornar éxito
			SELECT 1 as Exitoso;

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;

		-- Retornar error
		SELECT 0 as Exitoso;
	END CATCH
END