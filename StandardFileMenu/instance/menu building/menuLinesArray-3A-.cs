menuLinesArray: aDirectory
"Answer a menu lines object corresponding to aDirectory"

	| typeCount nameCnt |
	typeCount _ canTypeFileName 
		ifTrue: [1] 
		ifFalse: [0].
	nameCnt _ aDirectory directoryNames size.
	^Array streamContents: [:s |
		canTypeFileName ifTrue: [s nextPut: 1].
		s nextPut: aDirectory pathParts size + typeCount + 1.
		s nextPut: aDirectory pathParts size + 
					nameCnt + typeCount + 1]