/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[CodDocumento] [int] NULL,
	[RazonSocial] [varchar](300) NOT NULL,
	[Numero] [varchar](11) NOT NULL,
	[Direccion] [varchar](300) NOT NULL,
	[IdUbigeo] [int] NULL,
	[Email] [varchar](160) NULL,
	[Telefono] [varchar](11) NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Proveedor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Proveedor]
AS
SELECT        dbo.Proveedor.IdProveedor, dbo.Proveedor.RazonSocial, dbo.Proveedor.Numero, dbo.Proveedor.Direccion, dbo.Proveedor.Email, dbo.Proveedor.Telefono, dbo.Proveedor.Estado, dbo.Ubigeo.IdUbigeo, dbo.Ubigeo.Codigo, 
                         dbo.Ubigeo.Departamento, dbo.Ubigeo.Provincia, dbo.Ubigeo.Distrito, dbo.Proveedor.CodDocumento
FROM            dbo.Proveedor INNER JOIN
                         dbo.Ubigeo ON dbo.Proveedor.IdUbigeo = dbo.Ubigeo.IdUbigeo
GO

/****** Object:  Table [dbo].[Contacto]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[IdContacto] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [int] NULL,
	[Nombres] [varchar](200) NOT NULL,
	[Area] [varchar](100) NULL,
	[Email] [varchar](200) NULL,
	[Telefono] [varchar](11) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD FOREIGN KEY([IdUbigeo])
REFERENCES [dbo].[Ubigeo] ([IdUbigeo])
GO
/****** Object:  StoredProcedure [dbo].[ActivateProveedor]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ActivateProveedor]
@IdProveedor int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Proveedor Set Estado=@Estado
		Where IdProveedor=@IdProveedor
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultaContacto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultaContacto]
@IdProveedor int
as
	begin
		Select 
		IdContacto,
		IdProveedor,
		Nombres,
		Area,
		Email,
		Telefono,
		Estado
		from Contacto
		where IdProveedor=@IdProveedor
	end
GO
/****** Object:  StoredProcedure [dbo].[ConsultaProveedor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[ConsultaProveedor]
@CodDocumento int,
@Numero varchar(11)
as
	begin
		Select 
		Proveedor.IdProveedor
		,Proveedor.RazonSocial
		,Proveedor.CodDocumento
		,Proveedor.Numero
		,Proveedor.Direccion
		,Ubigeo.Departamento
		,Ubigeo.Provincia
		,Ubigeo.Distrito
		,Ubigeo.Codigo Ubigeo
		,Ubigeo.IdUbigeo
		,Proveedor.Email
		,Proveedor.Telefono
		,Proveedor.Estado
		 from Proveedor
		inner join Ubigeo on Ubigeo.IdUbigeo=Proveedor.IdUbigeo
		where CodDocumento=@CodDocumento and Proveedor.Numero=@Numero
	end
GO
/****** Object:  StoredProcedure [dbo].[EliminarContacto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarContacto]
@IdContacto int,
@Mensaje Varchar(100) Out
as
	begin
	begin try
		if(exists(select * from Contacto where IdContacto=@IdContacto))
			begin
				delete Contacto where IdContacto=@IdContacto
				set @Mensaje='1'
			end
		else
			set @Mensaje='No existe Contacto'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[ListProveedor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ListarProveedor]
@CodDocumento int
as
	begin
		Select 
		Proveedor.IdProveedor
		,Proveedor.RazonSocial
		,Proveedor.CodDocumento
		,Proveedor.Numero
		,Proveedor.Direccion
		,Ubigeo.Departamento
		,Ubigeo.Provincia
		,Ubigeo.Distrito
		,Ubigeo.Codigo Ubigeo
		,Ubigeo.IdUbigeo
		,Proveedor.Email
		,Proveedor.Telefono
		,Proveedor.Estado
		 from Proveedor
		inner join Ubigeo on Ubigeo.IdUbigeo=Proveedor.IdUbigeo
		where Proveedor.CodDocumento=@CodDocumento
	end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarContactoProveedor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarContacto]
@IdProveedor int,
@Nombres Varchar(200),
@Area Varchar(100),
@Email Varchar(200),
@Telefono Varchar(200),
@Mensaje Varchar(50)  Out
As Begin
	begin try
			if(not exists(select Nombres from Contacto where Nombres=@Nombres and IdProveedor=@IdProveedor))
				begin
					Insert into Contacto Values(@IdProveedor,@Nombres,@Area,@Email,@Telefono,1)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este contacto ya existe para este proveedor'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End



GO
/****** Object:  StoredProcedure [dbo].[RegistrarProveedor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[RegistrarProveedor]
@CodDocumento int,
@RazonSocial varchar(300),
@Numero varchar(11),
@Direccion varchar(300),
@IdUbigeo int,
@Email varchar(160),
@Telefono varchar(11),
@IdProveedor int out,
@Mensaje varchar(100) out
As Begin
	begin try
		if(Not exists(select Numero from Proveedor where Numero=@Numero))
			if(Not exists(select * from Proveedor where RazonSocial=@RazonSocial))
				begin
					Insert into Proveedor Values(@CodDocumento,@RazonSocial,@Numero,@Direccion,@IdUbigeo,@Email,@Telefono,1)
					set @IdProveedor=SCOPE_IDENTITY()
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este este Proveedor con este razon social ya existe'
		else
			set @Mensaje='Este Proveedor con este Numero de documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarContacto]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ModificarContacto]
@IdContacto int,
@IdProveedor int,
@Nombres Varchar(200),
@Area Varchar(100),
@Email Varchar(200),
@Telefono Varchar(200),
@Mensaje Varchar(50)  Out
As Begin
	begin try
			if(not exists(select Nombres from Contacto where Nombres=@Nombres and IdProveedor=@IdProveedor and IdContacto!= @IdContacto))
				begin
					update Contacto set 
					Nombres=@Nombres,
					Area=@Area,
					Email=@Email,
					Telefono=@Telefono
					where IdContacto=@IdContacto
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este contacto ya existe para este proveedor'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarProveedor]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ModificarProveedor]
@IdProveedor int,
@CodDocumento int,
@RazonSocial varchar(300),
@Numero varchar(11),
@Direccion varchar(300),
@IdUbigeo int,
@Email varchar(160),
@Telefono varchar(11),
@Mensaje varchar(100) out
As Begin
	begin try
		if(not exists(select Numero from Proveedor where Numero = @Numero and IdProveedor!=@IdProveedor))
			if(not exists(select Numero from Proveedor where RazonSocial = @RazonSocial and IdProveedor!=@IdProveedor))
				begin
					update Proveedor set 
					RazonSocial=@RazonSocial,
					CodDocumento=@CodDocumento,
					Numero=@Numero,
					Direccion=@Direccion,
					IdUbigeo=@IdUbigeo,
					Email=@Email,
					Telefono=@Telefono
					where IdProveedor=@IdProveedor
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este este Proveedor con este razon social ya existe'
		else
			set @Mensaje='Este Proveedor con este Numero de documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
