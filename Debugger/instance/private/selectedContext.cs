selectedContext

	contextStackIndex = 0
		ifTrue: [^contextStackTop]
		ifFalse: [^contextStack at: contextStackIndex]