USE [PharmacyDroneDB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2019/11/04 19:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drone]    Script Date: 2019/11/04 19:52:34 ******/
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
/****** Object:  Table [dbo].[MedicalSupply]    Script Date: 2019/11/04 19:52:34 ******/
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
/****** Object:  Table [dbo].[OrderRequests]    Script Date: 2019/11/04 19:52:34 ******/
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
	[DestLat] [float] NOT NULL,
	[DestLong] [float] NOT NULL,
	[OrderStatus] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 2019/11/04 19:52:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NOT NULL,
	[PatientSurname] [varchar](50) NOT NULL,
	[PatientContact] [varchar](50) NOT NULL,
	[PatientAddress] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019/11/04 19:52:34 ******/
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
SET IDENTITY_INSERT [dbo].[MedicalSupply] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (1, N'Brandon', N'1234', 1, 2)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (2, N'Anthony', N'1234', 0, 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [AccountType], [AccountState]) VALUES (3, N'Johan', N'1234', 0, 2)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[OrderRequests] ADD  DEFAULT ((0)) FOR [OrderStatus]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [AccountType]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [AccountState]
GO
