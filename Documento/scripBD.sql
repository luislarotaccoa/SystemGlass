/****** Object:  Table [dbo].[Tienda]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[IdTienda] [int] IDENTITY(1,1) NOT NULL,
	[NomTienda] [varchar](50) NULL,
	[Serie] [varchar](3) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proforma]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proforma](
	[IdProforma] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Fecha] [datetime] NULL,
	[IdComprobante] [int] NULL,
	[Igv] [decimal](4, 2) NULL,
	[IdTienda] [int] NULL,
	[IdUsuario] [int] NULL,
	[IdTipoVenta] [int] NULL,
	[IdAlmacen] [int] NULL,
	[Estado] [bit] NULL,
	[ENUSO] [bit] NULL,
	[Plazo] [int] NULL,
	[Directo] [varchar](100) NULL,
	[Numero] [int] NOT NULL,
 CONSTRAINT [PK__IdProforma] PRIMARY KEY CLUSTERED 
(
	[IdProforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobante](
	[IdComprobante] [int] IDENTITY(1,1) NOT NULL,
	[NomComprobante] [varchar](20) NOT NULL,
	[Simbolo] [varchar](5) NOT NULL,
	[Codigo] [int] not null,
	[Ingreso] [bit] NULL,
	[Venta] [bit] NULL,
	[Declarable] [bit] NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Proforma_Descripcion_Documento]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Proforma_Descripcion_Documento]
AS
SELECT        P.IdProforma, T.Serie, C.Simbolo, P.IdCliente, T.IdTienda, P.Directo, C.IdComprobante, P.IdUsuario, P.IdTipoVenta, P.Plazo
FROM            dbo.Proforma AS P INNER JOIN
                         dbo.Tienda AS T ON T.IdTienda = P.IdTienda INNER JOIN
                         dbo.Comprobante AS C ON C.IdComprobante = P.IdComprobante
GO
/****** Object:  Table [dbo].[TipoVenta]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVenta](
	[IdTipoVenta] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[Estado] [bit] NULL,
	[Credito] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  View [dbo].[View_Proforma]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create View [dbo].[View_Proforma]
As
SELECT       
dbo.Almacen.IdAlmacen
,dbo.Almacen.Serie SerieA
,dbo.Almacen.Nombre
,C.IdCliente
,C.RazSocial
,C.NumDocumento
,C.Direccion
,C.IdDocumento
,C.NomDocumento
,c.Ruc
,C.Dni
,C.IdUbigeo
,C.Departamento
,C.Provincia
,C.Distrito
,dbo.Usuario.IdUsuario
,dbo.Usuario.NomUsuario
,dbo.Comprobante.IdComprobante
,dbo.Comprobante.NomComprobante
,dbo.Comprobante.Codigo
,dbo.Comprobante.Declarable
,dbo.Comprobante.Venta
,dbo.Comprobante.Ingreso
,dbo.Comprobante.Simbolo
,dbo.Tienda.IdTienda
,dbo.Tienda.NomTienda
,dbo.Tienda.Serie SerieT
,dbo.TipoVenta.IdTipoVenta
,dbo.TipoVenta.Tipo
,dbo.TipoVenta.Credito
,dbo.Proforma.IdProforma
,dbo.Proforma.Fecha
,dbo.Proforma.Estado
,dbo.Proforma.ENUSO
,dbo.Proforma.Igv
,dbo.Proforma.Plazo
,dbo.Proforma.Directo
,dbo.Proforma.Numero
FROM dbo.Proforma 
INNER JOIN dbo.Almacen ON dbo.Almacen.IdAlmacen = dbo.Proforma.IdAlmacen
INNER JOIN dbo.Comprobante ON dbo.Comprobante.IdComprobante = dbo.Proforma.IdComprobante
INNER JOIN dbo.View_Cliente C ON C.IdCliente = dbo.Proforma.IdCliente
INNER JOIN dbo.Tienda ON dbo.Tienda.IdTienda = dbo.Proforma.IdTienda 
INNER JOIN dbo.TipoVenta ON dbo.TipoVenta.IdTipoVenta = dbo.Proforma.IdTipoVenta
INNER JOIN dbo.Usuario ON dbo.Usuario.IdUsuario = dbo.Proforma.IdUsuario
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[IdBanco] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](300) NOT NULL,
	[Codigo] [int] NULL,
	[Estado] [bit] NULL,
	[Efectivo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBanco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cobranza]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobranza](
	[IdCobranza] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdBanco] [int] NULL,
	[IdMedioPago] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Importe] [decimal](11, 4) NOT NULL,
	[NumOperacion] [int] NULL,
	[FOperacion] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCobranza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consumo]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consumo](
	[IdConsumo] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdComprobante] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdConsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleConsumo]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleConsumo](
	[IdDetalleConsumo] [int] IDENTITY(1,1) NOT NULL,
	[IdConsumo] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdUnidad] [int] NOT NULL,
	[Cantidad] [decimal](11, 4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleConsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleEntrega]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleEntrega](
	[IdDetalleEntrega] [int] IDENTITY(1,1) NOT NULL,
	[IdEntrega] [int] NULL,
	[IdDetalleProforma] [int] NULL,
	[Cantidad] [decimal](11, 4) NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleIngreso]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleIngreso](
	[IdDetalleIngreso] [int] IDENTITY(1,1) NOT NULL,
	[IdIngreso] [int] NOT NULL,
	[IdDetalleOCompra] [int] NULL,
	[Cantidad] [decimal](11, 4) NULL,
	[Promedio] [decimal](11, 4) NULL,
	[Promediado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleOCompra]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleOCompra](
	[IdDetalleOCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdOCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdUnidad] [int] NOT NULL,
	[Cantidad] [decimal](11, 4) NOT NULL,
	[PCompra] [decimal](11, 4) NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleOCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleProforma]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleProforma](
	[IdDetalleProforma] [int] IDENTITY(1,1) NOT NULL,
	[IdProforma] [int] NULL,
	[IdProducto] [int] NULL,
	[IdUnidad] [int] NULL,
	[Cantidad] [decimal](11, 4) NULL,
	[PUnitario] [decimal](11, 4) NULL,
	[Descuento] [decimal](11, 4) NULL,
	[Estado] [bit] NULL,
	[IdAlmacen] [int] NOT NULL,
 CONSTRAINT [PK_IdDetalleProforma] PRIMARY KEY CLUSTERED 
(
	[IdDetalleProforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[DetalleTransferencia]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleTransferencia](
	[IdDetalleTransferencia] [int] IDENTITY(1,1) NOT NULL,
	[IdTransferencia] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](11, 4) NOT NULL,
	[IdUnidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleTransferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrega]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega](
	[IdEntrega] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdVentas] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Numero] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[IdComprobante] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Igv]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Igv](
	[IdIgv] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NULL,
	[IGV] [decimal](6, 4) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIgv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingreso]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingreso](
	[IdIngreso] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdComprobante] [int] NOT NULL,
	[IdCompProveedor] [int] NOT NULL,
	[SerieProveedor] [int] NOT NULL,
	[NumCompProveedor] [int] NOT NULL,
	[FechaProveedor] [datetime] NOT NULL,
	[IdTransportista] [int] NULL,
	[IdCompTransportista] [int] NOT NULL,
	[SerieTransportista] [int] NOT NULL,
	[NumCompTransportista] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedioPago]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedioPago](
	[IdMedioPago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Codigo] [int] NULL,
	[Efectivo] [bit] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMedioPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[IdMoneda] [int] IDENTITY(1,1) NOT NULL,
	[Divisa] [varchar](30) NULL,
	[Simbolo] [varchar](3) NULL,
	[Abrev] [varchar](3) NULL,
	[Nacional] [bit] NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OCompra]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OCompra](
	[IdOCompra] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Numero] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdComprobante] [int] NOT NULL,
	[IdMoneda] [int] NOT NULL,
	[TipoCambio] [decimal](11, 4) NULL,
	[Estado] [bit] NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Plazo] [int] NOT NULL,
	[Igv] [decimal](4, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiendaUsuario]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiendaUsuario](
	[IdTiendaUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdTienda] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTiendaUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transferencia]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transferencia](
	[IdTransferencia] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Numero] [int] NOT NULL,
	[IdComprobante] [int] NOT NULL,
	[IdAlmacen1] [int] NOT NULL,
	[IdAlmacen2] [int] NOT NULL,
	[IdUbicacion1] [int] NOT NULL,
	[IdUbicacion2] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTransferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Ventas]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[IdVentas] [int] IDENTITY(1,1) NOT NULL,
	[IdProforma] [int] NOT NULL,
	[FEmision] [datetime] NOT NULL,
	[Numero] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Cancelado] [bit] NOT NULL,
 CONSTRAINT [PK_Ventas_1] PRIMARY KEY CLUSTERED 
(
	[IdVentas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [index_Cobranza_IdUsuario]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [index_Cobranza_IdUsuario] ON [dbo].[Cobranza]
(
	[IdUsuario] ASC
)
INCLUDE ( 	[IdVenta],
	[IdBanco],
	[IdMedioPago],
	[Fecha],
	[Importe],
	[NumOperacion],
	[FOperacion],
	[Estado]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_Cobranza_IdVenta]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [index_Cobranza_IdVenta] ON [dbo].[Cobranza]
(
	[IdVenta] ASC
)
INCLUDE ( 	[IdUsuario],
	[IdBanco],
	[IdMedioPago],
	[Fecha],
	[Importe],
	[NumOperacion],
	[FOperacion],
	[Estado]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [FKS_DetalleProforma]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [FKS_DetalleProforma] ON [dbo].[DetalleProforma]
(
	[IdProforma] ASC,
	[IdProducto] ASC,
	[IdUnidad] ASC,
	[IdAlmacen] ASC
)
INCLUDE ( 	[Cantidad],
	[PUnitario],
	[Descuento],
	[Estado]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [DC_Empleado]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [DC_Empleado] ON [dbo].[Empleado]
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Num_Empleado]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [Num_Empleado] ON [dbo].[Empleado]
(
	[NumDocumento] ASC
)
INCLUDE ( 	[IdUbigeo],
	[Nombres],
	[Apellidos],
	[Documento],
	[Sexo],
	[FechaNacimiento],
	[Direccion],
	[EstCivil],
	[Email],
	[Especialidad],
	[Telefono],
	[Estado]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_Proforma_IdCliente]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [Index_Proforma_IdCliente] ON [dbo].[Proforma]
(
	[IdCliente] ASC
)
INCLUDE ( 	[IdProforma],
	[Fecha],
	[IdComprobante],
	[Igv],
	[IdTienda],
	[IdUsuario],
	[IdTipoVenta],
	[IdAlmacen],
	[Estado],
	[ENUSO],
	[Plazo],
	[Directo],
	[Numero]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_Venta_IdProform]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [index_Venta_IdProform] ON [dbo].[Ventas]
(
	[IdProforma] ASC
)
INCLUDE ( 	[Numero],
	[FEmision],
	[Estado],
	[Cancelado],
	[IdVentas]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comprobante] ADD  DEFAULT ((1)) FOR [Declarable]
GO
ALTER TABLE [dbo].[DetalleIngreso] ADD  DEFAULT ((0)) FOR [Promedio]
GO
ALTER TABLE [dbo].[DetalleIngreso] ADD  DEFAULT ((0)) FOR [Promediado]
GO
ALTER TABLE [dbo].[DetalleProforma] ADD  DEFAULT ((1)) FOR [IdAlmacen]
GO
ALTER TABLE [dbo].[Entrega] ADD  DEFAULT ((9)) FOR [IdComprobante]
GO
ALTER TABLE [dbo].[Proforma] ADD  DEFAULT ((1)) FOR [Numero]
GO
ALTER TABLE [dbo].[TipoVenta] ADD  DEFAULT ((0)) FOR [Credito]
GO
ALTER TABLE [dbo].[Unidad] ADD  DEFAULT ((1)) FOR [Medible]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT ((1)) FOR [Cancelado]
GO

ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Banco] ([IdBanco])
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD FOREIGN KEY([IdMedioPago])
REFERENCES [dbo].[MedioPago] ([IdMedioPago])
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cobranza]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Ventas] ([IdVentas])
GO
ALTER TABLE [dbo].[Consumo]  WITH CHECK ADD FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Consumo]  WITH CHECK ADD FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Consumo]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Consumo]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Contenido]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Contenido]  WITH CHECK ADD FOREIGN KEY([IdUnidadMinima])
REFERENCES [dbo].[Unidad] ([IdUnidad])
GO
ALTER TABLE [dbo].[Contenido]  WITH CHECK ADD FOREIGN KEY([IdUnidad])
REFERENCES [dbo].[Unidad] ([IdUnidad])
GO
ALTER TABLE [dbo].[DetalleConsumo]  WITH NOCHECK ADD FOREIGN KEY([IdConsumo])
REFERENCES [dbo].[Consumo] ([IdConsumo])
GO
ALTER TABLE [dbo].[DetalleConsumo]  WITH NOCHECK ADD FOREIGN KEY([IdContenido])
REFERENCES [dbo].[Contenido] ([IdContenido])
GO
ALTER TABLE [dbo].[DetalleConsumo]  WITH NOCHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleEntrega]  WITH NOCHECK ADD FOREIGN KEY([IdDetalleProforma])
REFERENCES [dbo].[DetalleProforma] ([IdDetalleProforma])
GO
ALTER TABLE [dbo].[DetalleEntrega]  WITH NOCHECK ADD FOREIGN KEY([IdEntrega])
REFERENCES [dbo].[Entrega] ([IdEntrega])
GO
ALTER TABLE [dbo].[DetalleIngreso]  WITH NOCHECK ADD FOREIGN KEY([IdDetalleOCompra])
REFERENCES [dbo].[DetalleOCompra] ([IdDetalleOCompra])
GO
ALTER TABLE [dbo].[DetalleIngreso]  WITH NOCHECK ADD FOREIGN KEY([IdIngreso])
REFERENCES [dbo].[Ingreso] ([IdIngreso])
GO
ALTER TABLE [dbo].[DetalleOCompra]  WITH NOCHECK ADD FOREIGN KEY([IdContenido])
REFERENCES [dbo].[Contenido] ([IdContenido])
GO
ALTER TABLE [dbo].[DetalleOCompra]  WITH NOCHECK ADD FOREIGN KEY([IdOCompra])
REFERENCES [dbo].[OCompra] ([IdOCompra])
GO
ALTER TABLE [dbo].[DetalleOCompra]  WITH NOCHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleProforma]  WITH NOCHECK ADD FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[DetalleProforma]  WITH NOCHECK ADD FOREIGN KEY([IdContenido])
REFERENCES [dbo].[Contenido] ([IdContenido])
GO
ALTER TABLE [dbo].[DetalleProforma]  WITH NOCHECK ADD FOREIGN KEY([IdProforma])
REFERENCES [dbo].[Proforma] ([IdProforma])
GO
ALTER TABLE [dbo].[DetalleProforma]  WITH NOCHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleTransferencia]  WITH NOCHECK ADD FOREIGN KEY([IdContenido])
REFERENCES [dbo].[Contenido] ([IdContenido])
GO
ALTER TABLE [dbo].[DetalleTransferencia]  WITH NOCHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleTransferencia]  WITH NOCHECK ADD FOREIGN KEY([IdTransferencia])
REFERENCES [dbo].[Transferencia] ([IdTransferencia])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([IdVentas])
REFERENCES [dbo].[Ventas] ([IdVentas])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdCompProveedor])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdCompTransportista])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdTransportista])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[OCompra]  WITH CHECK ADD FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[OCompra]  WITH CHECK ADD FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[Moneda] ([IdMoneda])
GO
ALTER TABLE [dbo].[OCompra]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[OCompra]  WITH CHECK ADD FOREIGN KEY([IdTipoVenta])
REFERENCES [dbo].[TipoVenta] ([IdTipoVenta])
GO
ALTER TABLE [dbo].[OCompra]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

ALTER TABLE [dbo].[ProductoAlmacen]  WITH CHECK ADD  CONSTRAINT [FK__ProductoA__IdAlmacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[ProductoAlmacen] CHECK CONSTRAINT [FK__ProductoA__IdAlmacen]
GO
ALTER TABLE [dbo].[ProductoAlmacen]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO

ALTER TABLE [dbo].[Proforma]  WITH CHECK ADD  CONSTRAINT [FK__Proforma__IdAlma__7814D14C] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Proforma] CHECK CONSTRAINT [FK__Proforma__IdAlma__7814D14C]
GO
ALTER TABLE [dbo].[Proforma]  WITH CHECK ADD  CONSTRAINT [FK__Proforma__IdClie__73501C2F] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Proforma] CHECK CONSTRAINT [FK__Proforma__IdClie__73501C2F]
GO
ALTER TABLE [dbo].[Proforma]  WITH CHECK ADD  CONSTRAINT [FK__Proforma__IdComp__74444068] FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Proforma] CHECK CONSTRAINT [FK__Proforma__IdComp__74444068]
GO
ALTER TABLE [dbo].[Proforma]  WITH CHECK ADD  CONSTRAINT [FK__Proforma__IdTien__753864A1] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([IdTienda])
GO
ALTER TABLE [dbo].[Proforma] CHECK CONSTRAINT [FK__Proforma__IdTien__753864A1]
GO
ALTER TABLE [dbo].[Proforma]  WITH CHECK ADD  CONSTRAINT [FK__Proforma__IdTipo__7720AD13] FOREIGN KEY([IdTipoVenta])
REFERENCES [dbo].[TipoVenta] ([IdTipoVenta])
GO
ALTER TABLE [dbo].[Proforma] CHECK CONSTRAINT [FK__Proforma__IdTipo__7720AD13]
GO
ALTER TABLE [dbo].[Proforma]  WITH CHECK ADD  CONSTRAINT [FK__Proforma__IdUsua__762C88DA] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Proforma] CHECK CONSTRAINT [FK__Proforma__IdUsua__762C88DA]
GO
ALTER TABLE [dbo].[TiendaUsuario]  WITH CHECK ADD FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([IdTienda])
GO
ALTER TABLE [dbo].[TiendaUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdAlmacen1])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdAlmacen2])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdComprobante])
REFERENCES [dbo].[Comprobante] ([IdComprobante])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdUbicacion1])
REFERENCES [dbo].[Ubicacion] ([IdUbicacion])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdUbicacion2])
REFERENCES [dbo].[Ubicacion] ([IdUbicacion])
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK__Ventas__IdProfor__595B4002] FOREIGN KEY([IdProforma])
REFERENCES [dbo].[Proforma] ([IdProforma])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK__Ventas__IdProfor__595B4002]
GO
/****** Object:  StoredProcedure [dbo].[ActivateBanco]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivateBanco]
@IdBanco int,
@Estado bit,
@Mensaje varchar(100) out
As Begin
	Begin try
		if Exists(Select Codigo from Banco where IdBanco=@IdBanco)
			begin
				UPdate Banco set Estado=@Estado where IdBanco=@IdBanco
				set @Mensaje='1'
			end
		else
			set @Mensaje='Este banco no existe'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[ActivateComprobante]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ActivateComprobante]
@IdComprobante int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Comprobante Set Estado=@Estado
		Where IdComprobante=@IdComprobante
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ActivateDetalleEntrega]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ActivateDetalleEntrega]
@IdDetalleEntrega int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select IdDetalleEntrega from DetalleEntrega where IdDetalleEntrega=@IdDetalleEntrega))
				begin
					update DetalleEntrega set Estado=@Estado
					where IdDetalleEntrega=@IdDetalleEntrega
					Set @Mensaje='1'
				end
		else
			set @Mensaje='No existe documento!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ActivateIgv]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ActivateIgv]
@IdIgv int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
	if(@Estado=1)
		begin
			Update Igv Set Estado=0
			Update Igv Set Estado=@Estado
			Where IdIgv=@IdIgv
			Set @Mensaje='1'
		end
	else
		Set @Mensaje='No te puedes quedar sin IGV Activo alguno'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ActivateMedioPago]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[ActivateMedioPago]
@IdMedioPago int,
@Estado bit,
@Mensaje varchar(100) out
As Begin
	Begin try
		if Exists(Select Codigo from MedioPago where IdMedioPago=@IdMedioPago)
			begin
				UPdate MedioPago set Estado=@Estado where IdMedioPago=@IdMedioPago
				set @Mensaje='1'
			end
		else
			set @Mensaje='Este Medio de Pago no existe'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[ActivateMoneda]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ActivateMoneda]
@IdMoneda int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Moneda Set Estado=@Estado
		Where IdMoneda=@IdMoneda
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ActivateTienda]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ActivateTienda]
@IdTienda int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Tienda Set Estado=@Estado
		Where IdTienda=@IdTienda
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ActivateTiendaUsuario]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ActivateTiendaUsuario]
@IdTiendaUsuario int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update TiendaUsuario Set Estado=@Estado
		Where IdTiendaUsuario=@IdTiendaUsuario
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ActivateTipoVenta]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ActivateTipoVenta]
@IdTipoVenta int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update TipoVenta Set Estado=@Estado
		Where IdTipoVenta=@IdTipoVenta
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[AnularConsumo]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AnularConsumo]
@IdConsumo int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select IdConsumo from Consumo where IdConsumo=@IdConsumo))
				begin
					update Consumo set Estado=@Estado
					where IdConsumo=@IdConsumo
					Set @Mensaje='1'
				end
		else
			set @Mensaje='No existe documento!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[AnularEntrega]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AnularEntrega]
@IdEntrega int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select IdEntrega from Entrega where IdEntrega=@IdEntrega))
				begin
					update Entrega set Estado=@Estado
					where IdEntrega=@IdEntrega
					Set @Mensaje='1'
				end
		else
			set @Mensaje='No existe documento!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[AnularIngreso]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AnularIngreso]
@IdIngreso int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select IdIngreso from Ingreso where IdIngreso=@IdIngreso))
				begin
					update Ingreso set Estado=@Estado
					where IdIngreso=@IdIngreso
					Set @Mensaje='1'
				end
		else
			set @Mensaje='No existe documento!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[AnularOCompra]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AnularOCompra]
@IdOCompra int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update OCompra Set Estado=@Estado
		Where IdOCompra=@IdOCompra
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[AnularTransferencia]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AnularTransferencia]
@IdTransferencia int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select IdTransferencia from Transferencia where IdTransferencia=@IdTransferencia))
				begin
					update Transferencia set Estado=@Estado
					where IdTransferencia=@IdTransferencia
					Set @Mensaje='1'
				end
		else
			set @Mensaje='No existe documento!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[AnularVentas]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AnularVentas]
@IdVentas int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select IdVentas from Ventas where IdVentas=@IdVentas))
			--Validar que los productos no esten entregadas de esta venta
			if(not exists(select IdVentas from Entrega where IdVentas=@IdVentas and Estado=1))
			--Validar que la venta no tenga cobraza
				if(not exists(select IdVenta from Cobranza where IdVenta=@IdVentas))
					--Validar fecha de envio a la sunat (validar en el UI)
					begin
						update Ventas set Estado=@Estado
						where IdVentas=@IdVentas
						Set @Mensaje='1'
					end
				else
					set @Mensaje='Esta venta no se puede anular, por que ya fue cobrada'
			else
				set @Mensaje='Esta venta no se puede anular, por que ya tiene una entrega'
		else
			set @Mensaje='No existe documento!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[CancelarVenta]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CancelarVenta]
@IdVentas int,
@Cancelado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Ventas Set Cancelado=@Cancelado
		Where IdVentas=@IdVentas
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaCobranzaCajero]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaCobranzaCajero]
@Fecha DateTime,
@IdUsuario int
	As Begin
		Select 
		C.IdCobranza
		,C.Fecha
		,C.Importe
		,V.IdVentas
		,V.Numero
		,V.FEmision
		,CL.RazSocial Cliente
		,VP.Directo
		,CL.NumDocumento
		,VP.Simbolo
		,VP.Serie
		,MP.Descripcion MPago
		,TV.Tipo TVenta
		,U.NomUsuario Usuario
		,C.NumOperacion
		 from Cobranza C
		inner join Ventas V on V.IdVentas=C.IdVenta
		inner join View_Proforma_Descripcion_Documento VP on VP.IdProforma=V.IdProforma
		inner join TipoVenta TV on TV.IdTipoVenta=VP.IdTipoVenta
		inner join Cliente CL on CL.IdCliente=VP.IdCliente
		inner join Banco B on B.IdBanco=C.IdBanco
		inner join MedioPago MP on Mp.IdMedioPago=C.IdMedioPago
		inner join Usuario U on U.IdUsuario=VP.IdUsuario
		where CONVERT(date,C.Fecha,5)=CONVERT(date,@Fecha,5) and C.IdUsuario=@IdUsuario
		
	End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaCobranzaCajeroVendedor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaCobranzaCajeroVendedor]
@Fecha DateTime,
@IdCajero int,
@IdVededor int
	As Begin
		Select 
		C.IdCobranza
		,C.Fecha
		,C.Importe
		,V.IdVentas
		,V.Numero
		,V.FEmision
		,CL.RazSocial Cliente
		,VP.Directo
		,CL.NumDocumento
		,VP.Simbolo
		,VP.Serie
		,MP.Descripcion MPago
		,TV.Tipo TVenta
		,U.NomUsuario Usuario
		,C.NumOperacion
		 from Cobranza C
		inner join Ventas V on V.IdVentas=C.IdVenta
		inner join View_Proforma_Descripcion_Documento VP on VP.IdProforma=V.IdProforma
		inner join TipoVenta TV on TV.IdTipoVenta=VP.IdTipoVenta
		inner join Cliente CL on CL.IdCliente=VP.IdCliente
		inner join Banco B on B.IdBanco=C.IdBanco
		inner join MedioPago MP on Mp.IdMedioPago=C.IdMedioPago
		inner join Usuario U on U.IdUsuario=VP.IdUsuario
		where CONVERT(date,C.Fecha,5)=CONVERT(date,@Fecha,5) and C.IdUsuario=@IdCajero and VP.IdUsuario=@IdVededor
		
	End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaCobranzaIdVenta]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ConsultaCobranzaIdVenta]
@IdVenta int
	As Begin
		Select 
		C.IdCobranza
		,C.Fecha --Fecha de cobranza
		,C.Importe
		,U.NomUsuario Usuario --Usuario quien cobra
		,C.NumOperacion --Mostrar si es un movimiento bancario
		,MP.Efectivo --Control de Efectivo o mb
		,MP.Descripcion MPago --Si es un movimiento bancario
		,B.Nombre Banco ---Si es un movimiento bancario
		from Cobranza C
		inner join Banco B on B.IdBanco=C.IdBanco
		inner join MedioPago MP on Mp.IdMedioPago=C.IdMedioPago
		inner join Usuario U on U.IdUsuario=C.IdUsuario
		where C.IdVenta=@IdVenta
	End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaCobranzaVendedor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaCobranzaVendedor]
@Fecha DateTime,
@IdUsuario int
	As Begin
		Select 
		C.IdCobranza
		,C.Fecha
		,C.Importe
		,V.IdVentas
		,V.Numero
		,V.FEmision
		,CL.RazSocial Cliente
		,VP.Directo
		,CL.NumDocumento
		,VP.Simbolo
		,VP.Serie
		,MP.Descripcion MPago
		,TV.Tipo TVenta
		,U.NomUsuario Usuario
		,C.NumOperacion
		 from Cobranza C
		inner join Ventas V on V.IdVentas=C.IdVenta
		inner join View_Proforma_Descripcion_Documento VP on VP.IdProforma=V.IdProforma
		inner join TipoVenta TV on TV.IdTipoVenta=VP.IdTipoVenta
		inner join Cliente CL on CL.IdCliente=VP.IdCliente
		inner join Banco B on B.IdBanco=C.IdBanco
		inner join MedioPago MP on Mp.IdMedioPago=C.IdMedioPago
		inner join Usuario U on U.IdUsuario=C.IdUsuario
		where CONVERT(date,C.Fecha,5)=CONVERT(date,@Fecha,5) and VP.IdUsuario=@IdUsuario
		
	End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaConsumo]
@IdAlmacen int,
@Numero int
As Begin
	select 
	Consumo.IdConsumo,
	Consumo.Fecha,
	Consumo.IdAlmacen,
	Consumo.Numero,
	Consumo.IdUsuario,
	Consumo.IdEmpleado,
	Consumo.IdComprobante,
	Consumo.Estado,
	U.NomUsuario Usuario,
	E.NumDocumento,
	E.Documento,
	E.Nombres,
	E.Apellidos
	from Consumo
	inner join Usuario U on U.IdUsuario=Consumo.IdUsuario
	inner join Empleado E on E.IdEmpleado=Consumo.IdEmpleado
	where Consumo.IdAlmacen=@IdAlmacen and Consumo.Numero=@Numero
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleDeudasCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaDetalleDeudasCliente]
@IdCliente int
As Begin
	--Todas las ventas aun no canceladas
	select V.IdVentas,DP.PUnitario Importe from Ventas V
	inner join Proforma P on P.IdProforma=V.IdProforma
	inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
	where P.IdCliente=@IdCliente  and V.Estado=1 and V.Cancelado=0

	--Ventas cobradas pero un no canceladas
	select V.IdVentas,C.Importe from Ventas V
	inner join Cobranza C on C.IdVenta=V.IdVentas
	inner join Proforma P on P.IdProforma=V.IdProforma
	where P.IdCliente=@IdCliente and V.Estado=1 and V.Cancelado=0
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaDetalleEntrega]
@IdVentas int
As Begin
	select
	E.IdEntrega
	,DE.IdDetalleEntrega
	,DE.IdDetalleProforma
	,DE.Cantidad
	,E.IdAlmacen
	,E.Numero
	,E.Fecha
	,A.Serie
	,C.Simbolo
	,U.NomUsuario
	from Entrega E
	inner join Almacen A on A.IdAlmacen=E.IdAlmacen
	inner join Usuario U on U.IdUsuario=E.IdUsuario
	inner join Comprobante C on C.IdComprobante=E.IdComprobante
	inner join DetalleEntrega DE on DE.IdEntrega=E.IdEntrega
	where E.IdVentas = @IdVentas 
	and E.Estado=1 --Entregas vigentes y no anuladas
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaDetalleIngreso]
@IdOCompra int
As Begin
	select 
	DI.IdDetalleOCompra
	,DI.Cantidad
	
	from DetalleIngreso DI
	inner join Ingreso on Ingreso.IdIngreso=DI.IdIngreso
	inner join DetalleOCompra DOC on DOC.IdDetalleOCompra=DI.IdDetalleOCompra
	inner join OCompra OC on OC.IdOCompra=DOC.IdOCompra
	where OC.IdOCompra=@IdOCompra and Ingreso.Estado=1
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaDetalleProforma]
@IdProforma int
as begin
	Select IdDetalleProforma
	,IdProforma
	,P.IdProducto
	,U.IdUnidad
	,Cantidad
	,PUnitario
	,Descuento
	,Almacen.IdAlmacen
	,Almacen.Nombre Almacen
	,Almacen.Serie
	,U.AUnidad
	,P.IdCategoria
	,P.Serie2
	,P.IdColor
	,P.Modelo
	,P.Descripcion1
	,P.Descripcion2
	,P.NomColor
	,P.Bilateral
	,DetalleProforma.Estado
	from DetalleProforma
	inner join Almacen on Almacen.IdAlmacen=DetalleProforma.IdAlmacen
	inner join Unidad U on U.IdUnidad=DetalleProforma.IdUnidad
	inner join View_Producto P on P.IdProducto=DetalleProforma.IdProducto
	 where IdProforma=@IdProforma
end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleVenta]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultaDetalleVenta]
@IdVentas int
As Begin
	--Todas las ventas aun no canceladas
	select V.IdVentas,DP.PUnitario Importe from Ventas V
	inner join Proforma P on P.IdProforma=V.IdProforma
	inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
	where V.IdVentas=@IdVentas  and V.Estado=1
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalleVentaCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaDetalleVentaCliente]
--ConsultaDeudasCliente
@IdCliente int
As Begin
	--Todas las ventas aun no canceladas
	select FEmision,DP.PUnitario Importe from Ventas V
	inner join Proforma P on P.IdProforma=V.IdProforma
	inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
	where P.IdCliente=@IdCliente and V.Estado=1
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaDeudasVenta]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaDeudasVenta]
@IdVentas int
As Begin
	--la venta realizada
	select V.IdVentas,DP.PUnitario Importe from Ventas V
	inner join Proforma P on P.IdProforma=V.IdProforma
	inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
	where V.IdVentas=@IdVentas

	--Venta cobradas pero un no canceladas
	select V.IdVentas,C.Importe from Ventas V
	inner join Cobranza C on C.IdVenta=V.IdVentas
	inner join Proforma P on P.IdProforma=V.IdProforma
	where V.IdVentas=@IdVentas
end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaEntrega]
@NumeroE int,
@IdAlmacen int --Serie de almacen
As Begin
	select
	 E.IdEntrega
	,V.IdVentas
	,U.IdUsuario
	,E.IdAlmacen
	,C.IdComprobante
	,E.Fecha FechaE
	,E.Estado --Si es falso significa que está anulado
	,E.Numero NumeroE
	,V.FEmision
	,V.Numero NumeroV
	,P.RazSocial
	,P.NumDocumento --dni/ruc
	,P.Simbolo SimboloV
	,P.SerieT SerieV
	,P.NomUsuario UsuarioV
	,C.Simbolo SimboloE
	,U.NomUsuario UsuarioE
	from Entrega E
	inner join Comprobante C on C.IdComprobante=E.IdComprobante
	inner join Ventas V on V.IdVentas=E.IdVentas
	inner join View_Proforma P on P.IdProforma=V.IdProforma
	inner join Usuario U on U.IdUsuario=E.IdUsuario
	where E.Numero = @NumeroE and E.IdAlmacen= @IdAlmacen
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaEntrega1]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaEntrega1]
@IdVentas int,
@IdAlmacen int
As Begin
	select
	 IdVentas
	,DE.Cantidad
	,DE.IdDetalleProforma
	,E.IdAlmacen
	from Entrega E
	inner join DetalleEntrega DE on DE.IdEntrega=E.IdEntrega
	where E.IdVentas = @IdVentas and E.IdAlmacen= @IdAlmacen 
	and E.Estado=1 --Entregas vigentes y no anuladas
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaIngreso]
@Serie int,
@Numero int
As Begin
	Select 
	I.IdIngreso,
	I.Fecha,
	I.IdAlmacen,
	A.Nombre Almacen,
	A.Serie,
	I.Numero,
	I.IdUsuario,
	U.NomUsuario Usuario,
	I.IdProveedor,
	P.RazonSocial Proveedor,
	P.Numero NumProveedor,
	P.NomDocumento DocProveedor,
	I.IdComprobante,
	C.Simbolo SimboloIngreso,--Nuevo
	I.IdCompProveedor,
	CP.Simbolo SimboloProveedor,--Nuevo
	CP.NomComprobante CompProveedor,
	I.SerieProveedor,
	I.NumCompProveedor,
	I.FechaProveedor,
	I.IdTransportista,
	T.RazonSocial Transportista,
	T.Numero NumTransportista,
	T.IdDocumento IdDocTransportista,
	T.NomDocumento DocTransportista,
	I.IdCompTransportista,
	CT.Simbolo SimboloTransportista,--Nuevo
	CT.NomComprobante CompTransportista,
	I.SerieTransportista,
	I.NumCompTransportista,
	I.Estado
	from Ingreso I
	inner join Almacen A on A.IdAlmacen=I.IdAlmacen
	inner join Usuario U on U.IdUsuario=I.IdUsuario
	inner join View_Proveedor P on P.IdProveedor=I.IdProveedor
	inner join Comprobante C on C.IdComprobante=I.IdComprobante
	inner join Comprobante CP on CP.IdComprobante=I.IdCompProveedor
	inner join View_Proveedor T on T.IdProveedor=I.IdTransportista
	inner join Comprobante CT on CT.IdComprobante=I.IdCompTransportista
	where A.Serie=@Serie and I.Numero = @Numero
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaIngreso_Compra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaIngreso_Compra]
@IdProducto int
as
select 
I.IdIngreso
,OC.IdOCompra
,I.Fecha
,DI.Cantidad
,U.AUnidad
,U.IdUnidad
--,U.Factor
,M.Simbolo Moneda
,DOC.PCompra Costo
,OC.TipoCambio TCambio
,A.Nombre Almacen
,A.Serie
,I.Numero
,C.Simbolo--Simbolo comprobante
,P.RazonSocial Proveedor
,P.Numero NumDocumento
from DetalleIngreso  DI
inner join Ingreso I on I.IdIngreso=DI.IdIngreso
inner join Comprobante C on C.IdComprobante=I.IdComprobante
inner join DetalleOCompra DOC on DOC.IdDetalleOCompra=DI.IdDetalleOCompra
inner join Unidad U on U.IdUnidad=DOC.IdUnidad
inner join OCompra OC on OC.IdOCompra=DOC.IdOCompra
inner join Proveedor P on P.IdProveedor=OC.IdProveedor
inner join Moneda M on M.IdMoneda=OC.IdMoneda
inner join Almacen A on A.IdAlmacen=I.IdAlmacen
where IdProducto=@IdProducto and i.Estado=1
GO
/****** Object:  StoredProcedure [dbo].[ConsultaOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaOCompra]
@Numero int
as
	begin
		Select 
		OCompra.IdOCompra
		,OCompra.Fecha
		,OCompra.Numero
		,Proveedor.IdProveedor
		,Proveedor.RazonSocial Proveedor
		,Documento.IdDocumento
		,Documento.NomDocumento Documento
		,Proveedor.Numero NumDocumento
		,Usuario.IdUsuario
		,Usuario.NomUsuario Usuario
		,Comprobante.IdComprobante
		,Comprobante.NomComprobante Comprobante
		,Moneda.IdMoneda
		,Moneda.Abrev
		,OCompra.TipoCambio
		,OCompra.Estado
		,TipoVenta.IdTipoVenta
		,TipoVenta.Credito
		,TipoVenta.Tipo
		,OCompra.Plazo
		,OCompra.Igv
		from OCompra
		inner join Proveedor on Proveedor.IdProveedor=OCompra.IdProveedor
		inner join Documento on Documento.IdDocumento=Proveedor.IdDocumento
		inner join Ubigeo on Ubigeo.IdUbigeo=Proveedor.IdUbigeo
		inner join Usuario on Usuario.IdUsuario=OCompra.IdUsuario
		inner join Comprobante on Comprobante.IdComprobante=OCompra.IdComprobante
		inner join Moneda on Moneda.IdMoneda=OCompra.IdMoneda
		inner join TipoVenta on TipoVenta.IdTipoVenta=OCompra.IdTipoVenta
		where OCompra.Numero=@Numero
	end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaOCompra_Ingreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaOCompra_Ingreso]
@IdOCompra int
as
begin
	select IdDetalleIngreso from DetalleIngreso
	inner join DetalleOCompra on DetalleOCompra.IdDetalleOCompra=DetalleIngreso.IdDetalleOCompra
	inner join OCompra on OCompra.IdOCompra=DetalleOCompra.IdOCompra
	inner join Ingreso on Ingreso.IdIngreso=DetalleIngreso.IdIngreso
	where OCompra.IdOCompra=@IdOCompra and Ingreso.Estado=1
end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaProforma]
@IdTienda int,
@Numero int
as begin
	Select 
	IdProforma
	,Numero
	,Fecha
	,Estado
	,ENUSO
	,IdAlmacen
	,SerieA
	,Nombre Almacen
	,IdCliente
	,RazSocial Cliente
	,Directo
	,IdDocumento
	,NomDocumento Documento--(DNI,RUC,)
	,Ruc --Si el tipo de documento es RUC
	,NumDocumento
	,IdUsuario
	,NomUsuario Usuario
	,IdComprobante 
	,NomComprobante Comprobante
	,Codigo --Codigo sunat
	,Declarable
	,Venta
	,Ingreso
	,Simbolo --Para generar el formato serie
	,IdTienda
	,NomTienda Tienda
	,SerieT --Serie Tienda
	,IdTipoVenta
	,Tipo --Tipo de Venta
	,Igv
	,Concat(Direccion,' - ',Distrito,' - ',Provincia,' - ',Departamento) Direccion
	,Plazo
	,Credito
	 from View_Proforma where IdTienda = @IdTienda and Numero=@Numero
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaProformaId]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ConsultaProformaId]
@IdProforma int
as begin
	Select 
	IdProforma
	,Numero
	,Fecha
	,Estado
	,ENUSO
	,IdAlmacen
	,SerieA
	,Nombre Almacen
	,IdCliente
	,RazSocial Cliente
	,Directo
	,IdDocumento
	,NomDocumento Documento--(DNI,RUC,)
	,Ruc --Si el tipo de documento es RUC
	,NumDocumento
	,IdUsuario
	,NomUsuario Usuario
	,IdComprobante 
	,NomComprobante Comprobante
	,Codigo --Codigo sunat
	,Declarable
	,Venta
	,Ingreso
	,Simbolo --Para generar el formato serie
	,IdTienda
	,NomTienda Tienda
	,SerieT --Serie Tienda
	,IdTipoVenta
	,Tipo --Tipo de Venta
	,Igv
	,Concat(Direccion,' - ',Distrito,' - ',Provincia,' - ',Departamento) Direccion
	,Plazo
	,Credito
	 from View_Proforma where IdProforma = @IdProforma
end

GO
/****** Object:  StoredProcedure [dbo].[ConsultaPromedio]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ConsultaPromedio]
@IdProducto int
as
--Revisar
select Promedio,PU.Factor from DetalleIngreso DI
inner join DetalleOCompra DOC on DOC.IdDetalleOCompra=DI.IdDetalleOCompra
inner  join Unidad U on U.IdUnidad=DOC.IdUnidad
inner join ProductoUnidad PU on PU.IdProducto=DOC.IdProducto
where DOC.IdProducto=@IdProducto and  Promediado=1
GO
/****** Object:  StoredProcedure [dbo].[ConsultaTiendaUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaTiendaUsuario]
@IdUsuario int
as
	begin
		Select 
		IdTiendaUsuario
		,Tienda.IdTienda
		,Tienda.NomTienda
		,Tienda.Serie
		,Usuario.IdUsuario
		,Usuario.NomUsuario
		,TiendaUsuario.Estado 
		from TiendaUsuario
		inner join Usuario on Usuario.IdUsuario=TiendaUsuario.IdUsuario
		inner join Tienda on Tienda.IdTienda=TiendaUsuario.IdTienda
		where Usuario.IdUsuario=@IdUsuario and Tienda.Estado=1
	end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaTransferencia]
@Numero int,
@IdAlmacen1 int --Almacen de generacion de transferencia
As Begin
	select 
	T.IdTransferencia
	,T.Fecha
	,T.IdAlmacen1
	,T.IdAlmacen2
	,T.IdUbicacion1
	,T.IdUbicacion2
	,T.IdUsuario
	,E.IdEmpleado
	,E.NumDocumento
	,E.Nombres 
	,E.Apellidos
	,T.Estado
	from Transferencia T
	inner join Comprobante C on C.IdComprobante=T.IdComprobante
	inner join Empleado E on E.IdEmpleado=T.IdEmpleado
	where T.Numero = @Numero and T.IdAlmacen1=@IdAlmacen1 
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaUltimaCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultaUltimaCompra]
@IdProducto int
as
select top 1 IdUnidad,PCompra from DetalleOCompra
inner join DetalleIngreso on DetalleIngreso.IdDetalleOCompra=DetalleOCompra.IdDetalleOCompra
where  IdProducto=@IdProducto
order by IdDetalleIngreso desc
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVenta1]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaVenta1]
@FInicio datetime,--Desde, Fecha de emision de venta
@FFin datetime,--Asta, Fecha de emision de venta
@IdAlmacen int
As Begin
	select 
	IdVentas
	,V.FEmision
	,P.Plazo
	,V.Numero
	,V.Estado 
	,P.IdProforma
	,P.RazSocial
	,P.NumDocumento
	,P.NomUsuario
	,DP.IdAlmacen
	,P.Simbolo
	,P.SerieT
	,DP.Cantidad
	,DP.IdDetalleProforma
	,U.AUnidad --x
	,VP.IdCategoria --x
	,VP.Serie2 --x
	,VP.IdColor --x
	,VP.Modelo --x
	,VP.Descripcion1 --x
	,VP.Descripcion2 --x
	,VP.NomColor --x
	,VP.Bilateral --x
	--Agregar mas segun la nececidad
	from Ventas V
	Inner join View_Proforma P on P.IdProforma=V.IdProforma
	inner join DetalleProforma DP on Dp.IdProforma=P.IdProforma
	inner join View_Producto VP on VP.IdProducto=DP.IdProducto
	inner join Unidad U on U.IdUnidad=DP.IdUnidad
	where V.FEmision between  DATEADD(DAY,-1,@FInicio) and  @FFin and DP.IdAlmacen=@IdAlmacen and V.Estado=1
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVentaId]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaVentaId]
@IdVentas int
as begin
	select 
	V.IdVentas
	,V.Numero
	,V.FEmision
	,P.Plazo
	,P.IdProforma
	,P.Serie SerieT
	,P.Simbolo
	,P.Directo
	,TV.Tipo TipoVenta
	,P.Plazo
	 from Ventas V
	inner join View_Proforma_Descripcion_Documento P on P.IdProforma=V.IdProforma
	inner join TipoVenta TV on TV.IdTipoVenta=P.IdTipoVenta
	where V.IdVentas = @IdVentas
end
 
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVentaNumero]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaVentaNumero]
@IdComprobante int,
@IdTienda int,
@Numero int
as begin
	select 
	V.IdVentas
	,V.Numero
	,V.FEmision
	,P.Plazo
	,P.IdProforma
	,P.Serie SerieT
	,P.Simbolo
	,C.NumDocumento
	,C.RazSocial
	,P.Directo
	,V.Estado
	,V.Cancelado
	 from Ventas V
	inner join View_Proforma_Descripcion_Documento P on P.IdProforma=V.IdProforma
	inner join Cliente C on C.IdCliente=P.IdCliente
	where P.IdComprobante =@IdComprobante and P.IdTienda=@IdTienda and V.Numero=@Numero 
end
 
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVentaProducto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultaVentaProducto]
@IdProducto int,
@IdUnidad int
as
select Cantidad,FEmision from Ventas V
inner join Proforma P on P.IdProforma=V.IdProforma
inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
where IdProducto=@IdProducto and IdUnidad=@IdUnidad
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVentas]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaVentas]
@IdVenta int
as begin
	Select IdVentas
	,IdProforma
	,FEmision
	,Numero
	,Estado
	from Ventas
	where IdVentas=@IdVenta
end
 
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVentasCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaVentasCliente]
@IdCliente int
as select 
V.IdVentas
,V.Numero
,V.FEmision
,P.Plazo
,TV.Tipo TipoVenta
,TV.Credito
,P.IdProforma
,P.Serie SerieT
,P.Simbolo
,V.Estado
,P.Plazo
,U.NomUsuario
,V.Cancelado
 from Ventas V
inner join View_Proforma_Descripcion_Documento P on P.IdProforma=V.IdProforma
inner join TipoVenta TV on TV.IdTipoVenta=P.IdTipoVenta
INNER JOIN Usuario U on U.IdUsuario=P.IdUsuario
where P.IdCliente =@IdCliente and V.Estado=1
GO
/****** Object:  StoredProcedure [dbo].[ConsultaVentaSerieNumero]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaVentaSerieNumero]
@IdComprobante int,
@Serie int,
@Numero int
as begin
	select 
	V.IdVentas
	,V.IdProforma
	,V.Numero
	,V.FEmision
	,P.Plazo
	,P.Serie SerieT
	,P.Simbolo
	,V.Estado
	,V.Cancelado
	 from Ventas V
	inner join View_Proforma_Descripcion_Documento P on P.IdProforma=V.IdProforma
	where P.IdComprobante =@IdComprobante and P.Serie=@Serie and V.Numero=@Numero 
end
 
GO
/****** Object:  StoredProcedure [dbo].[CostoPromedioProducto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[CostoPromedioProducto]
@IdProducto int
As
select Promedio Costo, Factor from DetalleOCompra
inner join DetalleIngreso on DetalleIngreso.IdDetalleOCompra=DetalleOCompra.IdDetalleOCompra
inner join Unidad on Unidad.IdUnidad=DetalleOCompra.IdUnidad
inner join ProductoUnidad PU on PU.IdProducto=DetalleOCompra.IdProducto
where DetalleOCompra.IdProducto=@IdProducto and Promediado=1
GO
/****** Object:  StoredProcedure [dbo].[EliminarAlmacenUbicacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarAlmacenUbicacion]
@IdAlmacen int,
@IdUbicacion int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
		if not exists(select * from Transferencia where IdAlmacen1=@IdAlmacen and IdUbicacion1 = @IdUbicacion)
			or not exists(select * from Transferencia where IdAlmacen2=@IdAlmacen and IdUbicacion2 = @IdUbicacion)
				begin
					delete AlmacenUbicacion Where IdAlmacen=@IdAlmacen and IdUbicacion=@IdUbicacion
					Set @Mensaje='1'
				end
		else
			Set @Mensaje='No es posible eliminar, esta ubicacion esta siendo utilizado con este almacen'
		end
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarCobranza]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarCobranza]
@IdCobranza int,
@Mensaje varchar(100) out
As Begin
	Begin try
		if Exists(Select Idcobranza from Cobranza where IdCobranza=@IdCobranza)
			begin
				delete Cobranza where IdCobranza=@IdCobranza
				set @Mensaje='1'
			end
		else
			set @Mensaje='No existe Cobranza'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarDetalleConsumo]
@IdDetalleConsumo int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
			delete DetalleConsumo Where IdDetalleConsumo=@IdDetalleConsumo
			Set @Mensaje='1'
		end
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarDetalleIngreso]
@IdDetalleIngreso int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
			delete DetalleIngreso Where IdDetalleIngreso=@IdDetalleIngreso
			Set @Mensaje='1'
		end
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarDetalleOCompra]
@IdDetalleOCompra int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
			delete DetalleOCompra Where IdDetalleOCompra=@IdDetalleOCompra
			Set @Mensaje='1'
		end
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[EliminarDetalleProforma]
@IdDetalleProforma int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
			delete DetalleProforma Where IdDetalleProforma=@IdDetalleProforma
			Set @Mensaje='1'
		end
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetalleTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarDetalleTransferencia]
@IdDetalleTransferencia int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
				delete DetalleTransferencia Where IdDetalleTransferencia=@IdDetalleTransferencia
				Set @Mensaje='1'
			end
		end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarTiendaUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarTiendaUsuario]
@IdTiendaUsuario int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		begin
		if exists(select * from TiendaUsuario where IdTiendaUsuario=@IdTiendaUsuario)
				begin
					delete TiendaUsuario Where IdTiendaUsuario=@IdTiendaUsuario
					Set @Mensaje='1'
				end
		else
			Set @Mensaje='No existe esta combinación'
		end
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[Emision]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Emision]
@IdTienda int
as Begin
	select P.IdProforma
	,P.IdTienda
	,P.Fecha
	,P.SerieT
	,P.Numero
	,P.IdComprobante
	,P.NomComprobante
	,P.Simbolo
	,P.RazSocial
	,P.NumDocumento
	,NomUsuario 
	,PUnitario
	,Descuento
	,Cantidad
	from View_Proforma P
	inner join DetalleProforma PD on PD.IdProforma=P.IdProforma and PD.Estado=1
	left outer join Ventas V on P.IdProforma=V.IdProforma
	where P.Estado=1 and  V.IdProforma is null and IdTienda=@IdTienda
End
GO
/****** Object:  StoredProcedure [dbo].[Estados]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
========= PARA VENTAS =============
=== MOVIMIENTOS  ===
1) STOCK
2) SEPARADOS
3) COMPROMETIDOS
4) DISPONIBLE

parametros:  IdProducto,IdContenido
//Mostrar cantidades segun la unidad base
*/
CREATE PROC [dbo].[Estados]
@IdProducto int
AS
DECLARE @Cantidad TABLE  
    ( 
	IdAlmacen int,
    Cantidad   decimal(11,4),
	Movimiento int,
	Direccion bit,
	IdUnidad int
	)
	   
--Ingreso (Compra) (1) (1)
insert  @Cantidad select I.IdAlmacen, DI.Cantidad,1,1,O.IdUnidad
from Ingreso I 
inner join DetalleIngreso DI on I.IdIngreso=DI.IdIngreso
inner join DetalleOCompra O on O.IdDetalleOCompra=DI.IdDetalleOCompra
where I.Estado=1 and IdProducto=@IdProducto

--Entrega (Ventas) (1) (0)
insert  @Cantidad select P.IdAlmacen, E.Cantidad,1,0,P.IdUnidad
from DetalleEntrega E
inner join DetalleProforma P on P.IdDetalleProforma=E.IdDetalleProforma
where E.Estado=1 and IdProducto=@IdProducto

--Consumo (Uso interno) (1) (0)
insert  @Cantidad select  C.IdAlmacen, Cantidad,1,0,IdUnidad
from Consumo C
inner join DetalleConsumo DC on DC.IdConsumo=C.IdConsumo
where C.Estado=1 and IdProducto=@IdProducto

--Transferencia Salida (1)(0)
insert  @Cantidad select T.IdAlmacen1, Cantidad,1,0,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where T.Estado=1 and IdProducto=@IdProducto

--Transferencia Ingreso (1)(1)
insert  @Cantidad select T.IdAlmacen2, Cantidad,1,1,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto

--'Separado' o 'Generado' (2)(0)
insert  @Cantidad select DP.IdAlmacen, Cantidad,2,0,DP.IdUnidad
from Proforma P
inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
left outer join Ventas V on P.IdProforma=V.IdProforma
where P.Estado=1 and  DP.IdProducto = @IdProducto and V.IdProforma is null

--'Comprometido' o 'Emitido' (3)(0)
insert  @Cantidad select DP.IdAlmacen,Cantidad,3,0,DP.IdUnidad
from Ventas V
inner join DetalleProforma DP on DP.IdProforma=V.IdProforma
left outer join Entrega E on E.IdVentas=V.IdVentas
where V.Estado=1 and DP.IdProducto=@IdProducto and (E.IdVentas is null or E.Estado=0)

--'Disponible'
--Salida
--MALOGRADOS(4)(0)
insert  @Cantidad select T.IdAlmacen1, Cantidad,4,0,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto and IdUbicacion1=2

--MOSTRARIO(4)(0)
insert  @Cantidad select T.IdAlmacen1, Cantidad,4,0,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto and IdUbicacion1=3

--RETENIDO(4)(0)
insert  @Cantidad select T.IdAlmacen1, Cantidad,4,0,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto and IdUbicacion1=4

--Ingreso
--MALOGRADOS(4)(1)
insert  @Cantidad select T.IdAlmacen2, Cantidad,4,1,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto and IdUbicacion2=2

--MOSTRARIO(4)(1)
insert  @Cantidad select T.IdAlmacen2, Cantidad,4,1,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto and IdUbicacion2=3

--RETENIDO(4)(1)
insert  @Cantidad select T.IdAlmacen2, Cantidad,4,1,IdUnidad
from Transferencia T
inner join DetalleTransferencia DT on DT.IdTransferencia=T.IdTransferencia
where  T.Estado=1 and IdProducto=@IdProducto and IdUbicacion2=4

select IdAlmacen,Cantidad,Movimiento,Direccion,ProductoUnidad.Factor,C.IdUnidad 
from  @Cantidad C
inner join ProductoUnidad on ProductoUnidad.IdUnidad=C.IdUnidad
GO
/****** Object:  StoredProcedure [dbo].[GenerarProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GenerarProforma]
@IdProforma int,
@Estado bit,
@Mensaje varchar(100) out
As begin
	begin try
		update Proforma set 
		Estado=@Estado
		where IdProforma = @IdProforma
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[ListBanco]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListBanco]
As Begin
	Select IdBanco,Nombre,Codigo,Estado,Efectivo from Banco
End
GO
/****** Object:  StoredProcedure [dbo].[ListCobranza]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListCobranza]
@Fecha DateTime
	As Begin
		Select 
		C.IdCobranza
		,C.Fecha
		,C.Importe
		,V.IdVentas
		,V.Numero
		,V.FEmision
		,CL.RazSocial Cliente
		,VP.Directo
		,CL.NumDocumento
		,VP.Simbolo
		,VP.Serie
		,MP.Descripcion MPago
		,TV.Tipo TVenta
		,UC.NomUsuario Usuario
		,C.NumOperacion
		from Cobranza C
		inner join Ventas V on V.IdVentas=C.IdVenta
		inner join View_Proforma_Descripcion_Documento VP on VP.IdProforma=V.IdProforma
		inner join TipoVenta TV on TV.IdTipoVenta=VP.IdTipoVenta
		inner join Cliente CL on CL.IdCliente=VP.IdCliente
		inner join Banco B on B.IdBanco=C.IdBanco
		inner join MedioPago MP on Mp.IdMedioPago=C.IdMedioPago
		inner join Usuario UC on UC.IdUsuario=VP.IdUsuario
		where CONVERT(date,C.Fecha,5)=CONVERT(date,@Fecha,5)
	End
GO
/****** Object:  StoredProcedure [dbo].[ListComprobante]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListComprobante]
as
 Select IdComprobante,Codigo,NomComprobante,Estado,Simbolo,Declarable,Venta,Ingreso from Comprobante
GO
/****** Object:  StoredProcedure [dbo].[ListConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListConsumo]
@f1 datetime,
@f2 datetime
As Begin
	select 
	Consumo.IdConsumo,
	Consumo.Fecha,
	Consumo.IdAlmacen,
	Consumo.Numero,
	Consumo.IdUsuario,
	Consumo.IdEmpleado,
	Consumo.IdComprobante,
	Consumo.Estado,
	U.NomUsuario Usuario,
	E.Nombres,
	E.Apellidos
	from Consumo
	inner join Usuario U on U.IdUsuario=Consumo.IdUsuario
	inner join Empleado E on E.IdEmpleado=Consumo.IdEmpleado
	where Consumo.Fecha between @f1 and @f2
End
GO
/****** Object:  StoredProcedure [dbo].[ListCreditosDatos]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListCreditosDatos]
@f1 date,
@f2 date
as select 
V.IdVentas
,V.Numero
,V.FEmision
,P.Serie SerieT
,P.Simbolo
,C.RazSocial
,C.NumDocumento
,P.Directo
,P.Plazo
,TP.Tipo TipoVenta
,U.NomUsuario
 from Ventas V
inner join View_Proforma_Descripcion_Documento P on P.IdProforma=V.IdProforma
inner join Usuario U on U.IdUsuario=P.IdUsuario
inner join TipoVenta TP on TP.IdTipoVenta=P.IdTipoVenta
inner join Cliente C on C.IdCliente=P.IdCliente
where V.Estado=1 and V.Cancelado=0 and V.FEmision between @f1 and dateadd(day,1,@f2)
GO
/****** Object:  StoredProcedure [dbo].[ListCreditosImporte]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListCreditosImporte]
@f1 date,
@f2 date
As Begin
	--Todas las ventas aun no canceladas
	select V.IdVentas,DP.PUnitario Importe from Ventas V
	inner join Proforma P on P.IdProforma=V.IdProforma
	inner join DetalleProforma DP on DP.IdProforma=P.IdProforma
	where  V.Estado=1 and V.Cancelado=0 and V.FEmision between @f1 and dateadd(day,1,@f2)

	--Ventas cobradas pero un no canceladas
	select V.IdVentas,C.Importe from Ventas V
	inner join Cobranza C on C.IdVenta=V.IdVentas
	inner join Proforma P on P.IdProforma=V.IdProforma
	where V.Estado=1 and V.Cancelado=0 and V.FEmision between @f1 and dateadd(day,1,@f2)
End
GO
/****** Object:  StoredProcedure [dbo].[ListDetalleConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListDetalleConsumo]
@IdConsumo int
As Begin
	Select 
	DC.IdDetalleConsumo
	,DC.IdConsumo
	,P.IdProducto
	,DC.IdUnidad
	,DC.Cantidad
	,P.IdCategoria
	,P.Serie2
	,P.IdColor
	,P.Descripcion1
	,P.Descripcion2
	,P.NomColor Color
	,P.Bilateral
	,P.Modelo
	,U.AUnidad
	from DetalleConsumo DC
	inner join Unidad U on U.IdUnidad=DC.IdUnidad
	inner join View_Producto P on P.IdProducto=DC.IdProducto
	where IdConsumo=@IdConsumo
End
GO
/****** Object:  StoredProcedure [dbo].[ListDetalleEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListDetalleEntrega]
@IdEntrega int
As Begin
	select 
	IdDetalleEntrega
	,DE.IdEntrega
	,DP.IdDetalleProforma
	,P.IdCategoria
	,P.Serie2
	,P.IdColor
	,P.Descripcion1
	,P.Descripcion2
	,P.NomColor
	,P.Bilateral
	,P.Modelo
	,U.AUnidad
	,DE.Cantidad
	,DE.Estado
	from DetalleEntrega  DE
	inner join DetalleProforma DP on DP.IdDetalleProforma=DE.IdDetalleProforma
	inner join Unidad U on U.IdUnidad=DP.IdUnidad
	inner join View_Producto P on P.IdProducto=DP.IdProducto
	where IdEntrega=@IdEntrega
End
GO
/****** Object:  StoredProcedure [dbo].[ListDetalleIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListDetalleIngreso]
@IdIngreso int
As Begin
	Select 
	IdDetalleIngreso
	,IdIngreso
	,D.IdDetalleOCompra
	,D.IdOCompra
	,P.IdProducto
	,P.IdCategoria
	,P.Serie2
	,P.IdColor
	,P.Descripcion1
	,P.Descripcion2
	,P.NomColor Color
	,P.Bilateral
	,P.Modelo
	,U.AUnidad
	,I.Cantidad
	,D.Cantidad CantCompra
	,O.Numero
	from DetalleIngreso I
	inner join DetalleOCompra D on D.IdDetalleOCompra=I.IdDetalleOCompra
	inner join OCompra O on O.IdOCompra=D.IdOCompra
	inner join Unidad U on U.IdUnidad=D.IdUnidad
	inner join View_Producto P on P.IdProducto=D.IdProducto
	where IdIngreso=@IdIngreso
End
GO
/****** Object:  StoredProcedure [dbo].[ListDetalleOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListDetalleOCompra]
@IdOCompra int
As Begin
	select 
	IdDetalleOCompra
	,DOC.IdOCompra
	,P.IdProducto
	,P.IdCategoria
	,P.Serie2
	,P.IdColor
	,P.Descripcion1
	,P.Descripcion2
	,P.NomColor
	,P.Bilateral
	,P.Modelo
	,U.IdUnidad
	,U.AUnidad
	,DOC.Cantidad
	,DOC.PCompra
	,DOC.Estado
	from DetalleOCompra  DOC
	inner join Unidad U on U.IdUnidad=DOC.IdUnidad
	inner join View_Producto P on P.IdProducto=DOC.IdProducto
	where IdOCompra=@IdOCompra
End
GO
/****** Object:  StoredProcedure [dbo].[ListDetalleTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListDetalleTransferencia]
@IdTransferencia int
As Begin
	select 
	IdDetalleTransferencia
	,DT.IdTransferencia
	,P.IdProducto
	,P.IdCategoria
	,P.Serie2
	,P.IdColor
	,P.Descripcion1
	,P.Descripcion2
	,P.NomColor
	,P.Bilateral
	,P.Modelo
	,U.Idunidad
	,U.AUnidad
	,DT.Cantidad
	from DetalleTransferencia  DT
	inner join Unidad U on U.IdUnidad=DT.IdUnidad
	inner join View_Producto P on P.IdProducto=DT.IdProducto
	where IdTransferencia=@IdTransferencia
End
GO
/****** Object:  StoredProcedure [dbo].[ListEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListEntrega]
@FInicio datetime,
@FFin datetime
As Begin
	select 
	 E.IdEntrega
	,E.Fecha
	--Venta
	,V.IdVentas
	,V.Numero
	--Comprovante
	,NomComprobante
	,Tipo --simbolo del comprobante
	,Codigo --Codigo de comprobante segun Sunat
	--Cliente
	,P.RazSocial
	,P.NumDocumento
	--Serie
	,NomTienda
	,SerieT Serie
	--Usuario
	,U.IdUsuario
	,U.NomUsuario
	,DP.IdAlmacen
	,DP.Cantidad
	from Entrega E
	Inner join Ventas V on V.IdVentas=E.IdVentas
	Inner join View_Proforma P on P.IdProforma=V.IdProforma
	Inner join Usuario U on U.IdUsuario=E.IdUsuario
	inner join DetalleProforma DP on Dp.IdProforma=P.IdProforma
	where E.Fecha between @FInicio and @FInicio 
	and E.Estado=1 --Entregas vigentes y no anuladas
End
GO
/****** Object:  StoredProcedure [dbo].[ListIgv]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListIgv]
as
Select IdIgv,Año,IGV,Estado from Igv
GO
/****** Object:  StoredProcedure [dbo].[ListIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListIngreso]
@f1 Datetime,
@f2 Datetime
As Begin
	Select 
	I.IdIngreso,
	I.Fecha,
	I.IdAlmacen,
	A.Nombre Almacen,
	A.Serie,
	I.Numero,
	I.IdUsuario,
	U.NomUsuario Usuario,
	I.IdProveedor,
	P.RazonSocial Proveedor,
	P.Numero NumProveedor,
	P.NomDocumento DocProveedor,
	I.IdComprobante,
	C.Simbolo SimboloIngreso,
	I.IdCompProveedor,
	CP.Simbolo SimboloProveedor,
	CP.NomComprobante CompProveedor,
	I.SerieProveedor,
	I.NumCompProveedor,
	I.FechaProveedor,
	I.IdTransportista,
	T.RazonSocial Transportista,
	T.Numero NumTransportista,
	T.IdDocumento IdDocTransportista,
	T.NomDocumento DocTransportista,
	I.IdCompTransportista,
	CT.Simbolo SimboloTransportista,
	CT.NomComprobante CompTransportista,
	I.SerieTransportista,
	I.NumCompTransportista,
	I.Estado
	from Ingreso I
	inner join Almacen A on A.IdAlmacen=I.IdAlmacen
	inner join Usuario U on U.IdUsuario=I.IdUsuario
	inner join View_Proveedor P on P.IdProveedor=I.IdProveedor
	inner join Comprobante C on C.IdComprobante=I.IdComprobante
	inner join Comprobante CP on CP.IdComprobante=I.IdCompProveedor
	inner join View_Proveedor T on T.IdProveedor=I.IdTransportista
	inner join Comprobante CT on C.IdComprobante=I.IdCompTransportista
	where I.Fecha between @f1 and @f2
End
GO
/****** Object:  StoredProcedure [dbo].[ListMedioPago]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListMedioPago]
	As Begin
		Select IdMedioPago,Descripcion,Codigo,Efectivo,Estado from MedioPago
	End
GO
/****** Object:  StoredProcedure [dbo].[ListMoneda]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListMoneda]
as
 Select IdMoneda,Divisa,Simbolo,Abrev,Nacional,Estado from Moneda
GO
/****** Object:  StoredProcedure [dbo].[ListOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListOCompra]
@F1 datetime,
@F2 Datetime
as
	begin
		Select 
		OCompra.IdOCompra
		,OCompra.Fecha
		,OCompra.Numero
		,Proveedor.IdProveedor
		,Proveedor.RazonSocial Proveedor
		,Documento.IdDocumento
		,Documento.NomDocumento Documento
		,Proveedor.Numero NumDocumento
		,Usuario.IdUsuario
		,Usuario.NomUsuario Usuario
		,Comprobante.IdComprobante
		,Comprobante.NomComprobante Comprobante
		,Moneda.IdMoneda
		,Moneda.Abrev
		,OCompra.TipoCambio
		,OCompra.Estado
		,TipoVenta.IdTipoVenta
		,TipoVenta.Credito
		,TipoVenta.Tipo
		,OCompra.Plazo
		,OCompra.Igv
		from OCompra
		inner join Proveedor on Proveedor.IdProveedor=OCompra.IdProveedor
		inner join Documento on Documento.IdDocumento=Proveedor.IdDocumento
		inner join Ubigeo on Ubigeo.IdUbigeo=Proveedor.IdUbigeo
		inner join Usuario on Usuario.IdUsuario=OCompra.IdUsuario
		inner join Comprobante on Comprobante.IdComprobante=OCompra.IdComprobante
		inner join Moneda on Moneda.IdMoneda=OCompra.IdMoneda
		inner join TipoVenta on TipoVenta.IdTipoVenta=OCompra.IdTipoVenta
		where OCompra.Fecha between DATEADD(day,-1,@F1)and @F2
	end
GO
/****** Object:  StoredProcedure [dbo].[ListProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListProforma]
@FechaInc date,
@FechaEnd date
as begin
	Select 
	IdProforma
	,Numero
	,Fecha
	,Estado
	,ENUSO
	,IdAlmacen
	,SerieA
	,Nombre Almacen
	,IdCliente
	,RazSocial Cliente
	,Directo
	,IdDocumento
	,NomDocumento Documento--(DNI,RUC,)
	,Ruc --Si el tipo de documento es RUC
	,NumDocumento
	,IdUsuario
	,NomUsuario Usuario
	,IdComprobante 
	,NomComprobante Comprobante
	,Codigo --Codigo sunat
	,Declarable
	,Venta
	,Ingreso
	,Simbolo --Para generar el formato serie
	,IdTienda
	,NomTienda Tienda
	,SerieT --Serie Tienda
	,IdTipoVenta
	,Tipo --Tipo de Venta
	,Igv
	,Concat(Direccion,' - ',Distrito,' - ',Provincia,' - ',Departamento) Direccion
	,Plazo
	,Credito
	 from View_Proforma where Fecha between @FechaInc and @FechaEnd
end
GO
/****** Object:  StoredProcedure [dbo].[ListTienda]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListTienda]
as
	begin
		Select * from Tienda
	end
GO
/****** Object:  StoredProcedure [dbo].[ListTiendaUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListTiendaUsuario]
@IdTienda int
as
	begin
		Select 
		IdTiendaUsuario
		,Tienda.IdTienda
		,Tienda.NomTienda
		,Tienda.Serie
		,Usuario.IdUsuario
		,Usuario.NomUsuario
		,TiendaUsuario.Estado 
		from TiendaUsuario
		inner join Usuario on Usuario.IdUsuario=TiendaUsuario.IdUsuario
		inner join Tienda on Tienda.IdTienda=TiendaUsuario.IdTienda
		where Tienda.IdTienda=@IdTienda and Tienda.Estado=1
	end
GO
/****** Object:  StoredProcedure [dbo].[ListTipoVenta]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListTipoVenta]
as
 Select IdTipoVenta,Tipo,Estado,Credito from TipoVenta
GO
/****** Object:  StoredProcedure [dbo].[ListTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListTransferencia]
@FInicio datetime,
@FFin datetime
As Begin
	select 
	T.IdTransferencia
	,T.Fecha
	,T.Numero
	,C.IdComprobante
	,C.Simbolo
	,A1.IdAlmacen IdAlmacen1
	,A1.Nombre Nombre1
	,A1.Serie Serie
	,A1.Direccion Direccion1
	,A2.IdAlmacen IdAlmacen2
	,A2.Nombre Nombre2
	,A2.Direccion Direccion2
	,U1.IdUbicacion IdUbicacion1
	,U1.NomUbicacion Ubicacion1
	,U2.IdUbicacion IdUbicacion2
	,U2.NomUbicacion Ubicacion2
	,U.IdUsuario
	,U.NomUsuario Usuario
	,E.IdEmpleado
	,E.NumDocumento
	,E.Nombres 
	,E.Apellidos 
	from Transferencia T
	inner join Comprobante C on C.IdComprobante=T.IdComprobante
	Inner join Almacen A1 on A1.IdAlmacen=T.IdAlmacen1
	Inner join Almacen A2 on A2.IdAlmacen=T.IdAlmacen2
	inner join Ubicacion U1 on U1.IdUbicacion=T.IdUbicacion1
	inner join Ubicacion U2 on U2.IdUbicacion=T.IdUbicacion2
	inner join Usuario U on U.IdUsuario=T.IdUsuario
	inner join Empleado E on E.IdEmpleado=T.IdEmpleado
	where T.Fecha between @FInicio and @FInicio 
	and T.Estado=1 --Entregas vigentes y no anuladas
End
GO
/****** Object:  StoredProcedure [dbo].[ListVentas]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListVentas]
@FechaInicio varchar(13),
@FechaFin varchar(13)
as
select 
V.IdVentas
,V.Numero
,V.FEmision
,P.Plazo
,P.IdProforma
,P.RazSocial
,P.NomDocumento
,P.NumDocumento
,P.NomUsuario
,P.NomComprobante
,P.Codigo
,P.Igv
,P.SerieT
,P.Tipo
 from Ventas V
inner join View_Proforma P on P.IdProforma=V.IdProforma
where V.FEmision between @FechaInicio and @FechaFin
GO
/****** Object:  StoredProcedure [dbo].[RegistrarBanco]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarBanco]
@Nombre varchar(300),
@Codigo Int,
@Efectivo bit,
@Mensaje varchar(100) out
As Begin
	Begin try
		if not Exists(Select Codigo from Banco)
			if not exists (Select Nombre From Banco)
				begin
					insert into Banco values(@Nombre,@Codigo,1,@Efectivo)
					set @Mensaje='1'
				end
			else
				set @Mensaje='No se puede repitir el nombre del banco'
		else
			set @Mensaje='Este codigo de sunat para este banco ya existe'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCobranza]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarCobranza]
@IdVentas int,
@IdBanco int,
@Efectivo bit,
@IdMedioPago int,
@IdUsuario int,
@Fecha DateTime,
@Importe Decimal(11,4),
@NumOperacion int,
@FOperacion Datetime,
@Mensaje varchar(100) out
As Begin
	Begin try
		if not Exists(Select NumOperacion from Cobranza where NumOperacion = @NumOperacion and IdBanco = @IdBanco and @Efectivo=0)
			begin
				insert into Cobranza values(@IdVentas,@IdBanco,@IdMedioPago,@IdUsuario,@Fecha,@Importe,@NumOperacion,@FOperacion,1)
				set @Mensaje='1'
			end
		else
			set @Mensaje='Este Numero de op Ya existe para este banco'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarComprobante]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarComprobante]
@Codigo int,
@NomComprobante Varchar(20),
@Tipo varchar(5),
@Declarable bit,
@Venta bit,
@Ingreso bit,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@NomComprobante<>null or @NomComprobante<>'')
			if not exists(select * from Comprobante where NomComprobante=@NomComprobante)
				if not exists(select * from Comprobante where Codigo=@Codigo)
					begin
					Insert into Comprobante Values(@NomComprobante,1,@Tipo,@Codigo,@Declarable,@Venta,@Ingreso)
					Set @Mensaje='1'
					end
				else
					Set @Mensaje='Este Comprobante ya existe'
			else
				Set @Mensaje='Este Comprobante ya existe'
		else
			Set @Mensaje='No ingreso nombre'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarConsumo]
@Fecha Datetime,
@IdAlmacen int,
@Numero int,
@IdUsuario int,
@IdEmpleado int,
@IdComprobante int,
@Mensaje varchar(100) Out,
@IdConsumo int Out
As Begin
	begin try
		if(not exists(select IdConsumo from Consumo where IdAlmacen = @IdAlmacen and Numero = @Numero))
				begin
					Insert into Consumo Values(
					@Fecha,
					@IdAlmacen,
					@Numero,
					@IdUsuario,
					@IdEmpleado,
					@IdComprobante,
					1)
					set @IdConsumo=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Consumo ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarDetalleEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarDetalleEntrega]
@IdEntrega int,
@IdDetalleEntrega int,
@Cantidad decimal(11,4),
@Mensaje Varchar(100) Out
As Begin
	begin try
		if(exists(select IdEntrega from Entrega where IdEntrega=@IdEntrega))
				begin
					Insert into DetalleEntrega Values(@IdEntrega,@IdDetalleEntrega,@Cantidad,1)
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta entrega no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarDetalleProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarDetalleProforma]
@IdProforma int,
@IdProducto int,
@IdContenido int,
@Cantidad decimal(11,4),
@PUnitario decimal(11,4),
@Descuento decimal(11,4),
@Mensaje varchar(100) out
As begin
	begin try
		Insert into DetalleProforma Values(@IdProforma,@IdProducto,@IdContenido,@Cantidad,@PUnitario,@Descuento,1)
		Set @IdProforma=SCOPE_IDENTITY();
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarDetalleTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[RegistrarDetalleTransferencia]
@IdTransferencia int,
@IdProducto int,
@Cantidad decimal(11,4),
@IdContenido int,
@Mensaje Varchar(100) Out
As Begin
	begin try
		if(exists(select IdTransferencia from Transferencia where IdTransferencia=@IdTransferencia))
			begin
				Insert into DetalleTransferencia Values(@IdTransferencia,@IdProducto,@Cantidad,@IdContenido)
				Set @Mensaje='1'
			end
		else
			set @Mensaje='No existe transferencia'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarEntrega]
@IdVentas int,
@FechaE datetime,
@IdUsuario int,
@NumeroE int,
@IdAlmacen int,
@IdComprobante int,
@Mensaje Varchar(100) Out,
@IdEntrega int Out
As Begin
	begin try
		if(exists(select IdVentas from Ventas where IdVentas=@IdVentas))
				begin
					Insert into Entrega Values(@FechaE,@IdVentas,@IdUsuario,1,@NumeroE,@IdAlmacen,@IdComprobante)
					set @IdEntrega=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta Venta no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarIgv]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarIgv]
@Año Varchar(50),
@IGV Decimal(6,4),
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IGV >0 and not exists(select IdIgv from Igv where IGV=@IGV))
			Begin
				if(exists(select * from Igv where Estado=1))
					Update Igv set Estado=0;

				Insert into Igv Values(@Año,@IGV,1)
				Set @Mensaje='1'
			end
		else
			Set @Mensaje='Ingrese un valor distinto o valido'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarIngreso]
@Fecha Datetime,
@IdAlmacen int,
@Numero int,
@IdUsuario int,
@IdProveedor int,
@IdComprobante int,
@IdCompProveedor int,
@SerieProveedor int,
@NumCompProveedor int,
@FechaProveedor datetime,
@IdTransportista int,
@IdCompTransportista int,
@SerieTransportista int,
@NumCompTransportista int,
@IdIngreso int Out,
@Mensaje varchar(100) Out
As Begin
	begin try
		if(not exists(select IdIngreso from Ingreso where IdAlmacen = @IdAlmacen and Numero = @Numero))
				begin
					Insert into Ingreso Values(
					@Fecha,
					@IdAlmacen,
					@Numero,
					@IdUsuario,
					@IdProveedor,
					@IdComprobante,
					@IdCompProveedor,
					@SerieProveedor,
					@NumCompProveedor,
					@FechaProveedor,
					@IdTransportista,
					@IdCompTransportista,
					@SerieTransportista,
					@NumCompTransportista,1)
					set @IdIngreso=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Ingreso ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarMedioPago]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarMedioPago]
@Descripcion varchar(300),
@Codigo Int,
@Efectivo bit,
@Mensaje varchar(100) out
As Begin
	Begin try
		if not Exists(Select Codigo from MedioPago where Codigo=@Codigo)
			if not exists (Select Descripcion From MedioPago where Descripcion=@Descripcion)
				begin
					insert into MedioPago values(@Descripcion,@Codigo,@Efectivo,1)
					set @Mensaje='1'
				end
			else
				set @Mensaje='Este medio de pago ya existe'
		else
			set @Mensaje='Este codigo de sunat para este medio de pago ya existe'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarMoneda]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarMoneda]
@Divisa Varchar(30),
@Simbolo varchar(3),
@Abrev varchar(3),
@Nacional bit,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(not exists(select Divisa from Moneda where Abrev=@Abrev))
			Begin
				Insert into Moneda Values(@Divisa,@Simbolo,@Abrev,1,@Nacional)
				Set @Mensaje='1'
			end
		else
			Set @Mensaje='Este moneda ya se ingresó'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarOCompra]
@Fecha datetime,
@Numero int,
@IdProveedor int,
@IdUsuario int,
@IdComprobante int,
@IdMoneda int,
@TipoCambio decimal(11,4),
@IdTipoVenta int,
@Plazo int,
@Igv decimal(4,2),
@Mensaje Varchar(100) Out,
@IdOCompra int Out
As Begin
	begin try
		if(exists(select IdProveedor from Proveedor where IdProveedor=@IdProveedor))
				begin
					Insert into OCompra Values(@Fecha,@Numero,@IdProveedor,@IdUsuario,@IdComprobante,@IdMoneda,@TipoCambio,1,@IdTipoVenta,@Plazo,@Igv)
					set @IdOCompra=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta Venta no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarProforma]
@IdCliente int,
@Numero int,
@Fecha datetime,
@IdComprobante int,
@Igv decimal(4,2),
@IdTienda int,
@IdUsuario int,
@IdTipoVenta int,
@IdAlmacen int,
@Plazo int,
@Directo varchar(100),
@Mensaje varchar(100) out,
@IdProforma int out
As begin
	begin try
		Insert into Proforma Values(@IdCliente,@Fecha,@IdComprobante,@Igv,@IdTienda,@IdUsuario,@IdTipoVenta,@IdAlmacen,0,0,@Plazo,@Directo,@Numero)
		Set @IdProforma=SCOPE_IDENTITY();
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarTienda]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarTienda]
@NomTienda Varchar(50),
@Serie Varchar(3),
@Mensaje Varchar(100)  Out,
@IdTienda int Out
As Begin
	begin try
	if(Not exists(select Serie from Tienda where NomTienda=@NomTienda))
		if(Not exists(select Serie from Tienda where Serie=@Serie))
				begin
					Insert into Tienda Values(@NomTienda,@Serie,1)
					set @IdTienda=SCOPE_IDENTITY();
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este serie ya esixte'
	else
			set @Mensaje='Este nombre de tienda ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarTiendaUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarTiendaUsuario]
@IdUsuario int,
@IdTienda int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select * from TiendaUsuario where IdUsuario=@IdUsuario and IdTienda=@IdTienda))
				begin
					Insert into TiendaUsuario Values(@IdUsuario,@IdTienda,1)
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Rol para es Usuario ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarTipoVenta]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[RegistrarTipoVenta]
@Tipo Varchar(10),
@Credito bit,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@Tipo<>null or @Tipo<>'')
			if not exists(select * from TipoVenta where Tipo=@Tipo)
				begin
					Insert into TipoVenta Values(@Tipo,1,@Credito)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Tipo de Venta ya existe'
		else
			Set @Mensaje='No ingreso nombre'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarTransferencia]
@Fecha datetime,
@Numero int,
@IdComprobante int,
@IdAlmacen1 int,
@IdAlmacen2 int,
@IdUbicacion1 int,
@IdUbicacion2 int,
@IdUsuario int,
@IdEmpleado int,
@Mensaje Varchar(100) Out,
@IdTransferencia int Out
As Begin
	begin try
		if(exists(select IdAlmacen from Almacen where IdAlmacen=@IdAlmacen1))
			if(not exists(select IdTransferencia from Transferencia where Numero=@Numero and IdAlmacen1=@IdAlmacen1))
				begin
					Insert into Transferencia Values(
					@Fecha
					,@Numero
					,@IdComprobante
					,@IdAlmacen1
					,@IdAlmacen2
					,@IdUbicacion1
					,@IdUbicacion2
					,@IdUsuario
					,@IdEmpleado
					,1)
					set @IdTransferencia=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Rebice, algo esta mal, en el correlativo de transferencia'
		else
			set @Mensaje='Esta Almacen no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUbicacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarUbicacion]
@NomUbicacion varchar(30),
@IdUbicacion int out,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		insert into Ubicacion values(@NomUbicacion,1)
		set @IdUbicacion=SCOPE_IDENTITY()
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO

/****** Object:  StoredProcedure [dbo].[RegistrarVentas]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RegistrarVentas]
@IdProforma int,
@FEmision datetime,
@Numero int,
@Cancelado bit,
@Mensaje Varchar(100) Out,
@IdVentas int Out
As Begin
	begin try
		if(Not exists(select IdVentas from Ventas where IdProforma=@IdProforma))
				begin
					Insert into Ventas Values(@IdProforma,@FEmision,@Numero,1,@Cancelado)
					set @IdVentas=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta proforma ya fue generada!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateBanco]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateBanco]
@IdBanco int,
@Nombre varchar(300),
@Codigo Int,
@Efectivo bit,
@Mensaje varchar(100) out
As Begin
	Begin try
		if not Exists(Select Codigo from Banco where IdBanco!=@IdBanco)
			if not exists (Select Nombre From Banco where IdBanco!=@IdBanco)
				begin
					UPdate Banco set Nombre=@Nombre, Codigo=@Codigo, Efectivo=@Efectivo where IdBanco=@IdBanco
					set @Mensaje='1'
				end
			else
				set @Mensaje='No se puede repitir el nombre del banco'
		else
			set @Mensaje='Este codigo de sunat para este banco ya existe'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateCobranza]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateCobranza]
@IdCobranza int,
@IdVenta int,
@IdBanco int,
@IdMedioPago int,
@IdUsuario int,
@Fecha DateTime,
@Importe Decimal(11,4),
@NumOperacion int,
@FOperacion Datetime,
@Mensaje varchar(100) out
As Begin
	Begin try
		if not Exists(Select NumOperacion from Cobranza where NumOperacion = @NumOperacion and IdBanco = @IdBanco and IdCobranza!=@IdCobranza)
			begin
				UPdate Cobranza set 
				IdBanco=@IdBanco,
				IdMedioPago=@IdMedioPago,
				IdUsuario=@IdUsuario,
				Importe=@Importe,
				NumOperacion=@NumOperacion,
				FOperacion=@FOperacion where IdCobranza=@IdCobranza
				set @Mensaje='1'
			end
		else
			set @Mensaje='Este numero de operacion ya existe para este Banco'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateComprobante]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateComprobante]
@IdComprobante int,
@Codigo int,
@NomComprobante Varchar(100),
@Simbolo varchar(5),
@Declarable bit,
@Venta bit,
@Ingreso bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NomComprobante from Comprobante where NomComprobante = @NomComprobante and IdComprobante!=@IdComprobante))
				begin
					update Comprobante set 
					NomComprobante=@NomComprobante,
					Simbolo=@Simbolo,
					Codigo=@Codigo,
					Declarable=@Declarable,
					Venta=@Venta,
					Ingreso=@Ingreso
					where IdComprobante=@IdComprobante
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Tipo de Venta ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateConsumo]
@IdConsumo int,
@Fecha Datetime,
@IdAlmacen int,
@IdUsuario int,
@IdEmpleado int,
@Mensaje varchar(100) Out
As Begin
	begin try
		if(exists(select IdConsumo from Consumo where IdConsumo = @IdConsumo))
				begin
					update Consumo 
					set
					Fecha = @Fecha,
					IdAlmacen = @IdAlmacen,
					IdUsuario = @IdUsuario,
					IdEmpleado = @IdEmpleado
					where IdConsumo = @IdConsumo
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este documento no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateDetalleConsumo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateDetalleConsumo]
@IdDetalleConsumo int,
@IdProducto int,
@IdUnidad int,
@Cantidad decimal(11,4),
@Mensaje varchar(100) out
As begin
	begin try
		update DetalleConsumo set 
		IdProducto=@IdProducto,
		IdUnidad=@IdUnidad,
		Cantidad=@Cantidad
		where IdDetalleConsumo=@IdDetalleConsumo
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateDetalleEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateDetalleEntrega]
@IdDetalleEntrega int,
@IdEntrega int,
@IdDetalleProforma int,
@Cantidad decimal(11,4),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Exists(select IdDetalleEntrega from DetalleEntrega where IdDetalleEntrega=@IdDetalleEntrega))
				begin
					update DetalleEntrega 
					set 
					IdEntrega=@IdEntrega,
					IdDetalleProforma=@IdDetalleProforma,
					Cantidad=@Cantidad
					where IdDetalleEntrega=@IdDetalleEntrega
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta fila no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateDetalleIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateDetalleIngreso]
@IdDetalleIngreso int,
@Cantidad decimal(11,4),
@Mensaje varchar(100) out
As begin
	begin try
		update DetalleIngreso set 
		Cantidad=@Cantidad
		where IdDetalleIngreso=@IdDetalleIngreso
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDetalleOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateDetalleOCompra]
@IdDetalleOCompra int,
@IdProducto int,
@IdUnidad int,
@Cantidad decimal(11,4),
@PCompra decimal(11,4),
@Mensaje varchar(100) out
As begin
	begin try
		update DetalleOCompra set 
		IdProducto=@IdProducto,
		IdUnidad=@IdUnidad,
		Cantidad=@Cantidad,
		PCompra=@PCompra
		where IdDetalleOCompra=@IdDetalleOCompra
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDetalleProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateDetalleProforma]
@IdDetalleProforma int,
@IdProforma int,
@IdProducto int,
@IdUnidad int,
@Cantidad decimal(11,4),
@PUnitario decimal(11,4),
@Descuento decimal(11,4),
@IdAlmacen int,
@Mensaje varchar(100) out
As begin
	begin try
		update DetalleProforma set 
		IdProforma= @IdProforma,
		IdProducto=@IdProducto,
		IdUnidad=@IdUnidad,
		Cantidad=@Cantidad,
		PUnitario=@PUnitario,
		Descuento=@Descuento,
		IdAlmacen=@IdAlmacen
		where IdDetalleProforma=@IdDetalleProforma
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDetalleTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateDetalleTransferencia]
@IdDetalleTransferencia int,
@IdProducto int,
@Cantidad decimal(11,4),
@IdUnidad int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Exists(select IdDetalleTransferencia from DetalleTransferencia where IdDetalleTransferencia=@IdDetalleTransferencia))
				begin
					update DetalleTransferencia 
					set 
					IdProducto=@IdProducto,
					Cantidad=@Cantidad,
					IdUnidad=@IdUnidad
					where IdDetalleTransferencia=@IdDetalleTransferencia
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta fila no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateEntrega]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateEntrega]
@IdEntrega int,
@Fecha datetime,
@IdVentas int,
@IdUsuario int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Exists(select IdEntrega from Entrega where IdEntrega=@IdEntrega))
				begin
					update Entrega 
					set 
					Fecha=@Fecha,
					IdVentas=@IdVentas,
					IdUsuario=@IdUsuario
					where IdEntrega=@IdEntrega
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta entrega no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateIgv]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateIgv]
@IdIgv int,
@Año int,
@IGV decimal(6,4),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select IdIgv from Igv where IGV = @IGV and IdIgv!=@IdIgv))
				begin
					update Igv set 
					Año=@Año,
					IGV=@IGV
					where IdIgv=@IdIgv
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este IGV ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateIngreso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateIngreso]
@IdIngreso int,
@IdUsuario int,
@IdCompProveedor int,
@SerieProveedor int,
@NumCompProveedor int,
@FechaProveedor datetime,
@IdTransportista int,
@IdCompTransportista int,
@SerieTransportista int,
@NumCompTransportista int,
@Mensaje varchar(100) Out
As Begin
	begin try
		if(exists(select IdIngreso from Ingreso where IdIngreso = @IdIngreso))
				begin
					Update Ingreso set
					IdUsuario = @IdUsuario,
					IdCompProveedor=@IdCompProveedor,
					SerieProveedor=@SerieProveedor,
					NumCompProveedor=@NumCompProveedor,
					FechaProveedor=@FechaProveedor,
					IdTransportista=@IdTransportista,
					IdCompTransportista=@IdCompTransportista,
					SerieTransportista=@SerieTransportista,
					NumCompTransportista=@NumCompTransportista
					where IdIngreso=@IdIngreso
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Ingreso no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateMedioPago]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateMedioPago]
@IdMedioPago int,
@Descripcion varchar(300),
@Codigo Int,
@Efectivo bit,
@Mensaje varchar(100) out
As Begin
	Begin try
		if not Exists(Select Codigo from MedioPago where Codigo=@Codigo and IdMedioPago!=@IdMedioPago)
			if not exists (Select Descripcion From MedioPago where Descripcion=@Descripcion and IdMedioPago!=@IdMedioPago)
				begin
					UPdate MedioPago set Descripcion=@Descripcion, Codigo=@Codigo,Efectivo=@Efectivo where IdMedioPago=@IdMedioPago
					set @Mensaje='1'
				end
			else
				set @Mensaje='Este medio de pago ya existe'
		else
			set @Mensaje='Este codigo de sunat para este Medio de pago ya existe'
	End try 
	Begin Catch
		Set @Mensaje=(select ERROR_MESSAGE())
	End Catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateMoneda]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateMoneda]
@IdMoneda int,
@Divisa Varchar(30),
@Simbolo Varchar(3),
@Abrev Varchar(3),
@Nacional bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if((@Abrev<>null or @Abrev<>'') and (@Divisa<>null or @Divisa<>''))
			if(not exists(select * from Moneda where Abrev=@Abrev and IdMoneda<>@IdMoneda))
				begin
					update Moneda set Divisa=@Divisa, Simbolo=@Simbolo, Abrev=@Abrev,Nacional=@Nacional where IdMoneda=@IdMoneda
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Moneda ya existe registrado'
		else
			Set @Mensaje='Ingrese codigo o nombre de la moneda'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[UpdateOCompra]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateOCompra]
@IdOCompra int,
@Fecha datetime,
@Numero int,
@IdProveedor int,
@IdUsuario int,
@IdComprobante int,
@IdMoneda int,
@TipoCambio decimal(11,4),
@IdTipoVenta int,
@Plazo int,
@Igv decimal(4,2),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Exists(select IdOCompra from OCompra where IdOCompra=@IdOCompra))
				begin
					update OCompra 
					set 
					Fecha=@Fecha,
					Numero=@Numero,
					IdProveedor=@IdProveedor,
					IdUsuario=@IdUsuario,
					IdComprobante=@IdComprobante,
					IdMoneda=@IdMoneda,
					TipoCambio=@TipoCambio,
					IdTipoVenta=@IdTipoVenta,
					Plazo=@Plazo,
					Igv=@Igv
					where IdOCompra=@IdOCompra
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta orden de compra no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateProforma]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateProforma]
@IdProforma int,
@IdCliente int,
@Fecha datetime,
@IdComprobante int,
@Igv decimal(4,2),
@IdTienda int,
@IdUsuario int,
@IdTipoVenta int,
@IdAlmacen int,
@Plazo int,
@Directo varchar(100),
@Mensaje varchar(100) out
As begin
	begin try
		update Proforma set 
		IdCliente= @IdCliente,
		Fecha=@Fecha,
		IdComprobante=@IdComprobante,
		Igv=@Igv,
		IdTienda=@IdTienda,
		IdUsuario=@IdUsuario,
		IdTipoVenta=@IdTipoVenta,
		IdAlmacen=@IdAlmacen,
		Plazo=@Plazo,
		Directo=@Directo
		where IdProforma=@IdProforma
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateTienda]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTienda]
@IdTienda int,
@NomTienda Varchar(50),
@Serie Varchar(3),
@Mensaje Varchar(100)  Out
As Begin
	begin try
	if(not exists(select NomTienda from Tienda where NomTienda = @NomTienda and IdTienda!=@IdTienda))
		if(not exists(select Serie from Tienda where Serie = @Serie and IdTienda!=@IdTienda))
				begin
					update Tienda set NomTienda=@NomTienda,Serie=@Serie where IdTienda=@IdTienda
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este serie ya existe'
	else
		set @Mensaje='Este nombre de tienda ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateTiendaUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateTiendaUsuario]
@IdTiendaUsuario int,
@IdTienda int,
@IdUsuario int,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdTienda>0)
			if(not exists(select * from TiendaUsuario where IdTienda=@IdTienda and IdUsuario=@IdUsuario))
				begin
					update TiendaUsuario set IdUsuario=@IdUsuario where IdTiendaUsuario=@IdTiendaUsuario
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Tienda para este Usuario ya existe'
		else
			Set @Mensaje='Ingrese una tienda valida'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[UpdateTipoVenta]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateTipoVenta]
@IdTipoVenta int,
@Tipo Varchar(100),
@Credito bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select Tipo from TipoVenta where Tipo = @Tipo and IdTipoVenta!=@IdTipoVenta))
				begin
					update TipoVenta set 
					Tipo=@Tipo,
					Credito=@Credito
					where IdTipoVenta=@IdTipoVenta
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Tipo de Venta ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateTransferencia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateTransferencia]
@IdTransferencia int,
@Fecha datetime,
@Numero int,
@IdComprobante int,
@IdAlmacen1 int,
@IdAlmacen2 int,
@IdUbicacion1 int,
@IdUbicacion2 int,
@IdUsuario int,
@IdEmpleado int,
@Mensaje Varchar(100) Out
As Begin
	begin try
		if(exists(select IdTransferencia from Transferencia where Numero=@Numero and IdTransferencia=@IdTransferencia))
			begin
				update Transferencia set 
				Fecha=@Fecha
				,Numero=@Numero
				,IdComprobante= @IdComprobante
				,IdAlmacen1=@IdAlmacen1
				,IdAlmacen2=@IdAlmacen2
				,IdUbicacion1=@IdUbicacion1
				,IdUbicacion2=@IdUbicacion2
				,IdUsuario=@IdUsuario
				,IdEmpleado=@IdEmpleado
				where IdTransferencia = IdTransferencia and Numero=@Numero
				Set @Mensaje='1'
			end
		else
			set @Mensaje='Rebice, algo esta mal, en el correlativo de transferencia'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateVentas]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateVentas]
@IdVentas int,
@IdProforma int,
@FEmision datetime,
@Numero int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select IdVentas from Ventas where IdVentas=@IdVentas and  IdProforma!=@IdProforma))
				begin
					update Ventas set IdProforma=@IdProforma,FEmision=@FEmision,
					Numero=@Numero
					where IdVentas=@IdVentas
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta proforma ya fue generada!!!'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionConsumo]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[NumeracionConsumo]
( @IdAlmacen int --Serie
)
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select IdAlmacen from Consumo where IdAlmacen=@IdAlmacen)
		set @Numero = (select max(Numero) from Consumo where IdAlmacen=@IdAlmacen)
	return @Numero+1
end

GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionEntrega]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[NumeracionEntrega]
( @IdAlmacen int --Serie
)
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select IdAlmacen from Entrega where IdAlmacen=@IdAlmacen)
		set @Numero = (select max(Numero) from Entrega where IdAlmacen=@IdAlmacen)
	return @Numero+1
end

GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionIngreso]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[NumeracionIngreso]
( @IdAlmacen int --Serie
)
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select IdAlmacen from Ingreso where IdAlmacen=@IdAlmacen)
		set @Numero = (select max(Numero) from Ingreso where IdAlmacen=@IdAlmacen)
	return @Numero+1
end

GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionOCompra]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[NumeracionOCompra]()
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select IdOCompra from OCompra)
		set @Numero = (select max(Numero) from OCompra)
	return @Numero+1
end

GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionProforma]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[NumeracionProforma]
( @IdTienda int --Serie
)
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select IdTienda from Proforma where IdTienda=@IdTienda)
		set @Numero = (select max(Numero) from Proforma where IdTienda=@IdTienda)
	return @Numero+1
end

GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionTransferencia]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[NumeracionTransferencia]
( @IdAlmacen int --Serie
)
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select IdAlmacen1 from Transferencia where IdAlmacen1=@IdAlmacen)
		set @Numero = (select max(Numero) from Transferencia where IdAlmacen1=@IdAlmacen)
	return @Numero+1
end

GO
/****** Object:  UserDefinedFunction [dbo].[NumeracionVenta]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[NumeracionVenta]
( @IdTienda int, --Serie
@IdComprobante int
)
returns int
as
begin
	declare @Numero int
	set @Numero=0
	if exists (select Ventas.Numero from Ventas
inner join View_Proforma P on P.IdProforma=Ventas.IdProforma
where P.IdTienda=@IdTienda and p.IdComprobante=@IdComprobante)
		set @Numero = (select max(Ventas.Numero) from Ventas
inner join View_Proforma P on P.IdProforma=Ventas.IdProforma
where P.IdTienda=@IdTienda and p.IdComprobante=@IdComprobante)
	return @Numero+1
end

GO
