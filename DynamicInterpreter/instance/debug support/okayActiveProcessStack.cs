okayActiveProcessStack

	| ctx stable pseudo |
	ctx _ activeCachedContext.
	stable _ 0.
	[stable == 0] whileTrue: [
		self okayFields: (self cachedMethodAt: ctx).
		self okayFields: (self cachedTranslatedMethodAt: ctx).
		self okayFields: (self cachedReceiverAt: ctx).
		pseudo _ self cachedPseudoContextAt: ctx.
		pseudo == 0 ifFalse: [self okayFields: pseudo].
		ctx == lowestCachedContext ifTrue: [stable _ self cachedSenderAt: ctx].
		ctx _ self cachedContextBefore: ctx.
	].
	[stable == nilObj] whileFalse: [
		self okayFields: stable.
		stable _ self fetchPointer: SenderIndex ofObject: stable.
	].