dumpStack
	| ctx stable |
	^String streamContents: [:strm |
		ctx _ activeCachedContext.
		stable _ 0.
		[stable == 0] whileTrue: [
			strm nextPutAll: '* ' , (self dumpCachedContext: ctx); cr.
			ctx == lowestCachedContext ifTrue: [stable _ self cachedSenderAt: ctx].
			ctx _ self cachedContextBefore: ctx.
		].
		[stable == nilObj] whileFalse: [
			strm nextPutAll: '+ ', (self dumpStableContext: stable); cr.
			stable _ self fetchPointer: SenderIndex ofObject: stable.
		].
	].