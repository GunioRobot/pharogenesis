normalSend
	"Send a message, starting lookup with the receiver's class."
	"Assume: messageSelector and argumentCount have been set, and that 
	the receiver and arguments have been pushed onto the stack,"
	"Note: This method is inlined into the interpreter dispatch loop."
	| rcvr |
	self inline: true.
	self sharedCodeNamed: 'normalSend' inCase: 131.
	rcvr _ self internalStackValue: argumentCount.
	lkupClass _ self fetchClassOf: rcvr.
	receiverClass _ lkupClass.
	self commonSend.