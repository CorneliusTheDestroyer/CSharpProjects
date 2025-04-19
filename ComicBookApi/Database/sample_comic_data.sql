-- 🌐 Series
INSERT INTO Series (Title) VALUES 
('Amazing Spider-Man'),
('Uncanny X-Men'),
('Fantastic Four'),
('Avengers'),
('Black Panther');

-- 📘 Comics
INSERT INTO Comics (Title, IssueNumber, ReleaseDate, SeriesId) VALUES 
('Spider-Man: Homecoming', '001', '2020-06-01', 1),
('The Clone Conspiracy', '002', '2020-07-15', 1),
('Days of Future Past', '141', '1981-01-01', 2),
('The Dark Phoenix Saga', '136', '1980-03-15', 2),
('Doomsday', '001', '2019-10-10', 3);

-- 👤 Characters
INSERT INTO Characters (Name) VALUES 
('Spider-Man'),
('Wolverine'),
('Jean Grey'),
('Reed Richards'),
('Black Panther'),
('Doctor Doom'),
('Iron Man');

-- 🧑‍🎨 Creators
INSERT INTO Creators (FullName) VALUES 
('Stan Lee'),
('Jack Kirby'),
('Steve Ditko'),
('Chris Claremont'),
('John Byrne');

-- 📚 Stories
INSERT INTO Stories (Title, Summary) VALUES 
('The Origin of Spider-Man', 'Peter Parker becomes Spider-Man after being bitten by a radioactive spider.'),
('Dark Phoenix Rises', 'Jean Grey becomes the Dark Phoenix.'),
('Fantastic Origins', 'The Fantastic Four gain powers from cosmic rays.'),
('Wakanda Forever', 'The rise of the Black Panther.'),
('Avengers Assemble', 'Earth''s mightiest heroes team up.');

-- 🌍 Events
INSERT INTO Events (Title, Description) VALUES 
('Infinity War', 'A cosmic event involving the Infinity Stones.'),
('Secret Wars', 'Heroes and villains battle on Battleworld.'),
('Civil War', 'Superhero registration divides the Marvel Universe.');

-- 🔗 ComicCharacters (many-to-many)
INSERT INTO ComicCharacters (ComicId, CharacterId) VALUES 
(1, 1), -- Spider-Man
(2, 1),
(3, 2), -- Wolverine
(4, 3), -- Jean Grey
(5, 4); -- Reed Richards

-- 🔗 ComicCreators (many-to-many)
INSERT INTO ComicCreators (ComicId, CreatorId) VALUES 
(1, 1), -- Stan Lee
(1, 3), -- Steve Ditko
(2, 1),
(3, 4), -- Chris Claremont
(4, 5); -- John Byrne

-- 🔗 ComicEvents (many-to-many)
INSERT INTO ComicEvents (ComicId, EventId) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 2);

-- 🔗 ComicStories (one-to-many)
UPDATE Comics SET SeriesId = 1 WHERE ComicId IN (1, 2);
UPDATE Comics SET SeriesId = 2 WHERE ComicId IN (3, 4);
UPDATE Comics SET SeriesId = 3 WHERE ComicId = 5;