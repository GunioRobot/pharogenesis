oldFileNamed: fileName
	"Open an existing file with the given name for reading and writing. If the name has no directory part, then the file will be created in the default directory. If the file already exists, its prior contents may be modified or replaced, but the file will not be truncated on close."

	| selection fullName newName |
	fullName _ self fullName: fileName.
	(self isAFileNamed: fullName) ifTrue:
		[^ self new open: fullName forWrite: true].

	"File does not exist..."
	selection _ (PopUpMenu labels:
'create a new file
choose another name
cancel')
			startUpWithCaption: (FileDirectory localNameFor: fullName) , '
does not exist.'.
	selection = 1 ifTrue:
		[^ self new open: fullName forWrite: true].
	selection = 2 ifTrue:
		[ newName _ FillInTheBlank request: 'Enter a new file name'
						initialAnswer:  fullName.
		^ self oldFileNamed:
			(self fullName: newName)].
	self halt