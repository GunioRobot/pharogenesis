forceNewFileNamed: fileName
 	"Create a new file with the given name, and answer a stream opened for writing on that file. If the file already exists, delete it without asking before creating the new file."

	| dir localName fullName |
	fullName _ self fullName: fileName.
	(self isAFileNamed: fullName)
		ifFalse: [^ self new open: fullName forWrite: true].

	dir _ FileDirectory forFileName: fullName.
	localName _ FileDirectory localNameFor: fullName.
	dir deleteFileNamed: localName
		ifAbsent: [self error: 'Could not delete the old version of that file'].
	^ self new open: fullName forWrite: true.
