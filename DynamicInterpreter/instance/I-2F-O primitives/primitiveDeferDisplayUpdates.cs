primitiveDeferDisplayUpdates
	"Set or clear the flag that controls whether modifications of the Display object are propagated to the underlying platform's screen."

	| flag |
	flag _ self stackTop.
	flag = trueObj
		ifTrue: [deferDisplayUpdates _ true]
		ifFalse: [
			flag = falseObj
				ifTrue: [deferDisplayUpdates _ false]
				ifFalse: [self primitiveFail]].
	successFlag ifTrue: [self pop: 1].  "pop flag; leave rcvr on stack"
