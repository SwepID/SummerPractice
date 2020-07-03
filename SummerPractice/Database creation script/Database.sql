USE [master]
GO
/****** Object:  Database [UserSkills]    Script Date: 03.07.2020 19:46:13 ******/
CREATE DATABASE [UserSkills]
GO
ALTER DATABASE [UserSkills] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserSkills] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserSkills] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserSkills] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserSkills] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserSkills] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserSkills] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserSkills] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserSkills] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserSkills] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserSkills] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserSkills] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserSkills] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserSkills] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserSkills] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserSkills] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserSkills] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserSkills] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserSkills] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserSkills] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserSkills] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserSkills] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserSkills] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UserSkills] SET  MULTI_USER 
GO
ALTER DATABASE [UserSkills] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserSkills] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserSkills] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserSkills] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserSkills] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UserSkills] SET QUERY_STORE = OFF
GO
USE [UserSkills]
DROP TABLE IF EXISTS Skill
DROP TABLE IF EXISTS [User]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[skillName] [varchar](255) NOT NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[skillName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[login] [varchar](255) NOT NULL,
	[fname] [varchar](255) NOT NULL,
	[sname] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddSkill]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSkill]
	@skillName varchar(255),
	@description varchar(255)
AS
SET NOCOUNT ON
insert into dbo.Skill(skillName, description) values(@skillName, @description);
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
@login varchar(255),
@fname varchar(255),
@sname varchar(255),
@password varchar(255)
AS
	insert into dbo.[User](login, fname, sname, password) values (@login, @fname, @sname, @password)
GO
/****** Object:  StoredProcedure [dbo].[GetAllSkills]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSkills]
AS
	select * from dbo.Skill
GO
/****** Object:  StoredProcedure [dbo].[GetSkill]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSkill]
	@skillName varchar(255)
AS
select * from dbo.Skill where @skillName = skillName
GO
/****** Object:  StoredProcedure [dbo].[RemoveSkill]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveSkill]
	@skillName varchar(255)
AS
delete from dbo.Skill where @skillName = dbo.Skill.skillName
GO
/****** Object:  StoredProcedure [dbo].[UpdateSkillDescription]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSkillDescription]
	@skillName varchar(255),
	@newDescription varchar(255)
AS
update dbo.Skill set description = @newDescription where skillName = @skillName
GO
/****** Object:  StoredProcedure [dbo].[UpdateSkillName]    Script Date: 03.07.2020 19:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSkillName]
	@oldName varchar(255),
	@newName varchar(255)
AS
update dbo.Skill set skillName = @newName where skillName = @oldName
GO
USE [master]
GO
ALTER DATABASE [UserSkills] SET  READ_WRITE 
GO
