primitiveSomeInstance
	| class instance |
	class _ self popStack.
	instance _ self initialInstanceOf: class.
	instance = nilObj
		ifTrue: [self unPop: 1. self primitiveFail]
		ifFalse: [self push: instance]