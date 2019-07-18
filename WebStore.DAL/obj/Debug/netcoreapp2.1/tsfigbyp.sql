IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Brands] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Sections] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ParentId] int NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Sections] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sections_Sections_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Sections] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Order] int NOT NULL,
    [SectionId] int NOT NULL,
    [BrandId] int NULL,
    [ImageUrl] nvarchar(max) NULL,
    [Price] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Products_Sections_SectionId] FOREIGN KEY ([SectionId]) REFERENCES [Sections] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Products_BrandId] ON [Products] ([BrandId]);

GO

CREATE INDEX [IX_Products_SectionId] ON [Products] ([SectionId]);

GO

CREATE INDEX [IX_Sections_ParentId] ON [Sections] ([ParentId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190718123848_Intial', N'2.1.11-servicing-32099');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190718124039_Initial second', N'2.1.11-servicing-32099');

GO

