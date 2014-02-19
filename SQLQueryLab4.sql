SELECT *
FROM Kund

SELECT *
FROM Telefon

SELECT *
FROM Teltyp

SELECT *
FROM Artikel

SELECT *
FROM Faktura

SELECT *
FROM Fakturarad

SELECT *
FROM Kategori

-- Uppgift 3 INSERT
INSERT INTO Kund (Namn, Adress, Postnr, Ort, Rabbat, KategoriID)
VALUES ('Danielssons Elektriska AB', 'Storgatan 128', '12356', 'STOCKHOLM', 0.03, 1)

INSERT INTO Telefon (KundID, Telenr, TeltypID)
VALUES (8, '08-897 02 00', 1),
	   (8, '070-547 02 87', 5)
	   
INSERT INTO Artikel (Artnamn, Antal, Pris, Rabatt)
VALUES ('Bildskärm, platt, 10ms', 47, 2176.00, 0),
	   ('Tangentbord', 36, 280.00, 0),
	   ('Nätkabel, TP kat 5', 1020, 2.50, 0)
	   
INSERT INTO Faktura (Datum, Betvilkor, KundID)
VALUES ('2012-04-20', 25, 8)

INSERT INTO Fakturarad (FakturaID, ArtikelID, Antal, Pris, Rabatt)
VALUES (4, 5, 2, 2176.00, 0.03),
	   (4, 1, 22, 6.70, 0.03)

INSERT INTO Kategori (Kategori)
VALUES ('Standard') 

-- Uppgift 4 UPDATE

UPDATE Kund
SET KategoriID = 4
WHERE KundID = 3

UPDATE Telefon
SET Telenr = '0480-492239'
WHERE Telenr = '0480-479888'

UPDATE Artikel
SET Pris = Pris*1.08

UPDATE Artikel
SET Plats = 'HLP 25'
WHERE ArtikelID = 3 OR ArtikelID = 5

UPDATE Artikel
SET Plats = 'Förråd 10'
WHERE Plats IS NULL

UPDATE Fakturarad
SET Pris = Pris*1.08
WHERE ArtikelID = 2

-- Uppgift 5 DELETE

DELETE
FROM Telefon
WHERE KundID = 8 AND TeltypID = 1

DELETE
FROM Fakturarad
WHERE ArtikelID = 4

DELETE
FROM Kategori
WHERE KategoriID = 4
-- Går inte att radera då den används av en kund man måste först ändra alla kunder som använde Standard innan man kan radera den

-- Uppgift 6 SELECT 1

SELECT *
FROM Kund

SELECT Namn, Postnr, Ort
FROM Kund

SELECT Namn, Postnr, Ort
FROM Kund
ORDER BY Postnr DESC

SELECT Namn, Adress, Postnr+Ort AS Postadress
FROM Kund
ORDER BY Ort ASC

SELECT ArtikelID AS Artikelnr, Artnamn AS Namn, Antal, Pris, FLOOR (Antal*Pris) AS Artikelvärde
FROM Artikel

SELECT ArtikelID AS Artikelnr, Artnamn AS Namn, Plats, Antal,'___________' AS 'Nytt antal'
FROM Artikel

SELECT ArtikelID AS Artikelnr, Artnamn AS Namn, Plats, Antal,'___________' AS 'Nytt antal'
FROM Artikel
WHERE Antal > 22 AND Plats = 'Förråd 10'

SELECT TOP 5 *
FROM Artikel
ORDER BY Pris*Antal DESC

-- Uppgift 7 SELECT 2

SELECT Namn, Ort, Telenr
FROM Kund LEFT JOIN Telefon
ON Kund.KundID = Telefon.KundID
ORDER BY Namn DESC

SELECT Datum, Betvilkor, Artnamn, Fakturarad.Antal, Fakturarad.Pris, FLOOR (Moms*100) AS 'Moms i Procent', FLOOR (Fakturarad.Rabatt*100) AS 'Rabatt i Procent', CONVERT ( DECIMAL(10,2), ROUND (((Fakturarad.Pris*Fakturarad.Antal)*(1-Fakturarad.Rabatt))*(1+Moms), 2)) AS Summa
FROM Faktura INNER JOIN Fakturarad
ON Faktura.FakturaID = Fakturarad.FakturaID
INNER JOIN Artikel
ON Fakturarad.ArtikelID = Artikel.ArtikelID
INNER JOIN Moms
ON Moms.MomsID = Fakturarad.MomsID

SELECT Datum, Betvilkor, Artnamn, Fakturarad.Antal, Fakturarad.Pris, FLOOR (Moms*100) AS 'Moms i Procent', FLOOR (Fakturarad.Rabatt*100) AS 'Rabatt i Procent', CONVERT ( DECIMAL(10,2), ROUND (((Fakturarad.Pris*Fakturarad.Antal)*(1-Fakturarad.Rabatt))*(1+Moms), 2)) AS Summa, DATEADD(DAY, Betvilkor, Datum) AS Förfallningsdatum
FROM Faktura INNER JOIN Fakturarad
ON Faktura.FakturaID = Fakturarad.FakturaID
INNER JOIN Artikel
ON Fakturarad.ArtikelID = Artikel.ArtikelID
INNER JOIN Moms
ON Moms.MomsID = Fakturarad.MomsID

SELECT Namn, Kategori, Datum, Betvilkor
FROM Kund LEFT JOIN Kategori
ON Kund.KategoriID = Kategori.KategoriID
LEFT JOIN Faktura
ON Kund.KundID = Faktura.KundID

SELECT Namn, Kategori, Datum, Betvilkor
FROM Kund LEFT JOIN Kategori
ON Kund.KategoriID = Kategori.KategoriID
LEFT JOIN Faktura
ON Kund.KundID = Faktura.KundID
WHERE Datum BETWEEN '2014-02-01' AND '2014-03-01'

SELECT Namn, Postnr+Adress AS Postadress
FROM Kund LEFT JOIN Faktura
ON Kund.KundID = Faktura.KundID
WHERE Datum IS NULL

SELECT art.ArtikelID, Artnamn, art.Antal, art.Pris
FROM Artikel AS art LEFT JOIN Fakturarad AS fak
ON art.ArtikelID = fak.ArtikelID
WHERE FakturaID IS NULL

-- Uppgift 8 SELECT 3
SELECT COUNT(*) AS 'Antal kunder'
FROM Kund

SELECT FLOOR (ROUND (SUM(Lagervärde),0)) AS 'Totalla värdet'
FROM Artikel

SELECT FLOOR (ROUND (SUM(Lagervärde),0)) AS 'Totalla värdet', SUM(Antal)AS 'Antal artiklar', FLOOR( ROUND (MAX(Lagervärde),0)) AS 'Högsta lagervärde',FLOOR (ROUND( MIN(Lagervärde), 0)) AS 'Minsta Lagervärde', FLOOR( ROUND( AVG(Lagervärde),0)) AS 'Medelvärdet'
FROM Artikel

SELECT FLOOR (ROUND (SUM(Lagervärde),0)) AS 'Totalla värdet', SUM(Antal)AS 'Antal artiklar', FLOOR( ROUND (MAX(Lagervärde),0)) AS 'Högsta lagervärde',FLOOR (ROUND( MIN(Lagervärde), 0)) AS 'Minsta Lagervärde', FLOOR( ROUND( AVG(Lagervärde),0)) AS 'Medelvärdet'
FROM Artikel
WHERE Lagervärde > (SELECT AVG(Lagervärde) From Artikel)

--36033

SELECT Faktura.FakturaID, Datum, SUM(CONVERT (DECIMAL(10,2), ROUND(((Pris*Antal)*(1-Rabatt))*(1+Moms),2))) AS Summa
FROM Faktura INNER JOIN Fakturarad
ON Faktura.FakturaID = Fakturarad.FakturaID
LEFT JOIN Moms
ON Fakturarad.MomsID = Moms.MomsID
GROUP BY Faktura.FakturaID, Datum

-- Uppgift 9 FUNCTIONS

SELECT CONVERT (VARCHAR(10), Datum, 20), Betvilkor, Artnamn, Fakturarad.Antal, Fakturarad.Pris, FLOOR (Moms*100) AS 'Moms i Procent', FLOOR (Fakturarad.Rabatt*100) AS 'Rabatt i Procent', CONVERT ( DECIMAL(10,2), ROUND (((Fakturarad.Pris*Fakturarad.Antal)*(1-Fakturarad.Rabatt))*(1+Moms), 2)) AS Summa, CONVERT (VARCHAR(10), DATEADD(DAY, Betvilkor, Datum), 20) AS Förfallningsdatum
FROM Faktura INNER JOIN Fakturarad
ON Faktura.FakturaID = Fakturarad.FakturaID
INNER JOIN Artikel
ON Fakturarad.ArtikelID = Artikel.ArtikelID
INNER JOIN Moms
ON Moms.MomsID = Fakturarad.MomsID

SELECT *, CONVERT(VARCHAR(3), Postnr) AS Postnr3
FROM Kund

SELECT Artnamn, '', '', Pris*Antal AS Summa 
FROM Artikel

SELECT DATEDIFF (DAY, GETDATE(), '2014-12-31') AS 'Till slutet av året', DATEDIFF (DAY, GETDATE(), '2014-04-06') AS 'Till Fördelsedag', DATEPART(WEEKDAY, '2014-04-06') AS 'Veckodagen jag fyller år'