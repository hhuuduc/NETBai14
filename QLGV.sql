USE [QLGV]
GO
/****** Object:  Table [dbo].[COSO]    Script Date: 19/12/2023 11:28:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COSO](
	[macoso] [int] NOT NULL,
	[tencoso] [nvarchar](50) NULL,
 CONSTRAINT [PK_COSO] PRIMARY KEY CLUSTERED 
(
	[macoso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONVI]    Script Date: 19/12/2023 11:28:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONVI](
	[madonvi] [int] NOT NULL,
	[tendonvi] [nvarchar](50) NULL,
	[macoso] [int] NULL,
 CONSTRAINT [PK_DONVI] PRIMARY KEY CLUSTERED 
(
	[madonvi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GV]    Script Date: 19/12/2023 11:28:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GV](
	[magv] [int] NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[sdt] [nchar](10) NULL,
	[ghichu] [nvarchar](max) NULL,
	[madonvi] [int] NULL,
 CONSTRAINT [PK_GV] PRIMARY KEY CLUSTERED 
(
	[magv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[COSO] ([macoso], [tencoso]) VALUES (1, N'Cơ sở 1')
INSERT [dbo].[COSO] ([macoso], [tencoso]) VALUES (2, N'Cơ sở 2')
INSERT [dbo].[COSO] ([macoso], [tencoso]) VALUES (3, N'Cơ sở 3')
INSERT [dbo].[DONVI] ([madonvi], [tendonvi], [macoso]) VALUES (1, N'Đơn vị 1', 1)
INSERT [dbo].[DONVI] ([madonvi], [tendonvi], [macoso]) VALUES (2, N'Đơn vị 2', 1)
INSERT [dbo].[DONVI] ([madonvi], [tendonvi], [macoso]) VALUES (3, N'Đơn vị 3', 2)
INSERT [dbo].[DONVI] ([madonvi], [tendonvi], [macoso]) VALUES (4, N'Đơn vị 4', 3)
INSERT [dbo].[GV] ([magv], [hoten], [sdt], [ghichu], [madonvi]) VALUES (1, N'aaaa', N'0123456789', N'aaaaaaaaaaaaaaa', 1)
INSERT [dbo].[GV] ([magv], [hoten], [sdt], [ghichu], [madonvi]) VALUES (2, N'bbbb', N'0234567891', N'bbbbbbbbbbbbbbb', 2)
INSERT [dbo].[GV] ([magv], [hoten], [sdt], [ghichu], [madonvi]) VALUES (3, N'cccc', N'0345678912', N'ccccccccccccccccccccccc', 3)
INSERT [dbo].[GV] ([magv], [hoten], [sdt], [ghichu], [madonvi]) VALUES (4, N'dddd', N'0456789123', N'ddddddddddddddddd', 4)
ALTER TABLE [dbo].[DONVI]  WITH CHECK ADD  CONSTRAINT [FK_DONVI_COSO] FOREIGN KEY([macoso])
REFERENCES [dbo].[COSO] ([macoso])
GO
ALTER TABLE [dbo].[DONVI] CHECK CONSTRAINT [FK_DONVI_COSO]
GO
ALTER TABLE [dbo].[GV]  WITH CHECK ADD  CONSTRAINT [FK_GV_DONVI] FOREIGN KEY([madonvi])
REFERENCES [dbo].[DONVI] ([madonvi])
GO
ALTER TABLE [dbo].[GV] CHECK CONSTRAINT [FK_GV_DONVI]
GO
