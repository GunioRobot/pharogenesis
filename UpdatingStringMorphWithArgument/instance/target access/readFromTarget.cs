readFromTarget
	| v |
	argumentTarget ifNil: [^ super readFromTarget].
	v _ target perform: getSelector with: (argumentTarget perform: argumentGetSelector).
	^ self acceptValueFromTarget: v