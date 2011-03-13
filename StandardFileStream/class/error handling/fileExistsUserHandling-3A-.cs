fileExistsUserHandling: fullFileName
	| dir localName choice newName newFullFileName |
	dir := FileDirectory forFileName: fullFileName.
	localName := FileDirectory localNameFor: fullFileName.
	choice := UIManager default 
		chooseFrom: {'Overwrite that file' translated. 'Choose another name' translated} 
		message: localName , ('\', ('already exists.' translated)) withCRs.

	choice = 1 ifTrue: [
		dir deleteFileNamed: localName
			ifAbsent: [self error: 'Could not delete the old version of that file'].
		^ self new open: fullFileName forWrite: true].

	choice = 2 ifTrue: [
		newName := UIManager default request: 'Enter a new file name' translated initialAnswer: fullFileName.
		newFullFileName := self fullName: newName.
		^ self newFileNamed: newFullFileName].

	self error: 'Please close this to abort file opening'