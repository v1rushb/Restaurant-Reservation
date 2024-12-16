IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(45) NOT NULL,
        [LastName] nvarchar(45) NOT NULL,
        [Email] nvarchar(85) NOT NULL,
        [PhoneNumber] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Restaurants] (
        [RestaurantId] int NOT NULL IDENTITY,
        [Name] nvarchar(75) NOT NULL,
        [Address] nvarchar(150) NOT NULL,
        [PhoneNumber] nvarchar(10) NOT NULL,
        [OpeningHours] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Restaurants] PRIMARY KEY ([RestaurantId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Username] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Employees] (
        [EmployeeId] int NOT NULL IDENTITY,
        [RestaurantId] int NULL,
        [FirstName] nvarchar(45) NOT NULL,
        [LastName] nvarchar(45) NOT NULL,
        [Position] nvarchar(45) NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId]),
        CONSTRAINT [FK_Employees_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [MenuItems] (
        [MenuItemId] int NOT NULL IDENTITY,
        [RestaurantId] int NOT NULL,
        [Name] nvarchar(75) NOT NULL,
        [Description] nvarchar(700) NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_MenuItems] PRIMARY KEY ([MenuItemId]),
        CONSTRAINT [FK_MenuItems_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Tables] (
        [TableId] int NOT NULL IDENTITY,
        [RestaurantId] int NULL,
        [Capacity] int NOT NULL,
        CONSTRAINT [PK_Tables] PRIMARY KEY ([TableId]),
        CONSTRAINT [FK_Tables_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Reservations] (
        [ReservationId] int NOT NULL IDENTITY,
        [CustomerId] int NULL,
        [RestaurantId] int NULL,
        [TableId] int NULL,
        [ReservationDate] datetime2 NOT NULL,
        [PartySize] int NOT NULL,
        CONSTRAINT [PK_Reservations] PRIMARY KEY ([ReservationId]),
        CONSTRAINT [FK_Reservations_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]),
        CONSTRAINT [FK_Reservations_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]),
        CONSTRAINT [FK_Reservations_Tables_TableId] FOREIGN KEY ([TableId]) REFERENCES [Tables] ([TableId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [ReservationId] int NULL,
        [EmployeeId] int NULL,
        [OrderDate] datetime2 NOT NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Orders_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]),
        CONSTRAINT [FK_Orders_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [Reservations] ([ReservationId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE TABLE [OrderItems] (
        [OrderItemId] int NOT NULL IDENTITY,
        [OrderId] int NULL,
        [MenuItemId] int NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderItemId]),
        CONSTRAINT [FK_OrderItems_MenuItems_MenuItemId] FOREIGN KEY ([MenuItemId]) REFERENCES [MenuItems] ([MenuItemId]),
        CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Employees_RestaurantId] ON [Employees] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_MenuItems_RestaurantId] ON [MenuItems] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_OrderItems_MenuItemId] ON [OrderItems] ([MenuItemId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Orders_EmployeeId] ON [Orders] ([EmployeeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Orders_ReservationId] ON [Orders] ([ReservationId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Reservations_CustomerId] ON [Reservations] ([CustomerId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Reservations_RestaurantId] ON [Reservations] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Reservations_TableId] ON [Reservations] ([TableId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    CREATE INDEX [IX_Tables_RestaurantId] ON [Tables] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116170831_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241116170831_Initial', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'Email', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([CustomerId], [Email], [FirstName], [LastName], [PhoneNumber])
    VALUES (1, N''cs.bashar.herbawi@gmail.com'', N''Bashar'', N''Herbawi'', N''0592696336''),
    (2, N''ali.hassan@example.com'', N''Ali'', N''Hassan'', N''0591234567''),
    (3, N''obada.khalil@example.com'', N''Obada'', N''Khalil'', N''0592345678''),
    (4, N''omar.abdullah@example.com'', N''Omar'', N''Abdullah'', N''0593456789''),
    (5, N''omar.herbawi@example.com'', N''Omar'', N''Herbawi'', N''0594567890'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'Email', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RestaurantId', N'Address', N'Name', N'OpeningHours', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
        SET IDENTITY_INSERT [Restaurants] ON;
    EXEC(N'INSERT INTO [Restaurants] ([RestaurantId], [Address], [Name], [OpeningHours], [PhoneNumber])
    VALUES (1, N''Ramallah'', N''Al Quds Restaurant'', N''9:00 - 22:00'', N''02-2987654''),
    (2, N''Nablus'', N''Nablus Delights'', N''10:00 - 23:00'', N''09-2345678''),
    (3, N''Hebron'', N''Hebron Grill'', N''8:00 - 20:00'', N''02-2298765''),
    (4, N''Gaza City'', N''Gaza Seafood'', N''11:00 - 23:00'', N''08-2887654''),
    (5, N''Jericho'', N''Jericho Oasis'', N''9:00 - 21:00'', N''02-2323456'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RestaurantId', N'Address', N'Name', N'OpeningHours', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
        SET IDENTITY_INSERT [Restaurants] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'FirstName', N'LastName', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([UserId], [FirstName], [LastName], [Password], [Username])
    VALUES (1, N''Ahmad'', N''Suleiman'', N''password123'', N''ahmad_s''),
    (2, N''Omar'', N''Yassin'', N''password123'', N''omar_y''),
    (3, N''Yousef'', N''Khatib'', N''password123'', N''yousef_k''),
    (4, N''Ali'', N''Zayed'', N''password123'', N''ali_z''),
    (5, N''Omar'', N''Herbawi'', N''password123'', N''omar_h'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'FirstName', N'LastName', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'Position', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] ON;
    EXEC(N'INSERT INTO [Employees] ([EmployeeId], [FirstName], [LastName], [Position], [RestaurantId])
    VALUES (1, N''Khaled'', N''Ahmad'', N''Manager'', 1),
    (2, N''Ahmad'', N''Salem'', N''Chef'', 2),
    (3, N''Obayd'', N''Ali'', N''Waiter'', 3),
    (4, N''Samir'', N''Zayed'', N''Accountant'', 4),
    (5, N''Omar'', N''Hassan'', N''Manager'', 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'Position', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MenuItemId', N'Description', N'Name', N'Price', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[MenuItems]'))
        SET IDENTITY_INSERT [MenuItems] ON;
    EXEC(N'INSERT INTO [MenuItems] ([MenuItemId], [Description], [Name], [Price], [RestaurantId])
    VALUES (1, N''Chicken with onions and sumac on taboon bread'', N''Musakhan'', 20.0, 1),
    (2, N''Sweet cheese pastry'', N''Kanafeh'', 15.0, 2),
    (3, N''Upside-down rice and vegetable dish'', N''Maqluba'', 18.0, 3),
    (4, N''Fish with rice and spices'', N''Sayadiyah'', 25.0, 4),
    (5, N''Classic Palestinian falafel wrap'', N''Falafel Sandwich'', 5.0, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MenuItemId', N'Description', N'Name', N'Price', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[MenuItems]'))
        SET IDENTITY_INSERT [MenuItems] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TableId', N'Capacity', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Tables]'))
        SET IDENTITY_INSERT [Tables] ON;
    EXEC(N'INSERT INTO [Tables] ([TableId], [Capacity], [RestaurantId])
    VALUES (1, 4, 1),
    (2, 6, 1),
    (3, 2, 2),
    (4, 8, 3),
    (5, 10, 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TableId', N'Capacity', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Tables]'))
        SET IDENTITY_INSERT [Tables] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ReservationId', N'CustomerId', N'PartySize', N'ReservationDate', N'RestaurantId', N'TableId') AND [object_id] = OBJECT_ID(N'[Reservations]'))
        SET IDENTITY_INSERT [Reservations] ON;
    EXEC(N'INSERT INTO [Reservations] ([ReservationId], [CustomerId], [PartySize], [ReservationDate], [RestaurantId], [TableId])
    VALUES (1, 1, 4, ''2024-11-16T00:00:00.0000000+02:00'', 1, 1),
    (2, 2, 2, ''2024-11-16T01:00:00.0000000+02:00'', 2, 3),
    (3, 3, 6, ''2024-11-16T02:00:00.0000000+02:00'', 3, 4),
    (4, 4, 8, ''2024-11-16T03:00:00.0000000+02:00'', 4, 5),
    (5, 5, 5, ''2024-11-16T05:00:00.0000000+02:00'', 5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ReservationId', N'CustomerId', N'PartySize', N'ReservationDate', N'RestaurantId', N'TableId') AND [object_id] = OBJECT_ID(N'[Reservations]'))
        SET IDENTITY_INSERT [Reservations] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'EmployeeId', N'OrderDate', N'ReservationId', N'TotalAmount') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    EXEC(N'INSERT INTO [Orders] ([OrderId], [EmployeeId], [OrderDate], [ReservationId], [TotalAmount])
    VALUES (1, 1, ''2024-11-16T02:00:00.0000000+02:00'', 1, 80.0),
    (2, 2, ''2024-11-16T04:00:00.0000000+02:00'', 2, 30.0),
    (3, 3, ''2024-11-16T06:00:00.0000000+02:00'', 3, 108.0),
    (4, 4, ''2024-11-16T08:00:00.0000000+02:00'', 4, 200.0),
    (5, 5, ''2024-11-16T10:00:00.0000000+02:00'', 5, 125.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'EmployeeId', N'OrderDate', N'ReservationId', N'TotalAmount') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderItemId', N'MenuItemId', N'OrderId', N'Quantity') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] ON;
    EXEC(N'INSERT INTO [OrderItems] ([OrderItemId], [MenuItemId], [OrderId], [Quantity])
    VALUES (1, 1, 1, 4),
    (2, 2, 2, 2),
    (3, 3, 3, 6),
    (4, 4, 4, 8),
    (5, 5, 5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderItemId', N'MenuItemId', N'OrderId', N'Quantity') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116174742_UpdateSeedData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241116174742_UpdateSeedData', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(45) NOT NULL,
        [LastName] nvarchar(45) NOT NULL,
        [Email] nvarchar(85) NOT NULL,
        [PhoneNumber] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Restaurants] (
        [RestaurantId] int NOT NULL IDENTITY,
        [Name] nvarchar(75) NOT NULL,
        [Address] nvarchar(150) NOT NULL,
        [PhoneNumber] nvarchar(10) NOT NULL,
        [OpeningHours] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Restaurants] PRIMARY KEY ([RestaurantId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Username] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Employees] (
        [EmployeeId] int NOT NULL IDENTITY,
        [RestaurantId] int NULL,
        [FirstName] nvarchar(45) NOT NULL,
        [LastName] nvarchar(45) NOT NULL,
        [Position] nvarchar(45) NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId]),
        CONSTRAINT [FK_Employees_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [MenuItems] (
        [MenuItemId] int NOT NULL IDENTITY,
        [RestaurantId] int NULL,
        [Name] nvarchar(75) NOT NULL,
        [Description] nvarchar(700) NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_MenuItems] PRIMARY KEY ([MenuItemId]),
        CONSTRAINT [FK_MenuItems_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Tables] (
        [TableId] int NOT NULL IDENTITY,
        [RestaurantId] int NULL,
        [Capacity] int NOT NULL,
        CONSTRAINT [PK_Tables] PRIMARY KEY ([TableId]),
        CONSTRAINT [FK_Tables_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Reservations] (
        [ReservationId] int NOT NULL IDENTITY,
        [CustomerId] int NULL,
        [RestaurantId] int NULL,
        [TableId] int NULL,
        [ReservationDate] datetime2 NOT NULL,
        [PartySize] int NOT NULL,
        CONSTRAINT [PK_Reservations] PRIMARY KEY ([ReservationId]),
        CONSTRAINT [FK_Reservations_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]),
        CONSTRAINT [FK_Reservations_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([RestaurantId]) ON DELETE SET NULL,
        CONSTRAINT [FK_Reservations_Tables_TableId] FOREIGN KEY ([TableId]) REFERENCES [Tables] ([TableId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [ReservationId] int NULL,
        [EmployeeId] int NULL,
        [OrderDate] datetime2 NOT NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Orders_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE SET NULL,
        CONSTRAINT [FK_Orders_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [Reservations] ([ReservationId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE TABLE [OrderItems] (
        [OrderItemId] int NOT NULL IDENTITY,
        [OrderId] int NULL,
        [MenuItemId] int NULL,
        [Quantity] int NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderItemId]),
        CONSTRAINT [FK_OrderItems_MenuItems_MenuItemId] FOREIGN KEY ([MenuItemId]) REFERENCES [MenuItems] ([MenuItemId]) ON DELETE SET NULL,
        CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'Email', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] ON;
    EXEC(N'INSERT INTO [Customers] ([CustomerId], [Email], [FirstName], [LastName], [PhoneNumber])
    VALUES (1, N''cs.bashar.herbawi@gmail.com'', N''Bashar'', N''Herbawi'', N''0592696336''),
    (2, N''ali.hassan@example.com'', N''Ali'', N''Hassan'', N''0591234567''),
    (3, N''obada.khalil@example.com'', N''Obada'', N''Khalil'', N''0592345678''),
    (4, N''omar.abdullah@example.com'', N''Omar'', N''Abdullah'', N''0593456789''),
    (5, N''omar.herbawi@example.com'', N''Omar'', N''Herbawi'', N''0594567890'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CustomerId', N'Email', N'FirstName', N'LastName', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Customers]'))
        SET IDENTITY_INSERT [Customers] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RestaurantId', N'Address', N'Name', N'OpeningHours', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
        SET IDENTITY_INSERT [Restaurants] ON;
    EXEC(N'INSERT INTO [Restaurants] ([RestaurantId], [Address], [Name], [OpeningHours], [PhoneNumber])
    VALUES (1, N''Ramallah'', N''Al Quds Restaurant'', N''9:00 - 22:00'', N''02-2987654''),
    (2, N''Nablus'', N''Nablus Delights'', N''10:00 - 23:00'', N''09-2345678''),
    (3, N''Hebron'', N''Hebron Grill'', N''8:00 - 20:00'', N''02-2298765''),
    (4, N''Gaza City'', N''Gaza Seafood'', N''11:00 - 23:00'', N''08-2887654''),
    (5, N''Jericho'', N''Jericho Oasis'', N''9:00 - 21:00'', N''02-2323456'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RestaurantId', N'Address', N'Name', N'OpeningHours', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
        SET IDENTITY_INSERT [Restaurants] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'FirstName', N'LastName', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([UserId], [FirstName], [LastName], [Password], [Username])
    VALUES (1, N''Ahmad'', N''Suleiman'', N''password123'', N''ahmad_s''),
    (2, N''Omar'', N''Yassin'', N''password123'', N''omar_y''),
    (3, N''Yousef'', N''Khatib'', N''password123'', N''yousef_k''),
    (4, N''Ali'', N''Zayed'', N''password123'', N''ali_z''),
    (5, N''Omar'', N''Herbawi'', N''password123'', N''omar_h'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'FirstName', N'LastName', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'Position', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] ON;
    EXEC(N'INSERT INTO [Employees] ([EmployeeId], [FirstName], [LastName], [Position], [RestaurantId])
    VALUES (1, N''Khaled'', N''Ahmad'', N''Manager'', 1),
    (2, N''Ahmad'', N''Salem'', N''Chef'', 2),
    (3, N''Obayd'', N''Ali'', N''Waiter'', 3),
    (4, N''Samir'', N''Zayed'', N''Accountant'', 4),
    (5, N''Omar'', N''Hassan'', N''Manager'', 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'FirstName', N'LastName', N'Position', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MenuItemId', N'Description', N'Name', N'Price', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[MenuItems]'))
        SET IDENTITY_INSERT [MenuItems] ON;
    EXEC(N'INSERT INTO [MenuItems] ([MenuItemId], [Description], [Name], [Price], [RestaurantId])
    VALUES (1, N''Chicken with onions and sumac on taboon bread'', N''Musakhan'', 20.0, 1),
    (2, N''Sweet cheese pastry'', N''Kanafeh'', 15.0, 2),
    (3, N''Upside-down rice and vegetable dish'', N''Maqluba'', 18.0, 3),
    (4, N''Fish with rice and spices'', N''Sayadiyah'', 25.0, 4),
    (5, N''Classic Palestinian falafel wrap'', N''Falafel Sandwich'', 5.0, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MenuItemId', N'Description', N'Name', N'Price', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[MenuItems]'))
        SET IDENTITY_INSERT [MenuItems] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TableId', N'Capacity', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Tables]'))
        SET IDENTITY_INSERT [Tables] ON;
    EXEC(N'INSERT INTO [Tables] ([TableId], [Capacity], [RestaurantId])
    VALUES (1, 4, 1),
    (2, 6, 1),
    (3, 2, 2),
    (4, 8, 3),
    (5, 10, 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TableId', N'Capacity', N'RestaurantId') AND [object_id] = OBJECT_ID(N'[Tables]'))
        SET IDENTITY_INSERT [Tables] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ReservationId', N'CustomerId', N'PartySize', N'ReservationDate', N'RestaurantId', N'TableId') AND [object_id] = OBJECT_ID(N'[Reservations]'))
        SET IDENTITY_INSERT [Reservations] ON;
    EXEC(N'INSERT INTO [Reservations] ([ReservationId], [CustomerId], [PartySize], [ReservationDate], [RestaurantId], [TableId])
    VALUES (1, 1, 4, ''2024-11-16T00:00:00.0000000+02:00'', 1, 1),
    (2, 2, 2, ''2024-11-16T01:00:00.0000000+02:00'', 2, 3),
    (3, 3, 6, ''2024-11-16T02:00:00.0000000+02:00'', 3, 4),
    (4, 4, 8, ''2024-11-16T03:00:00.0000000+02:00'', 4, 5),
    (5, 5, 5, ''2024-11-16T05:00:00.0000000+02:00'', 5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ReservationId', N'CustomerId', N'PartySize', N'ReservationDate', N'RestaurantId', N'TableId') AND [object_id] = OBJECT_ID(N'[Reservations]'))
        SET IDENTITY_INSERT [Reservations] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'EmployeeId', N'OrderDate', N'ReservationId', N'TotalAmount') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    EXEC(N'INSERT INTO [Orders] ([OrderId], [EmployeeId], [OrderDate], [ReservationId], [TotalAmount])
    VALUES (1, 1, ''2024-11-16T02:00:00.0000000+02:00'', 1, 80.0),
    (2, 2, ''2024-11-16T04:00:00.0000000+02:00'', 2, 30.0),
    (3, 3, ''2024-11-16T06:00:00.0000000+02:00'', 3, 108.0),
    (4, 4, ''2024-11-16T08:00:00.0000000+02:00'', 4, 200.0),
    (5, 5, ''2024-11-16T10:00:00.0000000+02:00'', 5, 125.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'EmployeeId', N'OrderDate', N'ReservationId', N'TotalAmount') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderItemId', N'MenuItemId', N'OrderId', N'Quantity') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] ON;
    EXEC(N'INSERT INTO [OrderItems] ([OrderItemId], [MenuItemId], [OrderId], [Quantity])
    VALUES (1, 1, 1, 4),
    (2, 2, 2, 2),
    (3, 3, 3, 6),
    (4, 4, 4, 8),
    (5, 5, 5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderItemId', N'MenuItemId', N'OrderId', N'Quantity') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Employees_RestaurantId] ON [Employees] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_MenuItems_RestaurantId] ON [MenuItems] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_OrderItems_MenuItemId] ON [OrderItems] ([MenuItemId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Orders_EmployeeId] ON [Orders] ([EmployeeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Orders_ReservationId] ON [Orders] ([ReservationId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Reservations_CustomerId] ON [Reservations] ([CustomerId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Reservations_RestaurantId] ON [Reservations] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Reservations_TableId] ON [Reservations] ([TableId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    CREATE INDEX [IX_Tables_RestaurantId] ON [Tables] ([RestaurantId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241116180632_UpdateFK'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241116180632_UpdateFK', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    DROP TABLE [Users];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Orders] SET [OrderDate] = ''2024-11-17T02:00:00.0000000+02:00''
    WHERE [OrderId] = 1;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Orders] SET [OrderDate] = ''2024-11-17T04:00:00.0000000+02:00''
    WHERE [OrderId] = 2;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Orders] SET [OrderDate] = ''2024-11-17T06:00:00.0000000+02:00''
    WHERE [OrderId] = 3;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Orders] SET [OrderDate] = ''2024-11-17T08:00:00.0000000+02:00''
    WHERE [OrderId] = 4;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Orders] SET [OrderDate] = ''2024-11-17T10:00:00.0000000+02:00''
    WHERE [OrderId] = 5;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Reservations] SET [ReservationDate] = ''2024-11-17T00:00:00.0000000+02:00''
    WHERE [ReservationId] = 1;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Reservations] SET [ReservationDate] = ''2024-11-17T01:00:00.0000000+02:00''
    WHERE [ReservationId] = 2;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Reservations] SET [ReservationDate] = ''2024-11-17T02:00:00.0000000+02:00''
    WHERE [ReservationId] = 3;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Reservations] SET [ReservationDate] = ''2024-11-17T03:00:00.0000000+02:00''
    WHERE [ReservationId] = 4;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    EXEC(N'UPDATE [Reservations] SET [ReservationDate] = ''2024-11-17T05:00:00.0000000+02:00''
    WHERE [ReservationId] = 5;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241117185857_CreateReservationsWithCustomersAndRestaurantsView', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241117193236_CreateEmployeesWithRestaurantsView'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241117193236_CreateEmployeesWithRestaurantsView', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118123130_ReservationWithCustomerAndRestaurantView'
)
BEGIN

                    CREATE VIEW ReservationWithCustomerAndRestaurantDetails AS
                    SELECT 
                        r.reservation_id,
                        r.customer_id,
                        c.first_name AS customer_first_name,
                        c.last_name AS customer_last_name,
                        c.phone_number AS customer_phone,
                        r.restaurant_id,
                        res.name AS restaurant_name,
                        res.address AS restaurant_address,
                        r.reservation_date,
                        r.table_id
                    FROM Reservations r
                    INNER JOIN Customers c ON r.customer_id = c.customer_id
                    INNER JOIN Restaurants res ON r.restaurant_id = res.restaurant_id;
                
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118123130_ReservationWithCustomerAndRestaurantView'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241118123130_ReservationWithCustomerAndRestaurantView', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118123607_EmployeeRestaurantDetails'
)
BEGIN

                    CREATE VIEW EmployeeRestaurantDetails AS
                    SELECT 
                        e.employee_id,
                        e.first_name,
                        e.last_name,
                        e.position,
                        e.restaurant_id,
                        res.name AS restaurant_name,
                        res.address AS restaurant_address,
                        res.phone_number AS restaurant_phone
                    FROM Employees e
                    INNER JOIN Restaurants res ON e.restaurant_id = res.restaurant_id;
                
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241118123607_EmployeeRestaurantDetails'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241118123607_EmployeeRestaurantDetails', N'9.0.0');
END;

COMMIT;
GO

