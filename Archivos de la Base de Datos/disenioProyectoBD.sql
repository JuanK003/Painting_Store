/*
Created: 14/09/2022
Modified: 14/09/2022
Model: Microsoft SQL Server 2019
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table MarcaProducto

CREATE TABLE [MarcaProducto]
(
 [IdMarca] Int IDENTITY(1,1) NOT NULL,
 [NombreMarca] Varchar(250) NOT NULL
)
go

-- Add keys for table MarcaProducto

ALTER TABLE [MarcaProducto] ADD CONSTRAINT [PK_MarcaProducto] PRIMARY KEY ([IdMarca])
go

-- Table Productos

CREATE TABLE [Productos]
(
 [IdProducto] Int IDENTITY(1,1) NOT NULL,
 [NombreProducto] Text NOT NULL,
 [DescripcionProducto] Text NOT NULL,
 [PrecioVenta] Float NOT NULL,
 [AñosDuracion] Int NOT NULL,
 [CantidadEnBodega] Int DEFAULT 0 NOT NULL,
 [ExistenciaMinima] Int NOT NULL,
 [IdMarca] Int NULL,
 [IdAplicacion] Int NULL,
 [IdPresentacionProducto] Int NULL
)
go

-- Create indexes for table Productos

CREATE INDEX [IX_Relationship3] ON [Productos] ([IdMarca])
go

CREATE INDEX [IX_Relationship4] ON [Productos] ([IdAplicacion])
go

CREATE INDEX [IX_Relationship5] ON [Productos] ([IdPresentacionProducto])
go

-- Add keys for table Productos

ALTER TABLE [Productos] ADD CONSTRAINT [PK_Productos] PRIMARY KEY ([IdProducto])
go

-- Table PresentacionProducto

CREATE TABLE [PresentacionProducto]
(
 [IdPresentacionProducto] Int IDENTITY(1,1) NOT NULL,
 [MedidaPresentacion] Float NOT NULL,
 [NombrePresentacion] Varchar(250) NOT NULL
)
go

-- Add keys for table PresentacionProducto

ALTER TABLE [PresentacionProducto] ADD CONSTRAINT [PK_PresentacionProducto] PRIMARY KEY ([IdPresentacionProducto])
go

-- Table AplicacionProducto

CREATE TABLE [AplicacionProducto]
(
 [IdAplicacion] Int IDENTITY(1,1) NOT NULL,
 [NombreAplicacion] Varchar(300) NOT NULL
)
go

-- Add keys for table AplicacionProducto

ALTER TABLE [AplicacionProducto] ADD CONSTRAINT [PK_AplicacionProducto] PRIMARY KEY ([IdAplicacion])
go

-- Table PedidoProducto

CREATE TABLE [PedidoProducto]
(
 [IdPedidoProducto] Int IDENTITY(1,1) NOT NULL,
 [CantidadPedidoProducto] Int NOT NULL,
 [FechaRealizacionPedido] Datetime NOT NULL,
 [IdProveedor] Int NULL,
 [IdProducto] Int NULL
)
go

-- Create indexes for table PedidoProducto

CREATE INDEX [IX_Relationship7] ON [PedidoProducto] ([IdProveedor])
go

CREATE INDEX [IX_Relationship8] ON [PedidoProducto] ([IdProducto])
go

-- Add keys for table PedidoProducto

ALTER TABLE [PedidoProducto] ADD CONSTRAINT [PK_PedidoProducto] PRIMARY KEY ([IdPedidoProducto])
go

-- Table EntradaProducto

CREATE TABLE [EntradaProducto]
(
 [IdEntradaProducto] Int IDENTITY(1,1) NOT NULL,
 [FechaEntradaProducto] Datetime NOT NULL,
 [CantidadEntradaProducto] Int NOT NULL,
 [IdPedidoProducto] Int NULL
)
go

-- Create indexes for table EntradaProducto

CREATE INDEX [IX_Relationship1] ON [EntradaProducto] ([IdPedidoProducto])
go

-- Add keys for table EntradaProducto

ALTER TABLE [EntradaProducto] ADD CONSTRAINT [PK_EntradaProducto] PRIMARY KEY ([IdEntradaProducto])
go

-- Table Proveedor

CREATE TABLE [Proveedor]
(
 [IdProveedor] Int IDENTITY(1,1) NOT NULL,
 [NombreProveedor] Varchar(400) NOT NULL,
 [TelefonoProveedor] Varchar(200) NOT NULL,
 [DireccionProveedor] Text NOT NULL,
 [ContactoProveedor] Text NOT NULL
)
go

-- Add keys for table Proveedor

ALTER TABLE [Proveedor] ADD CONSTRAINT [PK_Proveedor] PRIMARY KEY ([IdProveedor])
go

-- Table NivelesAcceso

CREATE TABLE [NivelesAcceso]
(
 [IdAcceso] Int IDENTITY(1,1) NOT NULL,
 [NombreAcceso] Varchar(100) NOT NULL
)
go

-- Add keys for table NivelesAcceso

ALTER TABLE [NivelesAcceso] ADD CONSTRAINT [PK_NivelesAcceso] PRIMARY KEY ([IdAcceso])
go

-- Table Empleado

CREATE TABLE [Empleado]
(
 [IdEmpleado] Int IDENTITY(1,1) NOT NULL,
 [UserName] Varchar(200) NOT NULL,
 [PasswordUsuario] Text NOT NULL,
 [NombreEmpleado] Varchar(200) NOT NULL,
 [DireccionEmpleado] Text NOT NULL,
 [TelefonoEmpleado] Varchar(100) NOT NULL,
 [FechaNacimiento] Datetime NOT NULL,
 [DPI] Varchar(75) NOT NULL,
 [IdAcceso] Int NULL
)
go

-- Create indexes for table Empleado

CREATE INDEX [IX_Relationship6] ON [Empleado] ([IdAcceso])
go

-- Add keys for table Empleado

ALTER TABLE [Empleado] ADD CONSTRAINT [PK_Empleado] PRIMARY KEY ([IdEmpleado])
go

-- Table Cliente

CREATE TABLE [Cliente]
(
 [IdCliente] Int IDENTITY(1,1) NOT NULL,
 [NombreCliente] Varchar(200) NOT NULL,
 [DireccionCliente] Text NOT NULL,
 [TelefonoCliente] Varchar(70) NOT NULL,
 [NIT] Varchar(70) NOT NULL
)
go

-- Add keys for table Cliente

ALTER TABLE [Cliente] ADD CONSTRAINT [PK_Cliente] PRIMARY KEY ([IdCliente])
go

-- Table Factura

CREATE TABLE [Factura]
(
 [IdFactura] Varchar(120) NOT NULL,
 [FechaEmision] Datetime NOT NULL,
 [Monto] Float NOT NULL,
 [IdEmpleado] Int NULL,
 [IdCliente] Int NULL
)
go

-- Create indexes for table Factura

CREATE INDEX [IX_Relationship2] ON [Factura] ([IdEmpleado])
go

CREATE INDEX [IX_Relationship13] ON [Factura] ([IdCliente])
go

-- Add keys for table Factura

ALTER TABLE [Factura] ADD CONSTRAINT [PK_Factura] PRIMARY KEY ([IdFactura])
go

-- Table DetalleFactura

CREATE TABLE [DetalleFactura]
(
 [IdDetalleFactura] Int IDENTITY(1,1) NOT NULL,
 [CantidadProductos] Int NOT NULL,
 [SubTotal] Float NOT NULL,
 [IdFactura] Varchar(120) NULL,
 [IdProducto] Int NULL
)
go

-- Create indexes for table DetalleFactura

CREATE INDEX [IX_Relationship9] ON [DetalleFactura] ([IdFactura])
go

CREATE INDEX [IX_Relationship14] ON [DetalleFactura] ([IdProducto])
go

-- Add keys for table DetalleFactura

ALTER TABLE [DetalleFactura] ADD CONSTRAINT [PK_DetalleFactura] PRIMARY KEY ([IdDetalleFactura])
go

-- Table PagoFactura

CREATE TABLE [PagoFactura]
(
 [IdPagoFactura] Int IDENTITY(1,1) NOT NULL,
 [MontoMetodoPago] Float NOT NULL,
 [IdMetodoPago] Int NULL,
 [IdFactura] Varchar(120) NULL
)
go

-- Create indexes for table PagoFactura

CREATE INDEX [IX_Relationship11] ON [PagoFactura] ([IdMetodoPago])
go

CREATE INDEX [IX_Relationship12] ON [PagoFactura] ([IdFactura])
go

-- Add keys for table PagoFactura

ALTER TABLE [PagoFactura] ADD CONSTRAINT [PK_PagoFactura] PRIMARY KEY ([IdPagoFactura])
go

-- Table MetodoPago

CREATE TABLE [MetodoPago]
(
 [IdMetodoPago] Int IDENTITY(1,1) NOT NULL,
 [NombreMetodoPago] Varchar(100) NOT NULL
)
go

-- Add keys for table MetodoPago

ALTER TABLE [MetodoPago] ADD CONSTRAINT [PK_MetodoPago] PRIMARY KEY ([IdMetodoPago])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [EntradaProducto] ADD CONSTRAINT [Relationship1] FOREIGN KEY ([IdPedidoProducto]) REFERENCES [PedidoProducto] ([IdPedidoProducto]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Factura] ADD CONSTRAINT [Relationship2] FOREIGN KEY ([IdEmpleado]) REFERENCES [Empleado] ([IdEmpleado]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Productos] ADD CONSTRAINT [Relationship3] FOREIGN KEY ([IdMarca]) REFERENCES [MarcaProducto] ([IdMarca]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Productos] ADD CONSTRAINT [Relationship4] FOREIGN KEY ([IdAplicacion]) REFERENCES [AplicacionProducto] ([IdAplicacion]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Productos] ADD CONSTRAINT [Relationship5] FOREIGN KEY ([IdPresentacionProducto]) REFERENCES [PresentacionProducto] ([IdPresentacionProducto]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Empleado] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([IdAcceso]) REFERENCES [NivelesAcceso] ([IdAcceso]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PedidoProducto] ADD CONSTRAINT [Relationship7] FOREIGN KEY ([IdProveedor]) REFERENCES [Proveedor] ([IdProveedor]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PedidoProducto] ADD CONSTRAINT [Relationship8] FOREIGN KEY ([IdProducto]) REFERENCES [Productos] ([IdProducto]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [DetalleFactura] ADD CONSTRAINT [Relationship9] FOREIGN KEY ([IdFactura]) REFERENCES [Factura] ([IdFactura]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PagoFactura] ADD CONSTRAINT [Relationship11] FOREIGN KEY ([IdMetodoPago]) REFERENCES [MetodoPago] ([IdMetodoPago]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [PagoFactura] ADD CONSTRAINT [Relationship12] FOREIGN KEY ([IdFactura]) REFERENCES [Factura] ([IdFactura]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Factura] ADD CONSTRAINT [Relationship13] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([IdCliente]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [DetalleFactura] ADD CONSTRAINT [Relationship14] FOREIGN KEY ([IdProducto]) REFERENCES [Productos] ([IdProducto]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




