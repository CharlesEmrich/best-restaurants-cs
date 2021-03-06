USE [best_restaurants]
GO
/****** Object:  Table [dbo].[cuisines]    Script Date: 6/7/2017 4:23:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuisines](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[restaurants]    Script Date: 6/7/2017 4:23:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restaurants](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[price_range] [varchar](10) NULL,
	[happy_hour] [bit] NULL,
	[cuisine_id] [int] NULL
) ON [PRIMARY]

GO
