writeEncoded: bytes
	| file |
	fileName ifNil:[^self].
	false ifTrue:[^self].
	file := FileStream forceNewFileNamed: fileName.
	[file nextPutAll: bytes] ensure:[file close].