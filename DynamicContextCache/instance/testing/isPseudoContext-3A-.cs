isPseudoContext: aContext
	self inline: true.
	self assertIsContext: aContext.

	^(self isIntegerObject: (self fetchPointer: SenderIndex ofObject: aContext))