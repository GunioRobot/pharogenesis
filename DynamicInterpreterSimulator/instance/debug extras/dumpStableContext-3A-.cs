dumpStableContext: aContext
	(self isMethodContext: aContext)
		ifTrue: [^self dumpStableMethodContext: aContext]
		ifFalse: [^self dumpStableBlockContext: aContext]