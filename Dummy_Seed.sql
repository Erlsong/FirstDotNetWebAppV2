

-------------------------
-- 1. Insert 3 Users	PUT the password in order to login
-------------------------
INSERT INTO Users (PenName, HashedPassword, Email, Role) VALUES
('WanderlustWill', 'hashed_will_pw', 'will@travelverse.com', 'admin'),
('CodeMuse', 'hashed_cm_pw', 'muse@devdiary.io', 'user'),
('LensQueen', 'hashed_lq_pw', 'queen@focusframe.org', 'user');


-------------------------
-- 2. Insert 3 Albums per User (3 x 3 = 9)
-------------------------
-- Assumes IDs for Users are 1, 2, 3
INSERT INTO Albums (Name, Description, Count, UserId) VALUES
-- Will's Albums (UserId 1)
('Icelandic Echoes', 'Chronicling the silence and sounds of Iceland', 0, 1),
('Desert Dreams', 'Moments captured under endless sand and sun', 0, 1),
('Skyline Fever', 'Skyscrapers through shifting weather', 0, 1),

-- CodeMuse's Albums (UserId 2)
('Terminal Thoughts', 'Abstracts inspired by long nights coding', 0, 2),
('Byte & Light', 'Code meets neon city streets', 0, 2),
('Error 404: Serenity', 'Snippets of peace in the chaos', 0, 2),

-- LensQueen's Albums (UserId 3)
('Portraits of Power', 'Faces that tell bold stories', 0, 3),
('Blurred Realities', 'Experimental motion and mood shots', 0, 3),
('Urban Ballet', 'Movements in city geometry', 0, 3);


-------------------------
-- 3. Insert 3 Posts per Album (9 x 3 = 27)
-------------------------
-- Assumes Album IDs are 1–9 and User IDs are 1–3 in round-robin
INSERT INTO Posts (Title, Description, Content, AlbumId, UserId) VALUES
-- Will's Posts (Albums 1–3, UserId 1)
('Frozen Silence', 'Capturing an untouched glacial plain.', 'Shot with a drone at dusk.', 1, 1),
('Aurora Dancer', 'Northern lights swirl like spirits.', 'Long exposure with wide angle.', 1, 1),
('Volcanic Calm', 'Steam rising from a dormant giant.', 'Muted tones and contrast play.', 1, 1),

('Dune Symphony', 'Waves of sand like music sheets.', 'Shot during a sandstorm break.', 2, 1),
('Oasis Reflection', 'A single palm mirrored perfectly.', 'Focus on symmetry and light.', 2, 1),
('Camel Trail', 'Footprints tell ancient stories.', 'Shot on 50mm from a dune ridge.', 2, 1),

('Glass Giants', 'A building piercing the fog.', 'Downtown captured before sunrise.', 3, 1),
('Window Wars', 'Reflections colliding.', 'Tilted perspective with high ISO.', 3, 1),
('City Pulse', 'Light trails between towers.', 'Layered exposure over 3 hours.', 3, 1),

-- CodeMuse’s Posts (Albums 4–6, UserId 2)
('CTRL+ALT+Night', 'Late-night debugging as metaphor.', 'Caffeine-fueled shot at 3 AM.', 4, 2),
('404 Emotions', 'Empty terminal, full head.', 'Backlit silhouette under monitor glow.', 4, 2),
('Compiled Thoughts', 'Syntax and soul.', 'Portrait surrounded by post-its.', 4, 2),

('Neon Graffiti', 'Code overlays on urban walls.', 'Blend of street art and JS syntax.', 5, 2),
('Array of Lights', 'LED signs mapped like arrays.', 'Deep focus on RGB contrast.', 5, 2),
('Infinite Loop', 'Escalators as recursion.', 'Mirrored lens trick shot.', 5, 2),

('Blue Screen Zen', 'Crash screens never looked so peaceful.', 'Shot at coworking space.', 6, 2),
('Dependency Drift', 'Teamwork tangled.', 'Conceptual multi-exposure.', 6, 2),
('Uptime Dreams', 'Server room sleepwalk.', 'Infrared camera use experiment.', 6, 2),

-- LensQueen’s Posts (Albums 7–9, UserId 3)
('Eyes That Speak', 'Portrait with no words needed.', 'Soft backlight with shadow curve.', 7, 3),
('Wrinkle Map', 'Age as a terrain of life.', 'High contrast B&W.', 7, 3),
('The Unblinking', 'Intense stare under neon light.', 'Model in static pose.', 7, 3),

('Running Still', 'Intentional motion blur.', 'Subject mid-sprint at night.', 8, 3),
('Rain Ribbons', 'Headlights turned into brush strokes.', 'Handheld long exposure.', 8, 3),
('Whispers in Glass', 'Reflections whisper different stories.', 'Bokeh foreground play.', 8, 3),

('Crosswalk Waltz', 'Timed shot of human movement.', 'Taken from 5th floor balcony.', 9, 3),
('Brick Serenade', 'Geometry meets sunlight.', 'Focus stacked urban wall.', 9, 3),
('Vertical Rhythm', 'Fire escapes become choreography.', 'Dramatic angles with shadows.', 9, 3);

-- Inserts 3 Comments per Post
INSERT INTO Comments (Text, PostId, UserId) VALUES
-- Comments for Post 1
('Great post! Really enjoyed reading it.', 1, 1),
('Thanks for sharing this insight.', 1, 2),
('I learned a lot from this post.', 1, 3),

-- Comments for Post 2
('Interesting perspective!', 2, 2),
('Could you elaborate more on this?', 2, 3),
('Nice write-up, looking forward to more.', 2, 3),

-- Comments for Post 3
('This was very helpful, thanks!', 3, 1),
('I disagree with some points here.', 3, 2),
('Well explained and clear.', 3, 3);





