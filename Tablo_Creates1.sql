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
	ÖðrenciID smallint
	FOREIGN KEY (ÖðreciID) REFERENCES Öðrenci (ÖðrenciID)
)

--Hilalin kisim
CREATE TABLE MealTable (
    MealID INT PRIMARY KEY,        -- Benzersiz yemek kimliði
    Breakfast NVARCHAR(81),      -- Kahvaltý menüsü
    Dinner NVARCHAR(81),         -- Akþam yemeði menüsü
    Price DECIMAL(3, 3)          -- Yemek fiyatý
);


CREATE TABLE DormitoryStaff (
    StaffID INT PRIMARY KEY,         -- Benzersiz personel kimliði
    FullName NVARCHAR(81),          -- Personelin adý ve soyadý
    JobTitle NVARCHAR(81),          -- Görevi
    WorkingHours NVARCHAR(50),       -- Çalýþma saatleri
    PhoneNumber NVARCHAR(15),        -- Telefon numarasý
    DormID INT,                      -- Ýlgili yurt ID'si (foreign key)
    FOREIGN KEY (DormID) REFERENCES DormitoryTable(DormID) -- YurtTablosu ile iliþkilendirme
);

--Zehra'nın Kısım
CREATE TABLE RoomTable (
RoomID INT PRIMARY KEY,
RoomNumber INT IDENTITY(1,1),
RoomBlock CHAR(1) NOT NULL CHECK (Block IN ('A', 'B')), 
Occupancy TINYINT NOT NULL CHECK (Occupancy >= 0), 
BedCount TINYINT NOT NULL CHECK (BedCount BETWEEN 1 AND 9),
    CHECK (Occupancy <= BedCount),
	FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable(DormBlockID), 
);

CREATE TABLE DormBlockTable (
    DormBlockID INT PRIMARY KEY,
    BlockName CHAR(1) NOT NULL CHECK (BlockName IN ('A', 'B')),
    RoomCount INT NOT NULL CHECK (RoomCount BETWEEN 0 AND 300),
    Capacity INT NOT NULL CHECK (Capacity BETWEEN 0 AND 1200),
    AvailableBeds INT NOT NULL CHECK (AvailableBeds >= 0 AND AvailableBeds <= Capacity)
	FOREIGN KEY (YurtID) REFERENCES YurtBilgi(YurtID), 
);


-- VERİ GİRİŞİ 
--Zehra 
--Yurt blok bilgileri / 2 adet blok var A ve B 
INSERT INTO DormBlockTable (DormBlockID, BlockName, RoomCount, Capacity, AvailableBeds, DormitoryID)
VALUES 
    (1, 'A', 180, 720, 20, 1),  -- A Blok, 720 kapasite, 20 boş yatak
    (2, 'B', 170, 680, 30, 1),  -- B Blok, 680 kapasite, 30 boş yatak

--Yurt bloklarındaki 180 ve 170 odanın hepsini döngü ile veritabanına kaydettim. Boş yatak sayısını korumak için boş yatak sayı sınırlarını kontrol ettirerek 
	--odalardaki kişi sayısını 1-4 arası rastgele verdirttim. Boş yatak sınırına ulasınca tüm odalar tam dolu olarak veri girişi olacak.
	
-- A BLOK İÇİN
DECLARE @Counter INT = 1; -- Sayaç başlangıcı
DECLARE @RoomBlock CHAR(1) = 'A'; -- Blok adı
DECLARE @Occupancy INT; -- Doluluk değişkeni
DECLARE @TotalBeds INT = 720; -- Toplam 180 oda × 4 yatak
DECLARE @TotalEmptyBeds INT = 20; -- A blok için toplam boş yatak

WHILE @Counter <= 180
BEGIN
    -- Yatak doluluk oranını rastgele belirle, toplam boş yatak sınırını koru
    IF @TotalBeds - @TotalEmptyBeds >= 4 * (@Counter - 1)
        SET @Occupancy = FLOOR(RAND() * 4) + 1;
    ELSE
        SET @Occupancy = 4; -- Kalan odaları tamamen doldur
    
    INSERT INTO RoomTable (RoomBlock, Occupancy, BedCount)
    VALUES (@RoomBlock, @Occupancy, 4);
    
    -- Boş yatak sayısını güncelle
    SET @TotalEmptyBeds = @TotalEmptyBeds - (4 - @Occupancy);
    SET @Counter = @Counter + 1;
END;

-- B BLOK İÇİN
SET @Counter = 1; -- Sayaç sıfırla
SET @RoomBlock = 'B'; -- Blok adı
SET @TotalBeds = 680; -- Toplam 170 oda × 4 yatak
SET @TotalEmptyBeds = 30; -- B blok için toplam boş yatak

WHILE @Counter <= 170
BEGIN
    -- Yatak doluluk oranını rastgele belirle, toplam boş yatak sınırını koru
    IF @TotalBeds - @TotalEmptyBeds >= 4 * (@Counter - 1)
        SET @Occupancy = FLOOR(RAND() * 4) + 1;
    ELSE
        SET @Occupancy = 4; -- Kalan odaları tamamen doldur
    
    INSERT INTO RoomTable (RoomBlock, Occupancy, BedCount)
    VALUES (@RoomBlock, @Occupancy, 4);
    
    -- Boş yatak sayısını güncelle
    SET @TotalEmptyBeds = @TotalEmptyBeds - (4 - @Occupancy);
    SET @Counter = @Counter + 1;
END;

