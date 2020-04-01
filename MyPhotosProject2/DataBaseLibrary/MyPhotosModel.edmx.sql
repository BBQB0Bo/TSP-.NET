
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2020 16:30:45
-- Generated from EDMX file: C:\Users\Robert\source\repos\MyPhotosProject2\DataBaseLibrary\MyPhotosModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyPhotosDB2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullPath] nvarchar(max)  NOT NULL,
    [IsPhoto] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Proprieties'
CREATE TABLE [dbo].[Proprieties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DataCreated] datetime  NOT NULL,
    [Event] nvarchar(max)  NOT NULL,
    [People] nvarchar(max)  NOT NULL,
    [Landscapes] nvarchar(max)  NOT NULL,
    [Photoplace] nvarchar(max)  NOT NULL,
    [File_Id] int  NULL
);
GO

-- Creating table 'DynamicProprieties'
CREATE TABLE [dbo].[DynamicProprieties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProprietyName] nvarchar(max)  NOT NULL,
    [ProprietyValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FileDynamicPropriety'
CREATE TABLE [dbo].[FileDynamicPropriety] (
    [Files_Id] int  NOT NULL,
    [DynamicProprieties_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proprieties'
ALTER TABLE [dbo].[Proprieties]
ADD CONSTRAINT [PK_Proprieties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DynamicProprieties'
ALTER TABLE [dbo].[DynamicProprieties]
ADD CONSTRAINT [PK_DynamicProprieties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Files_Id], [DynamicProprieties_Id] in table 'FileDynamicPropriety'
ALTER TABLE [dbo].[FileDynamicPropriety]
ADD CONSTRAINT [PK_FileDynamicPropriety]
    PRIMARY KEY CLUSTERED ([Files_Id], [DynamicProprieties_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [File_Id] in table 'Proprieties'
ALTER TABLE [dbo].[Proprieties]
ADD CONSTRAINT [FK_FilePropriety]
    FOREIGN KEY ([File_Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilePropriety'
CREATE INDEX [IX_FK_FilePropriety]
ON [dbo].[Proprieties]
    ([File_Id]);
GO

-- Creating foreign key on [Files_Id] in table 'FileDynamicPropriety'
ALTER TABLE [dbo].[FileDynamicPropriety]
ADD CONSTRAINT [FK_FileDynamicPropriety_File]
    FOREIGN KEY ([Files_Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DynamicProprieties_Id] in table 'FileDynamicPropriety'
ALTER TABLE [dbo].[FileDynamicPropriety]
ADD CONSTRAINT [FK_FileDynamicPropriety_DynamicPropriety]
    FOREIGN KEY ([DynamicProprieties_Id])
    REFERENCES [dbo].[DynamicProprieties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileDynamicPropriety_DynamicPropriety'
CREATE INDEX [IX_FK_FileDynamicPropriety_DynamicPropriety]
ON [dbo].[FileDynamicPropriety]
    ([DynamicProprieties_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------