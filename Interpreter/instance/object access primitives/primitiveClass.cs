primitiveClass
	| instance |
	instance _ self popStack.
	self push: (self fetchClassOf: instance)