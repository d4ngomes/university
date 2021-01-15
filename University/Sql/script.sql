CREATE TABLE [People] (
    [ID] int NOT NULL IDENTITY,
    [LastName] nvarchar(50) NULL,
    [FirstName] nvarchar(50) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [HireDate] datetime2 NULL,
    [Location] nvarchar(max) NULL,
    [EnrollmentDate] datetime2 NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([ID])
);

CREATE TABLE [Departments] (
    [DepartmentID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NULL,
    [Budget] money NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [InstructorID] int NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentID]),
    CONSTRAINT [FK_Departments_People_InstructorID] FOREIGN KEY ([InstructorID]) REFERENCES [People] ([ID]) ON DELETE NO ACTION
);

CREATE TABLE [Courses] (
    [CourseID] int NOT NULL,
    [Title] nvarchar(50) NULL,
    [Credits] int NOT NULL,
    [DepartmentID] int NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseID]),
    CONSTRAINT [FK_Courses_Departments_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [Departments] ([DepartmentID]) ON DELETE CASCADE
);

CREATE TABLE [CourseInstructor] (
    [CoursesCourseID] int NOT NULL,
    [InstructorsID] int NOT NULL,
    CONSTRAINT [PK_CourseInstructor] PRIMARY KEY ([CoursesCourseID], [InstructorsID]),
    CONSTRAINT [FK_CourseInstructor_Courses_CoursesCourseID] FOREIGN KEY ([CoursesCourseID]) REFERENCES [Courses] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CourseInstructor_People_InstructorsID] FOREIGN KEY ([InstructorsID]) REFERENCES [People] ([ID]) ON DELETE CASCADE
);

CREATE TABLE [Enrollments] (
    [EnrollmentID] int NOT NULL IDENTITY,
    [CourseID] int NOT NULL,
    [StudentID] int NOT NULL,
    [Grade] int NULL,
    CONSTRAINT [PK_Enrollments] PRIMARY KEY ([EnrollmentID]),
    CONSTRAINT [FK_Enrollments_Courses_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Courses] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollments_People_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [People] ([ID]) ON DELETE CASCADE
);

CREATE INDEX [IX_CourseInstructor_InstructorsID] ON [CourseInstructor] ([InstructorsID]);

CREATE INDEX [IX_Courses_DepartmentID] ON [Courses] ([DepartmentID]);

CREATE INDEX [IX_Departments_InstructorID] ON [Departments] ([InstructorID]);

CREATE INDEX [IX_Enrollments_CourseID] ON [Enrollments] ([CourseID]);

CREATE INDEX [IX_Enrollments_StudentID] ON [Enrollments] ([StudentID]);

