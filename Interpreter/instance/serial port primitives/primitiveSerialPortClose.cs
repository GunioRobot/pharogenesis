primitiveSerialPortClose

	| portNum |
	portNum _ self stackIntegerValue: 0.
	successFlag ifTrue: [self serialPortClose: portNum].
	successFlag ifTrue: [self pop: 1].  "pop portNum; leave rcvr on stack"
