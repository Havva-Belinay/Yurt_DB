CREATE DATABASE Yurt

---Haticenin kisim
CREATE TABLE StudentTable (
    StudentID INT IDENTITY(1000,1) PRIMARY KEY, 
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
	DormID INT,
    MealID INT, 
	PaymentID NVARCHAR(50),
    RegistrationDate DATE, 
	ParentID INT,
    FOREIGN KEY (RoomID) REFERENCES RoomTable(RoomID), 
    FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable(DormBlockID)
    FOREIGN KEY (DormID) REFERENCES DormTable(DormID),
	FOREIGN KEY (MealID) REFERENCES MealTable(MealID),
	FOREIGN KEY (PaymentID) REFERENCES Paymenttable(PaymentID),
	FOREIGN KEY (ParentID) REFERENCES ParentTable(ParentID)
);


---Belinayin kisim
CREATE TABLE YurtBilgi(
	YurtID smallint PRIMARY KEY,
	YurtAdi varchar(50),
	Adres varchar(200),
	Telefon char(10)
		CONSTRAINT ck_telefon 
		check(Telefon like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	BlokSayi tinyint,
	YurtKapasite smallint,
	YurtCalisan smallint
)

CREATE TABLE Veli(
	VeliID smallint PRIMARY KEY,
	AdSoyad varchar(50),
	Telefon char(10)
		CONSTRAINT ck_telefon 
		check(Telefon like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	��renciID smallint
	FOREIGN KEY (��reciID) REFERENCES ��renci (��renciID)
)

--Hilalin kisim
CREATE TABLE MealTable (
    MealID INT PRIMARY KEY,        -- Benzersiz yemek kimli�i
    Breakfast NVARCHAR(81),      -- Kahvalt� men�s�
    Dinner NVARCHAR(81),         -- Ak�am yeme�i men�s�
    Price DECIMAL(3, 3)          -- Yemek fiyat�
);


CREATE TABLE DormitoryStaff (
    StaffID INT PRIMARY KEY,         -- Benzersiz personel kimli�i
    FullName NVARCHAR(81),          -- Personelin ad� ve soyad�
    JobTitle NVARCHAR(81),          -- G�revi
    WorkingHours NVARCHAR(50),       -- �al��ma saatleri
    PhoneNumber NVARCHAR(15),        -- Telefon numaras�
    DormID INT,                      -- �lgili yurt ID'si (foreign key)
    FOREIGN KEY (DormID) REFERENCES DormitoryTable(DormID) -- YurtTablosu ile ili�kilendirme
);