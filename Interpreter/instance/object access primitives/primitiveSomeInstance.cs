primitiveSomeInstance
	| class instance |
	class _ self stackTop.
	instance _ self initialInstanceOf: class.
	instance = nilObj
		ifTrue: [self primitiveFail]
		ifFalse: [self pop: argumentCount+1 thenPush: instance]