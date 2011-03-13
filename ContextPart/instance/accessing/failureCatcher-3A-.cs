failureCatcher: exceptMethod
	"Answer a context in the sender chain that is executing BlockContext ifFail:
	 Skip such that are matched by contexts above them executing
	 exceptMethod.  Answer nil if none found.  Called only by Failure propagate."

	| stackFrame failureCatcher count |
	failureCatcher _ BlockContext compiledMethodAt: #ifFail:.
	stackFrame _ sender.
	count _ 1.
	[stackFrame ~~ nil and:
		[stackFrame method == failureCatcher ifTrue: [count _ count - 1].
		 stackFrame method == exceptMethod ifTrue: [count _ count + 1].
		 count > 0]] whileTrue:
			[stackFrame _ stackFrame sender].
	^stackFrame