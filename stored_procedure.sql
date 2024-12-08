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
