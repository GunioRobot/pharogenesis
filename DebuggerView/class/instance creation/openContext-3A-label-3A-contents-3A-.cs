openContext: haltContext label: aString contents: contentsString
	"Create and schedule a simple view on a Debugger on haltContext.
	The view is labeled with aString and shows a short sender stack."
	ErrorRecursion
		ifTrue: 
			[ErrorRecursion _ false.
			self primitiveError: aString].
	ErrorRecursion _ true.
	World ifNotNil:
			["Put up a Morphic debugger in Morphic worlds"
			"Written so that Morphic can still be removed."
			(Smalltalk at: #DebuggerStub) openContext: haltContext
				label: aString
				contents: contentsString.
			ErrorRecursion _ false.
			Project current spawnNewProcess.
			^ Processor activeProcess suspend].
	self openNotifier: (Debugger context: haltContext)
		contents: contentsString
		label: aString.
	ErrorRecursion _ false.
	Processor activeProcess suspend
