tallySelection
	"Treat the current selection as an expression; evaluate it and return the time took for this evaluation"
	| result rcvr ctxt cm v valueAsString |
	self lineSelectAndEmptyCheck: [^ -1].

	(model respondsTo: #doItReceiver) 
		ifTrue: [FakeClassPool adopt: model selectedClass.  "Include model pool vars if any"
				rcvr _ model doItReceiver.
				ctxt _ model doItContext]
		ifFalse: [rcvr _ ctxt _ nil].
	result _ [
		cm := rcvr class evaluatorClass new 
			compiledMethodFor: self selectionAsStream
			in: ctxt
			to: rcvr
			notifying: self
			ifFail: [FakeClassPool adopt: nil. ^ #failedDoit]
			logged: false.
		Time millisecondsToRun: 
			[v := cm valueWithReceiver: rcvr arguments: (Array with: ctxt)].
	] 
		on: OutOfScopeNotification 
		do: [ :ex | ex resume: true].
	FakeClassPool adopt: nil.

	"We do not want to have large result displayed"
	valueAsString := v printString.
	(valueAsString size > 30) ifTrue: [valueAsString := (valueAsString copyFrom: 1 to: 30), '...'].
	PopUpMenu 
		inform: 'Time to compile and execute: ', result printString, 'ms res: ', valueAsString.
