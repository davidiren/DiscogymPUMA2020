CREATE TABLE [dbo].[Mood] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR(50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[Category] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR(50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[ExerciseGoal] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[ExerciseLevel] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[User] (
    [Id]  INT IDENTITY (1, 1) NOT NULL,
    [Pswd] VARBINARY NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [ExerciseGoalId]  INT NOT NULL,
    [ExerciseLevelId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC),
    FOREIGN KEY ([ExerciseGoalId]) REFERENCES [dbo].[ExerciseGoal] ([Id]),
    FOREIGN KEY ([ExerciseLevelId]) REFERENCES [dbo].[ExerciseLevel] ([Id]),
);

CREATE TABLE [dbo].[Workout] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR(50)    NOT NULL,
    [WorkoutTime]   INT             NOT NULL,
    [Gym]           BIT             NOT NULL,
    [CreatedByUserId]           INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[User] ([Id]),  
);


CREATE TABLE [dbo].[FavoriteExercise] (
    [UserId]    INT   NOT NULL,
    [WorkoutId] INT   NOT NULL,
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]),  
);

CREATE TABLE [dbo].[Plan] (
    [Id]        INT   IDENTITY (1, 1) NOT NULL,
    [WorkoutId] INT   NOT NULL,
    [Date]      DATE  NOT NULL,
    [UserId]    INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]),  
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
);

CREATE TABLE [dbo].[Exercise] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR(50)    NOT NULL,
    [CategoryId]    INT             NOT NULL,
    [LevelId]       INT             NOT NULL,
    [Sets]          INT             NOT NULL,
    [Reps]          INT             NOT NULL,
    [Video]         NVARCHAR(100)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    FOREIGN KEY ([LevelId]) REFERENCES [dbo].[ExerciseLevel] ([Id]),  
);

CREATE TABLE [dbo].[WorkoutExercise] (
    [WorkoutId]     INT     NOT NULL,
    [ExerciseId]    INT     NOT NULL,
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]),
    FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([Id]),  
);



CREATE TABLE [dbo].[Log] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [UserId]        INT             NOT NULL,
    [Date]          DATETIME        NOT NULL,
    [MoodId]        INT             NOT NULL,
    [WorkoutId]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([WorkoutId]) REFERENCES [dbo].[Workout] ([Id]),
    FOREIGN KEY ([MoodId]) REFERENCES [dbo].[Mood] ([Id]),
);
