floatObjectOf: aFloat
	self var: #aFloat declareC: 'double aFloat'.
	aFloat class == Float ifFalse:[self error:'Not a float object'].
	^aFloat