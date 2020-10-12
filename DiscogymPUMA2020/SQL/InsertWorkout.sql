INSERT INTO dbo.[User] ([Pswd], [Name], [ExerciseGoalId], [ExerciseLevelId])
VALUES
	(
	EncryptByPassPhrase('key', 'user1'),
	'User1',
	2,
	3
	);
GO

INSERT INTO dbo.[Workout] ([Name], [WorkoutTime], [Gym], [CreatedByUserId])
VALUES	('5m legs',5,0,1),
		('7m legs',7,0,1),
		('7m legs',7,1,1);
GO

INSERT INTO dbo.[WorkoutExercise] ([WorkoutId], [ExerciseId])
VALUES	(1,2),
		(1,4),
		(2,1),
		(2,3),
		(2,4),
		(3,2),
		(3,3),
		(3,1);
GO
