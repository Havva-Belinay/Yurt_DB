CREATE TRIGGER tg_insert_student
ON StudentTable
AFTER INSERT
AS
BEGIN
	PRINT 'Ba�ar�yla yeni ��renci eklendi.'
END
GO

----------------------------------------------------

CREATE TRIGGER tg_delete_student
ON StudentTable
AFTER DELETE
AS
BEGIN
	PRINT 'Silme i�lemi ba�ar� ile ger�ekle�tirildi.'
END
GO

---------------------------------------------------------

CREATE TRIGGER tg_insert_worker
ON Worker
AFTER INSERT
AS
BEGIN
	PRINT 'Ba�ar�yla yeni personel eklendi.'
END
GO

--------------------------------------------------------

CREATE TRIGGER tg_insert_parent
ON Parent
AFTER INSERT
AS
BEGIN
	PRINT 'Ba�ar�yla veli eklendi.'
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
    -- Oda numaras� g�ncellendiyse
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

        -- E�er yatak kapasitesi doluysa, i�lem yap�lmaz
        IF @Occupancy >= @BedCount
        BEGIN
            RAISERROR('Oda kapasitesi dolmu�tur, ba�ka bir odaya ge�i� yap�n.', 16, 1);
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
    -- Yemek durumu g�ncellendiyse
    IF UPDATE(IsBreakfast) OR UPDATE(IsDinner)
    BEGIN
        DECLARE @StudentID smallint;
        DECLARE @IsBreakfast bit;
        DECLARE @IsDinner bit;

        SELECT @StudentID = StudentID, @IsBreakfast = IsBreakfast, @IsDinner = IsDinner
        FROM inserted;

        -- E�er yemek durumlar� de�i�tiyse, yeni durumu kaydedin
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
    -- Uygun yer kontrol�
    IF NOT EXISTS (
        SELECT 1
        FROM DormitoryInfo d
        JOIN DormBlockTable b ON d.DormID = b.DormID
        JOIN RoomTable r ON b.BlockName = r.BlockName
        WHERE r.BedCount > r.Occupancy
    )
    BEGIN
        RAISERROR('Yurtta uygun yer bulunmamaktad�r.', 16, 1);
        RETURN;
    END

    -- Blok ve oda se�imi
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

    -- ��renciyi uygun odaya yerle�tir
    INSERT INTO StudentTable (TC, FullName, PhoneNumber, BedNumber, RoomNumber, BlockName, DormID)
    SELECT 
        i.TC, i.FullName, i.PhoneNumber, 
        (r.Occupancy + 1), @RoomNumber, @BlockName, @DormID
    FROM inserted i;

    -- Oda doluluk bilgisini g�ncelle
    UPDATE RoomTable
    SET Occupancy = Occupancy + 1
    WHERE RoomNumber = @RoomNumber AND BlockName = @BlockName;

    -- Blok doluluk bilgisini g�ncelle
    UPDATE DormBlockTable
    SET AvailableBeds = AvailableBeds - 1
    WHERE BlockName = @BlockName;

    -- Yurt doluluk bilgisini g�ncelle
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
    -- ��renci ekleme i�leminden �nce oda kapasitesini kontrol et
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN RoomTable r ON i.RoomNumber = r.RoomNumber
        WHERE r.BedCount > r.Occupancy
    )
    BEGIN
        -- E�er yer varsa, ��renci kayd�n� ger�ekle�tirin
        INSERT INTO StudentTable (FullName, TC, RoomNumber, BedNumber, Department, Grade, University, DormID, ParentID)
        SELECT FullName, TC, RoomNumber, BedNumber, Department, Grade, University, DormID, ParentID
        FROM inserted;
    END
    ELSE
    BEGIN
        -- E�er oda doluysa, uygun oda bulunamad���n� belirten mesaj
        RAISERROR('Odadaki yatak kapasitesi dolmu�tur. L�tfen ba�ka bir oda se�iniz.', 16, 1);
    END
END;
go

---------------------------------------------

CREATE TRIGGER tg_insert_mealtable
ON MealTable
INSTEAD OF INSERT
AS
BEGIN
    -- ��rencinin yemek durumu kontrol edilir
    DECLARE @StudentID smallint;
    DECLARE @IsBreakfast bit;
    DECLARE @IsDinner bit;

    SELECT @StudentID = StudentID, @IsBreakfast = IsBreakfast, @IsDinner = IsDinner
    FROM inserted;

    -- E�er yemek kayd� varsa, ��rencinin yemek durumunu g�ncelle
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
    -- Ko�ul kontrol�
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN RoomTable r ON i.RoomID = r.RoomID
        WHERE i.Occupancy > r.BedCount
    )
    BEGIN
        -- E�er doluluk izin verilen de�eri a��yorsa uyar� ver ve i�lem yap�lmas�n
        PRINT 'Doluluk toplam yatak say�s�n� a�amaz. G�ncelleme i�lemi engellendi.';
    END
    ELSE
    BEGIN
        -- E�er ko�ul sa�lan�yorsa g�ncelleme i�lemini ger�ekle�tir
        UPDATE RoomTable
        SET Occupancy = i.Occupancy,
            BedCount = i.BedCount
        FROM RoomTable r
        JOIN inserted i ON r.RoomID = i.RoomID;

        PRINT 'G�ncelleme i�lemi ba�ar�yla tamamland�.';
    END
END;
GO

-----------------------------------------------------

	--odan�n dolulu�unu kontrol eden trigger
CREATE TRIGGER IsRoomAvailable
ON StudentTable
AFTER UPDATE
AS
BEGIN
    -- G�ncellenen RoomID de�erlerini kontrol et
    IF EXISTS (
        SELECT 1
        FROM RoomTable r
        INNER JOIN inserted i ON r.RoomID = i.RoomID
        WHERE r.Occupancy >= r.BedCount  -- Oda dolu mu kontrol et
    )
    BEGIN
        RAISERROR ('Se�ilen odada bo� yatak bulunmamaktad�r.', 16, 1);
        ROLLBACK TRANSACTION; -- ��lemi geri al
    END
END;
