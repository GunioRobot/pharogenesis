createMethod
	"Should only be called when this Debugger was created in response to a
	MessageNotUnderstood exception. Create a stub for the method that was
	missing and proceed into it."
	
	| msg chosenClass |
	msg _ contextStackTop tempAt: 1.
	chosenClass _ self
		askForSuperclassOf: contextStackTop receiver class
		toImplement: msg selector
		ifCancel: [^self].
	self implement: msg inClass: chosenClass.
