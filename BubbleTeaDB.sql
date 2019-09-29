--DROP DATABASE BubbleTeaDB;

CREATE DATABASE [BubbleTeaDB];
GO

USE [BubbleTeaDB];
GO

--Customers Table
CREATE TABLE [dbo].[Customers](
	[CustId] [smallint] NOT NULL IDENTITY(1,1),
	PRIMARY Key([CustId]),
	[CustUser] [nvarchar](50) NOT NULL,
	[CustPass] [nvarchar](50) NOT NULL,
	[CustName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
    [PostCode] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL) 

--Employees Table
CREATE TABLE [dbo].[Employees](
	[EmpId] [smallint] NOT NULL IDENTITY(1,1),
	PRIMARY Key([EmpId]),
	[EmpUser] [nvarchar](50) NOT NULL,
	[EmpPass] [nvarchar](50) NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
    [PostCode] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL) 

--BubbleTea Table
CREATE TABLE [dbo].[BubbleTea](
	[BubbleTeaId] [smallint] NOT NULL IDENTITY(1,1),
	PRIMARY Key([BubbleTeaId]),
	[Flavour] [nvarchar](50) NOT NULL,
	[Price] [nvarchar](50) NOT NULL) 

--Receipts Table
CREATE TABLE [dbo].[Receipts](
	[ReceiptId] [smallint] NOT NULL IDENTITY(1,1),
	PRIMARY Key([ReceiptId]),
	[Date] [nvarchar](50) NOT NULL,
	[TotalPrice] [nvarchar](50) NOT NULL,
	[CustId] [smallint] NOT NULL,
	[EmpId] [smallint] NOT NULL,
	[BubbleTeaId] [smallint] NOT NULL,
	FOREIGN Key([CustId]) REFERENCES [dbo].[Customers] ([CustId]),
	FOREIGN Key([EmpId]) REFERENCES [dbo].[Employees] ([EmpId]),
	FOREIGN Key([BubbleTeaId]) REFERENCES [dbo].[BubbleTea] ([BubbleTeaId]))


SELECT * FROM [dbo].[Customers]		
SELECT * FROM [dbo].[BubbleTea]
SELECT * FROM [dbo].[Receipts]


--DROP TABLE [dbo].[Customers]
--DROP TABLE [dbo].[BubbleTea]
--DROP TABLE [dbo].[Receipts]


--Bubble Tea Default Flavours
USE [BubbleTeaDB];
GO
INSERT INTO [dbo].[BubbleTea] VALUES ('Original Bubble Tea','4.55');
INSERT INTO [dbo].[BubbleTea] VALUES('Fruit Bubble Tea','5.55');
INSERT INTO [dbo].[BubbleTea] VALUES('Mango Green Tea', '5.99');
INSERT INTO [dbo].[BubbleTea] VALUES('Coffee Milk Bubble Tea','6.15');

SELECT * FROM [dbo].[BubbleTea];

--Default Customer
USE [BubbleTeaDB];
GO
INSERT INTO [dbo].[Customers] VALUES ('alex','alex', 'Alex', '100 Trafalgar Rd', 'L5L6L6', '4164164166');

SELECT * FROM [dbo].[Customers];

--Default Employee
USE [BubbleTeaDB];
GO
INSERT INTO [dbo].[Employees] VALUES ('bob','bob', 'Bobby', '101 Trafalgar Rd', 'L5L6L6', '4164164167');

SELECT * FROM [dbo].[Employees];

--Default Receipt
USE [BubbleTeaDB];
GO
INSERT INTO [dbo].[Receipts] VALUES('02/02/2019', '6.49', 1, 1, 3);

SELECT * FROM [dbo].[Receipts];