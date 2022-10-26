CREATE TYPE [dbo].[listaproductos]
As Table (Id int, IdProducto int, NombreProducto varchar(max), Precio decimal(6, 2), Cantidad int, Subtotal decimal(6, 2))
go

CREATE TYPE [dbo].[listametodospago]
As Table (Id int, IdTipoMetodo int, TipoMetodo varchar(max), Datos varchar(max), Cantidad decimal(6, 2))
go

-- Columns = { "Id", "IdProducto", "NombreProducto", "Precio", "Cantidad", "Subtotal" }
-- Columns = { "Id", "IdTipoMetodo", "TipoMetodo", "Datos", "Cantidad" }

CREATE PROCEDURE [dbo].[sp_Facturacion]
	@idfactura varchar(120),
	@monto decimal(6,2),
	@idempleado int,
	@idcliente int,
	@productos [dbo].[listaproductos] READONLY,
	@metodospago [dbo].[listametodospago] READONLY,
	@mensaje varchar(max) output
AS
begin
	-- un unico procedimiento almacenado para actualizar e insertar
	begin try
		begin transaction facturacion
			if (select count(*) from [dbo].[Factura] where IdFactura like @idfactura) > 0
			begin
				set @mensaje = 'INFO: Factura actualizada con exito!'
				delete from [dbo].[PagoFactura] where IdFactura like @idfactura
				delete from [dbo].[DetalleFactura] where IdFactura like @idfactura
				delete from [dbo].[Factura] where IdFactura like @idfactura
			end
			else
			begin
				set @mensaje = 'INFO: Factura registrada con exito!'
			end

			insert into [dbo].[Factura] values(@idfactura, GETDATE(), @monto, @idempleado, @idcliente)
			
			declare @old_exist int
			declare @cont int = 1
			while(@cont <= (select count(*) from @productos) )
			begin
				insert into [dbo].[DetalleFactura] values((select Cantidad from @productos where Id=@cont), (select Subtotal from @productos where Id=@cont), @idfactura, (select IdProducto from @productos where Id=@cont))	
				set @old_exist = (select CantidadEnBodega from [dbo].[Productos] where IdProducto=(select IdProducto from @productos where Id=@cont))
				update [dbo].[Productos] set CantidadEnBodega=@old_exist-(select Cantidad from @productos where Id=@cont) where IdProducto=(select IdProducto from @productos where Id=@cont)
				set @cont = @cont + 1
			end

			set @cont = 1
			while (@cont <= (select count(*) from @metodospago))
			begin
				insert into [dbo].[PagoFactura]	values((select Cantidad from @metodospago where Id=@cont), (select Datos from @metodospago where Id=@cont), (select IdTipoMetodo from @metodospago where Id=@cont), @idfactura)
				set @cont = @cont + 1
			end


			IF (select min(CantidadEnBodega) from [dbo].[Productos]) < 0
			begin
				RAISERROR('ERROR: No puede vender productos de los que tiene!', 1, 1)
			end

			commit tran facturacion
	end try
	begin catch
		set @mensaje = concat('ERROR: Algo ha salido mal :c\n\nDescripción:\n', ERROR_MESSAGE())
		rollback transaction facturacion
	end catch
end;