CREATE TABLE [dbo].[WorkoutExercise] (
	[Id]		 INT IDENTITY(1,1),
    [WorkoutId]  INT NOT NULL,
    [ExerciseId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]),
    FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([Id])
);

