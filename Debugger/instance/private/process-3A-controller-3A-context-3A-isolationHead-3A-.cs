process: aProcess controller: aController context: aContext isolationHead: projectOrNil

	super initialize.
	Smalltalk at: #MessageTally ifPresent: [:c | c new close].
	contents _ nil. 
	interruptedProcess _ aProcess.
	interruptedController _ aController.
	contextStackTop _ aContext.
	self newStack: (contextStackTop stackOfSize: 1).
	contextStackIndex _ 1.
	externalInterrupt _ false.
	selectingPC _ true.
	isolationHead _ projectOrNil