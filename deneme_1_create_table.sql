-- Belinay kýsmý (Belinay's section)
CREATE TABLE DormitoryInfo(
    DormID smallint PRIMARY KEY,
    DormName varchar(50),
    Address varchar(200),
    Phone char(10)
        CONSTRAINT ck_phone_dormitory  -- Constraint adýný deðiþtirdik
        CHECK(Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    BlokNum tinyint,
    DormCapacity smallint,
    DormWorker smallint
);

CREATE TABLE Parent(
    ParentID smallint PRIMARY KEY,
    NameLastName varchar(50),
    Phone char(10)
        CONSTRAINT ck_phone_parent -- Renamed the constraint to avoid conflict
        CHECK(Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    StudentID smallint
);

-- Hilal'in kýsmý (Hilal's section)
CREATE TABLE MealTable (
    MealID INT PRIMARY KEY,        -- Unique meal ID
    Breakfast NVARCHAR(81),        -- Breakfast menu
    Dinner NVARCHAR(81),           -- Dinner menu
    Price DECIMAL(3, 3)            -- Meal price
);

CREATE TABLE DormitoryStaff (
    StaffID INT PRIMARY KEY,       -- Unique staff ID
    FullName NVARCHAR(81),         -- Staff full name
    JobTitle NVARCHAR(81),         -- Job title
    WorkingHours NVARCHAR(50),     -- Working hours
    PhoneNumber NVARCHAR(15),      -- Phone number
    DormID smallint                -- Dormitory ID
);

-- Zehra'nýn kýsmý (Zehra's section)
CREATE TABLE DormBlockTable(
    DormBlockID INT PRIMARY KEY,
    BlockName CHAR(1) NOT NULL CHECK (BlockName IN ('A', 'B')),
    RoomCount INT NOT NULL CHECK (RoomCount BETWEEN 0 AND 300),
    Capacity INT NOT NULL CHECK (Capacity BETWEEN 0 AND 1200),
    AvailableBeds INT NOT NULL CHECK (AvailableBeds >= 0), -- Removed the direct reference to Capacity
    DormID smallint
);

CREATE TABLE RoomTable (
    RoomID INT PRIMARY KEY,
    RoomNumber INT IDENTITY(1,1),
    RoomBlock CHAR(1) NOT NULL CHECK (RoomBlock IN ('A', 'B')),
    Occupancy TINYINT NOT NULL CHECK (Occupancy >= 0),
    BedCount TINYINT NOT NULL CHECK (BedCount BETWEEN 1 AND 9),
    CHECK (Occupancy <= BedCount),
    DormBlockID INT
);

-- Hatice'nin kýsmý (Hatice's section)
CREATE TABLE StudentTable (
    StudentID smallint IDENTITY(1000,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    TC NVARCHAR(11),
    IBAN NVARCHAR(34),
    PhoneNumber NVARCHAR(15),
    BedNumber TINYINT,
    RoomNumber INT,
    ExitTime DATETIME,
    EntryTime DATETIME,
    Deposit DECIMAL(10, 2),
    BirthDate DATE,
    Department NVARCHAR(100),
    Grade NVARCHAR(10),
    University NVARCHAR(100),
    RoomID INT,
    DormBlockID INT,
    DormID smallint,
    MealID INT,
    PaymentID NVARCHAR(50),
    RegistrationDate DATE,
    ParentID INT
);
