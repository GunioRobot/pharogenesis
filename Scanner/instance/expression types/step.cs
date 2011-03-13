step

	| c |
	c _ hereChar.
	hereChar _ aheadChar.
	source atEnd
		ifTrue: [aheadChar _ 30 asCharacter "doit"]
		ifFalse: [aheadChar _ source next].
	^c