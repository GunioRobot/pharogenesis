doesNotUnderstand: aMessage 
	"All external messages (those not caused by the re-send) get trapped here"
	"Present a dubugger before proceeding to re-send the message"

	DebuggerView openContext: thisContext
				label: 'About to perform: ', aMessage selector
				contents: thisContext shortStack.
	^ aMessage sentTo: tracedObject.
