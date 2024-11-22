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
	��renciID smallint
	FOREIGN KEY (��reciID) REFERENCES ��renci (��renciID)
)