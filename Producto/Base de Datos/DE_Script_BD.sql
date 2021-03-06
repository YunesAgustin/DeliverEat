USE [DeliverEat]
GO
/****** Object:  Table [dbo].[DetallesPedido]    Script Date: 09/29/2018 21:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetallesPedido](
	[idDetallePedido] [int] IDENTITY(1,1) NOT NULL,
	[descripcionProducto] [varchar](100) NOT NULL,
	[imagenProducto] [varchar](50) NULL,
	[monto] [money] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[idDetallePedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TiposPago]    Script Date: 09/29/2018 21:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposPago](
	[idTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposPago] PRIMARY KEY CLUSTERED 
(
	[idTipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TiposPago] ON
INSERT [dbo].[TiposPago] ([idTipoPago], [descripcion]) VALUES (1, N'Efectivo')
INSERT [dbo].[TiposPago] ([idTipoPago], [descripcion]) VALUES (2, N'Tarjeta VISA')
SET IDENTITY_INSERT [dbo].[TiposPago] OFF
/****** Object:  Table [dbo].[TiposDocumento]    Script Date: 09/29/2018 21:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposDocumento](
	[idTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDocumento] PRIMARY KEY CLUSTERED 
(
	[idTipoDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDocumento] ON
INSERT [dbo].[TiposDocumento] ([idTipoDocumento], [nombre]) VALUES (1, N'DNI')
SET IDENTITY_INSERT [dbo].[TiposDocumento] OFF
/****** Object:  Table [dbo].[Paises]    Script Date: 09/29/2018 21:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paises](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON
INSERT [dbo].[Paises] ([idPais], [nombre]) VALUES (1, N'Argentina')
SET IDENTITY_INSERT [dbo].[Paises] OFF
/****** Object:  Table [dbo].[Pagos]    Script Date: 09/29/2018 21:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pagos](
	[idPago] [int] IDENTITY(1,1) NOT NULL,
	[domicilioFacturacion] [varchar](100) NULL,
	[telefono] [varchar](50) NULL,
	[total] [money] NOT NULL,
	[ciudad] [varchar](50) NULL,
	[idPais] [int] NULL,
	[idTipoPago] [int] NOT NULL,
	[titularTarjeta] [varchar](50) NULL,
	[documento] [bigint] NULL,
	[idTipoDocumento] [int] NULL,
	[vuelto] [money] NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 09/29/2018 21:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pedidos](
	[idPedido] [int] IDENTITY(1,1) NOT NULL,
	[idDetallePedido] [int] NOT NULL,
	[calleComercio] [varchar](50) NULL,
	[nroCalleComercio] [int] NULL,
	[calleCliente] [varchar](50) NOT NULL,
	[nroCalleCliente] [int] NOT NULL,
	[pisoCliente] [int] NULL,
	[deptoCliente] [varchar](50) NULL,
	[loAntesPosible] [bit] NOT NULL,
	[fechaHoraEntrega] [datetime] NULL,
	[idPago] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Pedidos_loAntesPosible]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_loAntesPosible]  DEFAULT ((1)) FOR [loAntesPosible]
GO
/****** Object:  ForeignKey [FK_Pagos_Paises]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Paises] FOREIGN KEY([idPais])
REFERENCES [dbo].[Paises] ([idPais])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_Paises]
GO
/****** Object:  ForeignKey [FK_Pagos_TiposDocumento]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_TiposDocumento] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TiposDocumento] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_TiposDocumento]
GO
/****** Object:  ForeignKey [FK_Pagos_TiposPago]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_TiposPago] FOREIGN KEY([idTipoPago])
REFERENCES [dbo].[TiposPago] ([idTipoPago])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_TiposPago]
GO
/****** Object:  ForeignKey [FK_Pedidos_DetallesPedido]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_DetallesPedido] FOREIGN KEY([idDetallePedido])
REFERENCES [dbo].[DetallesPedido] ([idDetallePedido])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_DetallesPedido]
GO
/****** Object:  ForeignKey [FK_Pedidos_Pagos]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Pagos] FOREIGN KEY([idPago])
REFERENCES [dbo].[Pagos] ([idPago])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Pagos]
GO
/****** Object:  ForeignKey [FK_Pedidos_Productos]    Script Date: 09/29/2018 21:50:19 ******/
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Productos] FOREIGN KEY([idDetallePedido])
REFERENCES [dbo].[DetallesPedido] ([idDetallePedido])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Productos]
GO
