ALTER TRIGGER ut_logging ON Telefon
AFTER UPDATE
AS
BEGIN
	DECLARE @tblID int, @Old VARCHAR(100), @New VARCHAR(100), @Usr VARCHAR(10)
	IF UPDATE(KundID)
	BEGIN
		Select @tblID = i.TelID, @New = i.KundID
		FROM inserted AS i
		SELECT @Old = d.KundID
		FROM deleted AS d
	
		INSERT Logging(tbl, tblID, kol, Old, New, Usr)
		VALUES('Telefon', @tblID , 'KundID', @Old, @New, SYSTEM_USER)
	
	END
	
	IF UPDATE(Telenr)
	BEGIN
		Select @tblID = i.TelID, @New = i.Telenr
		FROM inserted AS i
		SELECT @Old = d.Telenr
		FROM deleted AS d
	
		INSERT Logging(tbl, tblID, kol, Old, New, Usr)
		VALUES('Telefon', @tblID , 'Telenr', @Old, @New, SYSTEM_USER)
	
	END
	
		IF UPDATE(TeltypID)
	BEGIN
		Select @tblID = i.TelID, @New = i.TeltypID
		FROM inserted AS i
		SELECT @Old = d.TeltypID
		FROM deleted AS d
	
		INSERT Logging(tbl, tblID, kol, Old, New, Usr)
		VALUES('Telefon', @tblID , 'TeltypID', @Old, @New, SYSTEM_USER)
	
	END

END