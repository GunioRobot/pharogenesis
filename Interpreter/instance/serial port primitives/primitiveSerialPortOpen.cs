primitiveSerialPortOpen

	| xOffChar xOnChar inFlowControl outFlowControl dataBits
	  parityType stopBitsType baudRate portNum |
	xOffChar		_ self stackIntegerValue: 0.
	xOnChar		_ self stackIntegerValue: 1.
	outFlowControl	_ self stackIntegerValue: 2.
	inFlowControl	_ self stackIntegerValue: 3.
	dataBits			_ self stackIntegerValue: 4.
	parityType		_ self stackIntegerValue: 5.
	stopBitsType		_ self stackIntegerValue: 6.
	baudRate		_ self stackIntegerValue: 7.
	portNum		_ self stackIntegerValue: 8.
	successFlag ifTrue: [
		self cCode: 'serialPortOpen(
			portNum, baudRate, stopBitsType, parityType, dataBits,
			inFlowControl, outFlowControl, xOnChar, xOffChar)'].
	successFlag ifTrue: [self pop: 9].  "pop 9 args; leave rcvr on stack"
