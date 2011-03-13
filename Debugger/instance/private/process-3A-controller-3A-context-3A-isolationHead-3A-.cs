process: aProcess controller: aController context: aContext isolationHead: projectOrNil 
	super initialize.
	Smalltalk
		at: #MessageTally
		ifPresentAndInMemory: [:c | c new close].
	contents := nil.
	interruptedProcess := aProcess.
	interruptedController := aController.
	contextStackTop := aContext.
	self
		newStack: (contextStackTop stackOfSize: 1).
	contextStackIndex := 1.
	externalInterrupt := false.
	selectingPC := true.
	isolationHead := projectOrNil.
	errorWasInUIProcess := false