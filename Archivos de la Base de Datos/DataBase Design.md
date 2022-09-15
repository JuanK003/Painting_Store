## Marca_Producto

- Id_Marca
- Nombre_Marca

## Productos

- Id_Producto
- Nombre_Producto (Nombre con el color)
- Descripcion_Producto
- Precio_Venta
- Descuento
- Años_Duracion
- Cantidad_Bodega → (Valor por defecto 0)
- Existencia_Minima

## Presentación

- Id_Presentacion
- Cantidad
- Nombre_Presentacion

## Aplicación_Producto

- Id_Aplicacion_Producto
- Nombre_Aplicacion

## Pedido_Productos

- Id_Pedido_Producto
- Cantidad_Pedido
- Fecha_Realizacion_Pedido

## Entrada_Productos

- Id_Entrada_Producto
- Fecha_Entrada_Producto
- Cantidad_Entrada
- (Tiene una migración entrante de la tabla Pedido_Producto)

## Proveedor

- Id_Proveedor
- Nombre_Proveedor
- Telefono_Proveedor
- Direccion_Proveedor
- Contacto_Proveedor

## Niveles_Acceso

- Id_Acceso
- Nombre_Acceso

## Empleado

- Id_Empleado
- Username
- Contraseña
- Nombre
- Direccion
- Telefono
- Fecha_Nacimiento
- DPI

## Cliente

- Id_Cliente
- Nombre
- Direccion
- Telefono
- NIT

## Factura

- Id_Factura (Varchar)

- Fecha_Emision

- Monto

  (Esta tabla recibe la llave primaria de la tabla Empleado)

## Detalle_Factura

- Id_Detalle_Factura
- Cantidad
- Subtotal

## Pago_Factura

- Id_Pago_Factura
- Monto_Metodo_Pago

## Metodo_Pago

- Id_Metodo_Pago
- Metodo_Pago

