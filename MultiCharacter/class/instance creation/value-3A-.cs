value: anInteger

	anInteger < 256
		ifTrue: [^ Character value: anInteger].
	^ self basicNew value: anInteger.
