stringToLed
	| i k actualString |
	i _ scroller ifNil: [1].
	k _ 1.
	actualString _ String new: chars.
	actualString do: 
		[:m | 
		i > string size ifFalse: [actualString at: k put: (string at: i) asUppercase asCharacter].
		i _ i + 1.
		k _ k + 1].
	i _ 1.
	submorphs do: 
		[:m | 
		m char: (actualString at: i).
		i _ i + 1].
	self changed