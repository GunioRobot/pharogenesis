compileSelectionAsBlock
	"Treat the current selection as an expression; evaluate it and return the result"
	
	| stream result rcvr ctxt |
	self lineSelectAndEmptyCheck: [^ ''].

	stream := ReadWriteStream on: (String new: (startBlock stringIndex) - (stopBlock stringIndex) + 2).
	stream nextPutAll: '[[ '.
	stream next: ((startBlock stringIndex) - (stopBlock stringIndex))
		putAll: paragraph string
		startingAt: stopBlock stringIndex.
	stream nextPutAll: ' ] on: Error do: [ :ex | ex ]]'.
	stream reset.

	(model respondsTo: #doItReceiver) 
		ifTrue: [ FakeClassPool adopt: model selectedClass.  "Include model pool vars if any"
				rcvr := model doItReceiver.
				ctxt := model doItContext]
		ifFalse: [rcvr := ctxt := nil].
	result := [
		rcvr class evaluatorClass new 
			evaluate: stream
			in: ctxt
			to: rcvr
			notifying: self
			ifFail: [ FakeClassPool adopt: nil. 
					^ #failedDoit]
	] 
		on: OutOfScopeNotification 
		do: [ :ex | ex resume: true].
	FakeClassPool adopt: nil.
	^ result