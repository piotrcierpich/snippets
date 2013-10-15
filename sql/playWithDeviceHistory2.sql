declare @temp_table table
(
	dateColumn datetime
)

declare @COUNTER int;

BEGIN TRAN
BEGIN TRY
	SET @COUNTER = 100;

	WHILE @COUNTER > 0
	BEGIN
		insert into @temp_table values (GETDATE());
		SET @COUNTER = @COUNTER - 1;
	END

	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH
SELECT * FROM @temp_table