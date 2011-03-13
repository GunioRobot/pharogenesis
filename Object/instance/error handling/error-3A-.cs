error: aString 
	"The default behavior for error: is the same as halt:. The code is 
	replicated in order to avoid showing an extra level of message sending 
	in the Debugger. This additional message is the one a subclass should 
	override in order to change the error handling behavior."
	| currentProcesss currentProcess |
	(currentProcess _ ScheduledControllers activeControllerProcess) isErrorHandled
        ifTrue:
            [currentProcess errorHandler value: aString value: self]
        ifFalse:
            [DebuggerView
			openContext: thisContext
			label: aString
			contents: thisContext shortStack]

	"nil error: 'error message'."