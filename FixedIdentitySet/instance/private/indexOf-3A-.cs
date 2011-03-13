indexOf: anObject
	anObject isNil ifTrue: [self error: 'This class collection cannot handle nil as an element'].
	^ (anObject identityHash bitAnd: self basicSize - 1) + 1