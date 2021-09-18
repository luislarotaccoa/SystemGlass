/****** Object:  Table [dbo].[CategoriaUnidad]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaUnidad](
	[IdCategoriaUnidad] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[IdUnidad] [int] NULL,
	[IdUnidadMinima] [int] NULL,--Nuevo
PRIMARY KEY CLUSTERED 
(
	[IdCategoriaUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Familia]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[IdFamilia] [int] IDENTITY(1,1) NOT NULL,
	[NomFamilia] [varchar](300) NULL,
	[IdCategoria] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Familia]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
/****** Object:  Table [dbo].[Color]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[NomColor] [varchar](20) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descrip1]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descrip1](
	[IdDescrip1] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[IdFamilia] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDescrip1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Descrip1]  WITH CHECK ADD FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
/****** Object:  Table [dbo].[Descrip2]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descrip2](
	[IdDescrip2] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDescrip2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad](
	[IdUnidad] [int] IDENTITY(1,1) NOT NULL,
	[AUnidad] [varchar](50) NULL,
	[Medible] [bit] NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Producto]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Serie2] [varchar](20) NOT NULL,
	[Modelo] [varchar](20) NOT NULL,
	[IdDescrip1] [int] NULL,
	[IdDescrip2] [int] NULL,
	[IdUnidad] [int] NULL,
	[IdColor] [int] NULL,
	[Peso] [decimal](5, 2) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoUnidad]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoUnidad](
	[IdProductoUnidad] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[IdUnidad] [int] NULL,
	[DescContado] [decimal](11, 4) NULL,
	[DescCredito] [decimal](11, 4) NULL,
	[PContado] [decimal](11, 4) NULL,
	[PCredito] [decimal](11, 4) NULL,
	[UnidadBase] [bit] NULL,
	[Factor] [decimal](11, 4) NULL,--Nuevo
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProductoUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdDescrip1])
REFERENCES [dbo].[Descrip1] ([IdDescrip1])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdDescrip2])
REFERENCES [dbo].[Descrip2] ([IdDescrip2])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdColor])
REFERENCES [dbo].[Color] ([IdColor])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  FOREIGN KEY([IdUnidad])
REFERENCES [dbo].[Unidad] ([IdUnidad])
GO
ALTER TABLE [dbo].[CategoriaUnidad]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[CategoriaUnidad]  WITH CHECK ADD FOREIGN KEY([IdUnidad])
REFERENCES [dbo].[Unidad] ([IdUnidad])
GO
ALTER TABLE [dbo].[CategoriaUnidad]  WITH CHECK ADD FOREIGN KEY([IdUnidadMinima])
REFERENCES [dbo].[Unidad] ([IdUnidad])
GO
ALTER TABLE [dbo].[ProductoUnidad]  WITH NOCHECK ADD FOREIGN KEY([IdUnidad])
REFERENCES [dbo].[Unidad] ([IdUnidad])
GO
ALTER TABLE [dbo].[ProductoUnidad]  WITH NOCHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
/****** Object:  View [dbo].[View_Producto]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Producto]
AS
SELECT        dbo.Producto.IdProducto, dbo.Producto.Serie2, dbo.Producto.Modelo, dbo.Producto.Estado, dbo.Producto.Peso, dbo.Producto.IdUnidad, dbo.Color.IdColor, dbo.Color.NomColor, dbo.Descrip1.IdDescrip1, 
                         dbo.Descrip1.Descripcion AS Descripcion1, dbo.Descrip2.IdDescrip2, dbo.Descrip2.Descripcion AS Descripcion2, dbo.Familia.IdFamilia, dbo.Familia.NomFamilia, dbo.Categoria.IdCategoria, dbo.Categoria.NomCategoria, 
                         dbo.Categoria.Bilateral
FROM            dbo.Producto INNER JOIN
                         dbo.Color ON dbo.Color.IdColor = dbo.Producto.IdColor AND dbo.Color.Estado = 1 INNER JOIN
                         dbo.Descrip1 ON dbo.Descrip1.IdDescrip1 = dbo.Producto.IdDescrip1 AND dbo.Descrip1.Estado = 1 INNER JOIN
                         dbo.Descrip2 ON dbo.Descrip2.IdDescrip2 = dbo.Producto.IdDescrip2 AND dbo.Descrip2.Estado = 1 INNER JOIN
                         dbo.Familia ON dbo.Familia.IdFamilia = dbo.Descrip1.IdFamilia AND dbo.Familia.Estado = 1 INNER JOIN
                         dbo.Categoria ON dbo.Categoria.IdCategoria = dbo.Familia.IdCategoria AND dbo.Categoria.Estado = 1
GO
/****** Object:  Index [NonClusteredIndex-20201012-221438]    Script Date: 29/04/2021 20:48:47 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20201012-221438] ON [dbo].[Producto]
(
	[IdDescrip1] ASC
)
INCLUDE ( 	[IdProducto],
	[Serie2],
	[Modelo],
	[IdColor],
	[Estado],
	[Peso],
	[IdUnidad]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[CategoriaColor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaColor](
	[IdCategoria] [int] not NULL,
	[IdColor] [int] not NULL,
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategoriaColor]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[CategoriaColor]  WITH CHECK ADD FOREIGN KEY([IdColor])
REFERENCES [dbo].[Color] ([IdColor])
GO

/****** Object:  Table [dbo].[CategoriaDescrip2]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaDescrip2](
	[IdCategoria] [int] not NULL,
	[IdDescrip2] [int] not NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategoriaDescrip2]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[CategoriaDescrip2]  WITH CHECK ADD FOREIGN KEY([IdDescrip2])
REFERENCES [dbo].[Descrip2] ([IdDescrip2])
GO
/****** Object:  StoredProcedure [dbo].[EliminarColor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarColor]
@IdColor int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Color Set Estado=@Estado
		Where IdColor=@IdColor
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarDescrip1]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarDescrip1]
@IdDescrip1 int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Descrip1 Set Estado=@Estado
		Where IdDescrip1=@IdDescrip1
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarDescrip2]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarDescrip2]
@IdDescrip2 int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Descrip2 Set Estado=@Estado
		Where IdDescrip2=@IdDescrip2
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarFamilia]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarFamilia]
@IdFamilia int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Familia Set Estado=@Estado
		Where IdFamilia=@IdFamilia
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[EliminarProducto]
@IdProducto int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Producto Set Estado=@Estado
		Where IdProducto=@IdProducto
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarProductoUnidad]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarProductoUnidad]
@IdProductoUnidad int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update ProductoUnidad Set Estado=@Estado
		Where IdProducto=@IdProductoUnidad
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarUnidad]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarUnidad]
@IdUnidad int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Unidad Set Estado=@Estado
		Where IdUnidad=@IdUnidad
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaProducto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[ConsultaProducto]
@IdCategoria int, --serie1
@Serie2 varchar(3), --serie2
@IdColor int --serie3
as Begin
 Select IdProducto
 ,P.IdDescrip1
 ,P.IdDescrip2
 ,P.IdColor
 ,Unidad.IdUnidad --Unidad minima
 ,Unidad.AUnidad
 ,Unidad.Medible
 ,P.IdFamilia
 ,P.NomFamilia Familia
 ,P.IdCategoria
 ,P.NomCategoria Categoria
 ,P.Bilateral
 ,P.Descripcion1
 ,P.Descripcion2
 ,P.Serie2
 ,P.Modelo
 ,P.Peso
 ,P.NomColor Color
 ,P.Estado 
 from View_Producto P
 inner join Unidad on Unidad.IdUnidad=P.IdUnidad
 where P.IdCategoria=@IdCategoria and  P.Serie2=@Serie2 and P.IdColor=@IdColor
end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaProductoModelo]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[ConsultaProductoModelo]
@Modelo varchar(20)
as Begin
 Select IdProducto
 ,P.IdDescrip1
 ,P.IdDescrip2
 ,P.IdColor
 ,Unidad.IdUnidad
 ,Unidad.AUnidad
 ,Unidad.Medible
 ,P.IdFamilia
 ,P.NomFamilia Familia
 ,P.IdCategoria
 ,P.NomCategoria Categoria
 ,P.Bilateral
 ,P.Descripcion1
 ,P.Descripcion2
 ,P.Serie2
 ,P.Modelo
 ,P.Peso
 ,P.NomColor Color
 ,P.Estado 
 from View_Producto P
 inner join Unidad on Unidad.IdUnidad=P.IdUnidad
 where Modelo=@Modelo
end
GO
/****** Object:  StoredProcedure [dbo].[ListCategoria]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListCategoria]
as
 Select * from Categoria
GO
/****** Object:  StoredProcedure [dbo].[ListCategoriaColor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListCategoriaColor]
@IdCategoria int
as
 Select 
 Categoria.IdCategoria
 ,Color.IdColor
 ,Categoria.NomCategoria
 ,Categoria.Bilateral
 ,Color.NomColor
 ,Color.Estado 
 from CategoriaColor
 inner join Color on Color.IdColor=CategoriaColor.IdColor
 inner join Categoria on Categoria.IdCategoria=CategoriaColor.IdCategoria
 where Color.Estado=1 and CategoriaColor.IdCategoria=@IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[ListCategoriaDescrip2]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListCategoriaDescrip2]
@IdCategoria int
as
	begin
		Select 
		Categoria.IdCategoria,
		Descrip2.IdDescrip2,
		Categoria.NomCategoria,
		Descrip2.Descripcion,
		Descrip2.Estado
		from CategoriaDescrip2
		inner join Categoria on Categoria.IdCategoria=CategoriaDescrip2.IdCategoria
		inner join Descrip2 on Descrip2.IdDescrip2=CategoriaDescrip2.IdDescrip2
		where Categoria.Estado=1 and Descrip2.Estado=1 and Categoria.IdCategoria=@IdCategoria
	end
GO
/****** Object:  StoredProcedure [dbo].[ListCategoriaUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListCategoriaUnidad]
@IdCategoria int
as begin
 Select 
 Categoria.IdCategoria
 ,Categoria.NomCategoria
 ,U.IdUnidad
 ,U.AUnidad
 ,U.Medible
 ,UM.IdUnidad
 ,UM.AUnidad
  from CategoriaUnidad CU
	 inner join Categoria on CU.IdCategoria=Categoria.IdCategoria and Categoria.Estado=1
	 inner join Unidad U on CU.IdUnidad=U.IdUnidad and U.Estado=1
	 inner join Unidad UM on CU.IdUnidad=UM.IdUnidad
	 where Categoria.IdCategoria=@IdCategoria
	 end
GO
/****** Object:  StoredProcedure [dbo].[ListColor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListColor]
as
 Select IdColor,NomColor,Estado from Color
GO
/****** Object:  StoredProcedure [dbo].[ListarFamilia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarFamilia]
@IdCategoria int
as
	begin
		Select 
		Familia.IdFamilia,
		Familia.NomFamilia,
		Categoria.IdCategoria,
		Categoria.NomCategoria,
		Familia.Estado
		from Familia
		INNER JOIN Categoria on Categoria.IdCategoria=Familia.IdCategoria
		where Categoria.IdCategoria=@IdCategoria and Familia.Estado=1
	end
GO
/****** Object:  StoredProcedure [dbo].[ListDescrip1]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarDescrip1]
@IdFamilia int
as
	begin
		Select 
		Descrip1.IdDescrip1,
		Descrip1.Descripcion,
		Familia.IdFamilia,
		Familia.NomFamilia,
		Descrip1.Estado
		from Descrip1
		INNER JOIN Familia on Familia.IdFamilia=Descrip1.IdFamilia
		where Familia.IdFamilia=@IdFamilia and Descrip1.Estado=1
	end
GO
/****** Object:  StoredProcedure [dbo].[ListDescrip2]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListaDescrip2]
as
	begin
		Select 
		IdDescrip2,
		Descripcion,
		Estado
		from Descrip2
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarProducto]
as
 Select IdProducto
 ,Producto.IdDescrip1
 ,Producto.IdDescrip2
 ,Producto.IdColor
 ,Unidad.IdUnidad
 ,Unidad.AUnidad
 ,Unidad.Medible
 ,Producto.IdCategoria
 ,Producto.NomCategoria Categoria
 ,Producto.Bilateral
 ,Producto.IdFamilia
 ,Producto.NomFamilia Familia
 ,Producto.Descripcion1
 ,Producto.Descripcion2
 ,Producto.Serie2
 ,Producto.Modelo
 ,Producto.Peso
 ,Producto.NomColor Color
 ,Producto.Estado 
 from View_Producto Producto
 inner join Unidad on Unidad.IdUnidad=Producto.IdUnidad
 where Producto.Estado=1
GO
/****** Object:  StoredProcedure [dbo].[ListarProductoConsulta]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarProductoConsulta]
as
 Select 
 P.IdProducto
 ,P.IdCategoria
 ,P.Serie2
 ,P.IdColor
 ,P.Modelo
 ,P.Bilateral
 ,P.Descripcion1
 ,P.Descripcion2
 ,P.NomColor Color
 ,U.AUnidad
 ,U.IdUnidad
 ,PU.Factor
 ,PU.PContado Precio
 from View_Producto P
 inner join ProductoUnidad PU on PU.IdProducto=P.IdProducto
 inner join Unidad U on U.IdUnidad=PU.IdUnidad
 where P.Estado=1 and PU.UnidadBase=1
GO
/****** Object:  StoredProcedure [dbo].[ListarProductoUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarProductoUnidad]
@IdProducto int
as begin
 Select 
 PU.IdProductoUnidad
 ,U.IdUnidad
 ,P.IdProducto
 ,P.Modelo
 ,U.AUnidad
 ,PU.Factor
 ,P.Peso PesoMin
 ,PU.PContado
 ,PU.PCredito
 ,PU.DescContado
 ,PU.DescCredito
 ,PU.UnidadBase
 ,U.IdUnidad
 ,P.IdUnidad IdUnidadMinima 
 ,PU.Estado
  from ProductoUnidad PU
	 inner join Producto P on P.IdProducto=PU.IdProducto and P.Estado=1
	 inner join Unidad U on U.IdUnidad=PU.IdUnidad and U.Estado=1
	 where P.IdProducto=@IdProducto
	 end
GO

/****** Object:  StoredProcedure [dbo].[RegistrarCategoriaColor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[RegistrarCategoriaColor]
@IdCategoria int,
@IdColor int,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdCategoria>0 and @IdColor>0)
			if(not exists(select * from CategoriaColor where IdCategoria=@IdCategoria and IdColor=@IdColor))
				begin
					Insert into CategoriaColor Values(@IdCategoria,@IdColor)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Color para este Categoria ya existe'
		else
			Set @Mensaje='Ingrese un color o categoria valida'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCategoriaDescrip2]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarCategoriaDescrip2]
@IdCategoria int,
@IdDescrip2 int,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(not exists(select * from CategoriaDescrip2 where IdCategoria = @IdCategoria and IdDescrip2=@IdDescrip2))
			begin
				Insert into CategoriaDescrip2 Values(@IdDescrip2,@IdCategoria)
				Set @Mensaje='1'
			end
			else
				Set @Mensaje='Ya existe una combinacion igual'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCategoriaUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarCategoriaUnidad]
@IdCategoria int,
@IdUnidad int,
@IdUnidadMinima int,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdCategoria>0 and @IdUnidad>0)
			if(not exists(select * from CategoriaUnidad where IdCategoria=@IdCategoria and IdUnidad=@IdUnidad))
				begin
					Insert into CategoriaUnidad Values(@IdCategoria,@IdUnidad,@IdUnidadMinima)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Unidad para este Categoria ya existe'
		else
			Set @Mensaje='Ingrese una unidad o categoria valida'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarColor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarColor]
@NomColor Varchar(50),
@IdColor Varchar(50)  Out,
@Mensaje Varchar(50)  Out
As Begin
	begin try
			if(not exists(select NomColor from Color where NomColor=@NomColor))
				begin
					Insert into Color Values(@NomColor,1)
					Set @IdColor=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Color ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarDescrip1]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarDescrip1]
@IdFamilia int,
@Descripcion varchar(300),
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdFamilia>0)
		if(not exists(select Descripcion from Descrip1 where Descripcion = @Descripcion and IdFamilia = @IdFamilia))
			begin
				Insert into Descrip1 Values(@Descripcion,@IdFamilia,1)
				Set @Mensaje='1'
			end
			else
				Set @Mensaje='Ya exista familia para este categoria'
		else
			Set @Mensaje='Algunos datos son invalidos'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarDescrip2]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarDescrip2]
@Descripcion varchar(300),
@IdDescrip2 int  Out,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(not exists(select Descripcion from Descrip2 where Descripcion = @Descripcion))
			begin
				Insert into Descrip2 Values(@Descripcion,1)
				Set @IdDescrip2=SCOPE_IDENTITY()
				Set @Mensaje='1'
			end
			else
				Set @Mensaje='Ya existe una descripcion igual'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarFamilia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarFamilia]
@IdCategoria int,
@NomFamilia varchar(300),
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdCategoria>0)
			if(not exists(select NomFamilia from Familia  where NomFamilia = @NomFamilia and IdCategoria = @IdCategoria))
				begin
					Insert into Familia Values(@NomFamilia,@IdCategoria,1)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Ya exista familia para este categoria'
		else
			Set @Mensaje='Algunos datos son invalidos'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End


GO
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarProducto]
@Serie2 varchar(20),
@Modelo varchar(20),
@IdDescrip1 int,
@IdDescrip2 int,
@IdColor int,
@IdUnidad int,
@Peso Decimal(5,2),
@IdProducto int Out,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdColor>0 and @IdDescrip1>0 and @IdDescrip2>0)
			if(@Serie2 <> '')
				if(not exists(select * from Producto where Serie2=@Serie2 and IdDescrip1=@IdDescrip1 and IdColor=@IdColor and IdDescrip2=@IdDescrip2 and Modelo=@Modelo))
					begin
						Insert into Producto Values(@Serie2,@Modelo,@IdDescrip1,@IdDescrip2,@IdColor,1,@Peso,@IdUnidad)
						set @IdProducto=SCOPE_IDENTITY()
						Set @Mensaje='1'
					end
				else
					Set @Mensaje='Este producto con este codigo ya existe'
			else
				Set @Mensaje='La Serie2 no puede ser vacio'
		else
			Set @Mensaje='Ingrese datos validos'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProductoUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarProductoUnidad]
@IdProducto int,
@IdUnidad int,
@DescContado decimal(11,4),
@DescCredito decimal(11,4),
@PContado decimal(11,4),
@PCredito decimal(11,4),
@Factor decimal(11,4),
@UnidadBase bit,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdProducto>0 and @IdUnidad>0 and @PContado>0)
			begin
				if(not exists(select * from ProductoUnidad where IdProducto=@IdProducto and IdUnidad=@IdUnidad))
					begin
						set @DescContado=ISNULL(@DescContado,0)
						set @DescCredito=ISNULL(@DescCredito,0)
						set @PCredito=ISNULL(@PCredito,0)
						set @Factor=ISNULL(@Factor,0)						
						Insert into ProductoUnidad Values(@IdProducto,@IdUnidad,@DescContado,@DescCredito,@PContado,@PCredito,@UnidadBase,@Factor,1)
						Set @Mensaje='1'
					end
				else
					Set @Mensaje='Este unidad para este producto ya existe'
			end
		else
			Set @Mensaje='Ingrese datos validos'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End


GO

/****** Object:  StoredProcedure [dbo].[RegistrarUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarUnidad]
@AUnidad Varchar(50),
@Medible bit,
@Mensaje Varchar(50)  Out,
@IdUnidad int  Out
As Begin
	begin try
		if(@AUnidad<>null or @AUnidad<>'')
			if(not exists(select * from Unidad where AUnidad=@AUnidad))
				begin
					Insert into Unidad Values(@AUnidad,@Medible,1)
					Set @IdUnidad = SCOPE_IDENTITY();
					Set @Mensaje = '1'
				end
			else
				Set @Mensaje='Este unidad ya existe'
		else
			Set @Mensaje='No ingreso unidad'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoriaColor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCategoriaColor]
@IdCategoriaOld int,
@IdColorOld int,
@IdCategoria int,
@IdColor int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select * from CategoriaColor where IdCategoria = @IdCategoria and IdColor=@IdColor))
			begin
				update CategoriaColor set
				IdCategoria=@IdCategoria,
				IdColor=@IdColor
				where IdCategoria=@IdCategoriaOld AND IdColor=@IdColorOld
				Set @Mensaje='1'
			end
		else
			set @Mensaje='Este combinacion ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoriaDescrip2]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCategoriaDescrip2]
@IdCategoria int,
@IdDescrip2 int,
@_IdCategoria int,
@_IdDescrip2 int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select * from CategoriaDescrip2 where IdCategoria = @IdCategoria and IdDescrip2=@IdDescrip2))
			if(not exists(select * from CategoriaDescrip2 where IdCategoria = @_IdCategoria and IdDescrip2=@_IdDescrip2))
				begin
					update CategoriaDescrip2 set
					IdCategoria=@_IdCategoria,
					IdDescrip2=@_IdDescrip2
					where IdCategoria=@IdCategoria and IdDescrip2=@IdDescrip2
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este combinacion no existe'
		else
			set @Mensaje='Este combinacion no existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoriaUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCategoriaUnidad]
@IdCategoriaUnidad int,
@IdCategoria int,
@IdUnidad int,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdCategoria>0 and @IdUnidad>0)
			if(not exists(select * from CategoriaUnidad where IdCategoria=@IdCategoria and IdUnidad=@IdUnidad))
				begin
					update CategoriaUnidad set IdUnidad=@IdUnidad,IdCategoria=@IdCategoria where IdCategoriaUnidad=@IdCategoriaUnidad
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Unidad para este Categoria ya existe'
		else
			Set @Mensaje='Ingrese una unidad o categoria valida'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[UpdateColor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateColor]
@IdColor int,
@NomColor Varchar(100),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NomColor from Color where NomColor = @NomColor and IdColor!=@IdColor))
				begin
					update Color set 
					NomColor=@NomColor
					where IdColor=@IdColor
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Color ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateDescrip1]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateDescrip1]
@IdDescrip1 int,
@Descripcion Varchar(300),
@IdFamilia int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select Descripcion from Descrip1  where Descripcion = @Descripcion and IdDescrip1!=@IdDescrip1))
				begin
					update Descrip1 set
					Descripcion=@Descripcion,
					IdFamilia=@IdFamilia
					where IdDescrip1=@IdDescrip1
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este familia con este nombre ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateDescrip2]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateDescrip2]
@IdDescrip2 int,
@Descripcion Varchar(300),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select Descripcion from Descrip2  where Descripcion = @Descripcion and IdDescrip2!=@IdDescrip2))
				begin
					update Descrip2 set
					Descripcion=@Descripcion
					where IdDescrip2=@IdDescrip2
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este familia con este nombre ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateFamilia]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateFamilia]
@IdFamilia int,
@NomFamilia Varchar(300),
@IdCategoria int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NomFamilia from Familia  where NomFamilia = @NomFamilia and IdFamilia!=@IdFamilia and IdCategoria = @IdCategoria))
				begin
					update Familia set
					NomFamilia=@NomFamilia,
					IdCategoria=@IdCategoria
					where IdFamilia=@IdFamilia
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este familia con este nombre ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateProducto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateProducto]
@IdProducto int,
@Serie2 varchar(20),
@Modelo varchar(20),
@IdDescrip1 int,
@IdDescrip2 int,
@IdColor int,
@Peso Decimal(5,2),
@Estado bit, --Estado del Modelo (Si esta activo o desactivado)
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdColor>0 and @IdDescrip1>0 and @IdDescrip2>0)
			if(@Serie2 <> '')
				if(not exists(select * from Producto where Serie2=@Serie2 and IdDescrip1=@IdDescrip1 and IdColor=@IdColor and IdDescrip2=@IdDescrip2 and Modelo=@Modelo and IdProducto!=@IdProducto))
					begin
						update Producto set
						Modelo=@Modelo,
						Peso=@Peso,
						Estado=@Estado
						where IdProducto=@IdProducto
						Set @Mensaje='1'
					end
				else
					Set @Mensaje='Este producto con este codigo ya existe'
			else
				Set @Mensaje='El codigo no puede ser vacio'
		else
			Set @Mensaje='Ingrese datos validos'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[UpdateProductoUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateProductoUnidad]
@IdProductoUnidad int,
@IdProducto int,
@IdUnidad int,
@DescContado decimal(11,4),
@DescCredito decimal(11,4),
@PContado decimal(11,4),
@PCredito decimal(11,4),
@UnidadBase bit,
@Estado bit,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@IdProducto>0 and @IdUnidad>0 and @PContado>0)
			begin
				if(not exists(select * from ProductoUnidad where IdProducto=@IdProducto and IdUnidad=@IdUnidad and IdProductoUnidad!=@IdProductoUnidad))
					begin
						set @DescContado=ISNULL(@DescContado,0)
						set @DescCredito=ISNULL(@DescCredito,0)
						set @PCredito=ISNULL(@PCredito,0)						
						
						update ProductoUnidad set
						IdUnidad=@IdUnidad,
						DescContado=@DescContado,
						DescCredito=@DescCredito,
						PContado=@PContado,
						PCredito=@PCredito,
						UnidadBase=@UnidadBase,
						Estado=@Estado
						where IdProductoUnidad=@IdProductoUnidad
						Set @Mensaje='1'
					end
				else
					Set @Mensaje='Este unidad para este producto ya existe'
			end
		else
			Set @Mensaje='Ingrese datos validos'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End


GO
/****** Object:  StoredProcedure [dbo].[UpdateUnidad]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateUnidad]
@IdUnidad int,
@AUnidad Varchar(100),
@Medible bit,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select AUnidad from Unidad where AUnidad=@AUnidad and IdUnidad!=@IdUnidad))
				begin
					update Unidad set 
					AUnidad=@AUnidad,
					Medible=@Medible,
					Estado=@Estado
					where IdUnidad=@IdUnidad
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Nombre o la abreviatura de la unidad ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
