USE [MyDB]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220324140159_Initial', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220326002634_secondMigration', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (8, 2, CAST(23.00 AS Decimal(18, 2)), N'StoreA', N'CustumerA', CAST(N'2022-03-25T00:00:00.0000000' AS DateTime2), 10)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (9, 1, CAST(17.33 AS Decimal(18, 2)), N'StoreA', N'CustumerB', CAST(N'2022-03-24T18:51:28.4810000' AS DateTime2), 10)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (12, 3, CAST(44.88 AS Decimal(18, 2)), N'StoreB', N'CustumerA', CAST(N'2022-03-24T22:38:20.5620000' AS DateTime2), 10)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (13, 4, CAST(232.00 AS Decimal(18, 2)), N'StoreB', N'CustumerC', CAST(N'2022-12-21T00:00:00.0000000' AS DateTime2), 20)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (14, 5, CAST(3032.25 AS Decimal(18, 2)), N'StoreC', N'CustumerA', CAST(N'2022-03-25T22:27:04.5830000' AS DateTime2), 10)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (15, 5, CAST(444.00 AS Decimal(18, 2)), N'StoreD', N'CustumerD', CAST(N'2022-03-25T22:28:39.7170000' AS DateTime2), 10)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (16, 3, CAST(444.00 AS Decimal(18, 2)), N'StoreA', N'CustumerB', CAST(N'2022-03-25T22:28:39.7170000' AS DateTime2), 40)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (17, 2, CAST(23.00 AS Decimal(18, 2)), N'StoreC', N'CustumerD', CAST(N'2022-03-25T00:00:00.0000000' AS DateTime2), 10)
INSERT [dbo].[Order] ([Id], [BrandId], [Price], [StoreName], [CustomerName], [CreatedOn], [Status]) VALUES (18, 3, CAST(34.00 AS Decimal(18, 2)), N'StoreB', N'CustumerA', CAST(N'2022-03-25T00:00:00.0000000' AS DateTime2), 50)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
