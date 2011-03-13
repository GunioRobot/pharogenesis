primitiveMIDIGetPortCount

	| n |
	n _ self sqMIDIGetPortCount.
	successFlag ifTrue: [
		self pop: 1.  "pop rcvr"
		self pushInteger: n].
