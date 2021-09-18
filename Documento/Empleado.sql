/****** Object:  Table [dbo].[Empleado]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[IdUbigeo] [int] NULL,
	[Apellidos] [varchar](300) NOT NULL,
	[Nombres] [varchar](300) NOT NULL,
	[CodDocumento] int NULL,
	[NumDocumento] [varchar](11) NOT NULL,
	[Sexo] [char](1) NULL,
	[FechaNacimiento] [date] NULL,
	[Direccion] [varchar](300) NOT NULL,
	[EstCivil] [varchar](20) NULL,
	[Email] [varchar](200) NULL,
	[Especialidad] [varchar](100) NULL,
	[Telefono] [varchar](10) NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NomUsuario] [varchar](50) NULL,
	[Contrasena] [varchar](300) NULL,
	[IdEmpleado] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Permisos]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Permiso] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcesoPermiso]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcesoPermiso](
	[IdProceso] [int] NULL,
	[IdPermiso] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Procesos]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procesos](
	[IdProceso] [int] IDENTITY(1,1) NOT NULL,
	[Nodo] [int] NOT NULL,
	[Proceso] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRoles] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](25) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRoles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRoles]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRoles](
	[IdUsuarioRoles] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdRoles] [int] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuarioRoles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolProceso]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolProceso](
	[IdRolProceso] [int] IDENTITY(1,1) NOT NULL,
	[IdRoles] [int] NULL,
	[IdProceso] [int] NULL,
	[Permisos] [varchar](15) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRolProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdUbigeo])
REFERENCES [dbo].[Ubigeo] ([IdUbigeo])
GO
ALTER TABLE [dbo].[ProcesoPermiso]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[ProcesoPermiso]  WITH CHECK ADD FOREIGN KEY([IdProceso])
REFERENCES [dbo].[Procesos] ([IdProceso])
GO
ALTER TABLE [dbo].[RolProceso]  WITH CHECK ADD FOREIGN KEY([IdProceso])
REFERENCES [dbo].[Procesos] ([IdProceso])
GO
ALTER TABLE [dbo].[RolProceso]  WITH CHECK ADD FOREIGN KEY([IdRoles])
REFERENCES [dbo].[Roles] ([IdRoles])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD FOREIGN KEY([IdRoles])
REFERENCES [dbo].[Roles] ([IdRoles])
GO
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[EliminarEmpleado]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarEmpleado]
@IdEmpleado int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Empleado Set Estado=@Estado
		Where IdEmpleado=@IdEmpleado
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarRoles]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[EliminarRoles]
@IdRoles int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Roles Set Estado=@Estado
		Where IdRoles=@IdRoles
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[EliminarUsuario]
@IdUsuario int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Usuario Set Estado=@Estado
		Where IdUsuario=@IdUsuario
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuarioRoles]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[EliminarUsuarioRoles]
@IdUsuarioRoles int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update UsuarioRoles Set Estado=@Estado
		Where IdUsuarioRoles=@IdUsuarioRoles
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[CambioContrasena]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CambioContrasena]
@IdUsuario int,
@Contrasena_old Varchar(300),
@Contrasena_new varchar(300),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(exists(select NomUsuario from Usuario where IdUsuario=@IdUsuario and Contrasena=@Contrasena_old))
				begin
					update Usuario set Contrasena=@Contrasena_new where Contrasena=@Contrasena_old and IdUsuario=@IdUsuario
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Ingresa tu contraseña actual'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEmpleado]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultarEmpleado]
@NumDocumento varchar(11),
@CodDocumento int
as
	begin
		Select 
		Empleado.IdEmpleado
		,Empleado.Nombres
		,Empleado.Apellidos
		,Empleado.CodDocumento
		,Empleado.NumDocumento
		,Empleado.Sexo
		,Empleado.FechaNacimiento
		,Empleado.Direccion
		,Ubigeo.IdUbigeo
		,Ubigeo.Departamento
		,Ubigeo.Provincia
		,Ubigeo.Distrito
		,Ubigeo.Codigo Ubigeo
		,Empleado.EstCivil
		,Empleado.Email
		,Empleado.Especialidad
		,Empleado.Telefono
		,Empleado.Estado
		 from Empleado
		inner join Ubigeo on Ubigeo.IdUbigeo=Empleado.IdUbigeo
		where Empleado.NumDocumento=@NumDocumento and CodDocumento=@CodDocumento
	end
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ConsultarUsuario]
@CodDocumento int,
@Numero varchar(11)
as
	begin
		Select 
		Usuario.IdUsuario
		,Empleado.IdEmpleado
		,Empleado.CodDocumento
		,Usuario.NomUsuario
		,Empleado.Nombres
		,Empleado.Apellidos
		,Empleado.NumDocumento Numero
		,Usuario.Estado
		from Usuario
		inner join Empleado on Empleado.IdEmpleado=Usuario.IdEmpleado
		where Empleado.CodDocumento=@CodDocumento and Empleado.NumDocumento=@Numero
	end
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuarioRol]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ConsultarUsuarioRol]
@IdUsuario int
as
	begin
		Select 
		IdUsuarioRoles
		,Usuario.IdUsuario
		,Usuario.NomUsuario
		,Roles.IdRoles
		,Roles.Rol
		,UsuarioRoles.Estado 
		from UsuarioRoles
		inner join Usuario on Usuario.IdUsuario=UsuarioRoles.IdUsuario
		inner join Roles on Roles.IdRoles=UsuarioRoles.IdRoles
		where UsuarioRoles.IdUsuario=@IdUsuario
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarEmpleado]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarEmpleado]
as
	begin
		Select 
		Empleado.IdEmpleado
		,Empleado.Nombres
		,Empleado.Apellidos
		,Empleado.CodDocumento
		,Empleado.NumDocumento
		,Empleado.Sexo
		,Empleado.FechaNacimiento
		,Empleado.Direccion
		,Ubigeo.IdUbigeo
		,Ubigeo.Departamento
		,Ubigeo.Provincia
		,Ubigeo.Distrito
		,Ubigeo.Codigo Ubigeo
		,Empleado.EstCivil
		,Empleado.Email
		,Empleado.Especialidad
		,Empleado.Telefono
		,Empleado.Estado
		 from Empleado
		inner join Ubigeo on Ubigeo.IdUbigeo=Empleado.IdUbigeo
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarNumeroEmpleado]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[ListarNumeroEmpleado]
@CodDocumento int
as Begin
 Select 
 NumDocumento
 from Empleado E
 where CodDocumento=@CodDocumento
end
GO
/****** Object:  StoredProcedure [dbo].[ListarPermisos]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarPermisos]
as 
Select * from Permisos

GO
/****** Object:  StoredProcedure [dbo].[ListarProcesoPermiso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarProcesoPermiso]
@IdProceso int
as
Select 
Procesos.IdProceso,
Procesos.Proceso,
Permisos.IdPermiso,
Permisos.Permiso
From ProcesoPermiso
inner join Procesos on Procesos.IdProceso=ProcesoPermiso.IdProceso
inner join Permisos on Permisos.IdPermiso=ProcesoPermiso.IdPermiso
where Procesos.IdProceso=@IdProceso
GO
/****** Object:  StoredProcedure [dbo].[ListarProcesos]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarProcesos]
as
Select * from Procesos

GO
/****** Object:  StoredProcedure [dbo].[ListarRoles]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarRoles]
as
	begin
		Select * from Roles
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarRolProceso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarRolProceso]
@IdRoles int
as 
select 
RolProceso.IdRolProceso
,RolProceso.Permisos
,Roles.Rol
,Roles.IdRoles
,Procesos.Proceso
,Procesos.IdProceso
,RolProceso.Estado
 from RolProceso
inner join Roles on Roles.IdRoles=RolProceso.IdRoles
inner join Procesos on Procesos.IdProceso=RolProceso.IdProceso
where RolProceso.IdRoles=@IdRoles
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarUsuario]
as
	begin
		Select 
		Usuario.IdUsuario
		,Usuario.IdEmpleado
		,Empleado.CodDocumento
		,Usuario.NomUsuario
		,Empleado.Nombres
		,Empleado.Apellidos
		,Empleado.NumDocumento Numero
		,Usuario.Estado
		 from Usuario
		inner join Empleado on Empleado.IdEmpleado=Usuario.IdEmpleado
	end
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarioRol]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListarUsuarioRol]
as
	begin
		Select 
		IdUsuarioRoles
		,Usuario.IdUsuario
		,Usuario.NomUsuario
		,Roles.IdRoles
		,Roles.Rol
		,UsuarioRoles.Estado 
		from UsuarioRoles
		inner join Usuario on Usuario.IdUsuario=UsuarioRoles.IdUsuario
		inner join Roles on Roles.IdRoles=UsuarioRoles.IdRoles
	end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarEmpleado]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarEmpleado]
@Apellidos Varchar(300),
@Nombres Varchar(300),
@CodDocumento int,
@NumDocumento varchar(11),
@Sexo char(1),
@FechaNacimiento date,
@Direccion varchar(300),
@IdUbigeo int,
@EstCivil varchar(20),
@Email varchar(200),
@Especialidad varchar(100),
@Telefono varchar(10),
@Mensaje Varchar(100)  Out,
@IdEmpleado int out
As Begin
	begin try
		if(Not exists(select NumDocumento from Empleado where CodDocumento=@CodDocumento and NumDocumento=@NumDocumento))
			if(Not exists(select * from Empleado where Apellidos=@Apellidos and Nombres=@Nombres))
				begin
					Insert into Empleado Values(
					@Apellidos
					,@Nombres
					,@CodDocumento
					,@NumDocumento
					,@Sexo
					,@FechaNacimiento
					,@Direccion
					,@IdUbigeo
					,@EstCivil
					,@Email
					,@Especialidad
					,@Telefono
					,1)
					set @IdEmpleado=SCOPE_IDENTITY();
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este empleado con estes nombres ya existe'
		else
			set @Mensaje='Este empleado con este Numero de documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistraRolProceso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistraRolProceso]
@IdRoles int,
@IdProceso int,
@Permisos varchar(10),
@Estado bit,
@Mensaje varchar(100) out
As Begin
	begin try
		if(@IdRoles>0 and @IdProceso>0)
			if(not exists(select * from RolProceso where IdRoles=@IdRoles and IdProceso=@IdProceso))
				begin
					Insert into RolProceso Values(@IdRoles,@IdProceso,@Permisos,@Estado)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Proceso para este rol ya existe'
		else
			Set @Mensaje='Ingrese un rol o proceso valido'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarRoles]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarRoles]
@Rol Varchar(20),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select Rol from Roles where Rol=@Rol))
				begin
					Insert into Roles Values(@Rol,1)
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Rol ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarUsuario]
@NomUsuario Varchar(25),
@Contrasena Varchar(300),
@IdEmpleado int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select NomUsuario from Usuario where NomUsuario=@NomUsuario))
				begin
					Insert into Usuario Values(@NomUsuario,@Contrasena,@IdEmpleado,1)
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este Rol ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuarioRoles]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RegistrarUsuarioRoles]
@IdUsuario int,
@IdRoles int,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(Not exists(select * from UsuarioRoles where IdUsuario=@IdUsuario and IdRoles=@IdRoles))
				begin
					Insert into UsuarioRoles Values(@IdUsuario,@IdRoles,1)
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
/****** Object:  StoredProcedure [dbo].[ModificarEmpleado]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificarEmpleado]
@IdEmpleado int,
@Apellidos Varchar(300),
@Nombres Varchar(300),
@CodDocumento int,
@NumDocumento varchar(11),
@Sexo char(1),
@FechaNacimiento date,
@Direccion varchar(300),
@IdUbigeo int,
@EstCivil varchar(20),
@Email varchar(200),
@Especialidad varchar(100),
@Telefono varchar(10),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NumDocumento from Empleado where CodDocumento=@CodDocumento and NumDocumento = @NumDocumento and IdEmpleado!=@IdEmpleado))
			if(not exists(select NumDocumento from Empleado where Apellidos = @Apellidos and Nombres=@Nombres and IdEmpleado!=@IdEmpleado))
				begin
					update Empleado set 
					Apellidos=@Apellidos,
					Nombres=@Nombres,
					CodDocumento=@CodDocumento,
					NumDocumento=@NumDocumento,
					Sexo=@Sexo,
					FechaNacimiento=@FechaNacimiento,
					Direccion=@Direccion,
					IdUbigeo=@IdUbigeo,
					EstCivil=@EstCivil,
					Email=@Email,
					Especialidad=@Especialidad,
					Telefono=@Telefono
					where IdEmpleado=@IdEmpleado
					Set @Mensaje='1'
				end
			else
				set @Mensaje='Este Empleado con estes Nombres ya existe'
		else
			set @Mensaje='Este empleado con este Numero de documento ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[ModificarRoles]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ModificarRoles]
@IdRoles int,
@Rol Varchar(20),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select Rol from Roles where Rol = @Rol and IdRoles!=@IdRoles))
				begin
					update Roles set Rol=@Rol where IdRoles=@IdRoles
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
/****** Object:  StoredProcedure [dbo].[ModificarRolProceso]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificarRolProceso]
@IdRolProceso int,
@Permisos varchar(10),
@Estado bit,
@Mensaje varchar(100) out
As Begin
	begin try
		if(@IdRolProceso>0)
			if(exists(select * from RolProceso where IdRolProceso=@IdRolProceso))
				begin
					Update RolProceso set Permisos=@Permisos, Estado=@Estado where IdRolProceso=@IdRolProceso
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Proceso para este rol ya existe'
		else
			Set @Mensaje='Ingrese un rol o proceso valido'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[MOdificarUsuario]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MOdificarUsuario]
@IdUsuario int,
@NomUsuario Varchar(25),
@Contrasena Varchar(300),
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NomUsuario from Usuario where NomUsuario=@NomUsuario and IdUsuario!=@IdUsuario))
				if(exists(select nomUsuario from Usuario where IdUsuario=@IdUsuario and Contrasena=@Contrasena))
					begin
						update Usuario set NomUsuario=@NomUsuario where IdUsuario = @IdUsuario
						Set @Mensaje='1'
					end
				else
					set @Mensaje='Tu contraseña no es Valida'
		else
			set @Mensaje='Ya esxiste un usuario con este nombre'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
