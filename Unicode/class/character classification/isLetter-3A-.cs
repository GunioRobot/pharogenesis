isLetter: char

	| value result |
	value _ char charCode.

	value > (GeneralCategory size - 1) ifTrue: [^ false].
	result _ GeneralCategory at: value+1.
	^ result first = $L.
