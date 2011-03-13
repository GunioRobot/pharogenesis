fileDoesNotExistUserHandling: fullFileName

	| selection newName |
	selection := UIManager default 
		chooseFrom: {'Create a new file' translated. 'Choose another name' translated} 
		message: (FileDirectory localNameFor: fullFileName) , ('\', ('does not exist.' translated)) withCRs.
	selection = 1 ifTrue:
		[^ self new open: fullFileName forWrite: true].
	selection = 2 ifTrue:
		[ newName := UIManager default request: 'Enter a new file name' translated	initialAnswer:  fullFileName.
		^ self oldFileNamed: (self fullName: newName)].
	self halt