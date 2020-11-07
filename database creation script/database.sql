USE [master]
GO
/****** Object:  Database [FormsAuth1]    Script Date: 10.07.2020 17:31:15 ******/
CREATE DATABASE [FormsAuth1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FormsAuth1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FormsAuth1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FormsAuth1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FormsAuth1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FormsAuth1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FormsAuth1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FormsAuth1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FormsAuth1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FormsAuth1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FormsAuth1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FormsAuth1] SET ARITHABORT OFF 
GO
ALTER DATABASE [FormsAuth1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FormsAuth1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FormsAuth1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FormsAuth1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FormsAuth1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FormsAuth1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FormsAuth1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FormsAuth1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FormsAuth1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FormsAuth1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FormsAuth1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FormsAuth1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FormsAuth1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FormsAuth1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FormsAuth1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FormsAuth1] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FormsAuth1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FormsAuth1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FormsAuth1] SET  MULTI_USER 
GO
ALTER DATABASE [FormsAuth1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FormsAuth1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FormsAuth1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FormsAuth1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FormsAuth1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FormsAuth1] SET QUERY_STORE = OFF
GO
USE [FormsAuth1]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](128) NOT NULL,
	[Discriminator] [nvarchar](128) NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](128) NOT NULL,
	[Fname] [nvarchar](max) NOT NULL,
	[Sname] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Discriminator] [nvarchar](128) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSkills]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkills](
	[IdSkill] [int] NOT NULL,
	[IdUser] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_Skills] FOREIGN KEY([IdSkill])
REFERENCES [dbo].[Skills] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_Skills]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddSkill]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSkill]
	@skillName varchar(255),
	@description varchar(255)
AS
SET NOCOUNT ON
insert into dbo.Skills(SkillName, Description) 
output inserted.Id
values(@skillName, @description);
GO
/****** Object:  StoredProcedure [dbo].[AddSkillToUser]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSkillToUser]
@UserId int,
@SkillId int
AS
INSERT INTO dbo.UserSkills(IdSkill, IdUser) VALUES (@SkillId, @UserId)
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangePassword]
@idUser int,
@newPass varchar(max)
AS
UPDATE dbo.Users SET dbo.Users.Password = @newPass WHERE dbo.Users.Id = @idUser
GO
/****** Object:  StoredProcedure [dbo].[EditUserInfo]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUserInfo]
@idUser int,
@fname varchar(max),
@sname varchar(max)
AS
UPDATE dbo.Users SET dbo.Users.Fname = @fname, dbo.Users.Sname = @sname WHERE dbo.Users.Id = @idUser
GO
/****** Object:  StoredProcedure [dbo].[GetAllSkills]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSkills]
AS
	select * from dbo.Skills
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
SELECT * FROM Users
GO
/****** Object:  StoredProcedure [dbo].[GetSkill]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSkill]
	@id int
AS
select * from dbo.Skills where @id = dbo.Skills.Id
GO
/****** Object:  StoredProcedure [dbo].[GetSkillByName]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSkillByName]
	@skillName varchar(255)
AS
select * from dbo.Skills where @skillName = SkillName
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
@idUser int
AS
SELECT * FROM Users WHERE Id = @idUser
GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByLogin]
@login varchar(MAX)
AS
SELECT * FROM Users where Login = @login
GO
/****** Object:  StoredProcedure [dbo].[GetUserSkills]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserSkills]
@idUser int
AS
SELECT * FROM UserSkills JOIN Skills ON
UserSkills.IdSkill = Skills.Id WHERE UserSkills.IdUser = @idUser
GO
/****** Object:  StoredProcedure [dbo].[RemoveSkill]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveSkill]
	@id int
AS
delete from dbo.Skills where @id = dbo.Skills.Id
GO
/****** Object:  StoredProcedure [dbo].[RemoveSkillFromUser]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveSkillFromUser]
@idUser int,
@idSkill int
AS
DELETE FROM dbo.UserSkills where dbo.UserSkills.IdSkill = @idSkill AND UserSkills.IdUser = @idUser
GO
/****** Object:  StoredProcedure [dbo].[SortByName]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SortByName]
AS
SELECT * FROM dbo.Skills order by SkillName
GO
/****** Object:  StoredProcedure [dbo].[UpdateSkill]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSkill]
@SkillId int,
@SkillName varchar(max),
@Description varchar(max)
AS
UPDATE Skills SET Skills.SkillName = @SkillName, Skills.Description = @Description WHERE Skills.Id = @SkillId
GO
/****** Object:  StoredProcedure [dbo].[UpdateSkillDescription]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSkillDescription]
	@skillName varchar(255),
	@newDescription varchar(255)
AS
update dbo.Skills set Description = @newDescription where SkillName = @skillName
GO
/****** Object:  StoredProcedure [dbo].[UpdateSkillName]    Script Date: 10.07.2020 17:31:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSkillName]
	@oldName varchar(255),
	@newName varchar(255)
AS
update dbo.Skills set SkillName = @newName where SkillName = @oldName
GO
USE [master]
GO
ALTER DATABASE [FormsAuth1] SET  READ_WRITE 
GO
