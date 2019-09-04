USE [SchoolDataBase]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 03/09/2019 23:39:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SchoolName] [nchar](20) NULL,
	[Description] [nchar](50) NULL,
	[From] [nvarchar](50) NULL,
	[To] [nvarchar](50) NULL,
	[Current] [bit] NULL,
	[EducationType] [nchar](20) NULL,
	[City] [nvarchar](10) NULL,
	[FieldOfStudy] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEducation]    Script Date: 03/09/2019 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteEducation]
	-- Add the parameters for the stored procedure here
	@educationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Education where id = @educationId
END
GO
/****** Object:  StoredProcedure [dbo].[spGetEducationById]    Script Date: 03/09/2019 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetEducationById]
	-- Add the parameters for the stored procedure here
	@educationID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Education where Id = @educationID 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetEducations]    Script Date: 03/09/2019 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetEducations] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Education
END
GO
/****** Object:  StoredProcedure [dbo].[spPostEducation]    Script Date: 03/09/2019 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spPostEducation]
	-- Add the parameters for the stored procedure here
	@current bit,
	@description nvarchar(50),
	@schoolName nvarchar(10),
	@city nvarchar(10),
	@educationType nvarchar(10),
	@fieldOfStudy nvarchar(10),
	@from nvarchar(10),
	@to nvarchar(10)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Education([Current],[Description],SchoolName,City,EducationType,FieldOfStudy,[from],[To]) 
	values
	(@current,@description,@schoolName,@city,@educationType,@fieldOfStudy,@from,@to)
END
GO
/****** Object:  StoredProcedure [dbo].[spPutEducation]    Script Date: 03/09/2019 23:39:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spPutEducation] 
	-- Add the parameters for the stored procedure here
	@current bit,
	@description nvarchar(50),
	@schoolName nvarchar(10),
	@city nvarchar(10),
	@educationType nvarchar(10),
	@fieldOfStudy nvarchar(10),
	@from nvarchar(10),
	@to nvarchar(10),
	@educationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Education set [Current] = @current , [Description]=@description,SchoolName=@schoolName
	where @educationId = id
END
GO
