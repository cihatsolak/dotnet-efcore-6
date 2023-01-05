-- read uncommitted
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION CourseReadTransaction
BEGIN TRY
SELECT * FROM Course
COMMIT TRANSACTION CourseReadTransaction
print 'transaction successfull'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION CourseReadTransaction
print 'transaction error'
END CATCH

-- read committed
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION CourseReadTransaction
BEGIN TRY
SELECT * FROM Course
COMMIT TRANSACTION CourseReadTransaction
print 'transaction successfull'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION CourseReadTransaction
print 'transaction error'
END CATCH

