USE [master]
GO
/****** Object:  Database [PM]    Script Date: 10/14/2020 17:23:08 ******/
CREATE DATABASE [PM] ON  PRIMARY 
( NAME = N'ProjectManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ProjectManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ProjectManagement_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PM] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PM] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PM] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PM] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PM] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PM] SET ARITHABORT OFF
GO
ALTER DATABASE [PM] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [PM] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [PM] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [PM] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [PM] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [PM] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [PM] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [PM] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [PM] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [PM] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [PM] SET  DISABLE_BROKER
GO
ALTER DATABASE [PM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [PM] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [PM] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [PM] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [PM] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [PM] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [PM] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [PM] SET  READ_WRITE
GO
ALTER DATABASE [PM] SET RECOVERY FULL
GO
ALTER DATABASE [PM] SET  MULTI_USER
GO
ALTER DATABASE [PM] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [PM] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'PM', N'ON'
GO
USE [PM]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 10/14/2020 17:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[pr_id] [int] IDENTITY(1,1) NOT NULL,
	[pr_name] [nvarchar](max) NOT NULL,
	[pr_belong] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10/14/2020 17:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[mn_id] [int] NOT NULL,
	[mn_tid] [int] NULL,
	[mn_pid] [int] NULL,
	[mn_name] [nvarchar](max) NULL,
	[mn_link] [nvarchar](max) NULL,
	[mn_order] [int] NULL,
	[mn_level] [int] NULL,
	[mn_onoff] [int] NULL,
	[mn_key] [nvarchar](max) NULL,
 CONSTRAINT [PK_prj_menu] PRIMARY KEY CLUSTERED 
(
	[mn_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顶级菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_tid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_pid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_link'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_onoff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'mn_key'
GO
/****** Object:  Table [dbo].[Finance]    Script Date: 10/14/2020 17:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Finance](
	[sf_id] [int] IDENTITY(1,1) NOT NULL,
	[sf_collectpay] [int] NULL,
	[sf_prid] [int] NULL,
	[sf_cnid] [int] NULL,
	[sf_date] [date] NULL,
	[sf_money] [money] NULL,
	[sf_account] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 10/14/2020 17:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ct_id] [int] IDENTITY(1,1) NOT NULL,
	[ct_name] [nvarchar](max) NOT NULL,
	[ct_belong] [int] NOT NULL,
	[ct_prid] [int] NOT NULL,
	[ct_no] [nvarchar](max) NOT NULL,
	[ct_clid] [int] NOT NULL,
	[ct_money] [money] NOT NULL,
	[ct_date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 10/14/2020 17:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[cl_id] [int] IDENTITY(1,1) NOT NULL,
	[cl_name] [nvarchar](max) NOT NULL,
	[cl_person] [nvarchar](max) NULL,
	[cl_tel] [nvarchar](max) NULL,
	[cl_address] [nvarchar](max) NULL,
	[cl_code] [nvarchar](max) NULL,
	[cl_bank] [nvarchar](max) NULL,
	[cl_account] [nvarchar](max) NULL,
	[cl_belong] [nvarchar](max) NULL,
 CONSTRAINT [PK_contract_a] PRIMARY KEY CLUSTERED 
(
	[cl_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
