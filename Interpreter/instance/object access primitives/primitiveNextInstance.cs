primitiveNextInstance
	| object instance |
	object _ self stackTop.
	instance _ self instanceAfter: object.
	instance = nilObj
		ifTrue: [self primitiveFail]
		ifFalse: [self pop: argumentCount+1 thenPush: instance]