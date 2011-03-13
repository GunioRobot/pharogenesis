normalSend
	"Send a message, starting lookup with the receiver's class."
	"Assume: messageSelector and argumentCount have been set, and that the receiver and arguments have been pushed onto the stack,"
	"Note: This method is inlined into the interpreter dispatch loop."

	| rcvr |
	self inline: true.
	self sharedCodeNamed: 'commonSend' inCase: 131.

	rcvr _ self internalStackValue: argumentCount.
	receiverClass _ lkupClass _ self fetchClassOf: rcvr.
	self internalFindNewMethod.
	self internalExecuteNewMethod.
	self fetchNextBytecode.
