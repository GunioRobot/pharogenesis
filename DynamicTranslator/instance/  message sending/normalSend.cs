normalSend
	"Send a message, starting lookup with the receiver's class."
	"Assume: messageSelector and argumentCount have been set, and that the receiver and arguments have been pushed onto the stack,"
	"Note: This method is inlined into the interpreter dispatch loop."

	| rcvrClass rcvr |
	self inline: true.
	self sharedCodeNamed: 'commonSend' inCase: CommonNormalSendCase.
	newReceiver _ (rcvr _ self internalStackValue: argumentCount).
	rcvrClass _ self fetchClassOf: rcvr.

	self externalizeIPandSP.
	self sendSelectorToClass: rcvrClass.
	self internalizeIPandSP.
