primitiveNextInstance
	| object instance |
	object _ self popStack.
	instance _ self instanceAfter: object.
	instance = nilObj
		ifTrue: [self unPop: 1. self primitiveFail]
		ifFalse: [self push: instance]