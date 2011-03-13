openInterrupt: aString onProcess: interruptedProcess 
	"Create and schedule a simple view with a debugger which can be opened later."

	| aDebugger |
	aDebugger _ Debugger interruptProcess: interruptedProcess.
	^ self openNotifier: aDebugger
		contents: aDebugger interruptedContext shortStack
		label: aString