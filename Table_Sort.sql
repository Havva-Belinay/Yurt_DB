CREATE DATABASE Dormitory


---Belinayin kisim
CREATE TABLE DormitoryInfo(
	DormID smallint PRIMARY KEY,
	DormName varchar(50),
	Address varchar(200),
	Phone char(10)
		CONSTRAINT ck_phone 
		check(Phone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	BlokNum tinyint,
	DormCapacity smallint,
	DormWorker smallint
);

--Hilalin kisim
CREATE TABLE MealTable (
    MealID INT PRIMARY KEY,        -- Benzersiz yemek kimliði
    Breakfast NVARCHAR(81),      -- Kahvaltý menüsü
    Dinner NVARCHAR(81),         -- Akþam yemeði menüsü
    Price DECIMAL(3, 3)          -- Yemek fiyatý
);

--bu kısmı create etmedim.
--Zehra'nın Kısım
CREATE TABLE DormBlockTable (
    DormBlockID INT PRIMARY KEY, -- Benzersiz blok ID'si
    BlockName CHAR(1) NOT NULL CHECK (BlockName IN ('A', 'B')), -- Blok adı (A veya B)
    RoomCount INT NOT NULL CHECK (RoomCount BETWEEN 0 AND 300), -- Oda sayısı 0-300 arasında
    Capacity INT NOT NULL CHECK (Capacity BETWEEN 0 AND 1200), -- Kapasite 0-1200 arasında
    AvailableBeds INT NOT NULL CHECK (AvailableBeds BETWEEN 0 AND 1200), -- Boş yatak sayısı 0-1200 arasında
    DormID smallint NOT NULL, -- Yurt ID'si
    FOREIGN KEY (DormID) REFERENCES DormitoryInfo(DormID) -- Yurt ID'si ile ilişkilendirme
);



--bu kısım da create edilmedi.
CREATE TABLE RoomTable (
    RoomID INT PRIMARY KEY, -- Benzersiz oda ID'si
    RoomNumber INT IDENTITY(1,1), -- Otomatik artan oda numarası
    RoomBlock CHAR(1) NOT NULL CHECK (RoomBlock IN ('A', 'B')), -- Blok adı (A veya B)
    Occupancy TINYINT NOT NULL CHECK (Occupancy >= 0), -- Doluluk sayısı en az 0
    BedCount TINYINT NOT NULL CHECK (BedCount BETWEEN 1 AND 9), -- Yatak sayısı 1-9 arasında
    CONSTRAINT chk_Occupancy_BedCount CHECK (Occupancy <= BedCount), -- Doluluk yatak sayısından fazla olamaz
    DormBlockID INT NOT NULL, -- Blok ID'si
    FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable(DormBlockID) -- Blok ID'si ile ilişkilendirme
);


CREATE TABLE Parent(
	ParentID smallint PRIMARY KEY,
	NameLastName varchar(50),
	Phone char(10)
		CONSTRAINT ck_phone 
		check(Phone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
)

alter table Parent add
StudentID smallint;
alter table Parent add
Constraint fk_student Foreign key (StudentID) references StudentTable(StudentID)


---Haticenin kisim
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
    RegistrationDate DATE, 
	ParentID smallint,
    FOREIGN KEY (RoomID) REFERENCES RoomTable(RoomID), 
    FOREIGN KEY (DormBlockID) REFERENCES DormBlockTable(DormBlockID),
    FOREIGN KEY (DormID) REFERENCES DormitoryInfo(DormID),
	FOREIGN KEY (MealID) REFERENCES MealTable(MealID),
	FOREIGN KEY (ParentID) REFERENCES Parent(ParentID)
);

CREATE TABLE DormitoryStaff (
    StaffID INT PRIMARY KEY,         -- Benzersiz personel kimliði
    FullName NVARCHAR(81),          -- Personelin adý ve soyadý
    JobTitle NVARCHAR(81),          -- Görevi
    WorkingHours NVARCHAR(50),       -- Çalýþma saatleri
    PhoneNumber NVARCHAR(15),        -- Telefon numarasý
    DormID smallint,                      -- Ýlgili yurt ID'si (foreign key)
    FOREIGN KEY (DormID) REFERENCES DormitoryInfo(DormID) -- YurtTablosu ile iliþkilendirme
);














-- VERİ GİRİŞİ 
--Zehra 
--Yurt blok bilgileri / 2 adet blok var A ve B 
INSERT INTO DormBlockTable (DormBlockID, BlockName, RoomCount, Capacity, AvailableBeds, DormID)
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

