fromISO2022JPString: string 

	| tempFileName stream contents |
	tempFileName _ Time millisecondClockValue printString , '.txt'.
	FileDirectory default deleteFileNamed: tempFileName ifAbsent: [].
	stream _ StandardFileStream fileNamed: tempFileName.
	[stream nextPutAll: string]
		ensure: [stream close].
	stream _ FileStream fileNamed: tempFileName.
	contents _ stream contentsOfEntireFile.
	FileDirectory default deleteFileNamed: tempFileName ifAbsent: [].
	^ contents
