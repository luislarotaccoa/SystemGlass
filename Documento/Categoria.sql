/****** Object:  Table [dbo].[Categoria]    Script Date: 29/04/2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NomCategoria] [varchar](100) NOT NULL,
	[Bilateral] [bit] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCategoria]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RegistrarCategoria]
@NomCategoria Varchar(50),
@Bilateral bit,
@Mensaje Varchar(50)  Out
As Begin
	begin try
		if(@NomCategoria<>null or @NomCategoria<>'')
			if(not exists(select NomCategoria from Categoria where NomCategoria=@NomCategoria))
				begin
					Insert into Categoria Values(@NomCategoria,@Bilateral,1)
					Set @Mensaje='1'
				end
			else
				Set @Mensaje='Este Categoría ya existe'
		else
			Set @Mensaje='No ingreso categoría'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoria]    Script Date: 29/04/2021 20:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificarCategoria]
@IdCategoria int,
@NomCategoria Varchar(100),
@Bilateral bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		if(not exists(select NomCategoria from Categoria where NomCategoria = @NomCategoria and IdCategoria!=@IdCategoria))
				begin
					update Categoria set 
					NomCategoria=@NomCategoria,
					Bilateral=@Bilateral
					where IdCategoria=@IdCategoria
					Set @Mensaje='1'
				end
		else
			set @Mensaje='Este categoria ya existe'
	end try
	begin catch
		set @Mensaje=(select ERROR_MESSAGE())
	end catch
End
GO

create proc [dbo].[EliminarCategoria]
@IdCategoria int,
@Estado bit,
@Mensaje Varchar(100)  Out
As Begin
	begin try
		Update Categoria Set Estado=@Estado
		Where IdCategoria=@IdCategoria
		Set @Mensaje='1'
	end try
	Begin Catch
		Set @Mensaje=(Select ERROR_MESSAGE())
	End Catch
End
go
create proc [dbo].[ListarCategoria]
As
Select IdCategoria,NomCategoria,Bilateral,Estado from Categoria