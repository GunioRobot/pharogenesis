superclassSend
	"Send a message to self, starting lookup with the superclass of the class containing the currently executing method."
	"Assume: messageSelector and argumentCount have been set, and that the receiver and arguments have been pushed onto the stack,"
	"Note: This method is inlined into the interpreter dispatch loop."

	| superClass |
	self inline: true.
	self sharedCodeNamed: 'commonSuperSend' inCase: CommonSuperCase.
	newReceiver _ 0.
	superClass _ self superclassOf: (self methodClassOf: self internalMethod).

	self externalizeIPandSP.
	self sendSelectorToClass: superClass.
	self internalizeIPandSP.
