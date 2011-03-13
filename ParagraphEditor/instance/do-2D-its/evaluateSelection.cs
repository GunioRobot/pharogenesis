evaluateSelection
	"Treat the current selection as an expression; evaluate it and return the result"
	| result rcvr ctxt |
	self lineSelectAndEmptyCheck: [^ ''].
	(model isKindOf: Model)
		ifTrue: [FakeClassPool adopt: model selectedClass.  "Include model pool vars if any"
				rcvr _ model doItReceiver.
				ctxt _ model doItContext]
		ifFalse: [rcvr _ ctxt _ nil].
	result _ rcvr class evaluatorClass new evaluate: self selectionAsStream
				in: ctxt to: rcvr notifying: self
				ifFail: [FakeClassPool adopt: nil.
						^ #failedDoit].
	FakeClassPool adopt: nil.
	Smalltalk logChange: self selection string.
	^ result