fileExistsUserHandling: fullFileName
	| dir localName choice newName newFullFileName |
	dir := FileDirectory forFileName: fullFileName.
	localName := FileDirectory localNameFor: fullFileName.
	choice := (PopUpMenu
		labels:
'overwrite that file\choose another name\cancel' withCRs)
		startUpWithCaption: localName, '
already exists.'.

	choice = 1 ifTrue: [
		dir deleteFileNamed: localName
			ifAbsent: [self error: 'Could not delete the old version of that file'].
		^ self new open: fullFileName forWrite: true].

	choice = 2 ifTrue: [
		newName := FillInTheBlank request: 'Enter a new file name' initialAnswer: fullFileName.
		newFullFileName := self fullName: newName.
		^ self newFileNamed: newFullFileName].

	self error: 'Please close this to abort file opening'