transcriptionOf: aString
	^ (aString findTokens: '/ ')
		collect: [ :each |
			each last isDigit
				ifTrue: [(self at: (each copyFrom: 1 to: each size - 1))
							stressed: each last asString asNumber]
				ifFalse: [self at: each]]