floatValueOf: oop
	"Fetch the instance variable at the given index of the given object. Return the C double precision floating point value of that instance variable, or fail if it is not a Float."
	"Note: May be called by translated primitive code."

	| result |
	self returnTypeC: 'double'.
	self var: #result declareC: 'double result'.
	self assertClassOf: oop is: (self splObj: ClassFloat).
	successFlag
		ifTrue: [self fetchFloatAt: oop + BaseHeaderSize into: result]
		ifFalse: [result _ 0.0].
	^ result