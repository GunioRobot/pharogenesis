unwindTo: aContext

	| ctx returnValue aContextSender unwindBlock |
	ctx := self.
	returnValue := nil.
	aContext == nil
		ifTrue: [aContextSender := nil]
		ifFalse: [aContextSender := aContext sender]. "if aContext itself is marked for unwind, then need to use sender for whileFalse: loop check"
	[ctx == aContextSender or: [ctx == nil]]
		whileFalse:
			[ctx isUnwindContext
				ifTrue:
					[unwindBlock := ctx tempAt: 1.
					ctx tempAt: 1 put: nil.	"see comment in #ensure:"
					unwindBlock == nil
						ifFalse: [returnValue := unwindBlock value]].
			ctx := ctx sender].
	^returnValue