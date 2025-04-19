CREATE OR ALTER PROCEDURE ResetComicBookData
AS
BEGIN
    SET NOCOUNT ON;

    -- Step 1: Clear Join Tables
    DELETE FROM ComicCharacters;
    DELETE FROM ComicCreators;
    DELETE FROM ComicEvents;

    -- Step 2: Clear Main Tables
    DELETE FROM Comics;
    DELETE FROM Characters;
    DELETE FROM Creators;
    DELETE FROM Events;
    DELETE FROM Stories;
    DELETE FROM Series;

    -- Step 3: Reset Identity Seeds
    DBCC CHECKIDENT ('ComicCharacters', RESEED, 0);
    DBCC CHECKIDENT ('ComicCreators', RESEED, 0);
    DBCC CHECKIDENT ('ComicEvents', RESEED, 0);
    DBCC CHECKIDENT ('Comics', RESEED, 0);
    DBCC CHECKIDENT ('Characters', RESEED, 0);
    DBCC CHECKIDENT ('Creators', RESEED, 0);
    DBCC CHECKIDENT ('Events', RESEED, 0);
    DBCC CHECKIDENT ('Stories', RESEED, 0);
    DBCC CHECKIDENT ('Series', RESEED, 0);
END