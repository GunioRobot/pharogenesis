primitiveFailAfterCleanup: outPointerArray
	"If the storeSegment primitive fails, it must clean up first."

	| i lastAddr |   "Store nils throughout the outPointer array."
	lastAddr _ outPointerArray + (self lastPointerOf: outPointerArray).
	i _ outPointerArray + BaseHeaderSize.
	[i <= lastAddr] whileTrue:
		[self longAt: i put: nilObj.
		i _ i + 4].

	DoAssertionChecks ifTrue: [self verifyCleanHeaders].
	self primitiveFail