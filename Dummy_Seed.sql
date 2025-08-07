-- Clear existing data (optional & careful!)
-- DELETE FROM Comments;
-- DELETE FROM Posts;
-- DELETE FROM Albums;
-- DELETE FROM Users;

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


-------------------------
-- 4. Insert 3 Comments per Post (27 x 3 = 81)
-------------------------
INSERT INTO Comments (Text, PostId) VALUES
-- Post 1
('Great post!', 1),
('Really enjoyed this.', 1),
('Looking forward to more.', 1),

-- Post 2
('Incredible work!', 2),
('So inspiring.', 2),
('Love the detail here.', 2),

-- Post 3
('Amazing content!', 3),
('This is gold.', 3),
('Shared with my friends.', 3),

-- Post 4
('Well done!', 4),
('Very informative.', 4),
('Keep it up!', 4),

-- Post 5
('Mind-blowing stuff.', 5),
('Loved reading this.', 5),
('Thanks for sharing.', 5),

-- Post 6
('Solid write-up.', 6),
('Couldn’t agree more.', 6),
('Saved this post.', 6),

-- Post 7
('Just wow!', 7),
('This hit home.', 7),
('Following for more.', 7),

-- Post 8
('I needed this today.', 8),
('Bookmarking this.', 8),
('You nailed it.', 8),

-- Post 9
('Keep writing!', 9),
('So thoughtful.', 9),
('I appreciate this.', 9),

-- Post 10
('Love your work.', 10),
('Well articulated.', 10),
('Great perspective.', 10),

-- Post 11
('Learned something new.', 11),
('Interesting take.', 11),
('Top quality post.', 11),

-- Post 12
('Beautifully written.', 12),
('Big fan of this.', 12),
('Subscribed immediately.', 12),

-- Post 13
('Respect your insights.', 13),
('Very creative.', 13),
('Shared on my feed.', 13),

-- Post 14
('Clear and concise.', 14),
('Love this style.', 14),
('Well structured.', 14),

-- Post 15
('Thanks for posting!', 15),
('Could read this all day.', 15),
('Absolute gem.', 15),

-- Post 16
('The best post today.', 16),
('This is so real.', 16),
('Great energy.', 16),

-- Post 17
('You"re talented.', 17),
('So refreshing.', 17),
('A+ writing.', 17),

-- Post 18
('Very valuable.', 18),
('Keep going!', 18),
('This is fantastic.', 18),

-- Post 19
('Loved every word.', 19),
('Impressive post.', 19),
('This made my day.', 19),

-- Post 20
('Smart and sharp.', 20),
('Thank you!', 20),
('This rocks.', 20),

-- Post 21
('Clean content.', 21),
('So engaging.', 21),
('What a read!', 21),

-- Post 22
('Brilliant!', 22),
('Very relatable.', 22),
('Good job.', 22),

-- Post 23
('Exceptional.', 23),
('Hit the mark.', 23),
('Love your brain.', 23),

-- Post 24
('Content goals.', 24),
('Perfectly said.', 24),
('Very thoughtful.', 24),

-- Post 25
('Love this angle.', 25),
('Genius.', 25),
('You got this.', 25),

-- Post 26
('So good.', 26),
('Keep doing this.', 26),
('Big yes.', 26),

-- Post 27
('Massive respect.', 27),
('This is everything.', 27),
('Legendary.', 27);
