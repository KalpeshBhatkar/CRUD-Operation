USE [CRUD_Practice]
GO

/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 17/11/2019 4:34:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CustomerMaster](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[MobileNo] [varchar](15) NULL,
	[Gender] [varchar](15) NULL,
	[EmailID] [varchar](250) NULL,
	[CreatedID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedID] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedID] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_CustomerMaster] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


