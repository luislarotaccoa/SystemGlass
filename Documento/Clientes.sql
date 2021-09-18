/****** Object:  Table [dbo].[Cliente]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[RazSocial] [varchar](300) NOT NULL,
	[IdDocumento] [int] NULL,
	[NumDocumento] [varchar](11) NOT NULL,
	[Direccion] [varchar](300) NOT NULL,
	[IdUbigeo] [int] NOT NULL,
	[Email] [varchar](200) NULL,
	[Telefono] [varchar](10) NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificacion]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificacion](
	[IdCalificacion] [int] IDENTITY(1,1) NOT NULL,
	[Nota] [char](1) NOT NULL,
	[Descripcion] [varchar](20) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_IdCalificacion] PRIMARY KEY CLUSTERED 
(
	[IdCalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SocioCliente]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocioCliente](
	[IdCliente1] [int] NULL,
	[IdCliente2] [int] NULL,
	[TipSocio] [varchar](200) NOT NULL,
	[Estado] [bit] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Documento]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[IdDocumento] [int] IDENTITY(1,1) NOT NULL,
	[NomDocumento] [varchar](20) NOT NULL,
	[CodDocumento] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__IdDocumento] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubigeo]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubigeo](
	[IdUbigeo] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](255) NULL,
	[Departamento] [nvarchar](255) NULL,
	[Provincia] [nvarchar](255) NULL,
	[Distrito] [nvarchar](255) NULL,
	[Y] [float] NULL,
	[X] [float] NULL,
 CONSTRAINT [PK_Ubigeo] PRIMARY KEY CLUSTERED 
(
	[IdUbigeo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Cliente]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Cliente]
AS
SELECT        dbo.Cliente.IdCliente, dbo.Cliente.RazSocial, dbo.Cliente.NumDocumento, dbo.Cliente.Direccion, dbo.Cliente.Email, dbo.Cliente.Telefono, dbo.Cliente.Estado AS EstadoCliente, dbo.Documento.IdDocumento, 
                         dbo.Documento.NomDocumento, dbo.Documento.Estado AS EstadoDocumento, dbo.Documento.CodDocumento, dbo.Ubigeo.IdUbigeo, dbo.Ubigeo.Codigo, dbo.Ubigeo.Departamento, dbo.Ubigeo.Provincia, 
                         dbo.Ubigeo.Distrito, dbo.Ubigeo.Y, dbo.Ubigeo.X
FROM            dbo.Cliente INNER JOIN
                         dbo.Documento ON dbo.Cliente.IdDocumento = dbo.Documento.IdDocumento INNER JOIN
                         dbo.Ubigeo ON dbo.Cliente.IdUbigeo = dbo.Ubigeo.IdUbigeo
GO
/****** Object:  Table [dbo].[LineaCredito]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineaCredito](
	[IdLineaCredito] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdCalificacion] [int] NULL,
	[DiasMax] [int] NOT NULL,
	[MontoMax] [decimal](11, 2) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLineaCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 01/07/2021 6:11:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Direccion](
	[IdDireccion] [int] IDENTITY(1,1) NOT NULL,
	[IdUbigeo] [int] NULL,
	[IdCliente] [int] NULL,
	[NombreDireccion] [varchar](300) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__Direccion] PRIMARY KEY CLUSTERED 
(
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Asociaciones
ALTER TABLE [dbo].[SocioCliente]  WITH CHECK ADD FOREIGN KEY([IdCliente1])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[SocioCliente]  WITH CHECK ADD FOREIGN KEY([IdCliente2])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO

ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([IdUbigeo])
REFERENCES [dbo].[Ubigeo] ([IdUbigeo])
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD FOREIGN KEY([IdUbigeo])
REFERENCES [dbo].[Ubigeo] ([IdUbigeo])
GO
ALTER TABLE [dbo].[LineaCredito]  WITH CHECK ADD FOREIGN KEY([IdCalificacion])
REFERENCES [dbo].[Calificacion] ([IdCalificacion])
GO
ALTER TABLE [dbo].[LineaCredito]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarCliente]
@IdCliente int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Cliente Set Estado=@Estado
		Where IdCliente=@IdCliente
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarCalificacion]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarCalificacion]
@IdCalificacion int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Calificacion Set Estado=@Estado
		Where IdCalificacion=@IdCalificacion
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO

/****** Object:  StoredProcedure [dbo].[EliminarLineaCredito]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarLineaCredito]
@IdLineaCredito int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update LineaCredito Set Estado=@Estado
		Where IdLineaCredito=@IdLineaCredito
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaCliente]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaCliente]
@IdDocumento int,
@NumDocumento varchar(11)
as
	begin
		Select 
		Cliente.IdCliente
		,Cliente.RazSocial
		,Documento.IdDocumento
		,Documento.NomDocumento
		,Cliente.NumDocumento
		,Cliente.Direccion
		,Ubigeo.Departamento
		,Ubigeo.Provincia
		,Ubigeo.Distrito
		,Ubigeo.Codigo Ubigeo
		,Ubigeo.IdUbigeo
		,Cliente.Email
		,Cliente.Telefono
		,Cliente.Estado
		 from Cliente
		inner join Documento on Documento.IdDocumento=Cliente.IdDocumento
		inner join Ubigeo on Ubigeo.IdUbigeo=Cliente.IdUbigeo
		where Cliente.NumDocumento=@NumDocumento and Cliente.IdDocumento=@IdDocumento
	end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaLineaCredito]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultaLineaCredito]
@IdCliente int
As Begin
	Select 
		LineaCredito.IdLineaCredito
		,IdCliente
		,LineaCredito.DiasMax
		,LineaCredito.MontoMax
		,Calificacion.IdCalificacion
		,Calificacion.Nota
		,Calificacion.Descripcion
		,LineaCredito.Estado
		from LineaCredito
		inner join Calificacion on Calificacion.IdCalificacion=LineaCredito.IdCalificacion
		where IdCliente=@IdCliente
End
GO
/****** Object:  StoredProcedure [dbo].[ListarSocioCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarSocioCliente]
@IdCliente int
as
	begin
		Select 
		SocioCliente.IdCliente1
		,SocioCliente.IdCliente2
		,Cliente.IdDocumento
		,Cliente.RazSocial
		,Cliente.NumDocumento
		,Cliente.Telefono
		,SocioCliente.TipSocio
		,SocioCliente.Estado
		 from SocioCliente
		 inner join Cliente on Cliente.IdCliente=SocioCliente.IdCliente2
		where SocioCliente.IdCliente1=@IdCliente
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarCliente]
@IdDocumento int
as
	begin
		Select 
		Cliente.IdCliente
		,Cliente.RazSocial
		,Documento.IdDocumento
		,Documento.NomDocumento
		,Cliente.NumDocumento
		,Cliente.Direccion
		,Ubigeo.Departamento
		,Ubigeo.Provincia
		,Ubigeo.Distrito
		,Ubigeo.Codigo Ubigeo
		,Ubigeo.IdUbigeo
		,Cliente.Email
		,Cliente.Telefono
		,Cliente.Estado
		 from Cliente
		inner join Documento on Documento.IdDocumento=Cliente.IdDocumento
		inner join Ubigeo on Ubigeo.IdUbigeo=Cliente.IdUbigeo
		where Cliente.IdDocumento=@IdDocumento
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarCalificacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarCalificacion]
as
	begin
		Select Nota,Descripcion,Estado from Calificacion
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarLineaCredito]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarLineaCredito]
@IdCliente int
as
	begin
		Select 
		LineaCredito.IdLineaCredito
		,IdCliente
		,LineaCredito.DiasMax
		,LineaCredito.MontoMax
		,Calificacion.IdCalificacion
		,Calificacion.Nota
		,Calificacion.Descripcion
		,LineaCredito.Estado
		from LineaCredito
		inner join Calificacion on Calificacion.IdCalificacion=LineaCredito.IdCalificacion
		where IdCliente=@IdCliente
	end
GO

/****** Object:  StoredProcedure [dbo].[RegistrarSocioCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[RegistrarSocioCliente]
@IdCliente1 int,
@IdCliente2 int,
@TipSocio varchar(200),
@Mensaje Varchar(100) Out
As Begin
	begin try
		if(not exists(select IdCliente1 from SocioCliente where IdCliente1 = @IdCliente1 and IdCliente2=@IdCliente2))
			if(@IdCliente1!=@IdCliente2)
				begin
					insert into SocioCliente values(@IdCliente1,@IdCliente2,@TipSocio,1)
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este cliente no puede ser socio de el mismo'
		else
			set @Mensaje='Este cliente ya es socio de este cliente'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End

GO
/****** Object:  StoredProcedure [dbo].[RegistrarCalificacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarCalificacion]
@Nota char(1),
@Descripcion varchar(20),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select Nota from Calificacion where Nota=@Nota))
				begin
					Insert into Calificacion Values(@Nota,@Descripcion,1)
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta calificacion ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarCliente]
@RazSocial Varchar(300),
@IdDocumento int,
@NumDocumento varchar(11),
@Direccion varchar(300),
@IdUbigeo int,
@Email varchar(200),
@Telefono varchar(10),
@Mensaje Varchar(100)  Out,
@IdCliente int out
As Begin
	begin try
		if(Not exists(select NumDocumento from Cliente where NumDocumento=@NumDocumento))
			if(Not exists(select * from Cliente where RazSocial=@RazSocial))
				begin
					Insert into Cliente Values(@RazSocial,@IdDocumento,@NumDocumento,@Direccion,@IdUbigeo,@Email,@Telefono,1)
					set @IdCliente=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este este clinete con este razon social ya existe'
		else
			set @Mensaje='Este cliente con este Numero de documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarLineaCredito]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarLineaCredito]
@IdCliente int,
@IdCalificacion int,
@DiasMax int,
@MontoMax decimal(11,2),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select top 1 * from LineaCredito where IdCliente=@IdCliente))
			if(@MontoMax>0 and @DiasMax>0)
				begin
					Insert into LineaCredito Values(@IdCliente,@IdCalificacion,@DiasMax,@MontoMax,1)
					Set @Mensaje='1'
				end
			else
				set @Mensaje='El Número, Días y monto máximo de crádito tienen que ser mayores que 0'
		else
			set @Mensaje='Este cliente ya tiene una cuenta de credito habierto'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarSocioCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[ModificarSocioCliente]
@IdCliente1 int,
@IdCliente2 int,
@TipSocio varchar(200),
@Mensaje Varchar(100) Out
As Begin
	begin try
		update SocioCliente set 
		TipSocio=@TipSocio
		where IdCliente1=@IdCliente1 and IdCliente2=@IdCliente2
		Set @Mensaje='1'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarCalificacion]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ModificarCalificacion]
@IdCalificacion int,
@Nota char(1),
@Descripcion varchar(20),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select Nota from Calificacion where Nota = @Nota and IdCalificacion!=@IdCalificacion))
				begin
					update Calificacion set Nota=@Nota,Descripcion=@Descripcion where IdCalificacion=@IdCalificacion
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Esta Calificación ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarCliente]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ModificarCliente]
@IdCliente int,
@RazSocial Varchar(300),
@IdDocumento int,
@NumDocumento varchar(11),
@Direccion varchar(300),
@IdUbigeo int,
@Email varchar(200),
@Telefono varchar(10),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NumDocumento from Cliente where NumDocumento = @NumDocumento and IdCliente!=@IdCliente))
			if(not exists(select NumDocumento from Cliente where RazSocial = @RazSocial and IdCliente!=@IdCliente))
				begin
					update Cliente set 
					RazSocial=@RazSocial,
					IdDocumento=@IdDocumento,
					NumDocumento=@NumDocumento,
					Direccion=@Direccion,
					IdUbigeo=@IdUbigeo,
					Email=@Email,
					Telefono=@Telefono
					where IdCliente=@IdCliente
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este este clinete con este razon social ya existe'
		else
			set @Mensaje='Este cliente con este Numero de documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarDocumento]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarDocumento]
@NomDocumento Varchar(20),
@CodDocumento int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select NomDocumento from Documento where NomDocumento=@NomDocumento))
				begin
					Insert into Documento Values(@NomDocumento,@CodDocumento,1)
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Tipo de Documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarDocumento]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificarDocumento]
@IdDocumento int,
@NomDocumento Varchar(20),
@CodDocumento int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NomDocumento from Documento where NomDocumento = @NomDocumento and IdDocumento!=@IdDocumento))
				begin
					update Documento set NomDocumento=@NomDocumento,CodDocumento=@CodDocumento where IdDocumento=@IdDocumento
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Tipo de Documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarLineaCredito]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificarLineaCredito]
@IdLineaCredito int,
@DiasMax int,
@MontoMax decimal(11,2),
@IdCalificacion int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(@MontoMax>0 and @DiasMax>0)
			begin
				update LineaCredito set 
				DiasMax=@DiasMax,
				MontoMax=@MontoMax,
				IdCalificacion=@IdCalificacion
				where IdLineaCredito=@IdLineaCredito
				Set @Mensaje='1'
			end
		else
			set @Mensaje='El Número, Días y monto máximo de crádito tienen que ser mayores que 0'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
