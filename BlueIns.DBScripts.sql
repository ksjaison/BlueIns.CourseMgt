USE [master]
GO
/****** Object:  Database [StudentCourseRegSystem]    Script Date: 30-05-2022 16:22:35 ******/
CREATE DATABASE [StudentCourseRegSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentCourseRegSystem', FILENAME = N'C:\Users\Dell\StudentCourseRegSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentCourseRegSystem_log', FILENAME = N'C:\Users\Dell\StudentCourseRegSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StudentCourseRegSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentCourseRegSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentCourseRegSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentCourseRegSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentCourseRegSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentCourseRegSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentCourseRegSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentCourseRegSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [StudentCourseRegSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentCourseRegSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StudentCourseRegSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentCourseRegSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentCourseRegSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentCourseRegSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentCourseRegSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentCourseRegSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StudentCourseRegSystem] SET QUERY_STORE = OFF
GO
USE [StudentCourseRegSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseDetails]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseDetails](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[TeacherName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[NoofSeats] [int] NOT NULL,
	[LastUpdatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CourseDetails] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegDetails]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegDetails](
	[RegId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LastUpdatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RegDetails] PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDetails]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[SurName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](1) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NULL,
	[Address3] [nvarchar](100) NULL,
	[LastUpdatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StudentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_RegDetails_CourseId]    Script Date: 30-05-2022 16:22:35 ******/
CREATE NONCLUSTERED INDEX [IX_RegDetails_CourseId] ON [dbo].[RegDetails]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RegDetails_Id]    Script Date: 30-05-2022 16:22:35 ******/
CREATE NONCLUSTERED INDEX [IX_RegDetails_Id] ON [dbo].[RegDetails]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RegDetails]  WITH CHECK ADD  CONSTRAINT [FK_RegDetails_CourseDetails_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseDetails] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegDetails] CHECK CONSTRAINT [FK_RegDetails_CourseDetails_CourseId]
GO
ALTER TABLE [dbo].[RegDetails]  WITH CHECK ADD  CONSTRAINT [FK_RegDetails_StudentDetails_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[StudentDetails] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegDetails] CHECK CONSTRAINT [FK_RegDetails_StudentDetails_Id]
GO
/****** Object:  StoredProcedure [dbo].[CreateRegDetails]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRegDetails]
    @CourseId int,
    @Id int
AS
BEGIN
    SET NOCOUNT ON;
    Insert into [dbo].[RegDetails]
           ([Id]
		   ,[CourseId]
           ,[LastUpdatedDate]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[UpdatedBy]
           ,[UpdateDate])
 Values (@CourseId, @Id,'2022-05-01 20:32:00.0000000','Jai','2022-05-01 20:32:00.0000000','Jai','2022-05-01 20:32:00.0000000')
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CourseMappedForEachStudent]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaison KS
-- Create date: 30 May 2022
-- Description:	Show registered courses for each student
-- Exec sp_CourseMappedForEachStudent
-- =============================================
CREATE PROCEDURE [dbo].[sp_CourseMappedForEachStudent] 
	--@StudentId int
AS
BEGIN

	--SELECT @StudentId = 1

	SELECT 
		Reg.RegId
		,Reg.Id
		,Reg.CourseId
		,St.FirstName
		,St.SurName
		,Co.CourseName
		,Co.NoofSeats
		,Co.TeacherName
	FROM 
		RegDetails Reg
	INNER JOIN 
		StudentDetails St
	ON 
		Reg.Id = St.Id
	INNER JOIN
		CourseDetails Co
	ON 
		Reg.CourseId = Co.CourseId
	--WHERE
	--	St.Id = @StudentId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CourseSpaceAvailability]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaison KS
-- Create date: 30 May 2022
-- Description:	Show how many courses still have the space
-- Exec sp_CourseSpaceAvailability
-- =============================================
CREATE PROCEDURE [dbo].[sp_CourseSpaceAvailability]
AS
BEGIN
	SELECT 
		Co.CourseId, 
		Co.CourseName 
	FROM 
		CourseDetails Co 
	WHERE 
		Co.NoofSeats != (SELECT count(CourseId) 
							FROM 
								RegDetails 
							WHERE 
								CourseId = Co.CourseId)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentDontHaveMaxRegCourse]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaison KS
-- Create date: 30 May 2022
-- Description:	Show how many students didn’t register max course
-- Exec sp_StudentDontHaveMaxRegCourse
-- =============================================
CREATE PROCEDURE [dbo].[sp_StudentDontHaveMaxRegCourse]
AS
BEGIN
	SELECT 
		count(St.Id),
		St.FirstName,
		St.SurName
	FROM 
		StudentDetails St
	LEFT JOIN 
		RegDetails Reg
	ON 
		St.Id = Reg.Id
	GROUP BY 
		St.Id, St.FirstName,St.SurName
	HAVING COUNT(St.Id) < 5
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentListForEachCourse]    Script Date: 30-05-2022 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaison KS
-- Create date: 30 May 2022
-- Description:	Show student list for each courses
-- Exec sp_StudentListForEachCourse 1
-- =============================================
CREATE PROCEDURE [dbo].[sp_StudentListForEachCourse]
(
@CourseId int
)
AS

BEGIN
	
	SELECT 
		Reg.RegId, 
		Reg.Id, 
		Reg.CourseId,
		St.FirstName, 
		St.SurName, 
		Co.CourseName, 
		Co.NoofSeats, 
		Co.TeacherName
	FROM 
		RegDetails Reg
	INNER JoIN 
		StudentDetails St
	ON 
		Reg.Id = St.Id

	INNER JOIN 
		CourseDetails Co
	ON 
		Reg.CourseId = Co.CourseId
	WHERE
		Co.CourseId = @CourseId
END
GO
USE [master]
GO
ALTER DATABASE [StudentCourseRegSystem] SET  READ_WRITE 
GO
