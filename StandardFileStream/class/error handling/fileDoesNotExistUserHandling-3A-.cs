fileDoesNotExistUserHandling: fullFileName

	| selection newName |
	selection := (PopUpMenu labels:
'create a new file
choose another name
cancel')
			startUpWithCaption: (FileDirectory localNameFor: fullFileName) , '
does not exist.'.
	selection = 1 ifTrue:
		[^ self new open: fullFileName forWrite: true].
	selection = 2 ifTrue:
		[ newName := FillInTheBlank request: 'Enter a new file name'
						initialAnswer:  fullFileName.
		^ self oldFileNamed:
			(self fullName: newName)].
	self halt