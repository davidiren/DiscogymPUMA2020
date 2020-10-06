CREATE TABLE [dbo].[FavoriteExercise] (
	[Id]		INT NOT NULL,
    [UserId]    INT NOT NULL,
    [WorkoutId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id])
);

