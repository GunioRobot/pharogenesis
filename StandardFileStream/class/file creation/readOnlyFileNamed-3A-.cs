readOnlyFileNamed: fileName 
	"Open an existing file with the given name for reading."
	"Changed to open a more usefull popup menu.  It now also includes the most likely choices.  jaf"
	| selection dir files choices newName fullName |
	fullName _ self fullName: fileName.
	(self isAFileNamed: fullName)
		ifTrue: [^ self new open: fullName forWrite: false].
	"File does not exist..."
	dir _ FileDirectory forFileName: fullName.
	files _ dir fileNames.
	choices _ (FileDirectory localNameFor: fullName) correctAgainst: files.
	choices add: 'Choose another name'.
	choices add: 'Cancel'.
	selection _ (PopUpMenu labelArray: choices lines: (Array with: 5) )
		startUpWithCaption: (FileDirectory localNameFor: fullName), '
does not exist.'.
	selection < (choices size - 1) ifTrue: [
		newName _ (dir pathName , FileDirectory slash , (choices at: selection))].
	selection = (choices size - 1) ifTrue: [
		newName _ FillInTheBlank 
							request: 'Enter a new file name' 
							initialAnswer: fileName].
	newName = '' ifFalse: [^ self readOnlyFileNamed: (self fullName: newName)].
	^ self error: 'Could not open a file'