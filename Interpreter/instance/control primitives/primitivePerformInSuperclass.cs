primitivePerformInSuperclass
	| lookupClass rcvr currentClass |
	lookupClass _ self stackTop.
	rcvr _ self stackValue: argumentCount.
	currentClass _ self fetchClassOf: rcvr.
	[currentClass ~= lookupClass]
		whileTrue:
		[currentClass _ self superclassOf: currentClass.
		currentClass = nilObj ifTrue: [^ self primitiveFail]].

	self popStack.
	self primitivePerformAt: lookupClass.
	successFlag ifFalse:
		[self push: lookupClass]