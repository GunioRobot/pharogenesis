allYoung: array1 and: array2 
	"Return true if all the oops in both arrays, and the arrays 
	themselves, are in the young object space."
	| fieldOffset |
	array1 < youngStart ifTrue: [^ false].
	array2 < youngStart ifTrue: [^ false].
	fieldOffset _ self lastPointerOf: array1.
	"same size as array2"
	[fieldOffset >= BaseHeaderSize]
		whileTrue: [(self longAt: array1 + fieldOffset) < youngStart ifTrue: [^ false].
			(self longAt: array2 + fieldOffset) < youngStart ifTrue: [^ false].
			fieldOffset _ fieldOffset - 4].
	^ true