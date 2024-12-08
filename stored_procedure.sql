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
