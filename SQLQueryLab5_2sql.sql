ALTER PROCEDURE usp_skapafakturarad
@ArtikelID int,
@FakturaID int,
@Antal smallint,
@MomsID int
AS
BEGIN
	DECLARE @Pris int, @Rabatt decimal
	SELECT @Pris = Pris, @Rabatt = Rabatt
	FROM Artikel
	WHERE ArtikelID = @ArtikelID
	
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO Fakturarad (ArtikelID, FakturaID, Antal, Pris, Rabatt, MomsID)
			VALUES (@ArtikelID, @FakturaID, @Antal, @Pris, @Rabatt, @MomsID)
			
			UPDATE Artikel
			SET Antal = Antal - @Antal
			WHERE ArtikelID = @ArtikelID
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		RAISERROR('Det gick inte att utföra', 16, 1)
	END CATCH
END

EXEC usp_skapafakturarad 5, 2, 5, 4

ALTER PROCEDURE usp_add_kund
@Namn VARCHAR(40),
@Adress VARCHAR(30),
@Postnr VARCHAR(6),
@Ort VARCHAR(25),
@Rabatt DECIMAL (2,2),
@KategoriID INT,
@Telenr VARCHAR(15),
@TeletpyID INT
AS
BEGIN
	DECLARE @KundID INT
	BEGIN TRY
	BEGIN TRAN
	
		INSERT INTO Kund(Namn, Adress, Postnr, Ort, Rabbat, KategoriID)
		VALUES(@Namn, @Adress, @Postnr, @Ort, @Rabatt, @KategoriID)
		
		SELECT @KundID = KundID
		FROM Kund
		WHERE Namn = @Namn
		
		EXEC usp_add_telefon @KundID, @Telenr, @TeletpyID
	
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		RAISERROR('Det gick inte att utföra', 16, 1)
	END CATCH

END

ALTER PROCEDURE usp_add_telefon
@KundID INT,
@Telenr VARCHAR(15),
@TeletypID INT
AS
BEGIN
	
	BEGIN TRY
	BEGIN TRAN
	
		INSERT INTO Telefon(KundID, Telenr, TeltypID)
		VALUES(@KundID, @Telenr, @TeletypID)
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		RAISERROR('Det gick inte att utföra', 16, 1)
	END CATCH

END

-- @Namn VARCHAR(40),
-- @Adress VARCHAR(30),
-- @Postnr VARCHAR(6),
-- @Ort VARCHAR(25),
-- @Rabatt DECIMAL (2,2),
-- @KategoriID INT,
-- @Telenr VARCHAR(15),
-- @TeletpyID INT

EXEC usp_add_kund 'Karls Verkstad', 'Fiskgatan 2', 32431, 'KALMAR', 0, 1, '2435423', 1 

ALTER PROCEDURE usp_delete_fakturarad
@FakturaID INT
AS
BEGIN

	DECLARE @Antal SMALLINT, @ArtikelID INT

	BEGIN TRY
		BEGIN TRAN
			
			DECLARE myCursor SCROLL CURSOR
			FOR SELECT ArtikelID, Antal FROM Fakturarad
			WHERE FakturaID = @FakturaID
			FOR UPDATE
			
			OPEN myCursor
			FETCH myCursor INTO @ArtikelID, @Antal
			WHILE @@FETCH_STATUS = 0
				BEGIN
				
					UPDATE Artikel 
					SET Antal = Antal + @Antal
					WHERE ArtikelID = @ArtikelID
					
					FETCH myCursor INTO @ArtikelID, @Antal 
				END
			CLOSE myCursor
			DEALLOCATE myCursor 
			
			DELETE 	
			FROM Fakturarad
			WHERE FakturaID = @FakturaID
			
			DELETE
			FROM Faktura
			WHERE FakturaID = @FakturaID		
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		RAISERROR('Raderingen lyckades inte', 16, 1)
	END CATCH

END


EXEC usp_delete_fakturarad 11
SELECT ArtikelID, Antal FROM Fakturarad WHERE FakturaID =8