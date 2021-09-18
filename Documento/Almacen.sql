/****** Object:  Table [dbo].[Almacen]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[IdAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](10) NULL,
	[Nombre] [varchar](100) NULL,
	[Direccion] [varchar](300) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicacion](
	[IdUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[NomUbicacion] [varchar](30) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[AlmacenUbicacion]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlmacenUbicacion](
	[IdAlmacenUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[IdUbicacion] [int] NULL,
	[IdAlmacen] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlmacenUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlmacenUbicacion]  WITH CHECK ADD FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[AlmacenUbicacion]  WITH CHECK ADD FOREIGN KEY([IdUbicacion])
REFERENCES [dbo].[Ubicacion] ([IdUbicacion])
GO
/****** Object:  StoredProcedure [dbo].[EliminarAlmacen]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarAlmacen]
@IdAlmacen int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Almacen Set Estado=@Estado
		Where IdAlmacen=@IdAlmacen
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO


GO
/****** Object:  StoredProcedure [dbo].[ActivateUbicacion]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarUbicacion]
@IdUbicacion int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Ubicacion Set Estado=@Estado
		Where IdUbicacion=@IdUbicacion
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ListAlmacen]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarAlmacen]
as
 Select IdAlmacen,Serie,Nombre,Direccion,Estado from Almacen
 
GO
/****** Object:  StoredProcedure [dbo].[ListAlmacenUbicacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarAlmacenUbicacion]
@IdAlmacen int
as
 Select IdAlmacenUbicacion
 ,AlmacenUbicacion.Estado
 ,Almacen.IdAlmacen
 ,Almacen.Serie
 ,Almacen.Nombre
 ,Almacen.Direccion
 ,Ubicacion.IdUbicacion
 ,Ubicacion.NomUbicacion
 from AlmacenUbicacion
 inner join Almacen on Almacen.IdAlmacen=AlmacenUbicacion.IdAlmacen and Almacen.Estado=1
 inner join Ubicacion on Ubicacion.IdUbicacion=AlmacenUbicacion.IdUbicacion and Ubicacion.Estado=1
 where Almacen.IdAlmacen=@IdAlmacen
GO
/****** Object:  StoredProcedure [dbo].[ListUbicacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarUbicacion]
As Begin
Select IdUbicacion, NomUbicacion,Estado from Ubicacion
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarAlmacen]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[RegistrarAlmacen]
@Serie Varchar(10),
@Nombre Varchar(100),
@Direccion Varchar(300),
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@Nombre<>null or @Nombre<>'')
			if(not exists(select * from Almacen where Nombre=@Nombre) and not exists(select * from Almacen where Serie=@Serie))
				begin
					Insert into Almacen Values(@Serie,@Nombre,@Direccion,1)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Almacen ya existe'
		else
			Set @Mensaje='No ingreso nombre'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarAlmacenUbicacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarAlmacenUbicacion]
@IdUbicacion int,
@IdAlmacen int,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(not exists(select * from AlmacenUbicacion where IdUbicacion = @IdUbicacion and IdAlmacen=@IdAlmacen))
			begin
				Insert into AlmacenUbicacion Values(@IdUbicacion,@IdAlmacen,1)
				Set @Mensaje='1'
			end
			else
				Set @Mensaje='Ya existe esta ubicacion en este Almacen'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarAlmacen]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ModificarAlmacen]
@IdAlmacen int,
@Serie Varchar(10),
@Nombre Varchar(100),
@Direccion Varchar(300),
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if((@Nombre<>null or @Nombre<>'') and (@Serie<>null or @Serie<>''))
			if(exists(select * from Almacen where Nombre=@Nombre and IdAlmacen<>@IdAlmacen) and exists(select * from Almacen where Serie=@Serie and IdAlmacen<>@IdAlmacen))
				begin
					update Almacen set Serie=@Serie, Nombre=@Nombre, Direccion=@Direccion where IdAlmacen=@IdAlmacen
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Almacen ya existe'
		else
			Set @Mensaje='No ingreso nombre o serie'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarUbicacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ModificarUbicacion]
@IdUbicacion int,
@NomUbicacion varchar(30),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Ubicacion Set NomUbicacion=@NomUbicacion
		Where IdUbicacion=@IdUbicacion
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO