fileExistsUserHandling: fullFileName
	| dir localName choice newName newFullFileName |
	dir _ FileDirectory forFileName: fullFileName.
	localName _ FileDirectory localNameFor: fullFileName.
	choice _ (PopUpMenu
		labels:
'overwrite that file\choose another name\cancel' withCRs)
		startUpWithCaption: localName, '
already exists.'.

	choice = 1 ifTrue: [
		dir deleteFileNamed: localName
			ifAbsent: [self error: 'Could not delete the old version of that file'].
		^ self new open: fullFileName forWrite: true].

	choice = 2 ifTrue: [
		newName _ FillInTheBlank request: 'Enter a new file name' initialAnswer: fullFileName.
		newFullFileName _ self fullName: newName.
		^ self newFileNamed: newFullFileName].

	self error: 'Please close this to abort file opening'