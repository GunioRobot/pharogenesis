getFile

	| result |
	result _ self getFilePathName.
	^result ifNotNil: [FileStream oldFileNamed: result]