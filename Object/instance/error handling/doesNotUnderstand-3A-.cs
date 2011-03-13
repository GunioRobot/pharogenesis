doesNotUnderstand: aMessage 
	"Report to the user that the receiver does not understand the argument, aMessage, as a message."
	| currentProcesss currentProcess aString |
	(self tryToDefineVariableAccess: aMessage)
		ifFalse: 
			[aString _ 'Message not understood:', aMessage selector.
		(currentProcess _ ScheduledControllers activeControllerProcess) isErrorHandled
		        ifTrue:
		            [currentProcess errorHandler value: aString value: self]
		        ifFalse:
		            [DebuggerView
					openContext: thisContext
					label: aString
					contents: thisContext shortStack]].
	^ aMessage sentTo: self