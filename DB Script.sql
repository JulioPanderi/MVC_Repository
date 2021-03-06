/****** Object:  Table [dbo].[Clientes]    Script Date: 25/01/2021 10:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Figuras]    Script Date: 25/01/2021 10:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Figuras](
	[IdFigura] [int] IDENTITY(5,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Costo] [money] NOT NULL,
 CONSTRAINT [PK_Figuras] PRIMARY KEY CLUSTERED 
(
	[IdFigura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesPedido]    Script Date: 25/01/2021 10:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesPedido](
	[IdPedido] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdFigura] [int] NOT NULL,
	[Combinacion] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Total] [int] NOT NULL,
 CONSTRAINT [PK_OrdenesPedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProduccionesDiaria]    Script Date: 25/01/2021 10:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProduccionesDiaria](
	[IdProduccion] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_ProduccionDiaria] PRIMARY KEY CLUSTERED 
(
	[IdProduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProduccionesDiariaDetalle]    Script Date: 25/01/2021 10:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProduccionesDiariaDetalle](
	[IdProduccionDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProduccion] [int] NOT NULL,
	[IdFigura] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Costo] [int] NOT NULL,
 CONSTRAINT [PK_ProduccionDiariaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdProduccionDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrdenesPedido]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPedido_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[OrdenesPedido] CHECK CONSTRAINT [FK_OrdenesPedido_Clientes]
GO
ALTER TABLE [dbo].[OrdenesPedido]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPedido_Figuras] FOREIGN KEY([IdFigura])
REFERENCES [dbo].[Figuras] ([IdFigura])
GO
ALTER TABLE [dbo].[OrdenesPedido] CHECK CONSTRAINT [FK_OrdenesPedido_Figuras]
GO
ALTER TABLE [dbo].[ProduccionesDiariaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionDiariaDetalle_Figuras] FOREIGN KEY([IdFigura])
REFERENCES [dbo].[Figuras] ([IdFigura])
GO
ALTER TABLE [dbo].[ProduccionesDiariaDetalle] CHECK CONSTRAINT [FK_ProduccionDiariaDetalle_Figuras]
GO
ALTER TABLE [dbo].[ProduccionesDiariaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionDiariaDetalle_ProduccionDiaria] FOREIGN KEY([IdProduccion])
REFERENCES [dbo].[ProduccionesDiaria] ([IdProduccion])
GO
ALTER TABLE [dbo].[ProduccionesDiariaDetalle] CHECK CONSTRAINT [FK_ProduccionDiariaDetalle_ProduccionDiaria]
GO
