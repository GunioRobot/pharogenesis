removeProperty: propName
	otherProperties == nil ifTrue: [^ self].
	otherProperties removeKey: propName ifAbsent: [].
	otherProperties size == 0 ifTrue: [otherProperties _ nil]