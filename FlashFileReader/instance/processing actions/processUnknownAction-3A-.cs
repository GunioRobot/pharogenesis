processUnknownAction: data
	| code length |
	data skip: -1. "For determining the length of the action"
	code _ data nextByte.
	(code anyMask: 128) ifTrue:["Two byte length following"
		length _ data nextWord.
		data skip: length].
	log ifNotNil:[log nextPutAll:'*** skipped ***'].
	^nil