primitiveClass
	| instance |
	instance _ self stackTop.
	self pop: argumentCount+1 thenPush: (self fetchClassOf: instance)