popFloat
	"Note: May be called by translated primitive code."

	| top result |
	self returnTypeC: 'double'.
	self var: #result declareC: 'double result'.
	top _ self popStack.
	self successIfClassOf: top is: (self splObj: ClassFloat).
	successFlag
		ifTrue: [self fetchFloatAt: top + BaseHeaderSize into: result].
	^ result