valueOfProperty: propName ifAbsent: aBlock
	otherProperties == nil ifTrue: [^ aBlock value].
	^ otherProperties at: propName ifAbsent: [^ aBlock value]