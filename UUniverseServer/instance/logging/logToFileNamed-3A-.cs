logToFileNamed: filename
	logfile := FileStream fileNamed: filename.
	logfile setToEnd.
	