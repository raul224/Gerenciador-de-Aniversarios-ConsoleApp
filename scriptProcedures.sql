USE [gerenciadorAniversariosConsole]
GO
/****** Object:  StoredProcedure [dbo].[CriaPessoa]    Script Date: 28/06/2021 20:36:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CriaPessoa]
	@Nome varchar(max),
	@SobreNome varchar(max),
	@aniversario date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO PESSOAS(Nome, SobreNome, Aniversario) Values(@Nome, @SobreNome, @Aniversario)
END
GO
/****** Object:  StoredProcedure [dbo].[DeletaPessoa]    Script Date: 28/06/2021 20:36:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletaPessoa]
	@IdPessoa int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM PESSOAS WHERE Id = @IdPessoa
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllPessoas]    Script Date: 28/06/2021 20:36:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllPessoas] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM DBO.Pessoas;
END
GO
/****** Object:  StoredProcedure [dbo].[SelectPessoaPeloId]    Script Date: 28/06/2021 20:36:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectPessoaPeloId]
	@IdPessoa Integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM PESSOAS WHERE Id = @IdPessoa
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePessoa]    Script Date: 28/06/2021 20:36:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePessoa]
	@Nome varchar(max),
	@SobreNome varchar(max),
	@Aniversario date,
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE PESSOAS SET Nome = @Nome, SobreNome = @SobreNome, Aniversario = @Aniversario WHERE Id = @Id
END
GO
