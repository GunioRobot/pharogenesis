debugIt

	| method receiver context |
	(model respondsTo: #doItReceiver) 
		ifTrue: 
			[FakeClassPool adopt: model selectedClass.
			receiver _ model doItReceiver.
			context _ model doItContext]
		ifFalse:
			[receiver _ context _ nil].
	self lineSelectAndEmptyCheck: [^self].
	method _ self compileSelectionFor: receiver in: context.
	method notNil ifTrue:
		[self debug: method receiver: receiver in: context].
	FakeClassPool adopt: nil