cannotInterpret: aMessage 
	 "Handle the fact that there was an attempt to send the given message to the receiver but a null methodDictionary was encountered while looking up the message selector.  Hopefully this is the result of encountering a stub for a swapped out class which induces this exception on purpose."

"If this is the result of encountering a swap-out stub, then simulating the lookup in Smalltalk should suffice to install the class properly, and the message may be resent."

	| handler errorString |
	(self class lookupSelector: aMessage selector) == nil ifFalse:
		["Simulated lookup succeeded -- resend the message."
		^ aMessage sentTo: self].

	"Could not recover by simulated lookup -- it's an error"
	errorString _ 'MethodDictionary fault'.
	(handler _ Processor activeProcess errorHandler) notNil
		ifTrue: [handler value: errorString value: self]
		ifFalse: [Debugger openContext: thisContext
					label: errorString
					contents: thisContext shortStack].
	^ aMessage sentTo: self