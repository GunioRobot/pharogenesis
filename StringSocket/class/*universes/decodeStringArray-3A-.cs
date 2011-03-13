decodeStringArray: aString
	| idx numStrings |
	idx _ 1.
	numStrings _ aString getInteger32: idx.
	idx _ idx + 4.
	numStrings < 0 ifTrue: [ ^self error: 'invalid string socket encoding' ].
	numStrings > 10000000 ifTrue: [ self error: 'refusing to decode humongous string socket' ].
	
	^(1 to: numStrings) collect: [ :ignored |
		| size str |
		size _ aString getInteger32: idx.
		idx _ idx + 4.
		str _ aString copyFrom: idx to: idx+size-1.
		idx _ idx + size.
		str ]
	