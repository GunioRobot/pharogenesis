readFileNamed: fileName
	| snd |
	snd _ Compiler evaluate:
		(FileStream readOnlyFileNamed: fileName) contentsOfEntireFile.
	soundName _ fileName copyFrom: 1 to: fileName size-4. "---.fmp"
	self editSound: snd