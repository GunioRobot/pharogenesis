startingIndex
	predecessor == nil ifTrue: [^ 1].
	^ predecessor lastCharacterIndex + 1