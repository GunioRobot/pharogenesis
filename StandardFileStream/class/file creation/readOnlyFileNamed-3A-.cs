readOnlyFileNamed: fileName 
	"Open an existing file with the given name for reading."

	| fullName f |
	fullName _ self fullName: fileName.
	f _ self new open: fullName forWrite: false.
	^ f isNil
		ifFalse: [f]
		ifTrue: ["File does not exist..."
			((FileDoesNotExistException fileName: fullName) readOnly: true) signal].

	"StandardFileStream readOnlyFileNamed: 'kjsd.txt' "