CREATE PROCEDURE [dbo].[sp_Facturacion]
	@idempleado int,
	@idcliente int,
	@mensaje varchar(max) output
AS
begin
	begin try
		begin transaction facturacion
			


			commit tran facturacion

	end try
	begin catch
		set @mensaje = concat('ERROR: Algo ha salido mal :c\n\nDescripción:\n', ERROR_MESSAGE())
		rollback transaction facturacion
	end catch
end;