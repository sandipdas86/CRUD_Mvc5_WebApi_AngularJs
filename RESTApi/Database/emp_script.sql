USE [RegisterDB]
GO
/****** Object:  Table [dbo].[TblEmployee]    Script Date: 11/10/2017 21:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblEmployee](
	[Emp_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Sex] [varchar](10) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[City] [int] NOT NULL,
	[Address] [varchar](max) NOT NULL,
 CONSTRAINT [PK__TblEmplo__262359AB164452B1] PRIMARY KEY CLUSTERED 
(
	[Emp_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmpDetails_SP]    Script Date: 11/10/2017 21:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateEmpDetails_SP]  
(  
   @EmpId int,  
   @Name varchar (50),  
   @Sex varchar(10),
   @DOB datetime,
   @City int,  
   @Address varchar (50)  
)  
as  
begin  
   Update TblEmployee   
   set Name=@Name, 
   Sex=@Sex,
   DOB=@DOB, 
   City=@City,  
   Address=@Address  
   where Emp_Id=@EmpId  
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmpById_SP]    Script Date: 11/10/2017 21:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteEmpById_SP]  
(  
   @EmpId int  
)  
as   
begin  
   Delete from TblEmployee where Emp_Id=@EmpId  
End
GO
/****** Object:  StoredProcedure [dbo].[AddNewEmpDetails_SP]    Script Date: 11/10/2017 21:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewEmpDetails_SP]  
(  
   @Name varchar (50),
   @Sex varchar(10),
   @DOB datetime,  
   @City int,  
   @Address varchar (50)
)  
as  
begin  
   Insert into TblEmployee values(@Name,@Sex,@DOB,@City,@Address)  
End
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees_SP]    Script Date: 11/10/2017 21:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetEmployees_SP]  
as  
begin  
   select * from TblEmployee  
End
GO
/****** Object:  StoredProcedure [dbo].[FetchState_SP]    Script Date: 11/10/2017 21:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FetchState_SP]
(
@CountryId int
)
as
begin
	if(@CountryId > 0)
	begin
	select state from TblState where Fk_CountryId = @CountryId
	end
end
GO
/****** Object:  StoredProcedure [dbo].[FetchCity_SP]    Script Date: 11/10/2017 21:42:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FetchCity_SP]
(
@StateId int
)
as
begin
	if(@StateId > 0)
	begin
	select city from TblCity where Fk_StateId = @StateId
	end
end
GO
