windowIsClosing
	"My window is being closed; clean up. Restart the low space watcher."

	interruptedProcess == nil ifTrue: [^ self].
	interruptedProcess terminate.
	interruptedProcess _ nil.
	interruptedController _ nil.
	contextStack _ nil.
	contextStackTop _ nil.
	receiverInspector _ nil.
	contextVariablesInspector _ nil.
	Smalltalk installLowSpaceWatcher.  "restart low space handler"
