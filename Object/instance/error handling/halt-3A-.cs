halt: aString 
	"This is the typical message to use for inserting breakpoints during 
	debugging. It creates and schedules a Notifier with the argument, 
	aString, as the label."

	DebuggerView
		openContext: thisContext
		label: aString
		contents: thisContext shortStack

	"nil halt: 'Test of halt:.'."