terminate 
	"Stop the process that the receiver represents forever."

	| context |
	Processor activeProcess == self
		ifTrue: 
			[thisContext sender == nil ifFalse:
				[thisContext sender release].
			thisContext removeSelf suspend]
		ifFalse: 
			[myList == nil
				ifFalse: 
					[myList remove: self ifAbsent: [].
					myList _ nil].
			context _ suspendedContext.
			suspendedContext _ nil.
			(context ~~ nil and: [context sender ~~ nil])
				ifTrue: [context sender release]]