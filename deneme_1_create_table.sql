

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

ALTER TABLE Parent ADD
	CONSTRAINT fk_studentID
	FOREIGN KEY (StudentID) REFERENCES StudentTable (StudentID);


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

ALTER TABLE DormitoryStaff ADD
	CONSTRAINT fk_dormID_staff
	FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID);


-- Zehra'nýn kýsmý (Zehra's section)
CREATE TABLE DormBlockTable(
    DormBlockID INT PRIMARY KEY,
    BlockName CHAR(1) NOT NULL CHECK (BlockName IN ('A', 'B')),
    RoomCount INT NOT NULL CHECK (RoomCount BETWEEN 0 AND 300),
    Capacity INT NOT NULL CHECK (Capacity BETWEEN 0 AND 1200),
    AvailableBeds INT NOT NULL CHECK (AvailableBeds >= 0), -- Removed the direct reference to Capacity
    DormID smallint
);

ALTER TABLE DormBlockTable ADD
	CONSTRAINT fk_dormID_blok_table
	FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID);


CREATE TABLE RoomTable (
    RoomID INT PRIMARY KEY,
    RoomNumber INT IDENTITY(1,1),
    RoomBlock CHAR(1) NOT NULL CHECK (RoomBlock IN ('A', 'B')),
    Occupancy TINYINT NOT NULL CHECK (Occupancy >= 0),
    BedCount TINYINT NOT NULL CHECK (BedCount BETWEEN 1 AND 9),
	CONSTRAINT ck_occupancy CHECK (Occupancy <= BedCount),
    DormBlockID INT
);

drop table RoomTable
drop table DormBlockTable
drop table DormitoryStaff
drop table MealTable
drop table Parent
drop table DormitoryInfo

ALTER TABLE RoomTable ADD
	CONSTRAINT fk_dormblockID_room_table
	FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable (DormBlockID);


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
    --PaymentID NVARCHAR(50),	bunun tablosu yok
    --RegistrationDate DATE,	bunun tablosu yok
    ParentID smallint
);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_roomID_student_table
	FOREIGN KEY (RoomID) REFERENCES RoomTable (RoomID);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_dormblockID_student_table
	FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable (DormBlockID);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_dormID_student_table
	FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_mealID_student_table
	FOREIGN KEY (MealID) REFERENCES MealTable (MealID);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_parentID_student_table
	FOREIGN KEY (ParentID) REFERENCES Parent (ParentID);






--Yukarıdakı tum kodların en sade ve tekrara dusmemıs halı

-- Student Table
CREATE TABLE StudentTable (
    StudentID SMALLINT IDENTITY(1000,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    TC NVARCHAR(11),
    IBAN NVARCHAR(34),
    PhoneNumber NVARCHAR(15),
    BedNumber TINYINT,
    RoomID INT,
    ExitTime DATETIME,
    EntryTime DATETIME,
    Deposit DECIMAL(10, 2),
    BirthDate DATE,
    Department NVARCHAR(100),
    Grade NVARCHAR(10),
    University NVARCHAR(100),
    DormBlockID INT,
    DormID SMALLINT,
    MealID INT,
    ParentID SMALLINT,
    CONSTRAINT fk_roomID_student_table FOREIGN KEY (RoomID) REFERENCES RoomTable (RoomID),
    CONSTRAINT fk_dormblockID_student_table FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable (DormBlockID),
    CONSTRAINT fk_dormID_student_table FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID),
    CONSTRAINT fk_mealID_student_table FOREIGN KEY (MealID) REFERENCES MealTable (MealID),
    CONSTRAINT fk_parentID_student_table FOREIGN KEY (ParentID) REFERENCES Parent (ParentID)
);

-- Dormitory Table
CREATE TABLE DormitoryInfo (
    DormID SMALLINT PRIMARY KEY,
    DormName VARCHAR(50),
    Address VARCHAR(200),
    Phone CHAR(10),
    BlokNum TINYINT,
    DormCapacity SMALLINT,
    DormWorker SMALLINT,
    CONSTRAINT ck_phone_dormitory CHECK (Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);

-- Parent Table
CREATE TABLE Parent (
    ParentID SMALLINT PRIMARY KEY,
    NameLastName VARCHAR(50),
    Phone CHAR(10),
    StudentID SMALLINT,
    CONSTRAINT ck_phone_parent CHECK (Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    CONSTRAINT fk_studentID FOREIGN KEY (StudentID) REFERENCES StudentTable (StudentID)
);

-- Meal Table
CREATE TABLE MealTable (
    MealID INT PRIMARY KEY,
    Breakfast NVARCHAR(81),
    Dinner NVARCHAR(81),
    Price DECIMAL(5, 2) -- Adjusted for realistic precision
);

-- Dormitory Staff Table
CREATE TABLE DormitoryStaff (
    StaffID INT PRIMARY KEY,
    FullName NVARCHAR(81),
    JobTitle NVARCHAR(81),
    WorkingHours NVARCHAR(50),
    PhoneNumber NVARCHAR(15),
    DormID SMALLINT,
    CONSTRAINT fk_dormID_staff FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID)
);

-- Dorm Block Table
CREATE TABLE DormBlockTable (
    DormBlockID INT PRIMARY KEY,
    BlockName CHAR(1) NOT NULL CHECK (BlockName IN ('A', 'B')),
    RoomCount INT NOT NULL CHECK (RoomCount BETWEEN 0 AND 300),
    Capacity INT NOT NULL CHECK (Capacity BETWEEN 0 AND 1200),
    AvailableBeds INT NOT NULL CHECK (AvailableBeds >= 0),
    DormID SMALLINT,
    CONSTRAINT fk_dormID_blok_table FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID)
);

-- Room Table
CREATE TABLE RoomTable (
    RoomID INT PRIMARY KEY,
    RoomNumber INT,
    RoomBlock CHAR(1) NOT NULL CHECK (RoomBlock IN ('A', 'B')),
    Occupancy TINYINT NOT NULL CHECK (Occupancy >= 0),
    BedCount TINYINT NOT NULL CHECK (BedCount BETWEEN 1 AND 9),
    DormBlockID INT,
    CONSTRAINT ck_occupancy CHECK (Occupancy <= BedCount),
    CONSTRAINT fk_dormblockID_room_table FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable (DormBlockID)
);

