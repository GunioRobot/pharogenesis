primitiveSetFullScreen
	"On platforms that support it, set full-screen mode to the value of the boolean argument."

	| argOop |
	argOop _ self stackTop.
	argOop = trueObj
		ifTrue: [self ioSetFullScreen: true]
		ifFalse: [
			argOop = falseObj
				ifTrue: [self ioSetFullScreen: false]
				ifFalse: [self primitiveFail]].
	successFlag ifTrue: [self pop: 1].
