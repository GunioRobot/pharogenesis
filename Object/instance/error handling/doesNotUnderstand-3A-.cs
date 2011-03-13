doesNotUnderstand: aMessage 
	 "Handle the fact that there was an attempt to send the given message to the receiver but the receiver does not understand this message (typically sent from the machine when a message is sent to the receiver and no method is defined for that selector)."
	"Unless the receiver has an error handler defined for the active process, report to the user that the receiver does not understand the argument, aMessage, as a message."
	"Testing: (3 activeProcess)"

	| handler errorString |
	(Preferences autoAccessors and: [self tryToDefineVariableAccess: aMessage])
		ifTrue: [^ aMessage sentTo: self].
	errorString _ 'Message not understood: ', aMessage selector.
	(handler _ Processor activeProcess errorHandler) notNil
		ifTrue: [handler value: errorString value: self]
		ifFalse: [Debugger openContext: thisContext
					label: errorString
					contents: thisContext shortStack].
	^ aMessage sentTo: self