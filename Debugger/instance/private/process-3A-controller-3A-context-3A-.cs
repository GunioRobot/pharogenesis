process: aProcess controller: aController context: aContext

	super initialize.
	contents _ nil. 
	interruptedProcess _ aProcess.
	interruptedController _ aController.
	contextStackTop _ aContext.
	self newStack: (contextStackTop stackOfSize: 1).
	contextStackIndex _ 1.
	externalInterrupt _ false.
	selectingPC _ true