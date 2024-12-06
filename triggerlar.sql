CREATE TRIGGER tg_insert_student
ON StudentTable
AFTER INSERT
AS
BEGIN
	PRINT 'Baþarýyla yeni öðrenci eklendi.'
END
GO

----------------------------------------------------

CREATE TRIGGER tg_delete_student
ON StudentTable
AFTER DELETE
AS
BEGIN
	PRINT 'Silme iþlemi baþarý ile gerçekleþtirildi.'
END
GO

---------------------------------------------------------

CREATE TRIGGER tg_insert_worker
ON Worker
AFTER INSERT
AS
BEGIN
	PRINT 'Baþarýyla yeni personel eklendi.'
END
GO

--------------------------------------------------------

CREATE TRIGGER tg_insert_parent
ON Parent
AFTER INSERT
AS
BEGIN
	PRINT 'Baþarýyla veli eklendi.'
END
GO

------------------------------------------------------------

CREATE TRIGGER tg_ins_insert_dorm
ON DormitoryInfo
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS (SELECT 1 
		FROM inserted i 
		join DormitoryInfo d 
		on i.DormID = d.DormID 
		WHERE d.DormCapacity > d.Occupancy)
		BEGIN
			

		END
		ELSE
		BEGIN
			PRINT'Hata: Yurt kapasitesi doludur.'
		END

END
go

------------------------------------------------

CREATE TRIGGER tg_update_student
ON StudentTable
AFTER UPDATE
AS
BEGIN
    -- Oda numarasý güncellendiyse
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

        -- Eðer yatak kapasitesi doluysa, iþlem yapýlmaz
        IF @Occupancy >= @BedCount
        BEGIN
            RAISERROR('Oda kapasitesi dolmuþtur, baþka bir odaya geçiþ yapýn.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
go

--------------------------------------------

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

        -- Eðer yemek durumlarý deðiþtiyse, yeni durumu kaydedin
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

--------------------------------------------------------------------------------------


CREATE TRIGGER tg_insert_student
ON StudentTable
INSTEAD OF INSERT
AS
BEGIN
    -- Uygun yer kontrolü
    IF NOT EXISTS (
        SELECT 1
        FROM DormitoryInfo d
        JOIN DormBlockTable b ON d.DormID = b.DormID
        JOIN RoomTable r ON b.BlockName = r.BlockName
        WHERE r.BedCount > r.Occupancy
    )
    BEGIN
        RAISERROR('Yurtta uygun yer bulunmamaktadýr.', 16, 1);
        RETURN;
    END

    -- Blok ve oda seçimi
    DECLARE @DormID SMALLINT, @BlockName CHAR(1), @RoomNumber SMALLINT;

    SELECT TOP 1 
        @DormID = d.DormID, 
        @BlockName = b.BlockName,
        @RoomNumber = r.RoomNumber
    FROM DormitoryInfo d
    JOIN DormBlockTable b ON d.DormID = b.DormID
    JOIN RoomTable r ON b.BlockName = r.BlockName
    WHERE r.BedCount > r.Occupancy
    ORDER BY d.DormID, b.BlockName, r.RoomNumber;

    -- Öðrenciyi uygun odaya yerleþtir
    INSERT INTO StudentTable (TC, FullName, PhoneNumber, BedNumber, RoomNumber, BlockName, DormID)
    SELECT 
        i.TC, i.FullName, i.PhoneNumber, 
        (r.Occupancy + 1), @RoomNumber, @BlockName, @DormID
    FROM inserted i;

    -- Oda doluluk bilgisini güncelle
    UPDATE RoomTable
    SET Occupancy = Occupancy + 1
    WHERE RoomNumber = @RoomNumber AND BlockName = @BlockName;

    -- Blok doluluk bilgisini güncelle
    UPDATE DormBlockTable
    SET AvailableBeds = AvailableBeds - 1
    WHERE BlockName = @BlockName;

    -- Yurt doluluk bilgisini güncelle
    UPDATE DormitoryInfo
    SET Occupancy = Occupancy + 1
    WHERE DormID = @DormID;
END
go

-------------------------------------------------------------

CREATE TRIGGER tg_insert_studenttable
ON StudentTable
INSTEAD OF INSERT
AS
BEGIN
    -- Öðrenci ekleme iþleminden önce oda kapasitesini kontrol et
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN RoomTable r ON i.RoomNumber = r.RoomNumber
        WHERE r.BedCount > r.Occupancy
    )
    BEGIN
        -- Eðer yer varsa, öðrenci kaydýný gerçekleþtirin
        INSERT INTO StudentTable (FullName, TC, RoomNumber, BedNumber, Department, Grade, University, DormID, ParentID)
        SELECT FullName, TC, RoomNumber, BedNumber, Department, Grade, University, DormID, ParentID
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Eðer oda doluysa, uygun oda bulunamadýðýný belirten mesaj
        RAISERROR('Odadaki yatak kapasitesi dolmuþtur. Lütfen baþka bir oda seçiniz.', 16, 1);
    END
END;
go

---------------------------------------------

CREATE TRIGGER tg_insert_mealtable
ON MealTable
INSTEAD OF INSERT
AS
BEGIN
    -- Öðrencinin yemek durumu kontrol edilir
    DECLARE @StudentID smallint;
    DECLARE @IsBreakfast bit;
    DECLARE @IsDinner bit;

    SELECT @StudentID = StudentID, @IsBreakfast = IsBreakfast, @IsDinner = IsDinner
    FROM inserted;

    -- Eðer yemek kaydý varsa, öðrencinin yemek durumunu güncelle
    IF @IsBreakfast = 1
    BEGIN
        INSERT INTO MealTable (IsBreakfast, StudentID)
        VALUES (1, @StudentID);
    END

    IF @IsDinner = 1
    BEGIN
        INSERT INTO MealTable (IsDinner, StudentID)
        VALUES (1, @StudentID);
    END
END;
go


--------------------------------------------


CREATE TRIGGER tg_update_roomtable
ON RoomTable
INSTEAD OF UPDATE
AS
BEGIN
    -- Yeni veriler 'inserted' sanal tablosunda, eski veriler 'deleted' sanal tablosunda bulunur.
    -- Koþul kontrolü
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN RoomTable r ON i.RoomID = r.RoomID
        WHERE i.Occupancy > r.BedCount
    )
    BEGIN
        -- Eðer doluluk izin verilen deðeri aþýyorsa uyarý ver ve iþlem yapýlmasýn
        PRINT 'Doluluk toplam yatak sayýsýný aþamaz. Güncelleme iþlemi engellendi.';
    END
    ELSE
    BEGIN
        -- Eðer koþul saðlanýyorsa güncelleme iþlemini gerçekleþtir
        UPDATE RoomTable
        SET Occupancy = i.Occupancy,
            BedCount = i.BedCount
        FROM RoomTable r
        JOIN inserted i ON r.RoomID = i.RoomID;

        PRINT 'Güncelleme iþlemi baþarýyla tamamlandý.';
    END
END;
GO

-----------------------------------------------------

	--odanýn doluluðunu kontrol eden trigger
CREATE TRIGGER IsRoomAvailable
ON StudentTable
AFTER UPDATE
AS
BEGIN
    -- Güncellenen RoomID deðerlerini kontrol et
    IF EXISTS (
        SELECT 1
        FROM RoomTable r
        INNER JOIN inserted i ON r.RoomID = i.RoomID
        WHERE r.Occupancy >= r.BedCount  -- Oda dolu mu kontrol et
    )
    BEGIN
        RAISERROR ('Seçilen odada boþ yatak bulunmamaktadýr.', 16, 1);
        ROLLBACK TRANSACTION; -- Ýþlemi geri al
    END
END;
