CREATE DATABASE Yurt

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

--Hilal
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