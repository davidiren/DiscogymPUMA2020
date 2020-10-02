INSERT INTO dbo.Category ([Name])
VALUES
	('Arms'),
	('Back'),
	('Chest'),
	('Core'),
	('Legs'),
	('Shoulders');
GO

INSERT INTO dbo.ExerciseLevel ([Name])
VALUES
	('Beginner'),
	('Intermediate'),
	('Advanced');
GO

INSERT INTO dbo.ExerciseGoal ([Name])
VALUES
	('Lose weight'),
	('Get fit'),
	('Build Muscle');
GO

INSERT INTO dbo.Mood ([Name])
VALUES
	('Exhausted'),
	('Tired'),
	('Normal'),
	('Great'),
	('Perfect');
GO

INSERT INTO dbo.[User] ([Pswd], [Name], [ExerciseGoalId], [ExerciseLevelId])
VALUES
	(
	EncryptByPassPhrase('key', 'admin'),
	'Discogym',
	2,
	3
	);
GO

INSERT INTO dbo.Exercise ([Name], [CategoryId], [LevelId], [Sets], [Reps], [Video])
VALUES
	(
	'Bench press',
	3,
	2,
	3,
	8,
	'watch?v=rT7DgCr-3pg'
	),
	(
	'Military press',
	6,
	2,
	3,
	8,
	'watch?v=2yjwXTZQDDI'
	),
	(
	'Squat',
	5,
	2,
	3,
	10,
	'watch?v=SW_C1A-rejs'
	),
	(
	'Plank',
	4,
	2,
	3,
	60,
	'watch?v=pSHjTRCQxIw'
	);