USE [PharmacyDroneDB]
GO
/****** Object:  Table [dbo].[Drone]    Script Date: 2019/11/28 13:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drone](
	[DroneID] [int] IDENTITY(1,1) NOT NULL,
	[DroneName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DroneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalSupply]    Script Date: 2019/11/28 13:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalSupply](
	[MedicalSupplyID] [int] IDENTITY(1,1) NOT NULL,
	[MedicalSupplyName] [varchar](20) NOT NULL,
	[MedicalSupplyType] [varchar](10) NOT NULL,
	[MedicalSupplyDesc] [varchar](50) NOT NULL,
	[MedicalSupplyPrice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicalSupplyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderRequests]    Script Date: 2019/11/28 13:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderRequests](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNum] [int] NOT NULL,
	[MedicalSupplyID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[DroneID] [int] NOT NULL,
	[DestLat] [varchar](50) NOT NULL,
	[DestLong] [varchar](50) NOT NULL,
	[OrderStatus] [int] NOT NULL,
 CONSTRAINT [PK_OrderRequests] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019/11/28 13:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[AccountType] [int] NOT NULL,
	[AccountState] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Drone] ON 

INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (1, N'FastFlyer')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (2, N'QuickDrone')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (3, N'Zoom')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (4, N'Fleeting')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (5, N'Gummie')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (6, N'EmergencyDrone')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (7, N'BackupDrone')
INSERT [dbo].[Drone] ([DroneID], [DroneName]) VALUES (8, N'IncrediDrone')
SET IDENTITY_INSERT [dbo].[Drone] OFF
SET IDENTITY_INSERT [dbo].[MedicalSupply] ON 

INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (1, N'Adderall 30mg', N'Pill', N'Used to treat ADHD', 300)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (3, N'Xanax 30mg', N'Pill', N'Used to treat Anxiety', 400)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (4, N'Codeine 15mg', N'Pill', N'Used to treat sever pain', 500)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (5, N'Lexapro 20mg', N'Pill', N'Used to treat Anxiety', 350)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (6, N'Oxycodone 30mg', N'Pill', N'Used to treat severe pain', 450)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (8, N'Baclofen 30mg', N'Pill', N'Used to treat muscle symptoms', 360)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (9, N'O+ Blood Bag', N'Blood', N'Used for O+,A+,B+,AB+', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (10, N'O- Blood Bag', N'Blood', N'Used for all blood types', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (13, N'A+ Blood Bag', N'Blood', N'Used for A+,AB+', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (15, N'A- Blood Bag', N'Blood', N'Used for A+,A-,AB+,AB-', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (16, N'B+ Blood Bag', N'Blood', N'Used for B+,AB+', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (17, N'B- Blood Bag', N'Blood', N'Used for B+,B-,AB+,AB-', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (18, N'AB+ Blood Bag', N'Blood', N'Used for AB+', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (19, N'AB- Blood Bag', N'Blood', N'Used for AB+,AB-', 800)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (20, N'Penicillin', N'Antibiotic', N'Used to fight bacteria in the body', 650)
INSERT [dbo].[MedicalSupply] ([MedicalSupplyID], [MedicalSupplyName], [MedicalSupplyType], [MedicalSupplyDesc], [MedicalSupplyPrice]) VALUES (1020, N'Oxiecotine', N'Pill', N'Used to treat pain', 250)
SET IDENTITY_INSERT [dbo].[MedicalSupply] OFF
SET IDENTITY_INSERT [dbo].[OrderRequests] ON 

INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (3, 16, 6, 3, 3, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (4, 16, 16, 3, 3, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (5, 39, 1, 3, 1, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (6, 39, 9, 3, 1, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (7, 84, 10, 3, 7, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (8, 84, 19, 3, 7, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (9, 17, 9, 3, 2, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (10, 17, 16, 3, 2, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (11, 19, 9, 3, 3, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (12, 19, 10, 3, 3, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (1011, 25, 1, 3, 1, N'-26,1482', N'28,0976', 2)
INSERT [dbo].[OrderRequests] ([OrderID], [OrderNum], [MedicalSupplyID], [UserID], [DroneID], [DestLat], [DestLong], [OrderStatus]) VALUES (1012, 25, 8, 3, 1, N'-26,1482', N'28,0976', 2)
SET IDENTITY_INSERT [dbo].[OrderRequests] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (1, N'Brandon', N'1234', 1, 2)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (2, N'Anthony', N'1234', 0, 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (3, N'Johan', N'1234', 0, 2)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (4, N'Help', N'1234', 0, 2)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (5, N'Helper', N'1234', 0, 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (6, N'helpers', N'1234', 0, 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (7, N'Mohammed', N'1234', 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[OrderRequests] ADD  CONSTRAINT [DF__OrderRequ__Order__403A8C7D]  DEFAULT ((0)) FOR [OrderStatus]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [AccountType]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [AccountState]
GO
ALTER TABLE [dbo].[OrderRequests]  WITH CHECK ADD  CONSTRAINT [FK_OrderRequests_Drone] FOREIGN KEY([DroneID])
REFERENCES [dbo].[Drone] ([DroneID])
GO
ALTER TABLE [dbo].[OrderRequests] CHECK CONSTRAINT [FK_OrderRequests_Drone]
GO
ALTER TABLE [dbo].[OrderRequests]  WITH CHECK ADD  CONSTRAINT [FK_OrderRequests_MedicalSupply] FOREIGN KEY([MedicalSupplyID])
REFERENCES [dbo].[MedicalSupply] ([MedicalSupplyID])
GO
ALTER TABLE [dbo].[OrderRequests] CHECK CONSTRAINT [FK_OrderRequests_MedicalSupply]
GO
ALTER TABLE [dbo].[OrderRequests]  WITH CHECK ADD  CONSTRAINT [FK_OrderRequests_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[OrderRequests] CHECK CONSTRAINT [FK_OrderRequests_User]
GO
