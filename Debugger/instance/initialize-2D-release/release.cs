release

	interruptedProcess ~~ nil ifTrue: [interruptedProcess terminate].
	interruptedProcess _ nil.
	interruptedController _ nil.
	contextStack _ nil.
	contextStackTop _ nil.
	receiverInspector _ nil.
	contextVariablesInspector _ nil.
	Smalltalk installLowSpaceWatcher.  "restart low space handler"
	super release.