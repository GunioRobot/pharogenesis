saveChangesInFileNamed: aString
	
	self deprecated: 'Use SmalltalkImage current saveChangesInFileNamed: aString'.
	FileDirectory default 
		copyFileWithoutOverwriteConfirmationNamed: SmalltalkImage current changesName 
		toFileNamed: aString.
	self	setMacFileInfoOn: aString.