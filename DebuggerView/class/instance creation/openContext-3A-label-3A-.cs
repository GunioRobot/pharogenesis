openContext: aContext label: aString 
	"Create and schedule an instance of me on a Debugger for the method 
	context, aContext. The label of the standard system view is aString."

	self openDebugger: (Debugger context: aContext)
		label: aString