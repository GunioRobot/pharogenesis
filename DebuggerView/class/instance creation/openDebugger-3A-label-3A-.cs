openDebugger: aDebugger label: aString 
	"Create and schedule an instance of me on the model, aDebugger. The 
	label is aString."

	self openNoSuspendDebugger: aDebugger label: aString.
	Processor activeProcess suspend