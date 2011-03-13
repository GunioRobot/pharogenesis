step

	| c |
	c := hereChar.
	hereChar := aheadChar.
	source atEnd
		ifTrue: [aheadChar := 30 asCharacter "doit"]
		ifFalse: [aheadChar := source next].
	^c