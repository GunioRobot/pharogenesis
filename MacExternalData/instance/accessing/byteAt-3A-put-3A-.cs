byteAt: index put: datum

	| loc offset val |
	(datum > 255 or: [datum<0]) ifTrue: [^self error: 'not a byte quantity'].
	loc _ ((index-1) // 4) + 1.
	offset _ 24 - (8*((index-1) \\ 4)).
	val _ ((16rFF << offset) bitInvert32) bitAnd: (self at: loc).
	val _ val bitOr: (datum<<offset).
	^super at: loc put: val