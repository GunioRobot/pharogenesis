newFileNamed: fileName
 	"Create a new file with the given name, and answer a stream opened for writing on that file. If the file already exists, ask the user what to do."

	| dir localName choice newName fullName |
	fullName _ self fullName: fileName.
	(self isAFileNamed: fullName)
		ifFalse: [^ self new open: fullName forWrite: true].

	"file already exists:"
	dir _ FileDirectory forFileName: fullName.
	localName _ FileDirectory localNameFor: fullName.
	choice _ (PopUpMenu
		labels:
'overwrite that file
choose another name
cancel')
		startUpWithCaption: localName, '
already exists.'.

	choice = 1 ifTrue: [
		dir deleteFileNamed: localName
			ifAbsent: [self error: 'Could not delete the old version of that file'].
		^ self new open: fullName forWrite: true].

	choice = 2 ifTrue: [
		newName _ FillInTheBlank request: 'Enter a new file name' initialAnswer: 'fullName'.
		newName isEmpty ifFalse: [
			fullName _ self fullName: newName.
			^ self newFileNamed: fullName]].

	self error: 'Please close this to abort file opening'