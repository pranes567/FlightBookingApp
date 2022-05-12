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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427062321_AddFlightBooingDB')
BEGIN
    CREATE TABLE [FlightDetails] (
        [Id] int NOT NULL IDENTITY,
        [FlightNumber] nvarchar(max) NULL,
        [Airline] nvarchar(max) NULL,
        [FromPlaceName] nvarchar(max) NULL,
        [ToPlaceName] nvarchar(max) NULL,
        [FlightStartDateTime] datetime2 NOT NULL,
        [FlightToDateTime] datetime2 NOT NULL,
        [TotalBusinessSeats] int NOT NULL,
        [TotalNonBusinessSeats] int NOT NULL,
        [TicketCost] decimal(18,2) NOT NULL,
        [FlightSeatRow] int NOT NULL,
        [Meal] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [Flag] int NOT NULL,
        CONSTRAINT [PK_FlightDetails] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427062321_AddFlightBooingDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220427062321_AddFlightBooingDB', N'5.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427090907_FlightBookingTable_Created')
BEGIN
    CREATE TABLE [bookFlights] (
        [BookingId] int NOT NULL IDENTITY,
        [PNR] bigint NOT NULL,
        [FlightNumber] nvarchar(max) NULL,
        [UserID] int NOT NULL,
        [FlightID] int NOT NULL,
        [FromPlaceName] nvarchar(max) NULL,
        [ToPlaceName] nvarchar(max) NULL,
        [FlightStartDateTime] datetime2 NOT NULL,
        [FlightToDateTime] datetime2 NOT NULL,
        [No_of_Seats] int NOT NULL,
        [TicketCost] decimal(18,2) NOT NULL,
        [DiscountCouponID] int NULL,
        [FinalPrice] int NOT NULL,
        [FlightSeatNo] int NOT NULL,
        [Meal] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [status] nvarchar(max) NULL,
        CONSTRAINT [PK_bookFlights] PRIMARY KEY ([BookingId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427090907_FlightBookingTable_Created')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220427090907_FlightBookingTable_Created', N'5.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427091505_DiscountCoupon_tableCreated')
BEGIN
    CREATE TABLE [DiscountCoupons] (
        [DiscountCouponID] int NOT NULL IDENTITY,
        [CouponCode] nvarchar(max) NULL,
        [couponvalue] int NOT NULL,
        [Remarks] nvarchar(max) NULL,
        CONSTRAINT [PK_DiscountCoupons] PRIMARY KEY ([DiscountCouponID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427091505_DiscountCoupon_tableCreated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220427091505_DiscountCoupon_tableCreated', N'5.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427104622_usernameadded')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[bookFlights]') AND [c].[name] = N'UserID');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [bookFlights] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [bookFlights] DROP COLUMN [UserID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427104622_usernameadded')
BEGIN
    ALTER TABLE [bookFlights] ADD [UserName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220427104622_usernameadded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220427104622_usernameadded', N'5.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220509080401_MealsColumn_datatypechanged')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FlightDetails]') AND [c].[name] = N'Meal');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [FlightDetails] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [FlightDetails] ALTER COLUMN [Meal] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220509080401_MealsColumn_datatypechanged')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[bookFlights]') AND [c].[name] = N'Meal');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [bookFlights] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [bookFlights] ALTER COLUMN [Meal] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220509080401_MealsColumn_datatypechanged')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220509080401_MealsColumn_datatypechanged', N'5.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220509101633_PassengerTable_Added')
BEGIN
    CREATE TABLE [Passengers] (
        [passengerID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [age] int NOT NULL,
        [Gender] nvarchar(max) NULL,
        [pnr] bigint NOT NULL,
        CONSTRAINT [PK_Passengers] PRIMARY KEY ([passengerID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220509101633_PassengerTable_Added')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220509101633_PassengerTable_Added', N'5.0.16');
END;
GO

COMMIT;
GO

