stackDepth
	| ctx stable depth |
	depth _ 0.
	ctx _ activeCachedContext.
	stable _ 0.
	[stable == 0] whileTrue: [
		depth _ depth + 1.
		ctx == lowestCachedContext ifTrue: [stable _ self cachedSenderAt: ctx].
		ctx _ self cachedContextBefore: ctx.
	].
	[stable == nilObj] whileFalse: [
		depth _ depth + 1.
		stable _ self fetchPointer: SenderIndex ofObject: stable.
	].
	^depth