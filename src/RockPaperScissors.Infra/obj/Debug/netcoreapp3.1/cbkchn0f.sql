IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Moves] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [MoveId] uniqueidentifier NULL,
    CONSTRAINT [PK_Moves] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Moves_Moves_MoveId] FOREIGN KEY ([MoveId]) REFERENCES [Moves] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Moves_MoveId] ON [Moves] ([MoveId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211005175351_Initial', N'5.0.10');
GO

COMMIT;
GO

