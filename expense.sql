USE [POS_db]
GO

/****** Object:  Table [dbo].[Expenses]    Script Date: 20/03/2018 7:12:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Expenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Exp_Category_FK] [int] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Expense Category] FOREIGN KEY([Exp_Category_FK])
REFERENCES [dbo].[Expense Category] ([ID])
GO

ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Expense Category]
GO


