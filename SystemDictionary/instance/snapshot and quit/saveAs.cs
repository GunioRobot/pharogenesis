saveAs

	| newName |
	newName _ self getFileNameFromUser.
	newName isNil ifTrue:[^self].
	self
		saveChangesInFileNamed: (self fullNameForChangesNamed: newName);
		saveImageInFileNamed: (self fullNameForImageNamed: newName);
		logChange: '----SAVEAS ', newName, '----', Date dateAndTimeNow printString.


