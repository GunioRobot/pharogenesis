string: str hasEncoding: encoding

	str do: [:each | each leadingChar = encoding ifTrue: [^ true]].
	^ false.
