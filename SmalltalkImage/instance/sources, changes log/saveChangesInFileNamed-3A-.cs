saveChangesInFileNamed: aString
	| fullChangesName |
	fullChangesName := (FileDirectory default fullNameFor: aString).
	(FileDirectory default directoryNamed:(FileDirectory dirPathFor: fullChangesName )) assureExistence.
	FileDirectory default 
		copyFileWithoutOverwriteConfirmationNamed: SmalltalkImage current changesName 
		toFileNamed: fullChangesName.
	Smalltalk setMacFileInfoOn: fullChangesName.