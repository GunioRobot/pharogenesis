menuLinesArray: aDirectory
"Answer a menu lines object corresponding to aDirectory"

	| typeCount nameCnt dirDepth|
	typeCount _ canTypeFileName 
		ifTrue: [1] 
		ifFalse: [0].
	nameCnt _ aDirectory directoryNames size.
	dirDepth _ aDirectory pathParts size.
	^Array streamContents: [:s |
		canTypeFileName ifTrue: [s nextPut: 1].
		s nextPut: dirDepth + typeCount + 1.
		s nextPut: dirDepth + nameCnt + typeCount + 1]