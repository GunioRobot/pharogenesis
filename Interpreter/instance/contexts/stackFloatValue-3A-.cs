stackFloatValue: offset
	"Note: May be called by translated primitive code."
	| result floatPointer |
	self returnTypeC: 'double'.
	self var: #result declareC: 'double result'.
	floatPointer _ self longAt: stackPointer - (offset*4).
	(self fetchClassOf: floatPointer) = (self splObj: ClassFloat) 
		ifFalse:[self primitiveFail. ^0.0].
	self cCode: '' inSmalltalk: [result _ Float new: 2].
	self fetchFloatAt: floatPointer + BaseHeaderSize into: result.
	^ result