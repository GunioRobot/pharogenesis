valueOfProperty: propName ifAbsent: aBlock
	extension == nil ifTrue: [^ aBlock value].
	^ extension valueOfProperty: propName ifAbsent: aBlock