primitiveMIDIGetPortName

	| portName portNum sz nameObj namePtr |
	self var: #portName declareC: 'char portName[256]'.
	portNum _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		sz _ self cCode: 'sqMIDIGetPortName(portNum, (int) &portName, 255)'].
	successFlag ifTrue: [
		nameObj _ self instantiateClass: (self splObj: ClassString) indexableSize: sz.
		namePtr _ nameObj + BaseHeaderSize.
		self cCode: 'memcpy((char *) namePtr, portName, sz)'].
	successFlag ifTrue: [
		self pop: 2.  "pop rcvr, portNum"
		self push: nameObj].
