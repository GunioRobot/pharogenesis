forceNewFileNamed: fileName 
	"Create a new file with the given name, and answer a stream opened 
	for writing on that file. If the file already exists, delete it without 
	asking before creating the new file."
	| dir localName fullName f |
	fullName _ self fullName: fileName.
	(self isAFileNamed: fullName)
		ifFalse: [f _ self new open: fullName forWrite: true.
			^ f isNil
				ifTrue: ["Failed to open the file"
					(FileDoesNotExistException fileName: fullName) signal]
				ifFalse: [f]].
	dir _ FileDirectory forFileName: fullName.
	localName _ FileDirectory localNameFor: fullName.
	dir
		deleteFileNamed: localName
		ifAbsent: [(CannotDeleteFileException new
			messageText: 'Could not delete the old version of file ' , fullName) signal].
	f _ self new open: fullName forWrite: true.
	^ f isNil
		ifTrue: ["Failed to open the file"
			(FileDoesNotExistException fileName: fullName) signal]
		ifFalse: [f]