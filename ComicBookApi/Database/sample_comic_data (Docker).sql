
-- Clear Join Tables First (due to FK constraints)
DELETE FROM ComicCharacters;
DELETE FROM ComicCreators;
DELETE FROM ComicEvents;

-- Clear Main Tables
DELETE FROM Comics;
DELETE FROM Characters;
DELETE FROM Creators;
DELETE FROM Events;
DELETE FROM Stories;
DELETE FROM Series;

-- Optionally Reset Identity Counters
DBCC CHECKIDENT ('ComicCharacters', RESEED, 0);
DBCC CHECKIDENT ('ComicCreators', RESEED, 0);
DBCC CHECKIDENT ('ComicEvents', RESEED, 0);
DBCC CHECKIDENT ('Comics', RESEED, 0);
DBCC CHECKIDENT ('Characters', RESEED, 0);
DBCC CHECKIDENT ('Creators', RESEED, 0);
DBCC CHECKIDENT ('Events', RESEED, 0);
DBCC CHECKIDENT ('Stories', RESEED, 0);
DBCC CHECKIDENT ('Series', RESEED, 0);

SET IDENTITY_INSERT [dbo].[Series] ON 
GO
INSERT [dbo].[Series] ([SeriesId], [Title], [Description]) VALUES (1, N'Amazing Spider-Man', NULL)
GO
INSERT [dbo].[Series] ([SeriesId], [Title], [Description]) VALUES (2, N'Uncanny X-Men', NULL)
GO
INSERT [dbo].[Series] ([SeriesId], [Title], [Description]) VALUES (3, N'Fantastic Four', NULL)
GO
INSERT [dbo].[Series] ([SeriesId], [Title], [Description]) VALUES (4, N'Avengers', NULL)
GO
INSERT [dbo].[Series] ([SeriesId], [Title], [Description]) VALUES (5, N'Black Panther', NULL)
GO
SET IDENTITY_INSERT [dbo].[Series] OFF
GO

SET IDENTITY_INSERT [dbo].[Comics] ON 
GO
INSERT [dbo].[Comics] ([ComicId], [SeriesId], [Title], [IssueNumber], [ReleaseDate]) VALUES (1, 1, N'Spider-Man: Homecoming', N'001', CAST(N'2020-06-01' AS Date))
GO
INSERT [dbo].[Comics] ([ComicId], [SeriesId], [Title], [IssueNumber], [ReleaseDate]) VALUES (2, 1, N'The Clone Conspiracy', N'002', CAST(N'2020-07-15' AS Date))
GO
INSERT [dbo].[Comics] ([ComicId], [SeriesId], [Title], [IssueNumber], [ReleaseDate]) VALUES (3, 2, N'Days of Future Past', N'141', CAST(N'1981-01-01' AS Date))
GO
INSERT [dbo].[Comics] ([ComicId], [SeriesId], [Title], [IssueNumber], [ReleaseDate]) VALUES (4, 2, N'The Dark Phoenix Saga', N'136', CAST(N'1980-03-15' AS Date))
GO
INSERT [dbo].[Comics] ([ComicId], [SeriesId], [Title], [IssueNumber], [ReleaseDate]) VALUES (5, 3, N'Doomsday', N'001', CAST(N'2019-10-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Comics] OFF
GO

SET IDENTITY_INSERT [dbo].[Characters] ON 
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (1, N'Spider-Man', NULL)
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (2, N'Wolverine', NULL)
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (3, N'Jean Grey', NULL)
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (4, N'Reed Richards', NULL)
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (5, N'Black Panther', NULL)
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (6, N'Doctor Doom', NULL)
GO
INSERT [dbo].[Characters] ([CharacterId], [Name], [Alias]) VALUES (7, N'Iron Man', NULL)
GO
SET IDENTITY_INSERT [dbo].[Characters] OFF
GO

INSERT [dbo].[ComicCharacters] ([ComicId], [CharacterId], [Role]) VALUES (1, 1, NULL)
GO
INSERT [dbo].[ComicCharacters] ([ComicId], [CharacterId], [Role]) VALUES (2, 1, NULL)
GO
INSERT [dbo].[ComicCharacters] ([ComicId], [CharacterId], [Role]) VALUES (3, 2, NULL)
GO
INSERT [dbo].[ComicCharacters] ([ComicId], [CharacterId], [Role]) VALUES (4, 3, NULL)
GO
INSERT [dbo].[ComicCharacters] ([ComicId], [CharacterId], [Role]) VALUES (5, 4, NULL)
GO
SET IDENTITY_INSERT [dbo].[Creators] ON 
GO

INSERT [dbo].[Creators] ([CreatorId], [FullName], [Role]) VALUES (1, N'Stan Lee', NULL)
GO
INSERT [dbo].[Creators] ([CreatorId], [FullName], [Role]) VALUES (2, N'Jack Kirby', NULL)
GO
INSERT [dbo].[Creators] ([CreatorId], [FullName], [Role]) VALUES (3, N'Steve Ditko', NULL)
GO
INSERT [dbo].[Creators] ([CreatorId], [FullName], [Role]) VALUES (4, N'Chris Claremont', NULL)
GO
INSERT [dbo].[Creators] ([CreatorId], [FullName], [Role]) VALUES (5, N'John Byrne', NULL)
GO

SET IDENTITY_INSERT [dbo].[Creators] OFF
GO
INSERT [dbo].[ComicCreators] ([ComicId], [CreatorId]) VALUES (1, 1)
GO
INSERT [dbo].[ComicCreators] ([ComicId], [CreatorId]) VALUES (1, 3)
GO
INSERT [dbo].[ComicCreators] ([ComicId], [CreatorId]) VALUES (2, 1)
GO
INSERT [dbo].[ComicCreators] ([ComicId], [CreatorId]) VALUES (3, 4)
GO
INSERT [dbo].[ComicCreators] ([ComicId], [CreatorId]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[Events] ON 
GO

INSERT [dbo].[Events] ([EventId], [Title], [Description]) VALUES (1, N'Infinity War', N'A cosmic event involving the Infinity Stones.')
GO
INSERT [dbo].[Events] ([EventId], [Title], [Description]) VALUES (2, N'Secret Wars', N'Heroes and villains battle on Battleworld.')
GO
INSERT [dbo].[Events] ([EventId], [Title], [Description]) VALUES (3, N'Civil War', N'Superhero registration divides the Marvel Universe.')
GO
SET IDENTITY_INSERT [dbo].[Events] OFF
GO

INSERT [dbo].[ComicEvents] ([ComicId], [EventId]) VALUES (1, 1)
GO
INSERT [dbo].[ComicEvents] ([ComicId], [EventId]) VALUES (2, 2)
GO
INSERT [dbo].[ComicEvents] ([ComicId], [EventId]) VALUES (3, 3)
GO
INSERT [dbo].[ComicEvents] ([ComicId], [EventId]) VALUES (4, 1)
GO
INSERT [dbo].[ComicEvents] ([ComicId], [EventId]) VALUES (5, 2)
GO

SET IDENTITY_INSERT [dbo].[Stories] ON 
GO
INSERT [dbo].[Stories] ([StoryId], [ComicId], [Title], [Summary]) VALUES (1, 1, N'The Origin of Spider-Man', N'Peter Parker becomes Spider-Man after being bitten by a radioactive spider.')
GO
INSERT [dbo].[Stories] ([StoryId], [ComicId], [Title], [Summary]) VALUES (2, 2, N'Dark Phoenix Rises', N'Jean Grey becomes the Dark Phoenix.')
GO
INSERT [dbo].[Stories] ([StoryId], [ComicId], [Title], [Summary]) VALUES (3, 3, N'Fantastic Origins', N'The Fantastic Four gain powers from cosmic rays.')
GO
INSERT [dbo].[Stories] ([StoryId], [ComicId], [Title], [Summary]) VALUES (4, 4, N'Wakanda Forever', N'The rise of the Black Panther.')
GO
INSERT [dbo].[Stories] ([StoryId], [ComicId], [Title], [Summary]) VALUES (5, 5, N'Avengers Assemble', N'Earth''s mightiest heroes team up.')
GO
SET IDENTITY_INSERT [dbo].[Stories] OFF
GO
