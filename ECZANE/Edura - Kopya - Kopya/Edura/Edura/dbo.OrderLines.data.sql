SET IDENTITY_INSERT [dbo].[OrderLines] ON
INSERT INTO [dbo].[OrderLines] ([OrderLineId], [OrderId], [Price], [ProductId], [Quantity]) VALUES (1, 1, 58, 1, 1)
INSERT INTO [dbo].[OrderLines] ([OrderLineId], [OrderId], [Price], [ProductId], [Quantity]) VALUES (2, 1, 67, 2, 1)
SET IDENTITY_INSERT [dbo].[OrderLines] OFF
