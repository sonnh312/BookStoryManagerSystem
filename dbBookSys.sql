

CREATE DATABASE BookSys1
GO

USE [BookSys1]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/4/2024 3:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[IdBook] [int] NOT NULL,
	[bookTitle] [nvarchar](50) NULL,
	[authorName] [nvarchar](50) NULL,
	[categoryBook] [nvarchar](50) NULL,
	[quantityInStock] [int] NULL,
	[purchasePrice] [float] NULL,
	[sellingPrice] [float] NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[IdBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Distributor]    Script Date: 2/4/2024 3:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributor](
	[IdDistributor] [int] NOT NULL,
	[distributorName] [nvarchar](50) NULL,
	[phoneNum] [int] NULL,
	[address] [nvarchar](50) NULL,
	[amountPaid] [float] NULL,
	[remaniningDebt] [float] NULL,
 CONSTRAINT [PK_Distributor] PRIMARY KEY CLUSTERED 
(
	[IdDistributor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SELECT * FROM Distributor
/****** Object:  Table [dbo].[ExportForm]    Script Date: 2/4/2024 3:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportForm](
	[idExportForm] [int] NOT NULL,
	[exportDate] [datetime] NULL,
	[IdDistributor] [int] NULL,
	[personDelivering] [nvarchar](50) NULL,
	[IdBook] [int] NULL,
	[exportQuantity] [int] NULL,
	[totalAmount] [float] NULL,
 CONSTRAINT [PK_ExportForm] PRIMARY KEY CLUSTERED 
(
	[idExportForm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SELECT * FROM ExportForm
/****** Object:  Table [dbo].[ImportForm]    Script Date: 2/4/2024 3:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportForm](
	[IdImportFrom] [int] NOT NULL,
	[importDate] [datetime] NULL,
	[idpublisher] [int] NULL,
	[personRecipient] [nvarchar](50) NULL,
	[IdBook] [int] NULL,
	[importQuantity] [int] NULL,
	[totalAmount] [float] NULL,
	[importNote] [nvarchar](50) NULL,
 CONSTRAINT [PK_ImportForm] PRIMARY KEY CLUSTERED 
(
	[IdImportFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 2/4/2024 3:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[IdPublisher] [int] NOT NULL,
	[publisherName] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phoneNum] [int] NULL,
	[accountNum] [int] NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[IdPublisher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE 
/****** Object:  Table [dbo].[Staff]    Script Date: 2/4/2024 3:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Staff](
	[IdUser] [int] NULL,
	[Displayname] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Role] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Book] ([IdBook], [bookTitle], [authorName], [categoryBook], [quantityInStock], [purchasePrice], [sellingPrice]) VALUES (1, N'Conan', N'Gosho Aoyama', N'Trinh tham', 100, 20000, 25000)
INSERT [dbo].[Book] ([IdBook], [bookTitle], [authorName], [categoryBook], [quantityInStock], [purchasePrice], [sellingPrice]) VALUES (2, N'Doraemon', N'Fujiko F Fujio', N'Hai huoc', 100, 20000, 25000)
INSERT [dbo].[Book] ([IdBook], [bookTitle], [authorName], [categoryBook], [quantityInStock], [purchasePrice], [sellingPrice]) VALUES (3, N'Naruto', N'Masashi Kishimoto', N'Hanh Dong', 100, 20000, 25000)
GO
INSERT [dbo].[Distributor] ([IdDistributor], [distributorName], [phoneNum], [address], [amountPaid], [remaniningDebt]) VALUES (1, N'Jinggg', 711111111, N'Ha Noi', 100000, 100000)
INSERT [dbo].[Distributor] ([IdDistributor], [distributorName], [phoneNum], [address], [amountPaid], [remaniningDebt]) VALUES (2, N'Dinggg', 722222222, N'Ha Noi', 150000, 150000)
INSERT [dbo].[Distributor] ([IdDistributor], [distributorName], [phoneNum], [address], [amountPaid], [remaniningDebt]) VALUES (3, N'Ginggg', 733333333, N'Ha Noi', 200000, 200000)
GO
INSERT [dbo].[ExportForm] ([idExportForm], [exportDate], [IdDistributor], [personDelivering], [IdBook], [exportQuantity], [totalAmount]) VALUES (1, CAST(N'2000-02-20T00:00:00.000' AS DateTime), 1, N'Qing', 1, 10, 250000)
INSERT [dbo].[ExportForm] ([idExportForm], [exportDate], [IdDistributor], [personDelivering], [IdBook], [exportQuantity], [totalAmount]) VALUES (2, CAST(N'2000-02-21T00:00:00.000' AS DateTime), 2, N'Wing', 2, 15, 370000)
INSERT [dbo].[ExportForm] ([idExportForm], [exportDate], [IdDistributor], [personDelivering], [IdBook], [exportQuantity], [totalAmount]) VALUES (3, CAST(N'2000-02-22T00:00:00.000' AS DateTime), 3, N'Ring', 3, 20, 500000)
GO
INSERT [dbo].[ImportForm] ([IdImportFrom], [importDate], [idpublisher], [personRecipient], [IdBook], [importQuantity], [totalAmount], [importNote]) VALUES (1, CAST(N'2000-02-22T00:00:00.000' AS DateTime), 1, N'Vinh', 1, 10, 200000, N'Sachmoi')
INSERT [dbo].[ImportForm] ([IdImportFrom], [importDate], [idpublisher], [personRecipient], [IdBook], [importQuantity], [totalAmount], [importNote]) VALUES (2, CAST(N'2000-02-23T00:00:00.000' AS DateTime), 2, N'Zinh', 2, 15, 300000, N'Nothing')
INSERT [dbo].[ImportForm] ([IdImportFrom], [importDate], [idpublisher], [personRecipient], [IdBook], [importQuantity], [totalAmount], [importNote]) VALUES (3, CAST(N'2000-02-20T00:00:00.000' AS DateTime), 3, N'Ting', 3, 20, 400000, N'Nothing')
GO
INSERT [dbo].[Publisher] ([IdPublisher], [publisherName], [address], [phoneNum], [accountNum]) VALUES (1, N'Kim Dong', N'HCM', 911111111, 123456)
INSERT [dbo].[Publisher] ([IdPublisher], [publisherName], [address], [phoneNum], [accountNum]) VALUES (2, N'Phuong Nam', N'HCM', 922222222, 123789)
INSERT [dbo].[Publisher] ([IdPublisher], [publisherName], [address], [phoneNum], [accountNum]) VALUES (3, N'NXB Tre', N'HCM', 933333333, 456789)
GO
INSERT [dbo].[Staff] ([IdUser], [Displayname], [UserName], [Password], [Type], [Role]) VALUES (1, N'ad', N'Ding', N'1111', 1, N'Admin')
INSERT [dbo].[Staff] ([IdUser], [Displayname], [UserName], [Password], [Type], [Role]) VALUES (2, N'stf', N'Zing', N'1111', 0, N'Staff')
INSERT [dbo].[Staff] ([IdUser], [Displayname], [UserName], [Password], [Type], [Role]) VALUES (3, N'ad', N'Son', N'1111', 1, N'Admin')
GO
ALTER TABLE [dbo].[ExportForm]  WITH CHECK ADD  CONSTRAINT [FK_ExportForm_Book] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Book] ([IdBook])
GO
ALTER TABLE [dbo].[ExportForm] CHECK CONSTRAINT [FK_ExportForm_Book]
GO
ALTER TABLE [dbo].[ExportForm]  WITH CHECK ADD  CONSTRAINT [FK_ExportForm_Distributor] FOREIGN KEY([IdDistributor])
REFERENCES [dbo].[Distributor] ([IdDistributor])
GO
ALTER TABLE [dbo].[ExportForm] CHECK CONSTRAINT [FK_ExportForm_Distributor]
GO
ALTER TABLE [dbo].[ImportForm]  WITH CHECK ADD  CONSTRAINT [FK_ImportForm_Book] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Book] ([IdBook])
GO
ALTER TABLE [dbo].[ImportForm] CHECK CONSTRAINT [FK_ImportForm_Book]
GO
ALTER TABLE [dbo].[ImportForm]  WITH CHECK ADD  CONSTRAINT [FK_ImportForm_Publisher] FOREIGN KEY([idpublisher])
REFERENCES [dbo].[Publisher] ([IdPublisher])
GO
ALTER TABLE [dbo].[ImportForm] CHECK CONSTRAINT [FK_ImportForm_Publisher]
GO

---Storeproc
----
----
exec USP_LoginAccount @username = N'Ding', @password = '1111'

CREATE PROCEDURE USP_LoginAccount
@username NVARCHAR(100),@password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Staff WHERE Username=@username AND Password=@password
END

