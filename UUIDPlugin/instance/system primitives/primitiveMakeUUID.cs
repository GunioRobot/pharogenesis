primitiveMakeUUID
	| oop location |
	self export: true.
	self var: #location type: 'char*'.
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	oop _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isBytes: oop) 
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy byteSizeOf: oop) = 16
		ifFalse:[^interpreterProxy primitiveFail].
	location _ interpreterProxy firstIndexableField: oop.

	self cCode: 'MakeUUID(location)' 
		inSmalltalk: [location. interpreterProxy primitiveFail].
