logFileStream

	LogFileStream ifNil:
		[LogFileStream := FileStream fileNamed: 'ConflictChecker.log'.
		LogFileStream setToEnd].
	^ LogFileStream