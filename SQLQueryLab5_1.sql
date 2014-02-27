ALTER PROCEDURE usp_add_artikel
@Artnamn VARCHAR(40),
@Antal SMALLINT,
@Pris DECIMAL,
@Rabatt DECIMAL,
@Plats CHAR(10)
AS
BEGIN 
	INSERT INTO Artikel(Artnamn, Antal, Pris, Rabatt, Plats)
	VALUES (@Artnamn, @Antal, @Pris, @Rabatt, @Plats)
END

EXEC usp_add_artikel 'HDMI kablar', 40, 50.50, 0, 'Hylla 25'

ALTER PROCEDURE usp_update_artikel
@ArtikelID int = 0,
@Artnamn VARCHAR(40) = null,
@Antal SMALLINT = null,
@Pris DECIMAL = null,
@Rabatt DECIMAL = null,
@Plats CHAR(10) = null
AS
BEGIN

	IF @Artnamn IS NOT null
	BEGIN
		UPDATE Artikel
		SET Artnamn = @Artnamn
		WHERE ArtikelID = @ArtikelID
	END
	IF @Antal IS NOT null
	BEGIN
		UPDATE Artikel
		SET Antal = @Antal
		WHERE ArtikelID = @ArtikelID
	END
	IF @Pris IS NOT null
	BEGIN
		UPDATE Artikel
		SET Pris = @Pris
		WHERE ArtikelID = @ArtikelID
	END
	IF @Rabatt IS NOT null
	BEGIN
		UPDATE Artikel
		SET Pris = @Pris
		WHERE ArtikelID = @ArtikelID
	END
	IF @Plats IS NOT null
	BEGIN
		UPDATE Artikel
		SET Plats = @Plats
		WHERE ArtikelID = @ArtikelID
	END

END

EXEC usp_update_artikel 13, 'HDMI kablar SHDIT', 15, 60, 0, 'Hylla 24'

ALTER PROCEDURE usp_delete_artikel
@ArtikelID int
AS
BEGIN
	IF EXISTS (SELECT ArtikelID FROM Artikel WHERE ArtikelID = @ArtikelID)
	BEGIN
		DELETE
		FROM Artikel
		WHERE ArtikelID = @ArtikelID
	END
	ELSE
	RAISERROR('Artikeln finns inte', 16, 1)

END

EXEC usp_delete_artikel 20

ALTER PROCEDURE usp_select_artikel

@ArtikelID INT = 0
AS
BEGIN
	
	IF EXISTS (SELECT ArtikelID FROM Artikel WHERE ArtikelID = @ArtikelID)
	BEGIN

		SELECT * 
		FROM Artikel
		WHERE ArtikelID = @ArtikelID
	
	END
	ELSE
	BEGIN
		
		IF @ArtikelID = 0
		BEGIN
			SELECT *
			FROM Artikel
		END
		ELSE
			RAISERROR ('Artikeln saknas', 16, 11)
		
	END
END

EXEC usp_select_artikel 3

ALTER PROCEDURE usp_telefonlista
@KundID INT = 0
AS	
BEGIN
	CREATE Table #temp
	(
		Namn varchar(50),
		Ort varchar(50),
		Telefon varchar(50),
		Telefontyp varchar(50)
	)
	
	IF EXISTS (SELECT KundID FROM Kund WHERE KundID = @KundID)
	BEGIN

		INSERT INTO #Temp (Namn, Ort, Telefon, Telefontyp)
		SELECT Namn, Ort, Telenr, Teltyp
		FROM Kund LEFT JOIN Telefon
		ON Kund.KundID = Telefon.KundID
		LEFT JOIN Teltyp ON Telefon.TeltypID = Teltyp.TeltypID
		WHERE Kund.KundID = @KundID
	
	END
	ELSE
	BEGIN
		
		IF @KundID = 0
		BEGIN
			INSERT INTO #Temp (Namn, Ort, Telefon, Telefontyp)
			SELECT Namn, Ort, Telenr, Teltyp
			FROM Kund LEFT JOIN Telefon
			ON Kund.KundID = Telefon.KundID
			LEFT JOIN Teltyp ON Telefon.TeltypID = Teltyp.TeltypID
		END
		ELSE
			RAISERROR ('Kund saknas', 16, 11)
		
	END
	
	SELECT * FROM #temp
	ORDER BY Namn ASC, Telefontyp ASC
	DROP table #temp
	
END
 
EXEC usp_telefonlista

ALTER PROCEDURE usp_försäljnigstatistisk
@startdatum date = '01-01-01',
@slutdatum date = '01-01-01'
AS
BEGIN

	CREATE Table #tempo
	(
		ArtikelID int,
		Namn varchar(50),
		Datum Date,
		Antal int,
		Pris Decimal,
		Lagervärde Decimal
	)
	IF @startdatum = '01-01-01'
	BEGIN
		INSERT INTO #tempo(ArtikelID, Namn, Datum, Antal, Pris, Lagervärde)
		SELECT Artikel.ArtikelID, Artnamn, Faktura.Datum, Fakturarad.Antal, Fakturarad.Pris, Lagervärde
		FROM Artikel INNER JOIN Fakturarad
		ON Artikel.ArtikelID = Fakturarad.ArtikelID
		LEFT JOIN Faktura ON Faktura.FakturaID = Fakturarad.FakturaID
		
	
	END
	
	ELSE
	BEGIN 
		INSERT INTO #tempo(ArtikelID, Namn, Datum, Antal, Pris, Lagervärde)
		SELECT Artikel.ArtikelID, Artnamn, Faktura.Datum, Fakturarad.Antal, Fakturarad.Pris, Lagervärde
		FROM Artikel INNER JOIN Fakturarad
		ON Artikel.ArtikelID = Fakturarad.ArtikelID
		LEFT JOIN Faktura ON Faktura.FakturaID = Fakturarad.FakturaID
		WHERE Datum > @startdatum AND Datum < @slutdatum
	END
	
	
	SELECT ArtikelID, Namn, Datum, SUM(Antal) AS Antal, SUM(Pris) AS Pris, MAX(Lagervärde) AS Lagervärde
	FROM #tempo
	GROUP BY ArtikelID, Namn, Datum
	
	DROP table #tempo
	
END

EXEC usp_försäljnigstatistisk '00-01-01', '12-12-30'

