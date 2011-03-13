saveChangesInFileNamed: aString
	FileDirectory default 
		copyFileWithoutOverwriteConfirmationNamed: self changesName 
		toFileNamed: aString.
	self	setMacFileInfoOn: aString.