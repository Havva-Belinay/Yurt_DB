

-- Belinay kismi (Belinay's section)
CREATE TABLE DormitoryInfo(
    DormID smallint identity(1,1)PRIMARY KEY,
    DormName nvarchar(50) not null, 
    Address nvarchar(200),
    Phone char(10) not null
        CONSTRAINT ck_phone_dormitory 
        CHECK(Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    BlokNum tinyint
		CONSTRAINT ck_bloknum 
		CHECK(BlokNum IN ('0', '1', '2')),
    DormCapacity smallint not null
		CONSTRAINT ck_dormcapacity 
		CHECK(DormCapacity BETWEEN 0 AND 2400), --      <<<<<<<<<<<<<<<<<<<trigger>>>>>>>>>>>>>>>>>>>>>>
	Occupancy smallint NOT NULL CHECK (Occupancy >= 0 AND Occupancy <= 2400)
);


CREATE TABLE Parent(
    ParentID smallint identity(1,1) PRIMARY KEY,
    NameLastName nvarchar(50) DEFAULT 'Veli bilgisine ulaşılamadı.',
    Phone char(10) DEFAULT '0000000000'
        CONSTRAINT ck_phone_parent
        CHECK(Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    StudentID smallint
);

ALTER TABLE Parent ADD
	CONSTRAINT fk_studentID_parent
	FOREIGN KEY (StudentID) REFERENCES StudentTable (StudentID);


-- Hilal'in kismi (Hilal's section)
CREATE TABLE MealTable (
    MealID INT identity(1,1) PRIMARY KEY , 
	IsDinner bit,
	IsBreakfast bit,
	StudentID smallint
);

ALTER TABLE MealTable ADD
	CONSTRAINT fk_studentID_mealtable
	FOREIGN KEY (StudentID) REFERENCES StudentTable (StudentID);

CREATE TABLE Worker (
    WorkerID INT identity(1,1) PRIMARY KEY, 
    TC NVARCHAR(11) NOT NULL 
		constraint ck_workertc
		check(TC LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	FullName NVARCHAR(81) not null, 
    JobTitle NVARCHAR(81), 
    PhoneNumber char(10) DEFAULT '0000000000'
        CONSTRAINT ck_phone_worker
        CHECK(PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	DormID smallint  
);

ALTER TABLE Worker ADD
	CONSTRAINT fk_dormID_worker
	FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID);

--alter table DormitoryStaff
--drop constraint fk_dormID_staff

-- Zehra'nin kismi (Zehra's section)
CREATE TABLE DormBlockTable(
    DormBlockID INT identity(1,1),
    BlockName CHAR(1) NOT NULL CHECK (BlockName IN ('A', 'B')) PRIMARY KEY,
    RoomCount smallint NOT NULL CHECK (RoomCount BETWEEN 0 AND 300),
    Capacity smallint NOT NULL CHECK (Capacity BETWEEN 0 AND 1200), --             <<<<<<<<<<trigger>>>>>>>>>>
    AvailableBeds smallint NOT NULL CHECK (AvailableBeds >= 0 AND AvailableBeds <= 1200), --  <<<<<<<<<trigger>>>>>>>>>>>>
    DormID smallint
);

ALTER TABLE DormBlockTable ADD
	CONSTRAINT fk_dormID_blok_table
	FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID);


CREATE TABLE RoomTable (
    RoomID INT , --PRIMARY KEY
    RoomNumber smallint IDENTITY(1,1) primary key,
    RoomBlock CHAR(1) NOT NULL CHECK (RoomBlock IN ('A', 'B')),
    Occupancy TINYINT NOT NULL CHECK (Occupancy >= 0 AND Occupancy <= 4),--            <<<<<<<<<<<<<<<<<<<<trigger>>>>>>>>>>>>>>>>>>>>>>  
    BedCount TINYINT NOT NULL CHECK (BedCount IN ('1', '2', '3', '4')),
	CONSTRAINT ck_occupancy 
	CHECK (Occupancy <= BedCount),
    BlockName char(1)
);

ALTER TABLE RoomTable ADD
	CONSTRAINT fk_blokname_room_table
	FOREIGN KEY (BlockName) REFERENCES DormBlockTable (BlockName);



-- Hatice'nin kismi (Hatice's section)
CREATE TABLE StudentTable (
    StudentID smallint IDENTITY(1,1) PRIMARY KEY,
    TC NVARCHAR(11) NOT NULL 
		constraint ck_tc
		check(TC LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	FullName NVARCHAR(100) NOT NULL,
    IBAN NVARCHAR(34),
    PhoneNumber char(10) DEFAULT '0000000000'
        CONSTRAINT ck_phone_student
        CHECK(PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    BedNumber TINYINT 
		Constraint ck_bednum
		check(BedNumber IN ('1', '2', '3', '4')),--            <<<<<<<<<trigger(yatak numarası odadaki yatak sayısından küçük ya da eşit olmalı)>>>>>>>>
    RoomNumber smallint check(RoomNumber <= 300 and RoomNumber > 0),
	BlockName char(1),
    ExitTime DATETIME,
    EntryTime DATETIME,
    Deposit DECIMAL(10, 2),
    BirthDate DATE,
    Department NVARCHAR(100),
    Grade nvarchar(8),
    University NVARCHAR(100),
    DormID smallint,
    ParentID smallint
);


CREATE TABLE DeletedStudentRecords (
    DeletedID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID SMALLINT,
    FullName NVARCHAR(100),
    TC NVARCHAR(11),
    DeletionTime DATETIME DEFAULT GETDATE()
);

------------------<<<<<<<<<<<<<<<<<yemek kısmı için trigger lazım. yendi mi yenmedi mi diye>>>>>>>>>>>>>>>>>>>


ALTER TABLE StudentTable ADD
	CONSTRAINT fk_roomnumber_student_table
	FOREIGN KEY (RoomNumber) REFERENCES RoomTable (RoomNumber);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_blockname_student_table
	FOREIGN KEY (BlockName) REFERENCES DormBlockTable (BlockName);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_dormID_student_table
	FOREIGN KEY (DormID) REFERENCES DormitoryInfo (DormID);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_mealID_student_table
	FOREIGN KEY (MealID) REFERENCES MealTable (MealID);

ALTER TABLE StudentTable ADD
	CONSTRAINT fk_parentID_student_table
	FOREIGN KEY (ParentID) REFERENCES Parent (ParentID);

-----------------------------------------------------------------------
			--password tabloları

CREATE TABLE StudentPassword (
    sPasswordID INT PRIMARY KEY IDENTITY(1,1),
    TC NVARCHAR(11) NOT NULL,
    sPassword CHAR(8) NOT NULL 
);

ALTER TABLE StudentPassword ADD
	CONSTRAINT fk_sPasswordID
	FOREIGN KEY (TC) REFERENCES StudentTable (TC);

CREATE TABLE WorkerPassword(
	wPasswordID INT PRIMARY KEY IDENTITY(1,1),
	TC nvarchar(11) NOT NULL,
	wPassword char(8) NOT NULL
);

ALTER TABLE WorkerPassword ADD
	CONSTRAINT fk_wPasswordID
	FOREIGN KEY (TC) REFERENCES Worker (TC);



--drop table RoomTable
--drop table DormBlockTable
--drop table Worker
--drop table MealTable
--drop table Parent
--drop table DormitoryInfo


GO
CREATE TRIGGER trg_AfterDelete_Student
ON StudentTable
AFTER DELETE
AS
BEGIN
    -- Silinen kayıtları DeletedStudentRecords tablosuna ekle
    INSERT INTO DeletedStudentRecords (StudentID, FullName, TC)
    SELECT d.StudentID, d.FullName, d.TC
    FROM DELETED d;

    PRINT 'Silinen kayıtlar DeletedStudentRecords tablosuna kaydedildi.';
END;
GO

CREATE TRIGGER trg_DeleteStudent_Parent
ON StudentTable
AFTER DELETE
AS
BEGIN
    -- Silinen öğrencinin Parent tablosundaki velisini sil
    DELETE FROM Parent
    WHERE Parent.StudentID IN (SELECT d.StudentID FROM DELETED d);

    PRINT 'Silinen öğrencinin veli bilgileri de Parent tablosundan kaldırıldı.';
END;
GO

CREATE TRIGGER tg_update_student
ON StudentTable
AFTER UPDATE
AS
BEGIN
    -- Oda numarası güncellendiyse
    IF UPDATE(RoomNumber)
    BEGIN
        DECLARE @RoomNumber smallint;
        DECLARE @BedCount smallint;
        DECLARE @Occupancy smallint;

        SELECT @RoomNumber = RoomNumber
        FROM inserted;

        SELECT @BedCount = BedCount, @Occupancy = Occupancy
        FROM RoomTable
        WHERE RoomNumber = @RoomNumber;

        -- Eğer yatak kapasitesi doluysa, işlem yapılmaz
        IF @Occupancy >= @BedCount
        BEGIN
            RAISERROR('Oda kapasitesi dolmuştur, başka bir odaya geçiş yapın.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
go

CREATE TRIGGER tg_update_mealtable
ON MealTable
AFTER UPDATE
AS
BEGIN
    -- Yemek durumu güncellendiyse
    IF UPDATE(IsBreakfast) OR UPDATE(IsDinner)
    BEGIN
        DECLARE @StudentID smallint;
        DECLARE @IsBreakfast bit;
        DECLARE @IsDinner bit;

        SELECT @StudentID = StudentID, @IsBreakfast = IsBreakfast, @IsDinner = IsDinner
        FROM inserted;

        -- Eğer yemek durumları değiştiyse, yeni durumu kaydedin
        IF @IsBreakfast = 1
        BEGIN
            UPDATE MealTable
            SET IsBreakfast = 1
            WHERE StudentID = @StudentID;
        END

        IF @IsDinner = 1
        BEGIN
            UPDATE MealTable
            SET IsDinner = 1
            WHERE StudentID = @StudentID;
        END
    END
END;
go


CREATE TRIGGER tg_insert_studenttable
ON StudentTable
INSTEAD OF INSERT
AS
BEGIN
    -- Öğrenci ekleme işleminden önce oda kapasitesini kontrol et
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN RoomTable r ON i.RoomNumber = r.RoomNumber
        WHERE r.BedCount > r.Occupancy
    )
    BEGIN
        -- Eğer yer varsa, öğrenci kaydını gerçekleştirin
        INSERT INTO StudentTable (FullName, TC, RoomNumber, BedNumber, Department, Grade, University, DormID, ParentID)
        SELECT FullName, TC, RoomNumber, BedNumber, Department, Grade, University, DormID, ParentID
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Eğer oda doluysa, uygun oda bulunamadığını belirten mesaj
        RAISERROR('Odadaki yatak kapasitesi dolmuştur. Lütfen başka bir oda seçiniz.', 16, 1);
    END
END;
go


CREATE TRIGGER tg_update_roomtable
ON RoomTable
INSTEAD OF UPDATE
AS
BEGIN
    -- Yeni veriler 'inserted' sanal tablosunda, eski veriler 'deleted' sanal tablosunda bulunur.
    -- Koşul kontrolü
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN RoomTable r ON i.RoomID = r.RoomID
        WHERE i.Occupancy > r.BedCount
    )
    BEGIN
        -- Eğer doluluk izin verilen değeri aşıyorsa uyarı ver ve işlem yapılmasın
        PRINT 'Doluluk toplam yatak sayısını aşamaz. Güncelleme işlemi engellendi.';
    END
    ELSE
    BEGIN
        -- Eğer koşul sağlanıyorsa güncelleme işlemini gerçekleştir
        UPDATE RoomTable
        SET Occupancy = i.Occupancy,
            BedCount = i.BedCount
        FROM RoomTable r
        JOIN inserted i ON r.RoomID = i.RoomID;

        PRINT 'Güncelleme işlemi başarıyla tamamlandı.';
    END
END;
GO



CREATE PROCEDURE sp_SearchByName
    @Ad NVARCHAR(81)  -- Kullanıcının gireceği ad
AS
BEGIN
    SELECT 
        StudentID, 
        FullName, 
        TC, 
        PhoneNumber, 
        RoomNumber, 
        DormID 
    FROM 
        StudentTable
    WHERE 
        FullName LIKE @Ad + '%'; -- Ad ile başlayan isimleri döndürür
END;
 --EXEC sp_SearchByName @Ad = 'Zehra';  arama şeklimiz bu
 go

 CREATE PROCEDURE sp_SearchByFullName
    @Ad NVARCHAR(50),       -- Kullanıcının gireceği ad
    @Soyad NVARCHAR(50)     -- Kullanıcının gireceği soyad
AS
BEGIN
    SELECT 
        StudentID, 
        FullName, 
        TC, 
        PhoneNumber, 
        RoomNumber, 
        DormID 
    FROM 
        StudentTable
    WHERE 
        FullName LIKE @Ad + ' ' + @Soyad; -- Tam ad ve soyad eşleşmesi
END;

--EXEC sp_SearchByFullName @Ad = 'Zehra', @Soyad = 'Bayraktar'; kullanım şekli
go

CREATE PROCEDURE sp_SearchByPartialName
    @NamePart NVARCHAR(100) -- Kullanıcının gireceği herhangi bir isim parçası
AS
BEGIN
    SELECT 
        StudentID, 
        FullName, 
        TC, 
        PhoneNumber, 
        RoomNumber, 
        DormID 
    FROM 
        StudentTable
    WHERE 
        FullName LIKE '%' + @NamePart + '%'; -- Ad veya soyad içinde geçenleri döndürür
END;

--EXEC sp_SearchByPartialName @NamePart = 'ehra'; kullanım şekli
