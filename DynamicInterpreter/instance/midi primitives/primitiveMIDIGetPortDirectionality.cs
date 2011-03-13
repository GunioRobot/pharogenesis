primitiveMIDIGetPortDirectionality

	| portNum dir |
	portNum _ self stackIntegerValue: 0.
	successFlag ifTrue: [dir _ self sqMIDIGetPortDirectionality: portNum].
	successFlag ifTrue: [
		self pop: 2.  "pop rcvr, portNum"
		self pushInteger: dir].
