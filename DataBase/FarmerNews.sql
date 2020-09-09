USE [FarmerNews]
GO
/****** Object:  Table [dbo].[USER_GROUPS]    Script Date: 20.4.2020 04:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_GROUPS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[RANK] [nvarchar](50) NULL,
	[ISAUTOMATIC_CATEGORY] [bit] NULL,
	[ISACTIVE] [bit] NULL,
	[ISDELETE] [bit] NULL,
 CONSTRAINT [PK_USER_GROUPS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 20.4.2020 04:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERTYPEID] [int] NOT NULL,
	[GROUPID] [int] NOT NULL,
	[EMAIL] [nvarchar](50) NOT NULL,
	[FIRST_NAME] [nvarchar](50) NOT NULL,
	[LAST_NAME] [nvarchar](50) NOT NULL,
	[PASSWORD] [nvarchar](20) NOT NULL,
	[PHONE] [nvarchar](50) NULL,
	[PICTURE] [nvarchar](50) NULL,
	[CREATED] [datetime] NULL,
	[MODIFIED] [datetime] NULL,
	[ISACTIVE] [bit] NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_USERGROUP]    Script Date: 20.4.2020 04:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_USERGROUP]
AS
SELECT        dbo.USER_GROUPS.NAME, dbo.USER_GROUPS.ID, dbo.USERS.ID AS userid, dbo.USERS.EMAIL, dbo.USERS.LAST_NAME
FROM            dbo.USER_GROUPS INNER JOIN
                         dbo.USERS ON dbo.USER_GROUPS.ID = dbo.USERS.GROUPID
GO
/****** Object:  View [dbo].[VW_DETALHESREGIOES]    Script Date: 20.4.2020 04:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[VW_DETALHESREGIOES]
AS
SELECT R.IdRegiao, R.NomeRegiao, QtdEstados = COUNT(1)
FROM dbo.Regioes R
INNER JOIN dbo.Estados E ON E.IdRegiao = R.IdRegiao
GROUP BY R.IdRegiao, R.NomeRegiao

GO
/****** Object:  Table [dbo].[BACKEND_MENUS]    Script Date: 20.4.2020 04:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BACKEND_MENUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MENU_GROUP_NUMBER] [int] NULL,
	[NAME] [nvarchar](50) NULL,
	[LINK] [nvarchar](50) NULL,
	[PICTURE] [nvarchar](50) NULL,
	[ISMANAGER] [bit] NULL,
	[ISACTIVE] [bit] NULL,
 CONSTRAINT [PK_BACKEND_MENUS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_AUTHORIZATIONS]    Script Date: 20.4.2020 04:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_AUTHORIZATIONS](
	[BAKEND_MENU_ID] [int] NOT NULL,
	[GROUPID] [int] NOT NULL,
	[ISDELETE] [bit] NULL,
	[ISLIST] [bit] NULL,
	[ISSAVE] [bit] NULL,
	[ISUPDATE] [bit] NULL,
	[CREATED] [date] NULL,
	[MODIFIED] [date] NULL,
 CONSTRAINT [PK_USER_AUTHORIZATIONS] PRIMARY KEY CLUSTERED 
(
	[BAKEND_MENU_ID] ASC,
	[GROUPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_TYPES]    Script Date: 20.4.2020 04:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_TYPES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_USER_TYPES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BACKEND_MENUS] ON 
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (1, 0, N'Genel İşlemler', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (2, 1, N'Genel Bilgiler', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (3, 1, N'Profil Ayarları', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (4, 1, N'Site Ayarları', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (5, 1, N'Sms Ayarları', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (6, 0, N'Grup ve Yetki İşlemleri', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (7, 6, N'Grup Tanımlama', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (8, 6, N'Kategori Yetkilendirme', NULL, NULL, 0, 1)
GO
INSERT [dbo].[BACKEND_MENUS] ([ID], [MENU_GROUP_NUMBER], [NAME], [LINK], [PICTURE], [ISMANAGER], [ISACTIVE]) VALUES (9, 6, N'Kullanıcı Tanımlam', NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[BACKEND_MENUS] OFF
GO
INSERT [dbo].[USER_AUTHORIZATIONS] ([BAKEND_MENU_ID], [GROUPID], [ISDELETE], [ISLIST], [ISSAVE], [ISUPDATE], [CREATED], [MODIFIED]) VALUES (1, 4224, 1, 0, 1, 1, CAST(N'2020-04-19' AS Date), CAST(N'2020-04-19' AS Date))
GO
INSERT [dbo].[USER_AUTHORIZATIONS] ([BAKEND_MENU_ID], [GROUPID], [ISDELETE], [ISLIST], [ISSAVE], [ISUPDATE], [CREATED], [MODIFIED]) VALUES (2, 4047, 1, 1, 1, 0, CAST(N'2020-04-19' AS Date), CAST(N'2020-04-19' AS Date))
GO
INSERT [dbo].[USER_AUTHORIZATIONS] ([BAKEND_MENU_ID], [GROUPID], [ISDELETE], [ISLIST], [ISSAVE], [ISUPDATE], [CREATED], [MODIFIED]) VALUES (2, 4227, 1, 1, 1, 0, CAST(N'2020-04-19' AS Date), CAST(N'2020-04-19' AS Date))
GO
SET IDENTITY_INSERT [dbo].[USER_GROUPS] ON 
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (1, N'Group 1', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (2, N'Group 2', NULL, 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (5, N'Group 3', NULL, 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (9, N'Group 4', NULL, 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (10, N'Group 6', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (11, N'Group 7', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (12, N'Sabri Uzun', NULL, 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (13, N'Group 8', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (14, N'Group 9', NULL, 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (15, N'Group 10', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (16, N'Group 11', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (1012, N'Group 13', NULL, 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (3013, N'test', NULL, 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (3014, N'test 111124', N'555', 1, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4044, N'Test 1', N'5', 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4045, N'Test2', N'66', 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4047, N'Test2', N'66', 0, 1, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4217, N'Eyüp 21', N'21', 0, 1, 1)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4218, N'Eyüp 31', N'31', 0, 1, 1)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4219, N'Eyüp 41', N'14', 0, 1, 1)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4223, N'Eyüp Ensar 12', N'751', 0, 0, 0)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4224, N'1 Eyüp Ensar 12', N'751', NULL, NULL, NULL)
GO
INSERT [dbo].[USER_GROUPS] ([ID], [NAME], [RANK], [ISAUTOMATIC_CATEGORY], [ISACTIVE], [ISDELETE]) VALUES (4227, N'2 Eyüp Ensar 2', N'851', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[USER_GROUPS] OFF
GO
SET IDENTITY_INSERT [dbo].[USER_TYPES] ON 
GO
INSERT [dbo].[USER_TYPES] ([ID], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[USER_TYPES] ([ID], [Name]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[USER_TYPES] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 
GO
INSERT [dbo].[USERS] ([ID], [USERTYPEID], [GROUPID], [EMAIL], [FIRST_NAME], [LAST_NAME], [PASSWORD], [PHONE], [PICTURE], [CREATED], [MODIFIED], [ISACTIVE]) VALUES (1, 1, 1012, N'yakupvarol@gmail.com', N'Yakup', N'Varol', N'1234567', N'02165432156', NULL, CAST(N'2019-09-23T15:50:24.980' AS DateTime), CAST(N'2019-09-23T15:50:24.980' AS DateTime), 1)
GO
INSERT [dbo].[USERS] ([ID], [USERTYPEID], [GROUPID], [EMAIL], [FIRST_NAME], [LAST_NAME], [PASSWORD], [PHONE], [PICTURE], [CREATED], [MODIFIED], [ISACTIVE]) VALUES (2, 2, 1012, N'sabriuzun@gmail.com', N'Sabri', N'Uzun', N'123', N'02165432157', NULL, CAST(N'2019-12-19T15:06:33.777' AS DateTime), CAST(N'2019-12-19T15:06:33.777' AS DateTime), 1)
GO
INSERT [dbo].[USERS] ([ID], [USERTYPEID], [GROUPID], [EMAIL], [FIRST_NAME], [LAST_NAME], [PASSWORD], [PHONE], [PICTURE], [CREATED], [MODIFIED], [ISACTIVE]) VALUES (3, 1, 1012, N'fatihbak@gmail.com', N'Fatih', N'Bak', N'123467', N'02165432157', NULL, CAST(N'2019-12-19T15:07:20.640' AS DateTime), CAST(N'2019-12-19T15:07:20.640' AS DateTime), 1)
GO
INSERT [dbo].[USERS] ([ID], [USERTYPEID], [GROUPID], [EMAIL], [FIRST_NAME], [LAST_NAME], [PASSWORD], [PHONE], [PICTURE], [CREATED], [MODIFIED], [ISACTIVE]) VALUES (4, 1, 1012, N'yunussaribulut@gmail.com', N'Yunus', N'Sarıbulut', N'12345', N'02165432157', NULL, CAST(N'2019-12-19T15:08:05.577' AS DateTime), CAST(N'2019-12-19T15:08:05.577' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
ALTER TABLE [dbo].[BACKEND_MENUS] ADD  CONSTRAINT [DF_BACKEND_MENUS_MENU_GROUP_NUMBER]  DEFAULT ((0)) FOR [MENU_GROUP_NUMBER]
GO
ALTER TABLE [dbo].[BACKEND_MENUS] ADD  CONSTRAINT [DF_BACKEND_MENUS_ISMANAGER]  DEFAULT ((0)) FOR [ISMANAGER]
GO
ALTER TABLE [dbo].[BACKEND_MENUS] ADD  CONSTRAINT [DF_BACKEND_MENUS_ISACTIVE]  DEFAULT ((0)) FOR [ISACTIVE]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_Table_1_ISACTIVE]  DEFAULT ((0)) FOR [GROUPID]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_USER_AUTHORIZATIONS_ISDELETE]  DEFAULT ((0)) FOR [ISDELETE]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_USER_AUTHORIZATIONS_ISLIST]  DEFAULT ((0)) FOR [ISLIST]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_USER_AUTHORIZATIONS_ISSAVE]  DEFAULT ((0)) FOR [ISSAVE]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_USER_AUTHORIZATIONS_ISUPDATE]  DEFAULT ((0)) FOR [ISUPDATE]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_USER_AUTHORIZATIONS_CREATED]  DEFAULT (getdate()) FOR [CREATED]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] ADD  CONSTRAINT [DF_USER_AUTHORIZATIONS_MODIFIED]  DEFAULT (getdate()) FOR [MODIFIED]
GO
ALTER TABLE [dbo].[USER_GROUPS] ADD  CONSTRAINT [DF_USER_GROUPS_ISAUTOMATIC_CATEGORY]  DEFAULT ((0)) FOR [ISAUTOMATIC_CATEGORY]
GO
ALTER TABLE [dbo].[USER_GROUPS] ADD  CONSTRAINT [DF_USER_GROUPS_ISACTIVE]  DEFAULT ((0)) FOR [ISACTIVE]
GO
ALTER TABLE [dbo].[USER_GROUPS] ADD  CONSTRAINT [DF_USER_GROUPS_ISDELETE_1]  DEFAULT ((0)) FOR [ISDELETE]
GO
ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_USER_TYPE]  DEFAULT ((0)) FOR [USERTYPEID]
GO
ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_GROUP_CODE]  DEFAULT ((0)) FOR [GROUPID]
GO
ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_CREATED]  DEFAULT (getdate()) FOR [CREATED]
GO
ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_MODIFIED]  DEFAULT (getdate()) FOR [MODIFIED]
GO
ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_ISACTIVE]  DEFAULT ((1)) FOR [ISACTIVE]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS]  WITH CHECK ADD  CONSTRAINT [FK_USER_AUTHORIZATIONS_BACKEND_MENUS] FOREIGN KEY([BAKEND_MENU_ID])
REFERENCES [dbo].[BACKEND_MENUS] ([ID])
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] CHECK CONSTRAINT [FK_USER_AUTHORIZATIONS_BACKEND_MENUS]
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS]  WITH CHECK ADD  CONSTRAINT [FK_USER_AUTHORIZATIONS_USER_GROUPS] FOREIGN KEY([GROUPID])
REFERENCES [dbo].[USER_GROUPS] ([ID])
GO
ALTER TABLE [dbo].[USER_AUTHORIZATIONS] CHECK CONSTRAINT [FK_USER_AUTHORIZATIONS_USER_GROUPS]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_USERS_USER_GROUPS1] FOREIGN KEY([GROUPID])
REFERENCES [dbo].[USER_GROUPS] ([ID])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_USER_GROUPS1]
GO
ALTER TABLE [dbo].[USERS]  WITH CHECK ADD  CONSTRAINT [FK_USERS_USER_TYPES] FOREIGN KEY([USERTYPEID])
REFERENCES [dbo].[USER_TYPES] ([ID])
GO
ALTER TABLE [dbo].[USERS] CHECK CONSTRAINT [FK_USERS_USER_TYPES]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "USER_GROUPS"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 174
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "USERS"
            Begin Extent = 
               Top = 6
               Left = 308
               Bottom = 136
               Right = 478
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_USERGROUP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_USERGROUP'
GO
