sideOf: aPoint 
	| result |
	result _ self destination - self origin crossProduct: aPoint - self origin.
	result > 0 ifTrue: [^ #left].
	result < 0 ifTrue: [^ #right].
	^ #center