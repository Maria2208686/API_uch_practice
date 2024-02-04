/*
Created: 02.02.2024
Modified: 02.02.2024
Model: Logical model
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table User

CREATE TABLE [User]
(
 [user_id] Int NOT NULL,
 [user_name] Char(100) NOT NULL,
 [user_surname] Char(100) NOT NULL,
 [user_patronymic] Char(100) NULL,
 [email] Char(100) NOT NULL,
 [password] Char(100) NOT NULL
)
go

-- Add keys for table User

ALTER TABLE [User] ADD CONSTRAINT [Unique_Identifier1] PRIMARY KEY ([user_id])
go

-- Table Trip

CREATE TABLE [Trip]
(
 [trip_id] Int NOT NULL,
 [trip_name] Char(1000) NOT NULL,
 [start_date] Date NOT NULL,
 [end_date] Date NOT NULL,
 [destination_place] Char(100) NOT NULL,
 [description] Varchar(max) NULL
)
go

-- Add keys for table Trip

ALTER TABLE [Trip] ADD CONSTRAINT [Unique_Identifier2] PRIMARY KEY ([trip_id])
go

-- Table Photo

CREATE TABLE [Photo]
(
 [user_id] Int NULL,
 [trip_id] Int NULL,
 [photo_id] Int NOT NULL,
 [photo_name] Char(1000) NULL,
 [date_of_creating] Date NOT NULL
)
go

-- Create indexes for table Photo

CREATE INDEX [IX_Relationship6] ON [Photo] ([trip_id])
go

CREATE INDEX [IX_Relationship14] ON [Photo] ([user_id])
go

-- Add keys for table Photo

ALTER TABLE [Photo] ADD CONSTRAINT [Unique_Identifier3] PRIMARY KEY ([photo_id])
go

-- Table Expense

CREATE TABLE [Expense]
(
 [trip_id] Int NULL,
 [expense_id] Int NOT NULL,
 [sum] Decimal(18,2) NOT NULL,
 [currency] Char(100) NOT NULL
)
go

-- Create indexes for table Expense

CREATE INDEX [IX_Relationship4] ON [Expense] ([trip_id])
go

-- Add keys for table Expense

ALTER TABLE [Expense] ADD CONSTRAINT [Unique_Identifier4] PRIMARY KEY ([expense_id])
go

-- Table To-do list

CREATE TABLE [To-do list]
(
 [user_id] Int NULL,
 [to_do_id] Int NOT NULL,
 [name_of_task] Char(100) NOT NULL,
 [description] Varchar(max) NULL
)
go

-- Create indexes for table To-do list

CREATE INDEX [IX_Relationship9] ON [To-do list] ([user_id])
go

-- Add keys for table To-do list

ALTER TABLE [To-do list] ADD CONSTRAINT [Unique_Identifier5] PRIMARY KEY ([to_do_id])
go

-- Table Event

CREATE TABLE [Event]
(
 [event_id] Int NOT NULL,
 [event_name] Char(100) NOT NULL,
 [date] Date NOT NULL,
 [time] Time NULL,
 [place] Char(100) NULL,
 [description] Varchar(max) NULL
)
go

-- Add keys for table Event

ALTER TABLE [Event] ADD CONSTRAINT [Unique_Identifier6] PRIMARY KEY ([event_id])
go

-- Table Review

CREATE TABLE [Review]
(
 [user_id] Int NULL,
 [event_id] Int NULL,
 [review_id] Int NOT NULL,
 [title_of_review] Char(100) NULL,
 [review_text] Char(1000) NULL,
 [estimation] Int NOT NULL
)
go

-- Create indexes for table Review

CREATE INDEX [IX_Relationship11] ON [Review] ([user_id])
go

CREATE INDEX [IX_Relationship13] ON [Review] ([event_id])
go

-- Add keys for table Review

ALTER TABLE [Review] ADD CONSTRAINT [Unique_Identifier7] PRIMARY KEY ([review_id])
go

-- Table User_Trip

CREATE TABLE [User_Trip]
(
 [user_id] Int NOT NULL,
 [trip_id] Int NOT NULL
)
go

-- Table Trip_Place

CREATE TABLE [Trip_Place]
(
 [trip_id] Int NOT NULL,
 [event_id] Int NOT NULL
)
go

-- Table To-do list_Place

CREATE TABLE [To-do list_Place]
(
 [to_do_id] Int NOT NULL,
 [event_id] Int NOT NULL
)
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Expense] ADD CONSTRAINT [Relationship4] FOREIGN KEY ([trip_id]) REFERENCES [Trip] ([trip_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Photo] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([trip_id]) REFERENCES [Trip] ([trip_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [To-do list] ADD CONSTRAINT [Relationship9] FOREIGN KEY ([user_id]) REFERENCES [User] ([user_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Review] ADD CONSTRAINT [Relationship11] FOREIGN KEY ([user_id]) REFERENCES [User] ([user_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Review] ADD CONSTRAINT [Relationship13] FOREIGN KEY ([event_id]) REFERENCES [Event] ([event_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Photo] ADD CONSTRAINT [Relationship14] FOREIGN KEY ([user_id]) REFERENCES [User] ([user_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




