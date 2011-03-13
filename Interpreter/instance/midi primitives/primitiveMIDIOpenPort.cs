primitiveMIDIOpenPort

	| clockRate semaIndex portNum |
	clockRate	_ self stackIntegerValue: 0.
	semaIndex	_ self stackIntegerValue: 1.
	portNum	_ self stackIntegerValue: 2.
	successFlag ifTrue: [
		self cCode: 'sqMIDIOpenPort(portNum, semaIndex, clockRate)'].
	successFlag ifTrue: [self pop: 3].  "pop portNum, semaIndex, clockRate; leave rcvr on stack"
