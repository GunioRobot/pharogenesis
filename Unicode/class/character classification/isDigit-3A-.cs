isDigit: char

	| value |
	value _ char charCode.

	value > (GeneralCategory size - 1) ifTrue: [^ false].
	^ (GeneralCategory at: value+1) = 'Nd'.
