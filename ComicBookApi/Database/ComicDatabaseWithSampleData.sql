
-- SERIES
CREATE TABLE Series (
    SeriesId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX)
);

-- COMICS
CREATE TABLE Comics (
    ComicId INT PRIMARY KEY IDENTITY,
    SeriesId INT NOT NULL,
    Title NVARCHAR(255),
    IssueNumber NVARCHAR(50),
    ReleaseDate DATE,
    FOREIGN KEY (SeriesId) REFERENCES Series(SeriesId)
);

-- CHARACTERS
CREATE TABLE Characters (
    CharacterId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    Alias NVARCHAR(255)
);

-- COMICCHARACTERS
CREATE TABLE ComicCharacters (
    ComicId INT,
    CharacterId INT,
    Role NVARCHAR(100),
    PRIMARY KEY (ComicId, CharacterId),
    FOREIGN KEY (ComicId) REFERENCES Comics(ComicId),
    FOREIGN KEY (CharacterId) REFERENCES Characters(CharacterId)
);

-- CREATORS
CREATE TABLE Creators (
    CreatorId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(255),
    Role NVARCHAR(100)
);

-- COMICCREATORS
CREATE TABLE ComicCreators (
    ComicId INT,
    CreatorId INT,
    PRIMARY KEY (ComicId, CreatorId),
    FOREIGN KEY (ComicId) REFERENCES Comics(ComicId),
    FOREIGN KEY (CreatorId) REFERENCES Creators(CreatorId)
);

-- EVENTS
CREATE TABLE Events (
    EventId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255),
    Description NVARCHAR(MAX)
);

-- COMICEVENTS
CREATE TABLE ComicEvents (
    ComicId INT,
    EventId INT,
    PRIMARY KEY (ComicId, EventId),
    FOREIGN KEY (ComicId) REFERENCES Comics(ComicId),
    FOREIGN KEY (EventId) REFERENCES Events(EventId)
);

-- STORIES
CREATE TABLE Stories (
    StoryId INT PRIMARY KEY IDENTITY,
    ComicId INT,
    Title NVARCHAR(255),
    Summary NVARCHAR(MAX),
    FOREIGN KEY (ComicId) REFERENCES Comics(ComicId)
);

-- SAMPLE DATA INSERTS

-- Series
INSERT INTO Series (Title, Description)
VALUES 
('Amazing Fantasy', 'An anthology series that introduced many characters including Spider-Man.'),
('The Amazing Spider-Man', 'The ongoing comic series following Peter Parker.');

-- Comics
INSERT INTO Comics (SeriesId, Title, IssueNumber, ReleaseDate)
VALUES 
(1, 'Spider-Man Debut', '15', '1962-08-01'),
(2, 'Spider-Man vs. The Chameleon', '1', '1963-03-01');

-- Characters
INSERT INTO Characters (Name, Alias)
VALUES 
('Peter Parker', 'Spider-Man'),
('May Parker', 'Aunt May'),
('J. Jonah Jameson', NULL),
('The Chameleon', NULL);

-- ComicCharacters
INSERT INTO ComicCharacters (ComicId, CharacterId, Role)
VALUES 
(1, 1, 'Hero'),
(1, 2, 'Supporting'),
(2, 1, 'Hero'),
(2, 3, 'Supporting'),
(2, 4, 'Villain');

-- Creators
INSERT INTO Creators (FullName, Role)
VALUES 
('Stan Lee', 'Writer'),
('Steve Ditko', 'Artist');

-- ComicCreators
INSERT INTO ComicCreators (ComicId, CreatorId)
VALUES 
(1, 1), (1, 2),
(2, 1), (2, 2);

-- Events
INSERT INTO Events (Title, Description)
VALUES 
('Secret Wars', 'A crossover event where Marvel characters are transported to Battleworld.'),
('Clone Saga', 'A storyline involving Spider-Man and his clones.');

-- ComicEvents
INSERT INTO ComicEvents (ComicId, EventId)
VALUES 
(2, 2);

-- Stories
INSERT INTO Stories (ComicId, Title, Summary)
VALUES 
(1, 'Origin of Spider-Man', 'Peter Parker gets bitten by a radioactive spider and gains powers.'),
(2, 'Face-off with Chameleon', 'Spider-Man tackles his first villain while navigating public scrutiny.');
