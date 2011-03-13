openContext: haltContext label: aString contents: contentsString
	"Create and schedule a simple view on a Debugger on haltContext.
	The view is labeled with aString and shows a short sender stack."
	ErrorRecursion
		ifTrue: 
			[ErrorRecursion _ false.
			self primitiveError: aString].
	ErrorRecursion _ true.
	self openNotifier: (Debugger context: haltContext)
		contents: contentsString
		label: aString.
	ErrorRecursion _ false.
	Processor activeProcess suspend
