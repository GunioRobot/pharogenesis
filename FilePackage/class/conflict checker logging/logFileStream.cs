logFileStream

	LogFileStream ifNil:
		[LogFileStream _ FileStream fileNamed: 'ConflictChecker.log'.
		LogFileStream setToEnd].
	^ LogFileStream